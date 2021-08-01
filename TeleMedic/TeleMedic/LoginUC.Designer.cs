
namespace TeleMedic
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMainAudioOutDevices = new System.Windows.Forms.ComboBox();
            this.cbMainVideoDevices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMainAudioDevices = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnStart.Location = new System.Drawing.Point(555, 308);
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
            this.Controls.Add(this.groupBox1);
            this.Name = "LoginUC";
            this.Size = new System.Drawing.Size(880, 641);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
