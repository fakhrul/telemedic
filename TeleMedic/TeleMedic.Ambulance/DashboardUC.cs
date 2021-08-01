using AVSPEED;
using iConfRTCModel;
using iConfRTCWinForm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleMedic.Library;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace TeleMedic.Ambulance
{
    public partial class DashboardUC : UserControl
    {
        protected List<CurrentParticipant> _publicParticipants = new List<CurrentParticipant>();

       // protected SettingForm settings;
        private RTCControl mainRtc;
        private RTCControl cam1Rtc;
        private RTCControl cam2Rtc;

        public event EventHandler<EventArgs> OnLeaveMeeting;

        HL7Listener _hl7;

        public DashboardUC()
            :this(new RTCControl(), new RTCControl(), new RTCControl())
        {


        }

        public DashboardUC(RTCControl mainRtc, RTCControl cam1Rtc, RTCControl cam2Rtc)
        {
            //RTC.Init();
            InitializeComponent();

            chatUC1.OnMessageSend += ChatUC1_OnMessageSend;
            this.mainRtc = mainRtc;
            this.cam1Rtc = cam1Rtc;
            this.cam2Rtc = cam2Rtc;

           // settings = new SettingForm();
            //settings.SetRtc(mainRtc, cam1Rtc, cam2Rtc);

            InitializeMainRtc();
            InitializeCam1Rtc();
            InitializeCam2Rtc();

            _hl7 = new HL7Listener();
            _hl7.OnMessageReceived += _hl7_OnMessageReceived;
            _hl7.Start();
        }

        private void _hl7_OnMessageReceived(object sender, HL7MessageEventArgs e)
        {
            //e.Message.
        }

        private void ChatUC1_OnMessageSend(object sender, ChatMessageEventArgs e)
        {
            mainRtc.SendMessageToMeeting(e.Message);
        }

        private void InitializeCam1Rtc()
        {
            cam1Rtc.Dock = DockStyle.Fill;

            cam1Rtc.SignalingUrl = IniFile.IniReadValue("device.ini", "Setting", "SignalingUrl", "https://rtc-signaling-service.herokuapp.com:443/");
            
            //cam1Rtc.SignalingUrl = ConfigurationManager.AppSettings["SignalingUrl"];
            cam1Rtc.SignalingType = SignalingTypes.Socketio;

            cam1Rtc.RTCInitialized += Cam1Rtc_RTCInitialized;
            cam1Rtc.IJoinedMeeting += Cam1Rtc_IJoinedMeeting;
            //cam1Rtc.UserJoinedMeeting += mainRtc_UserJoinedMeeting;
            //cam1Rtc.UserLeftMeeting += mainRtc_UserLeftMeeting;
            //cam1Rtc.ILeftMeeting += mainRtc_ILeftMeeting;
            //cam1Rtc.NewDevices += mainRtc_NewDevices;
            //cam1Rtc.MeetingMessageReceived += mainRtc_MeetingMessageReceived;

            DisplayRtcVideo(cam1Rtc, "Cam 1");

        }

        internal void StartMeeting()
        {
            UserExtra user = new UserExtra
            {
                UserName = IniFile.IniReadValue("device.ini", "Setting", "DeviceName", "AMB-VDK1811"),
                DeviceId = Helper.GetDeviceId(),
                DeviceType = Library.DeviceType.Ambulance
            };
            string userJson = JsonConvert.SerializeObject(user);
            string meetingId = user.DeviceId;
            mainRtc.JoinMeeting(userJson, meetingId);

            UserExtra userCam1 = new UserExtra
            {
                UserName = IniFile.IniReadValue("device.ini", "Setting", "DeviceName", "AMB-VDK1811"),
                DeviceId = Helper.GetDeviceId(),
                DeviceType = Library.DeviceType.AmbulanceCamera1
            };
            string userCam1Json = JsonConvert.SerializeObject(userCam1);
            cam1Rtc.JoinMeeting(userCam1Json, meetingId);

            UserExtra userCam2 = new UserExtra
            {
                UserName = IniFile.IniReadValue("device.ini", "Setting", "DeviceName", "AMB-VDK1811"),
                DeviceId = Helper.GetDeviceId(),
                DeviceType = Library.DeviceType.AmbulanceCamera2
            };
            string userCam2Json = JsonConvert.SerializeObject(userCam2);
            
            cam2Rtc.JoinMeeting(userCam2Json, meetingId);

        }

        private void Cam1Rtc_IJoinedMeeting(object sender, UserArgs e)
        {
            //cam1Rtc.StartVideo();
            //ProcessParticipants(e.Participants, e.Session, e.Sharing);
        }

        private void Cam1Rtc_RTCInitialized(object sender)
        {

        }

        private void InitializeCam2Rtc()
        {
            cam2Rtc.Dock = DockStyle.Fill;
            cam2Rtc.SignalingUrl = IniFile.IniReadValue("device.ini", "Setting", "SignalingUrl", "https://rtc-signaling-service.herokuapp.com:443/");
            //cam2Rtc.SignalingUrl = ConfigurationManager.AppSettings["SignalingUrl"];
            cam2Rtc.SignalingType = SignalingTypes.Socketio;

            cam2Rtc.RTCInitialized += Cam2Rtc_RTCInitialized;
            cam2Rtc.IJoinedMeeting += Cam2Rtc_IJoinedMeeting;
            //cam2Rtc.UserJoinedMeeting += mainRtc_UserJoinedMeeting;
            //cam2Rtc.UserLeftMeeting += mainRtc_UserLeftMeeting;
            //cam2Rtc.ILeftMeeting += mainRtc_ILeftMeeting;
            //cam2Rtc.NewDevices += mainRtc_NewDevices;
            //cam2Rtc.MeetingMessageReceived += mainRtc_MeetingMessageReceived;

            DisplayRtcVideo(cam2Rtc, "Cam 2");

        }

        private void Cam2Rtc_IJoinedMeeting(object sender, UserArgs e)
        {
            //cam2Rtc.StartVideo();
            //ProcessParticipants(e.Participants, e.Session, e.Sharing);

        }

        private void Cam2Rtc_RTCInitialized(object sender)
        {
            //string user = ConfigurationManager.AppSettings["DeviceId"] + "|" + "cam2" + "|" + Helper.GetDeviceId();
            //string meetingId = user;// ConfigurationManager.AppSettings["PublicRoom"];
            //cam2Rtc.JoinMeeting(user, meetingId);
        }

        private void InitializeMainRtc()
        {
            mainRtc.Dock = DockStyle.Fill;
            mainRtc.SignalingUrl = IniFile.IniReadValue("device.ini", "Setting", "SignalingUrl", "https://rtc-signaling-service.herokuapp.com:443/");
            //mainRtc.SignalingUrl = ConfigurationManager.AppSettings["SignalingUrl"];
            mainRtc.SignalingType = SignalingTypes.Socketio;

            mainRtc.RTCInitialized += mainRtc_RTCInitialized;
            mainRtc.IJoinedMeeting += mainRtc_IJoinedMeeting;
            mainRtc.UserJoinedMeeting += mainRtc_UserJoinedMeeting;
            mainRtc.UserLeftMeeting += mainRtc_UserLeftMeeting;
            mainRtc.ILeftMeeting += mainRtc_ILeftMeeting;
            mainRtc.NewDevices += mainRtc_NewDevices;
            mainRtc.MeetingMessageReceived += mainRtc_MeetingMessageReceived;

            DisplayRtcVideo(mainRtc, "You");

        }

        private OutlookPanelEx DisplayRtcVideo(RTCControl rtc, string userName)
        {
            var panel = new OutlookPanelEx()
            {
                Tag = rtc.Tag,
                Width = 240,
                Height = 180,
                Visible = true,
                HeaderText = userName
            };
            panel.Controls.Add(rtc);
            flowLayoutPanel1.Controls.Add(panel);
            rtc.Show();
            return panel;
        }

        private void mainRtc_MeetingMessageReceived(object sender, MeetingMessageEventArgs e)
        {
            ProcessChatMessage(e.FromUser, e.Message);

            //PlaySound(Resources.newalert);
            //throw new NotImplementedException();
        }

        private void ProcessChatMessage(string fromUser, string message)
        {
            chatUC1.ProcessMessage(mainRtc.MyUserName, fromUser, message);
           
        }

        private void mainRtc_NewDevices(object sender, DeviceEventArgs e)
        {
            //settings.UpdateDevices(e);
        }

        private void mainRtc_ILeftMeeting(object sender, UserArgs e)
        {
            // throw new NotImplementedException();
        }

        private void mainRtc_UserLeftMeeting(object sender, UserArgs e)
        {
            var participant = _publicParticipants.FirstOrDefault(x => x.Session == e.Session);
            if (participant == null)
                return;

            var ctrlToRemove = participant.PanelLayout;

            //dispose of the RTC Control
            participant.RTCControl.Dispose();

            //remove the appropriate panel layout
            flowLayoutPanel1.Controls.Remove(ctrlToRemove);

            ctrlToRemove.Dispose();

            _publicParticipants.RemoveAll(x => x.Session == e.Session);
            //UpdatePartipantList();
        }

        //private void UpdatePartipantList()
        //{
        //    lvOnline.Items.Clear();
        //    foreach (var participant in _publicParticipants)
        //    {
        //        lvOnline.Items.Add(new ListViewItem(new string[]{
        //            participant.UserName,
        //            participant.Session
        //        }));
        //    }
        //}

        private void mainRtc_UserJoinedMeeting(object sender, UserArgs e)
        {
            ProcessParticipants(e.Participants, e.Session, e.Sharing);
        }
        private void ProcessParticipants(List<MeetingParticipants> participants, string sessionJoined, bool isSharing)
        {

            foreach (var participant in participants)

            {
                if (participant.Session == mainRtc.MySession) //you are already seeing yourself :)
                    continue;
                if (participant.Session == cam1Rtc.MySession) //you are already seeing yourself :)
                    continue;
                if (participant.Session == cam2Rtc.MySession) //you are already seeing yourself :)
                    continue;

                UserExtra user = JsonConvert.DeserializeObject<UserExtra>(participant.UserName);
                if (user.DeviceType == Library.DeviceType.AmbulanceCamera1)
                    continue;
                if (user.DeviceType == Library.DeviceType.AmbulanceCamera2)
                    continue;

                if (participant.UserName == "sharing-" + mainRtc.MyUserName)
                    return;

                var sessionExists = _publicParticipants.Any(p => p.Session == participant.Session);

                if (sessionExists)
                    continue;



                var viewer = new RTCControl
                {
                    Tag = participant.Session,
                    SignalingType = SignalingTypes.Socketio,
                    SignalingUrl = mainRtc.SignalingUrl,
                    Dock = DockStyle.Fill
                };

                var panel = DisplayRtcVideo(viewer, user.UserName);

                _publicParticipants.Add(new CurrentParticipant
                {
                    Session = participant.Session,
                    User = user,
                    PanelLayout = panel,
                    RTCControl = viewer
                });

                viewer.RTCInitialized += a =>
                {
                    //you can add additional ice servers if you'd like
                    //  viewer.AddIceServer(url: "numb.viagenie.ca", userName: "support@avspeed.com", password: "avspeedwebrtc", clearFirst: false, type: "turn");
                    //viewer.AddIceServer("stun.voiparound.com");

                    //webrtc is ready, connect to signaling
                    viewer.ViewSession(participant.UserName, participant.Session);
                };
            }

            //UpdatePartipantList();
        }
        private void mainRtc_IJoinedMeeting(object sender, UserArgs e)
        {

            //mainRtc.StartVideo();

            //ProcessParticipants(e.Participants, e.Session, e.Sharing);

        }

        private void mainRtc_RTCInitialized(object sender)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("Initialized");

            //string user = ConfigurationManager.AppSettings["DeviceId"] + "|" + "main" + "|" + Helper.GetDeviceId();
            //string meetingId = user;// ConfigurationManager.AppSettings["PublicRoom"];
            //mainRtc.JoinMeeting(user, meetingId);
        }

        private void PublicUC_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        //private void btnSendMessage_Click(object sender, EventArgs e)
        //{
        //    mainRtc.SendMessageToMeeting(txtMsg.Text);
        //}

        private void btnSetting_Click(object sender, EventArgs e)
        {
        

        }

        private void LeaveMeeting()
        {
            mainRtc.LeaveMeeting();
            cam1Rtc.LeaveMeeting();
            cam2Rtc.LeaveMeeting();
        }

        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    mainRtc.SendMessageToMeeting(txtMsg.Text);
        //}

        private void btnStart_Click(object sender, EventArgs e)
        {
            mainRtc.StartVideo();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mainRtc.StopVideo();

        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            mainRtc.MuteVideo(true);

        }

        private void btnUnmute_Click(object sender, EventArgs e)
        {
            mainRtc.MuteVideo(false);

        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            cam1Rtc.LeaveMeeting();
            cam2Rtc.LeaveMeeting();
            mainRtc.LeaveMeeting();

            if(OnLeaveMeeting != null)
            {
                OnLeaveMeeting(sender, e);
            }
        }

        private void btnMuteAudio_Click(object sender, EventArgs e)
        {
            mainRtc.MuteAudio(true);

        }

        private void btnUnmuteAudio_Click(object sender, EventArgs e)
        {
            mainRtc.MuteAudio(false);
        }

        private void btnCam1StartVideo_Click(object sender, EventArgs e)
        {
            cam1Rtc.StartVideo();
        }

        private void btnCam1StopVideo_Click(object sender, EventArgs e)
        {
            cam1Rtc.StopVideo();
        }

        private void btnCam1MuteVideo_Click(object sender, EventArgs e)
        {
            cam1Rtc.MuteVideo(true);
        }

        private void btnCam1UnmuteVideo_Click(object sender, EventArgs e)
        {
            cam1Rtc.MuteVideo(false);
        }

        private void btnCam1MuteAudio_Click(object sender, EventArgs e)
        {
            cam1Rtc.MuteAudio(true);
        }

        private void btnCam1UnMuteAudio_Click(object sender, EventArgs e)
        {
            cam1Rtc.MuteAudio(false);
        }
    }
}
