using iConfRTCModel;
using iConfRTCWinForm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeleMedic.Library;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace TeleMedic
{
    public partial class PrivateUC : UserControl
    {
        protected List<CurrentParticipant> _publicParticipants = new List<CurrentParticipant>();
        protected HtmlPanel publicChat;
        string meetingId;
        RTCControl rtc;

        public event EventHandler<EventArgs> OnLeaveMeeting;

        public PrivateUC():
            this(new RTCControl(), "")
        {
        }

        public PrivateUC(RTCControl mainRtc, string meetingId)
        {
            //RTC.Init();
            InitializeComponent();
            this.meetingId = meetingId;
            rtc = mainRtc;

            rtc.Dock = DockStyle.Fill;
            rtc.SignalingUrl = IniFile.IniReadValue("device.ini", "Setting", "SignalingUrl", "https://rtc-signaling-service.herokuapp.com:443/");

            //rtc.SignalingUrl = ConfigurationManager.AppSettings["SignalingUrl"];
            rtc.SignalingType = SignalingTypes.Socketio;

            //logging
            rtc.LoggingEnabled = true;
            rtc.LogFilePath = Path.GetTempPath() + @"\private_rtclog.txt";

            rtc.RTCInitialized += PublicRTC_RTCInitialized;
            rtc.IJoinedMeeting += PublicRTC_IJoinedMeeting;
            rtc.UserJoinedMeeting += PublicRTC_UserJoinedMeeting;
            rtc.UserLeftMeeting += PublicRTC_UserLeftMeeting;
            rtc.ILeftMeeting += PublicRTC_ILeftMeeting;
            //rtc.NewDevices += PublicRTC_NewDevices;
            rtc.MeetingMessageReceived += PublicRTC_MeetingMessageReceived;

            //pnlViewer.Controls.Add(rtc);
            //pnlViewer.Show();
            DisplayRtcVideo(rtc, "You");

        }

        internal void StartMeeting()
        {
            
            UserExtra user = new UserExtra
            {
                UserName = IniFile.IniReadValue("device.ini", "Setting", "DeviceName", "HOSP1"),
            DeviceId = Helper.GetDeviceId(),
                DeviceType = Library.DeviceType.Hospital
            };
            string userJson = JsonConvert.SerializeObject(user);
            //string meetingId = user.DeviceId;
            rtc.JoinMeeting(userJson, meetingId);
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

        internal void RequestToJoin(string meetingId)
        {
            //string user = ConfigurationManager.AppSettings["DeviceId"] + "|" + Helper.GetDeviceId();

            UserExtra user = new UserExtra
            {
                UserName = IniFile.IniReadValue("device.ini", "Setting", "DeviceName", "HOSP1"),
                DeviceId = Helper.GetDeviceId(),
                DeviceType = Library.DeviceType.Hospital
            };
            string userJson = JsonConvert.SerializeObject(user);
            //string meetingId = user.DeviceId;
            //mainRtc.JoinMeeting(userJson, meetingId);


            rtc.JoinMeeting(userJson, meetingId);
        }

        private void PublicRTC_MeetingMessageReceived(object sender, MeetingMessageEventArgs e)
        {
            ProcessChatMessage(e.FromUser, e.Message);

            //PlaySound(Resources.newalert);
            //throw new NotImplementedException();
        }

        private void ProcessChatMessage(string fromUser, string message)
        {
            string[] messages = message.Split('|');
            if (messages.Length > 1 && messages[messages.Length - 1] == "messageCode")
            {

            }
            else
            {
                if (fromUser != rtc.MyUserName)
                    htmlChatBox.Text = htmlChatBox.GetHtml() + "<div style='background-color:#C4E6F7; margin-left:5px'>" + fromUser +
                                 "<br/>" + message + "</div>";
                else
                    htmlChatBox.Text = htmlChatBox.GetHtml() + "<div style='background-color:#DCF2FA; margin-left:10px'>" + fromUser +
                                 "<br/>" + message + "</div>";

                // Return focus to message text box
                txtMsg.Focus();
            }
        }

        private void PublicRTC_NewDevices(object sender, DeviceEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void PublicRTC_ILeftMeeting(object sender, UserArgs e)
        {
            // throw new NotImplementedException();
        }

        private void PublicRTC_UserLeftMeeting(object sender, UserArgs e)
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
        //    foreach(var participant in _publicParticipants)
        //    {
        //        lvOnline.Items.Add(new ListViewItem(new string[]{
        //            participant.UserName,
        //            participant.Session
        //        }));
        //    }
        //}

        private void PublicRTC_UserJoinedMeeting(object sender, UserArgs e)
        {
            ProcessParticipants(e.Participants, e.Session, e.Sharing);
        }
        private void ProcessParticipants(List<MeetingParticipants> participants, string sessionJoined, bool isSharing)
        {

            foreach (var participant in participants)
            {
                if (participant.Session == rtc.MySession) //you are already seeing yourself :)
                    continue;

                if (participant.UserName == "sharing-" + rtc.MyUserName)
                    return;

                var sessionExists = _publicParticipants.Any(p => p.Session == participant.Session);

                if (sessionExists)
                    continue;

                UserExtra user = JsonConvert.DeserializeObject<UserExtra>(participant.UserName);


                var viewer = new RTCControl
                {
                    Tag = participant.Session,
                    SignalingType = SignalingTypes.Socketio,
                    SignalingUrl = rtc.SignalingUrl,
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
        private void PublicRTC_IJoinedMeeting(object sender, UserArgs e)
        {
            //ProcessParticipants(e.Participants, e.Session, e.Sharing);

        }

        private void PublicRTC_RTCInitialized(object sender)
        {
            //RequestToJoin(this.meetingId);
            //throw new NotImplementedException();
            //MessageBox.Show("Initialized");


        }

        private void PublicUC_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            rtc.SendMessageToMeeting(txtMsg.Text);

        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            rtc.MuteVideo(true);
        }

        private void btnUnmute_Click(object sender, EventArgs e)
        {
            rtc.MuteVideo(false);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            rtc.StartVideo();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            rtc.StopVideo();
        }

        private void btnMuteAudio_Click(object sender, EventArgs e)
        {
            rtc.MuteAudio(true);
        }

        private void btnUnmuteAudio_Click(object sender, EventArgs e)
        {
            rtc.MuteAudio(false);
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            rtc.LeaveMeeting();

            if (OnLeaveMeeting != null)
            {
                OnLeaveMeeting(sender, e);
            }
        }
    }
}
