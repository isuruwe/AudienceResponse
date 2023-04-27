using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudienceResponse.CMN;
using System.Drawing.Drawing2D;
using AudienceResponse.BAL;

namespace AudienceResponse
{
    public partial class frmParticipantManagement : Form
    {
        BALParticipants oBALParticipants = new BALParticipants();
        private OpenFileDialog Myfile = new OpenFileDialog();
        public frmParticipantManagement()
        {
            InitializeComponent();
        }
        private void btnParticipantImage_Click(object sender, EventArgs e)
        {
            try
            {
                Myfile.Filter = "JPEG File(*.jpeg)|*.jpg|JPG File(*.jpg)|*.jpg|Bitmap(*.BMP)|*.bmp";
                Myfile.ShowDialog();
                System.IO.Stream _BitData = Myfile.OpenFile();
                Image image = Image.FromStream(_BitData);
                pbParticipantImage.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnIDCardImage_Click(object sender, EventArgs e)
        {
            try
            {
                Myfile.Filter = "JPEG File(*.jpeg)|*.jpg|JPG File(*.jpg)|*.jpg|Bitmap(*.BMP)|*.bmp|Png Image(*.PNG)|*.png";
                Myfile.ShowDialog();
                System.IO.Stream _BitData = Myfile.OpenFile();
                Image image = Image.FromStream(_BitData);
                pbIDCardImage.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CMNParticipants oCMNParticipants = new CMNParticipants();
            oCMNParticipants = setSaveData();
            oCMNParticipants.SysID = getNewParticipantID();

            oBALParticipants.insertParticipantData(oCMNParticipants, null);
            loadAllParticipants();
            clearAll();
        }
        public byte[] imageToByteArray(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Image ResizeImageFixedWidth(Image imgToResize, int width)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = ((float)width / (float)sourceWidth);

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.High;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
        private CMNParticipants setSaveData()
        {
            CMNParticipants oCMNParticipants = new CMNParticipants();

            oCMNParticipants.SeatRowNo = txtSeatRowNo.Text.Trim();
            oCMNParticipants.RankID = (int)cmbRank.SelectedValue;
            oCMNParticipants.Initials = txtInitials.Text.Trim();
            oCMNParticipants.Name = txtName.Text.Trim();
            oCMNParticipants.Titles = txtTitles.Text.Trim();
            oCMNParticipants.CountryID = cmbCountry.SelectedValue.ToString();

            if (rbActive.Checked==true)
            {
                oCMNParticipants.Status = 1;
            }
            else
            {
                oCMNParticipants.Status = 2;
            }

            oCMNParticipants.UserID = txtUserID.Text.Trim();
            oCMNParticipants.ParticipantImage = imageToByteArray(pbParticipantImage.Image); 
            oCMNParticipants.IDImage = imageToByteArray(pbIDCardImage.Image);        

            return oCMNParticipants;
        }
        private void loadComboBox()
        {
            DataTable dtRanks = new DataTable();
            dtRanks=oBALParticipants.selectRanks(null);

            if (dtRanks.Rows.Count>0)
            {
                cmbRank.DataSource = dtRanks;
                cmbRank.DisplayMember = "LongName";
                cmbRank.ValueMember = "RankID";
            }

            DataTable dtCountries = new DataTable();
            dtCountries = oBALParticipants.selectCountries(null);

            if (dtCountries.Rows.Count>0)
            {
                cmbCountry.DataSource = dtCountries;
                cmbCountry.DisplayMember = "CountryName";
                cmbCountry.ValueMember = "CountryID";
            }
        }
        private void frmParticipantManagement_Load(object sender, EventArgs e)
        {
            loadComboBox();
            loadAllParticipants();
            lblSysID.Text = "";
            clearAll();
        }
        private int getNewParticipantID()
        {
            return oBALParticipants.getNewParticipantID(null);
        }
        private void loadAllParticipants()
        {
            dgvParticipant.DataSource=oBALParticipants.selectAllParticipantData(null);
        }
        private void dgvParticipant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setGridDataToForm();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true);//Exception occurs here
            }
            catch { }
            return returnImage;
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
           // clearAll();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void clearAll()
        {
            lblSysID.Text = "";
            txtUserID.Text = "";
            txtInitials.Text = "";
            txtName.Text = "";
            txtSeatRowNo.Text = "";
            txtTitles.Text = "";

            rbActive.Checked = true;
            pbIDCardImage.Image =null;
            pbParticipantImage.Image = null;

            cmbCountry.SelectedValue = "SLK";
            cmbRank.SelectedValue = 1;
            txtSeatRowNo.Focus();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CMNParticipants oCMNParticipants = new CMNParticipants();
            oCMNParticipants = setSaveData();
            oCMNParticipants.SysID = Convert.ToInt32(lblSysID.Text);

            int rowID= dgvParticipant.CurrentCell.RowIndex;

            oBALParticipants.updateParticipantData(oCMNParticipants, null);
            loadAllParticipants();
            dgvParticipant.Rows[0].Selected = false;
            dgvParticipant.Rows[rowID].Selected = true;
            dgvParticipant.FirstDisplayedScrollingRowIndex = rowID;
            dgvParticipant.Focus();
            clearAll();
        }
        private void dgvParticipant_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setGridDataToForm();
        }
        private void setGridDataToForm()
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            CMNParticipants oCMNParticipants = new CMNParticipants();
            DataTable dtParticipantData = new DataTable();
            
            oCMNParticipants.SysID = Convert.ToInt32(dgvParticipant.Rows[dgvParticipant.CurrentCell.RowIndex].Cells[0].Value.ToString());
            dtParticipantData = oBALParticipants.selectAllBySysID(oCMNParticipants, null);

            if (dtParticipantData.Rows.Count > 0)
            {
                lblSysID.Text = oCMNParticipants.SysID.ToString();
                txtSeatRowNo.Text = dtParticipantData.Rows[0]["SeatRowNo"].ToString();
                cmbRank.SelectedValue = dtParticipantData.Rows[0]["RankID"];
                txtInitials.Text = dtParticipantData.Rows[0]["Initials"].ToString();
                txtName.Text = dtParticipantData.Rows[0]["Name"].ToString();
                txtTitles.Text = dtParticipantData.Rows[0]["Titles"].ToString();
                cmbCountry.SelectedValue = dtParticipantData.Rows[0]["CountryID"];

                string xx = dtParticipantData.Rows[0]["Status"].ToString();

                if (dtParticipantData.Rows[0]["Status"].ToString() == "1")
                {
                    rbActive.Checked = true;
                }
                else
                {
                    rbInactive.Checked = true;
                }

                txtUserID.Text = dtParticipantData.Rows[0]["userid"].ToString();
                pbParticipantImage.Image = byteArrayToImage((byte[])dtParticipantData.Rows[0]["ParticipantImage"]);
                pbIDCardImage.Image = byteArrayToImage((byte[])dtParticipantData.Rows[0]["IDImage"]);
            }
        }
        private void dgvParticipant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setGridDataToForm();
        }

        private void cbSkipParticipantImage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSkipParticipantImage.Checked)
            {
                pbParticipantImage.Image = null;
                btnParticipantImage.Enabled = false;
            }
            else
            {
                btnParticipantImage.Enabled = true;
                clearAll();
            }
        }

        private void cbSkipIDImage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSkipIDImage.Checked)
            {
                pbIDCardImage.Image = null;
                btnIDCardImage.Enabled = false;
            }
            else
            {
                btnIDCardImage.Enabled = true;
                clearAll();
            }
        }
    }
}
