
namespace TeleMedic.Library
{
    partial class ChatUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.htmlChatBox = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(492, 71);
            this.panel1.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(5, 5);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(407, 61);
            this.txtMsg.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(412, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 61);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // htmlChatBox
            // 
            this.htmlChatBox.AutoScroll = true;
            this.htmlChatBox.AutoScrollMinSize = new System.Drawing.Size(492, 25);
            this.htmlChatBox.BackColor = System.Drawing.SystemColors.Window;
            this.htmlChatBox.BaseStylesheet = null;
            this.htmlChatBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.htmlChatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlChatBox.Location = new System.Drawing.Point(0, 0);
            this.htmlChatBox.Name = "htmlChatBox";
            this.htmlChatBox.Padding = new System.Windows.Forms.Padding(5);
            this.htmlChatBox.Size = new System.Drawing.Size(492, 425);
            this.htmlChatBox.TabIndex = 3;
            this.htmlChatBox.Text = "htmlPanel1";
            // 
            // ChatUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.htmlChatBox);
            this.Controls.Add(this.panel1);
            this.Name = "ChatUC";
            this.Size = new System.Drawing.Size(492, 496);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlChatBox;
    }
}
