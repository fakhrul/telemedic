
namespace TeleMedic.Ambulance
{
    partial class LoginUC
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCam2VideoDevices = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCam1VideoDevices = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMainAudioOutDevices = new System.Windows.Forms.ComboBox();
            this.cbMainVideoDevices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMainAudioDevices = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCam2VideoDevices);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(194, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 105);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Room Camera";
            // 
            // cbRoomVideoDevices
            // 
            this.cbCam2VideoDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCam2VideoDevices.FormattingEnabled = true;
            this.cbCam2VideoDevices.Location = new System.Drawing.Point(20, 51);
            this.cbCam2VideoDevices.Margin = new System.Windows.Forms.Padding(4);
            this.cbCam2VideoDevices.Name = "cbRoomVideoDevices";
            this.cbCam2VideoDevices.Size = new System.Drawing.Size(399, 24);
            this.cbCam2VideoDevices.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Video";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCam1VideoDevices);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(194, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 99);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera 1";
            // 
            // cbPatientVideoDevices
            // 
            this.cbCam1VideoDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCam1VideoDevices.FormattingEnabled = true;
            this.cbCam1VideoDevices.Location = new System.Drawing.Point(20, 46);
            this.cbCam1VideoDevices.Margin = new System.Windows.Forms.Padding(4);
            this.cbCam1VideoDevices.Name = "cbPatientVideoDevices";
            this.cbCam1VideoDevices.Size = new System.Drawing.Size(399, 24);
            this.cbCam1VideoDevices.TabIndex = 7;
            this.cbCam1VideoDevices.SelectedIndexChanged += new System.EventHandler(this.cbPatientVideoDevices_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Video";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMainAudioOutDevices);
            this.groupBox1.Controls.Add(this.cbMainVideoDevices);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbMainAudioDevices);
            this.groupBox1.Location = new System.Drawing.Point(194, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 233);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Camera";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Audio Out";
            // 
            // cbMainAudioOutDevices
            // 
            this.cbMainAudioOutDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainAudioOutDevices.FormattingEnabled = true;
            this.cbMainAudioOutDevices.Location = new System.Drawing.Point(19, 116);
            this.cbMainAudioOutDevices.Margin = new System.Windows.Forms.Padding(4);
            this.cbMainAudioOutDevices.Name = "cbMainAudioOutDevices";
            this.cbMainAudioOutDevices.Size = new System.Drawing.Size(399, 24);
            this.cbMainAudioOutDevices.TabIndex = 8;
            // 
            // cbMainVideoDevices
            // 
            this.cbMainVideoDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainVideoDevices.FormattingEnabled = true;
            this.cbMainVideoDevices.Location = new System.Drawing.Point(19, 176);
            this.cbMainVideoDevices.Margin = new System.Windows.Forms.Padding(4);
            this.cbMainVideoDevices.Name = "cbMainVideoDevices";
            this.cbMainVideoDevices.Size = new System.Drawing.Size(399, 24);
            this.cbMainVideoDevices.TabIndex = 7;
            this.cbMainVideoDevices.SelectedIndexChanged += new System.EventHandler(this.cbMainVideoDevices_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 157);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Video";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Audio";
            // 
            // cbMainAudioDevices
            // 
            this.cbMainAudioDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainAudioDevices.FormattingEnabled = true;
            this.cbMainAudioDevices.Location = new System.Drawing.Point(20, 50);
            this.cbMainAudioDevices.Margin = new System.Windows.Forms.Padding(4);
            this.cbMainAudioDevices.Name = "cbMainAudioDevices";
            this.cbMainAudioDevices.Size = new System.Drawing.Size(399, 24);
            this.cbMainAudioDevices.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(555, 512);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // LoginUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoginUC";
            this.Size = new System.Drawing.Size(880, 641);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox cbCam2VideoDevices;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cbCam1VideoDevices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbMainAudioOutDevices;
        public System.Windows.Forms.ComboBox cbMainVideoDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbMainAudioDevices;
        private System.Windows.Forms.Button btnStart;
    }
}
