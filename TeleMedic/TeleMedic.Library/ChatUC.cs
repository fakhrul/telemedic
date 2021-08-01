using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeleMedic.Library
{
    public partial class ChatUC : UserControl
    {
        public event EventHandler<ChatMessageEventArgs> OnMessageSend;
        public ChatUC()
        {
            InitializeComponent();
        }

        public void ProcessMessage(string hostUserName, string messageUser, string message)
        {
            string[] messages = message.Split('|');
            if (messages.Length > 1 && messages[messages.Length - 1] == "messageCode")
            {

            }
            else
            {
                if (messageUser != hostUserName)
                    htmlChatBox.Text = htmlChatBox.GetHtml() + "<div style='background-color:#C4E6F7; margin-left:5px'>" + messageUser +
                                 "<br/>" + message + "</div>";
                else
                    htmlChatBox.Text = htmlChatBox.GetHtml() + "<div style='background-color:#DCF2FA; margin-left:10px'>" + messageUser +
                                 "<br/>" + message + "</div>";

                // Return focus to message text box
                txtMsg.Focus();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (OnMessageSend != null)
                OnMessageSend(this, new ChatMessageEventArgs { Message = txtMsg.Text });
        }
    }
    public class ChatMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
