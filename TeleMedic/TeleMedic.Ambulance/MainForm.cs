using AVSPEED;
using iConfRTCWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeleMedic.Ambulance
{
    public partial class MainForm : Form
    {
        protected RTCControl mainRtc;
        protected RTCControl cam1Rtc;
        protected RTCControl cam2Rtc;
        DashboardUC dbUC;
        LobbyUC lobbyUC;
        public MainForm()
        {
            RTC.Init();
            InitializeComponent();

            mainRtc = new RTCControl();
            cam1Rtc = new RTCControl();
            cam2Rtc = new RTCControl();

            loginUC1.OnStart += LoginUC1_OnStart;
            loginUC1.AddRtc(mainRtc, cam1Rtc, cam2Rtc);

            tabControl1.Show();
            loginUC1.Dock = DockStyle.Fill;
            loginUC1.Show();

            mainRtc.NewDevices += MainRtc_NewDevices;
            cam1Rtc.NewDevices += Cam1Rtc_NewDevices;
            cam2Rtc.NewDevices += Cam2Rtc_NewDevices;
            lobbyUC = new LobbyUC();
            lobbyUC.Dock = DockStyle.Fill;
            pnlViewer.Controls.Add(lobbyUC);

            dbUC = new DashboardUC(mainRtc, cam1Rtc, cam2Rtc);
            dbUC.OnLeaveMeeting += DbUC_OnLeaveMeeting;

            dbUC.Dock = DockStyle.Fill;
            panel2.Controls.Add(dbUC);

        }

        private void DbUC_OnLeaveMeeting(object sender, EventArgs e)
        {
            loginUC1.Show();
        }

        private void Cam2Rtc_NewDevices(object sender, iConfRTCModel.DeviceEventArgs e)
        {
            loginUC1.UpdateCam2Device(e);
        }

        private void LoginUC1_OnStart(object sender, EventArgs e)
        {
            dbUC.StartMeeting();

            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Show();
            loginUC1.Hide();

        }

        private void Cam1Rtc_NewDevices(object sender, iConfRTCModel.DeviceEventArgs e)
        {
            loginUC1.UpdateCam1Device(e);
        }

        private void MainRtc_NewDevices(object sender, iConfRTCModel.DeviceEventArgs e)
        {
            loginUC1.UpdateMainDevice(e);
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
