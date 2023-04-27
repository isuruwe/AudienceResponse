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
using System.IO.Ports;
using AudienceResponse.CMN;
using AudienceResponse.BAL;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Quartz.Impl;
using Quartz;
using System.Collections.Specialized;

namespace AudienceResponse
{
    public partial class frmMain : Form,IJob
    {
        BALParticipants oBALParticipants = new BALParticipants();
        CMNParticipants oCMNParticipants = new CMNParticipants();
        public string indata;
        public string message;
        string userid = "";
        delegate void SetTextCallback(string text);
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        Thread thread;
       
        public frmMain()
        {
            InitializeComponent();
        }
        private void loadAllParticipants()
        {
            DataTable dtAllParticipants = new DataTable();
            dtAllParticipants = oBALParticipants.selectAllParticipantData(null);
            dgvparticipants.DataSource = dtAllParticipants;

        }
        private void loadSeniorParticipants()
        {
            DataTable dtSeniorParticipants = new DataTable();
            dtSeniorParticipants = oBALParticipants.selectSeniorParticipantData(null);
            dgvparticipants.DataSource = dtSeniorParticipants;

        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            //readSerialPort();
            keepCenter();
            //loadAllParticipants();

            dgvparticipants.Columns["SysID"].Visible = false;
            dgvparticipants.Columns["Flag"].Visible = false;

            //thread = new Thread(StartListening);
            //thread.Start();
            NameValueCollection props = new NameValueCollection
    {
        { "quartz.serializer.type", "binary" }
    };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);

            // get a scheduler
            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<frmMain>()
                .WithIdentity("myJob", "group1")
                                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
            .Build();

