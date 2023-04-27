using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudienceResponse.CMN;
using AudienceResponse.BAL;
using System.IO;

namespace AudienceResponse
{
    public partial class frmInfoViewer : Form
    {
        CMNParticipants oCMNParticipants = new CMNParticipants();
        BALParticipants oBALParticipants = new BALParticipants();
        public frmInfoViewer(CMNParticipants _oCMNParticipants)
        {
            InitializeComponent();
            oCMNParticipants = _oCMNParticipants;
        }

        private void frmInfoViewer_Load(object sender, EventArgs e)
        {
            LoadBataBySysID();
            //keepCenter();
        }

        private void LoadBataBySysID()
        {
            DataTable dtParticipentData = new DataTable();
            dtParticipentData=oBALParticipants.selectParticipantDataBySysID(oCMNParticipants, null);


            if (dtParticipentData.Rows[0]["Name"].ToString().Length>21)
            {
                lblName.Font = new Font("Century Gothic", 20);
            }
            else
            {
                lblName.Font = new Font("Century Gothic", 24);
            }

            //lblSeatRowNo.Text = dtParticipentData.Rows[0]["SeatRowNo"].ToString();
            lblRank.Text = dtParticipentData.Rows[0]["LongName"].ToString();
            lblName.Text = dtParticipentData.Rows[0]["Name"].ToString();
            lblName.MaximumSize = new Size(397, 0);
            lblName.AutoSize = true;

            lblDecorations.Text = dtParticipentData.Rows[0]["Titles"].ToString();//Environment.NewLine
            lblDecorations.MaximumSize = new Size(410, 0);
            lblDecorations.AutoSize = true;

            picBoxUser.Image = byteArrayToImage((byte[])dtParticipentData.Rows[0]["ParticipantImage"]);

        }

        private void pbLogOut_MouseHover(object sender, EventArgs e)
        {
            pbLogOut.Image = AudienceResponse.Properties.Resources.logOut_2;
        }

        private void pbLogOut_MouseLeave(object sender, EventArgs e)
        {
            pbLogOut.Image = AudienceResponse.Properties.Resources.logOut;
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void keepCenter()
        {
            //pnlOuter.Width = Convert.ToInt16(this.Width * 0.85);
            //pnlOuter.Height = Convert.ToInt16(this.Height * 1);

            //pnlOuter.Location = new Point(
            //this.ClientSize.Width / 2 - pnlOuter.Size.Width / 2,
            //this.ClientSize.Height / 2 - pnlOuter.Size.Height / 2);
            //pnlOuter.Anchor = AnchorStyles.None;
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
    }
}
