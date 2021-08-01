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

namespace TeleMedic
{
    public partial class PrivateForm : Form
    {
        protected RTCControl rtc;
        
        PrivateUC _uc;
        LoginUC loginUC1;

        private string meetingId;

        public PrivateForm()
            :this("")
        {

        }

        public PrivateForm(string meetingId)
        {
            RTC.Init();
            InitializeComponent();
            rtc = new RTCControl();
            rtc.NewDevices += Rtc_NewDevices;

            loginUC1 = new LoginUC();
            loginUC1.AddRtc(rtc);
            loginUC1.OnStart += LoginUC1_OnStart;
            loginUC1.Show();
            loginUC1.Dock = DockStyle.Fill;
            panel1.Controls.Add(loginUC1);

            this.meetingId = meetingId;

            _uc = new PrivateUC(rtc, this.meetingId);
            _uc.OnLeaveMeeting += _uc_OnLeaveMeeting;

            _uc.Dock = DockStyle.Fill;
            _uc.Show();
            panel1.Controls.Add(_uc);

            //_uc = new PrivateUC(rtc, this.meetingId);
            //_uc.Dock = DockStyle.Fill;
            //Controls.Add(_uc);

        }

        private void _uc_OnLeaveMeeting(object sender, EventArgs e)
        {
            loginUC1.Show();
        }

        private void Rtc_NewDevices(object sender, iConfRTCModel.DeviceEventArgs e)
        {
            loginUC1.UpdateMainDevice(e);
        }

        private void LoginUC1_OnStart(object sender, EventArgs e)
        {
            _uc.StartMeeting();

            _uc.Dock = DockStyle.Fill;
            _uc.Show();
            loginUC1.Hide();
        }

        private void PrivateForm_Load(object sender, EventArgs e)
        {
        }
    }
}