            await sched.ScheduleJob(job, trigger);



        }
        private void dgvparticipants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvparticipants.Columns["Select"].Index)
            {
                int row = e.RowIndex;
                oCMNParticipants.SeatRowNo = dgvparticipants.Rows[row].Cells["SeatRowNo"].Value.ToString();
                oCMNParticipants.UserID = dgvparticipants.Rows[row].Cells["userid"].Value.ToString();
                oCMNParticipants.SysID = Convert.ToInt32(dgvparticipants.Rows[row].Cells["SysID"].Value.ToString());

                frmInfoViewer ofrmInfoViewer = new frmInfoViewer(oCMNParticipants);
                ofrmInfoViewer.ShowDialog();

                dgvparticipants.Rows[row].DefaultCellStyle.BackColor = Color.LawnGreen;
                // dgvparticipants.Rows[row].Cells["Flag"].Value = 1;
            }
            if (e.ColumnIndex == dgvparticipants.Columns["qst1"].Index)
            {
                int row = e.RowIndex;
                string qstes = dgvparticipants.Rows[row].Cells["qst"].Value.ToString();
                oCMNParticipants.SeatRowNo = dgvparticipants.Rows[row].Cells["SeatRowNo"].Value.ToString();
                oCMNParticipants.UserID = dgvparticipants.Rows[row].Cells["userid"].Value.ToString();
                oCMNParticipants.SysID = Convert.ToInt32(dgvparticipants.Rows[row].Cells["SysID"].Value.ToString());

                frmQst ofrmInfoViewer = new frmQst(oCMNParticipants, qstes);
                ofrmInfoViewer.ShowDialog();

                dgvparticipants.Rows[row].DefaultCellStyle.BackColor = Color.LawnGreen;
                dgvparticipants.Rows[row].Cells["Flag"].Value = 1;
            }

        }
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();
            string a = indata.Trim();

            SetText(a);
        }
        private void SetText(string text)
        {
            if (this.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                DataTable dtParticipants = new DataTable();
                DataTable dtExisting = new DataTable();
                userid = text;
                oCMNParticipants.UserID = userid;

                dtParticipants = oBALParticipants.selectParticipantDataByCardID(oCMNParticipants, null);
                dgvparticipants.DataSource = dtParticipants;

            }
        }
        private void readSerialPort()
        {
            SerialPort mySerialPort = new SerialPort("COM4");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            mySerialPort.Open();
        }
        private void keepCenter()
        {
            //pnlOuter.Width = Convert.ToInt16(this.Width * 0.85);
            //pnlOuter.Height = Convert.ToInt16(this.Height * 0.80);

            //pnlOuter.Location = new Point(
            //this.ClientSize.Width / 2 - pnlOuter.Size.Width / 2,
            //this.ClientSize.Height / 2 - pnlOuter.Size.Height / 2);
            //pnlOuter.Anchor = AnchorStyles.None;


            dgvparticipants.Columns[0].Width = Convert.ToInt16(dgvparticipants.Width * 0.125);
            //dgvparticipants.Columns[1].Width = Convert.ToInt16(dgvparticipants.Width * 0.125);
            dgvparticipants.Columns[2].Width = Convert.ToInt16(dgvparticipants.Width * 0.1);
            dgvparticipants.Columns[3].Width = Convert.ToInt16(dgvparticipants.Width * 0.1);
            dgvparticipants.Columns[4].Width = Convert.ToInt16(dgvparticipants.Width * 0.25);
            dgvparticipants.Columns[5].Width = Convert.ToInt16(dgvparticipants.Width * 0.175);
            dgvparticipants.Columns[6].Width = Convert.ToInt16(dgvparticipants.Width * 0.175);
            dgvparticipants.Columns[7].Width = Convert.ToInt16(dgvparticipants.Width * 0.073);
        }
        private void pbLogOut_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pbLogOut, "Exit");
            pbLogOut.Image = AudienceResponse.Properties.Resources.logOut_2;
        }
        private void pbLogOut_MouseLeave(object sender, EventArgs e)
        {
            pbLogOut.Image = AudienceResponse.Properties.Resources.logOut;
        }
        private void pbLogOut_Click(object sender, EventArgs e)
        {
            // thread.Abort();
            Application.Exit();
        }
        public void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[2048];

            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(200);

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    //   Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.ToString());
            }

            //  Console.WriteLine("\nPress ENTER to continue...");
            //  Console.Read();

        }
        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }
        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {

                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                if (content.Length < 15)
                {
                    // All the data has been read from the   
                    // client. Display it on the console. 

                    var sb = new StringBuilder(content.Length);

                    foreach (char i in content)
                        if (i != '\n' && i != '\r' && i != '\t')
                            sb.Append(i);

                    content = sb.ToString();

                    if (lblUserID.InvokeRequired)
                    {
                        if (!String.IsNullOrEmpty(content)) {
                            try
                            {
                                lblUserID.Invoke(new MethodInvoker(delegate { lblUserID.Text = content; }));
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }

                    // Echo the data back to the client.  
                    //Send(handler, content);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }
        private void lblCardID_TextChanged(object sender, EventArgs e)
        {
            if (lblUserID.Text != "")
            {


                DataTable dtParticipant = new DataTable();
                DataTable dtParticipantsDGV = new DataTable();
                oCMNParticipants.UserID = lblUserID.Text;

                dtParticipant = oBALParticipants.selectParticipantDataByCardID(oCMNParticipants, null);
                dtParticipant.PrimaryKey = new DataColumn[] { dtParticipant.Columns["SysID"] };

                dtParticipantsDGV = (DataTable)dgvparticipants.DataSource;

                if (dtParticipant.Rows.Count > 0)
                {
                    if (dgvparticipants.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtParticipant.Rows)
                        {
                            if (!dtParticipantsDGV.Rows.Contains(r["SysID"]))
                            {
                                dtParticipantsDGV.ImportRow(r);
                                dgvparticipants.DataSource = dtParticipantsDGV;
                                dgvparticipants.Refresh();
                            }
                            else
                            {
                                foreach (DataGridViewRow dgvRow in dgvparticipants.Rows)
                                {
                                    //if (dgvRow.Cells["SysID"].Value.ToString() == r["SysID"].ToString() && dgvRow.Cells["Flag"].Value.ToString() == "1")
                                    //{
                                    //    dgvparticipants.Rows[dgvRow.Index].DefaultCellStyle.BackColor = Color.Plum;
                                    //    break;
                                    //}
                                    if (dgvRow.Cells["SysID"].Value.ToString() == r["SysID"].ToString())
                                    {
                                        dgvparticipants.Rows.RemoveAt(dgvRow.Index);
                                        dtParticipantsDGV.ImportRow(r);
                                        dgvparticipants.DataSource = dtParticipantsDGV;
                                        dgvparticipants.Refresh();
                                    }
                                }

                                //r.Delete();
                                //dtParticipantsDGV.AcceptChanges();
                                //dtParticipantsDGV.ImportRow(r);
                                //dgvparticipants.DataSource = dtParticipantsDGV;
                                //dgvparticipants.Refresh();

                            }
                        }
                    }
                    else
                    {
                        dgvparticipants.DataSource = dtParticipant;
                        dgvparticipants.Refresh();
                    }
                }
                else
                {

                }

                lblUserID.Text = "";
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pbClear_Click(object sender, EventArgs e)
        {
            int length = dgvparticipants.Rows.Count;

            for (int i = 0; i < length; i++)
            {
                dgvparticipants.Rows.RemoveAt(0);
            }

            oBALParticipants.updateqst("", null);
            lblQuestion.Text = "";

        }

        private void pbClear_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pbClear, "Clear List");

            pbClear.Image = AudienceResponse.Properties.Resources.Clear_2;
        }

        private void pbClear_MouseLeave(object sender, EventArgs e)
        {
            pbClear.Image = AudienceResponse.Properties.Resources.Clear;
        }

        private void pbAddNew_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pbAddNew, "Add New Participant");

            pbAddNew.Image = AudienceResponse.Properties.Resources.AddNew_2;
        }

        private void pbAddNew_MouseLeave(object sender, EventArgs e)
        {
            pbAddNew.Image = AudienceResponse.Properties.Resources.AddNew;
        }

        private void pbAddNew_Click(object sender, EventArgs e)
        {
            frmParticipantManagement ofrmParticipantManagement = new frmParticipantManagement();
            ofrmParticipantManagement.ShowDialog();
        }

        private void pbRefreshList_Click(object sender, EventArgs e)
        {
            loadAllParticipants();
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            loadAllParticipants();
        }

        private void btnLoadSenior_Click(object sender, EventArgs e)
        {
            loadSeniorParticipants();
        }

        private void dgvparticipants_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvparticipants.Columns["Select"].Index)
            {
                int row = e.RowIndex;


                //label1.Text = dgvparticipants.Rows[row].Cells["qst"].Value.ToString();
            }



        }

        private void dgvparticipants_MouseHover(object sender, EventArgs e)
        {

        }

        private void dgvparticipants_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvparticipants_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row > -1)
            {
                lblQuestion.MaximumSize = new Size(1300, 0);
                lblQuestion.AutoSize = true;

                lblQuestion.Text = dgvparticipants.Rows[row].Cells["qst"].Value.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public async Task Execute(IJobExecutionContext context)
        {
            DataTable dtParticipant = new DataTable();
            DataTable dtParticipantsDGV = new DataTable();
            oCMNParticipants.UserID = lblUserID.Text;

            dtParticipant = oBALParticipants.selectParticipantDataByCardID(oCMNParticipants, null);
            dtParticipant.PrimaryKey = new DataColumn[] { dtParticipant.Columns["SysID"] };
            dgvparticipants.Invoke(new MethodInvoker(delegate { dgvparticipants.DataSource = dtParticipant; }));
            dgvparticipants.Invoke(new MethodInvoker(delegate { dgvparticipants.Refresh(); }));
            await Console.Out.WriteLineAsync("Greetings from HelloJob!");
        }


    }

    
}
