using AVSPEED;
using System;
using System.Windows.Forms;

namespace TeleMedic
{
    public partial class MainForm : Form
    {
        PublicUC publicUC;// = new PublicUC();
        public MainForm()
        {
            RTC.Init();
            InitializeComponent();

            publicUC = new PublicUC();
            publicUC.Dock = DockStyle.Fill;
            publicUC.JoinRequest += PublicUC_JoinRequest;
            panel1.Controls.Add(publicUC);
            //pnlPatient.Controls.Add(privateUC);
        }

        private void PublicUC_JoinRequest(object sender, Library.JoinRequestEventArgs e)
        {
            try
            {
                PrivateForm form = new PrivateForm(e.MeetingId);
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            catch (Exception ex)
            {
            }
            //PrivateUC privateUC = new PrivateUC();
            //privateUC.RequestToJoin(e.MeetingId);

            //tabControl1.TabPages.Add("dasdas");
            //tabControl1.TabPages[1].Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
