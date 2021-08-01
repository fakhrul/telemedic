
namespace TeleMedic.Ambulance
{
    partial class DashboardUC
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.htmlChatBox = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.btnCam1UnMuteAudio = new System.Windows.Forms.Button();
            this.btnCam1MuteAudio = new System.Windows.Forms.Button();
            this.btnCam1UnmuteVideo = new System.Windows.Forms.Button();
            this.btnCam1MuteVideo = new System.Windows.Forms.Button();
            this.btnCam1StopVideo = new System.Windows.Forms.Button();
            this.btnCam1StartVideo = new System.Windows.Forms.Button();
            this.btnUnmuteAudio = new System.Windows.Forms.Button();
            this.btnMuteAudio = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.btnUnmute = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.bingMap1 = new TeleMedic.Library.BingMap();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 657);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(538, 657);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(538, 328);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.htmlChatBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(538, 254);
            this.panel3.TabIndex = 1;
            // 
            // htmlChatBox
            // 
            this.htmlChatBox.AutoScroll = true;
            this.htmlChatBox.BackColor = System.Drawing.SystemColors.Window;
            this.htmlChatBox.BaseStylesheet = null;
            this.htmlChatBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.htmlChatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlChatBox.Location = new System.Drawing.Point(0, 0);
            this.htmlChatBox.Name = "htmlChatBox";
            this.htmlChatBox.Size = new System.Drawing.Size(538, 254);
            this.htmlChatBox.TabIndex = 0;
            this.htmlChatBox.Text = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 71);
            this.panel1.TabIndex = 0;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(463, 71);
            this.txtMsg.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(463, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 71);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.elementHost1);
            this.splitContainer2.Panel1.Controls.Add(this.button7);
            this.splitContainer2.Panel1.Controls.Add(this.button8);
            this.splitContainer2.Panel1.Controls.Add(this.button9);
            this.splitContainer2.Panel1.Controls.Add(this.button10);
            this.splitContainer2.Panel1.Controls.Add(this.button11);
            this.splitContainer2.Panel1.Controls.Add(this.button12);
            this.splitContainer2.Panel1.Controls.Add(this.btnCam1UnMuteAudio);
            this.splitContainer2.Panel1.Controls.Add(this.btnCam1MuteAudio);
            this.splitContainer2.Panel1.Controls.Add(this.btnCam1UnmuteVideo);
            this.splitContainer2.Panel1.Controls.Add(this.btnCam1MuteVideo);
            this.splitContainer2.Panel1.Controls.Add(this.btnCam1StopVideo);
            this.splitContainer2.Panel1.Controls.Add(this.btnCam1StartVideo);
            this.splitContainer2.Panel1.Controls.Add(this.btnUnmuteAudio);
            this.splitContainer2.Panel1.Controls.Add(this.btnMuteAudio);
            this.splitContainer2.Panel1.Controls.Add(this.btnLeave);
            this.splitContainer2.Panel1.Controls.Add(this.btnUnmute);
            this.splitContainer2.Panel1.Controls.Add(this.btnMute);
            this.splitContainer2.Panel1.Controls.Add(this.btnStop);
            this.splitContainer2.Panel1.Controls.Add(this.btnStart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(1123, 657);
            this.splitContainer2.SplitterDistance = 581;
            this.splitContainer2.TabIndex = 3;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(446, 469);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 50);
            this.button7.TabIndex = 18;
            this.button7.Text = "UnMute Audio";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(365, 469);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 50);
            this.button8.TabIndex = 17;
            this.button8.Text = "Mute Audio";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(284, 469);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 50);
            this.button9.TabIndex = 16;
            this.button9.Text = "UnMute Video";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(203, 469);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 50);
            this.button10.TabIndex = 15;
            this.button10.Text = "Mute Video";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(122, 469);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 50);
            this.button11.TabIndex = 14;
            this.button11.Text = "Stop Video";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(41, 469);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 50);
            this.button12.TabIndex = 13;
            this.button12.Text = "Start Video";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // btnCam1UnMuteAudio
            // 
            this.btnCam1UnMuteAudio.Location = new System.Drawing.Point(446, 401);
            this.btnCam1UnMuteAudio.Name = "btnCam1UnMuteAudio";
            this.btnCam1UnMuteAudio.Size = new System.Drawing.Size(75, 50);
            this.btnCam1UnMuteAudio.TabIndex = 12;
            this.btnCam1UnMuteAudio.Text = "UnMute Audio";
            this.btnCam1UnMuteAudio.UseVisualStyleBackColor = true;
            this.btnCam1UnMuteAudio.Click += new System.EventHandler(this.btnCam1UnMuteAudio_Click);
            // 
            // btnCam1MuteAudio
            // 
            this.btnCam1MuteAudio.Location = new System.Drawing.Point(365, 401);
            this.btnCam1MuteAudio.Name = "btnCam1MuteAudio";
            this.btnCam1MuteAudio.Size = new System.Drawing.Size(75, 50);
            this.btnCam1MuteAudio.TabIndex = 11;
            this.btnCam1MuteAudio.Text = "Mute Audio";
            this.btnCam1MuteAudio.UseVisualStyleBackColor = true;
            this.btnCam1MuteAudio.Click += new System.EventHandler(this.btnCam1MuteAudio_Click);
            // 
            // btnCam1UnmuteVideo
            // 
            this.btnCam1UnmuteVideo.Location = new System.Drawing.Point(284, 401);
            this.btnCam1UnmuteVideo.Name = "btnCam1UnmuteVideo";
            this.btnCam1UnmuteVideo.Size = new System.Drawing.Size(75, 50);
            this.btnCam1UnmuteVideo.TabIndex = 10;
            this.btnCam1UnmuteVideo.Text = "UnMute Video";
            this.btnCam1UnmuteVideo.UseVisualStyleBackColor = true;
            this.btnCam1UnmuteVideo.Click += new System.EventHandler(this.btnCam1UnmuteVideo_Click);
            // 
            // btnCam1MuteVideo
            // 
            this.btnCam1MuteVideo.Location = new System.Drawing.Point(203, 401);
            this.btnCam1MuteVideo.Name = "btnCam1MuteVideo";
            this.btnCam1MuteVideo.Size = new System.Drawing.Size(75, 50);
            this.btnCam1MuteVideo.TabIndex = 9;
            this.btnCam1MuteVideo.Text = "Mute Video";
            this.btnCam1MuteVideo.UseVisualStyleBackColor = true;
            this.btnCam1MuteVideo.Click += new System.EventHandler(this.btnCam1MuteVideo_Click);
            // 
            // btnCam1StopVideo
            // 
            this.btnCam1StopVideo.Location = new System.Drawing.Point(122, 401);
            this.btnCam1StopVideo.Name = "btnCam1StopVideo";
            this.btnCam1StopVideo.Size = new System.Drawing.Size(75, 50);
            this.btnCam1StopVideo.TabIndex = 8;
            this.btnCam1StopVideo.Text = "Stop Video";
            this.btnCam1StopVideo.UseVisualStyleBackColor = true;
            this.btnCam1StopVideo.Click += new System.EventHandler(this.btnCam1StopVideo_Click);
            // 
            // btnCam1StartVideo
            // 
            this.btnCam1StartVideo.Location = new System.Drawing.Point(41, 401);
            this.btnCam1StartVideo.Name = "btnCam1StartVideo";
            this.btnCam1StartVideo.Size = new System.Drawing.Size(75, 50);
            this.btnCam1StartVideo.TabIndex = 7;
            this.btnCam1StartVideo.Text = "Start Video";
            this.btnCam1StartVideo.UseVisualStyleBackColor = true;
            this.btnCam1StartVideo.Click += new System.EventHandler(this.btnCam1StartVideo_Click);
            // 
            // btnUnmuteAudio
            // 
            this.btnUnmuteAudio.Location = new System.Drawing.Point(446, 320);
            this.btnUnmuteAudio.Name = "btnUnmuteAudio";
            this.btnUnmuteAudio.Size = new System.Drawing.Size(75, 50);
            this.btnUnmuteAudio.TabIndex = 6;
            this.btnUnmuteAudio.Text = "UnMute Audio";
            this.btnUnmuteAudio.UseVisualStyleBackColor = true;
            this.btnUnmuteAudio.Click += new System.EventHandler(this.btnUnmuteAudio_Click);
            // 
            // btnMuteAudio
            // 
            this.btnMuteAudio.Location = new System.Drawing.Point(365, 320);
            this.btnMuteAudio.Name = "btnMuteAudio";
            this.btnMuteAudio.Size = new System.Drawing.Size(75, 50);
            this.btnMuteAudio.TabIndex = 5;
            this.btnMuteAudio.Text = "Mute Audio";
            this.btnMuteAudio.UseVisualStyleBackColor = true;
            this.btnMuteAudio.Click += new System.EventHandler(this.btnMuteAudio_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Location = new System.Drawing.Point(463, 586);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(75, 50);
            this.btnLeave.TabIndex = 4;
            this.btnLeave.Text = "Leave Meeting";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // btnUnmute
            // 
            this.btnUnmute.Location = new System.Drawing.Point(284, 320);
            this.btnUnmute.Name = "btnUnmute";
            this.btnUnmute.Size = new System.Drawing.Size(75, 50);
            this.btnUnmute.TabIndex = 3;
            this.btnUnmute.Text = "UnMute Video";
            this.btnUnmute.UseVisualStyleBackColor = true;
            this.btnUnmute.Click += new System.EventHandler(this.btnUnmute_Click);
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(203, 320);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(75, 50);
            this.btnMute.TabIndex = 2;
            this.btnMute.Text = "Mute Video";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(122, 320);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 50);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop Video";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(41, 320);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Video";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Top;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(581, 298);
            this.elementHost1.TabIndex = 19;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.bingMap1;
            // 
            // DashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(1123, 657);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlChatBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnUnmute;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnUnmuteAudio;
        private System.Windows.Forms.Button btnMuteAudio;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button btnCam1UnMuteAudio;
        private System.Windows.Forms.Button btnCam1MuteAudio;
        private System.Windows.Forms.Button btnCam1UnmuteVideo;
        private System.Windows.Forms.Button btnCam1MuteVideo;
        private System.Windows.Forms.Button btnCam1StopVideo;
        private System.Windows.Forms.Button btnCam1StartVideo;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Library.BingMap bingMap1;
    }
}
