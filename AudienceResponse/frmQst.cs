using AudienceResponse.BAL;
using AudienceResponse.CMN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AudienceResponse
{
    public partial class frmQst : Form
    {
        string qst = "";
        CMNParticipants oCMNParticipants = new CMNParticipants();
        BALParticipants oBALParticipants = new BAL.BALParticipants();
        public frmQst(CMNParticipants _oCMNParticipants, string sdf)
        {
            InitializeComponent();
            qst = sdf;
            oCMNParticipants = _oCMNParticipants;
            lblQuestion.Font = new Font("Century Gothic", 20);
           
            lblQuestion.MaximumSize = new Size(1200, 0);
            lblQuestion.AutoSize = true;
            lblQuestion.Text = qst;
        }

        private void pbLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQst_Load(object sender, EventArgs e)
        {
            LoadBataBySysID();
        }
        private void LoadBataBySysID()
        {
            DataTable dtParticipentData = new DataTable();
            dtParticipentData = oBALParticipants.selectParticipantDataBySysID(oCMNParticipants, null);


            if (dtParticipentData.Rows[0]["Name"].ToString().Length > 21)
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

