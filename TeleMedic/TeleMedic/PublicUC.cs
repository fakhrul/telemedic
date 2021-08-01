using AVSPEED;
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
    public partial class PublicUC : UserControl
    {
        protected RTCControl publicRTC;
        protected List<CurrentParticipant> _publicParticipants = new List<CurrentParticipant>();
        protected HtmlPanel publicChat;

        public event EventHandler<JoinRequestEventArgs> JoinRequest;
        public PublicUC()
        {
            RTC.Init();
            InitializeComponent();

            publicRTC = new RTCControl { Dock = DockStyle.Fill };
            publicRTC.SignalingUrl = IniFile.IniReadValue("device.ini", "Setting", "SignalingUrl", "https://rtc-signaling-service.herokuapp.com:443/");
            
            //publicRTC.SignalingUrl = ConfigurationManager.AppSettings["SignalingUrl"];
            publicRTC.SignalingType = SignalingTypes.Socketio;

            //logging
            publicRTC.LoggingEnabled = true;
            publicRTC.LogFilePath = Path.GetTempPath() + @"\public_rtclog.txt";

            publicRTC.RTCInitialized += PublicRTC_RTCInitialized;
            publicRTC.IJoinedMeeting += PublicRTC_IJoinedMeeting;
            publicRTC.UserJoinedMeeting += PublicRTC_UserJoinedMeeting;
            publicRTC.UserLeftMeeting += PublicRTC_UserLeftMeeting;
            publicRTC.ILeftMeeting += PublicRTC_ILeftMeeting;
            publicRTC.NewDevices += PublicRTC_NewDevices;
            publicRTC.MeetingMessageReceived += PublicRTC_MeetingMessageReceived;

            //publicRTC.StopVideo();
            //publicRTC.MuteAudio(true);
            //publicRTC.MuteVideo(true);

            Controls.Add(publicRTC);
            //pnlViewer.Show();

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
                if (fromUser != publicRTC.MyUserName)
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
            _publicParticipants.RemoveAll(x => x.Session == e.Session);
            UpdatePartipantList();
        }

        private void UpdatePartipantList()
        {
            lvOnline.Items.Clear();
            foreach (var participant in _publicParticipants)
            {
                string userJson = JsonConvert.SerializeObject(participant.User);

                //UserExtra user = JsonConvert.DeserializeObject<UserExtra>(participant.UserName);


                lvOnline.Items.Add(new ListViewItem(new string[]{
                        userJson,
                    participant.User.UserName,
                    participant.User.DeviceType.ToString(),
                    participant.User.DeviceId,
                    participant.Session
                }));
            }
        }

        private void PublicRTC_UserJoinedMeeting(object sender, UserArgs e)
        {
            ProcessParticipants(e.Participants, e.Session, e.Sharing);
        }
        private void ProcessParticipants(List<MeetingParticipants> participants, string sessionJoined, bool isSharing)
        {

            foreach (var participant in participants)

            {
                //if (participant.Session == publicRTC.MySession) //you are already seeing yourself :)
                //    continue;

                if (participant.UserName == "sharing-" + publicRTC.MyUserName)
                    return;

                var sessionExists = _publicParticipants.Any(p => p.Session == participant.Session);

                if (sessionExists)
                    continue;

                UserExtra user = JsonConvert.DeserializeObject<UserExtra>(participant.UserName);
                _publicParticipants.Add(new CurrentParticipant
                {
                    Session = participant.Session,
                    User = user,
                    //PanelLayout = pnlViewerParent,
                    //RTCControl = viewer
                });

            }

            UpdatePartipantList();
        }
        private void PublicRTC_IJoinedMeeting(object sender, UserArgs e)
        {
            //publicRTC.StartVideo();
            ProcessParticipants(e.Participants, e.Session, e.Sharing);
        }

        private void PublicRTC_RTCInitialized(object sender)
        {
            UserExtra user = new UserExtra
            {
                UserName = IniFile.IniReadValue("device.ini", "Setting", "DeviceName", "HOSP1"),
                DeviceId = Helper.GetDeviceId(),
                DeviceType = Library.DeviceType.Hospital
            };
            string userJson = JsonConvert.SerializeObject(user);

            string meetingId = IniFile.IniReadValue("device.ini", "Setting", "PublicRoom", "publicroom");
            publicRTC.StopVideo();
            publicRTC.MuteVideo(true);
            publicRTC.MuteAudio(true);
            publicRTC.JoinMeeting(userJson, meetingId);
        }

        private void PublicUC_Load(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string room = lvOnline.SelectedItems[0].Text;
        //        if (JoinRequest != null)
        //            JoinRequest(this, new JoinRequestEventArgs { MeetingId = room });
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            publicRTC.SendMessageToMeeting(txtMsg.Text);
        }

        private void lvOnline_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvOnline_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string room = lvOnline.SelectedItems[0].Text;
                UserExtra user = JsonConvert.DeserializeObject<UserExtra>(room);

                if (JoinRequest != null)
                    JoinRequest(this, new JoinRequestEventArgs { MeetingId = user.DeviceId });
            }
            catch (Exception ex)
            {
            }
        }
    }
}
