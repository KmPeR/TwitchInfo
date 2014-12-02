namespace TwitchInfo
{
    partial class WinOptions
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OptionsTwitch = new System.Windows.Forms.GroupBox();
            this.OptionsTwitchUsername_T = new System.Windows.Forms.TextBox();
            this.OptionsTwitchUsername_L = new System.Windows.Forms.Label();
            this.OptionsTwitchCheck_B = new System.Windows.Forms.Button();
            this.OptionsTwitchCheck_L = new System.Windows.Forms.Label();
            this.OptionsTwitch.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsTwitch
            // 
            this.OptionsTwitch.Controls.Add(this.OptionsTwitchCheck_L);
            this.OptionsTwitch.Controls.Add(this.OptionsTwitchCheck_B);
            this.OptionsTwitch.Controls.Add(this.OptionsTwitchUsername_L);
            this.OptionsTwitch.Controls.Add(this.OptionsTwitchUsername_T);
            this.OptionsTwitch.Location = new System.Drawing.Point(13, 13);
            this.OptionsTwitch.Name = "OptionsTwitch";
            this.OptionsTwitch.Size = new System.Drawing.Size(352, 120);
            this.OptionsTwitch.TabIndex = 0;
            this.OptionsTwitch.TabStop = false;
            this.OptionsTwitch.Text = "Twitch Options";
            // 
            // OptionsTwitchUsername_T
            // 
            this.OptionsTwitchUsername_T.Location = new System.Drawing.Point(119, 31);
            this.OptionsTwitchUsername_T.Name = "OptionsTwitchUsername_T";
            this.OptionsTwitchUsername_T.Size = new System.Drawing.Size(227, 22);
            this.OptionsTwitchUsername_T.TabIndex = 0;
            // 
            // OptionsTwitchUsername_L
            // 
            this.OptionsTwitchUsername_L.AutoSize = true;
            this.OptionsTwitchUsername_L.Location = new System.Drawing.Point(6, 31);
            this.OptionsTwitchUsername_L.Name = "OptionsTwitchUsername_L";
            this.OptionsTwitchUsername_L.Size = new System.Drawing.Size(109, 17);
            this.OptionsTwitchUsername_L.TabIndex = 1;
            this.OptionsTwitchUsername_L.Text = "Your username:";
            // 
            // OptionsTwitchCheck_B
            // 
            this.OptionsTwitchCheck_B.Location = new System.Drawing.Point(9, 63);
            this.OptionsTwitchCheck_B.Name = "OptionsTwitchCheck_B";
            this.OptionsTwitchCheck_B.Size = new System.Drawing.Size(337, 23);
            this.OptionsTwitchCheck_B.TabIndex = 2;
            this.OptionsTwitchCheck_B.Text = "Check!";
            this.OptionsTwitchCheck_B.UseVisualStyleBackColor = true;
            this.OptionsTwitchCheck_B.Click += new System.EventHandler(this.OptionsTwitchCheck_B_Click);
            // 
            // OptionsTwitchCheck_L
            // 
            this.OptionsTwitchCheck_L.AutoSize = true;
            this.OptionsTwitchCheck_L.Location = new System.Drawing.Point(9, 93);
            this.OptionsTwitchCheck_L.Name = "OptionsTwitchCheck_L";
            this.OptionsTwitchCheck_L.Size = new System.Drawing.Size(0, 17);
            this.OptionsTwitchCheck_L.TabIndex = 3;
            // 
            // WinOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 336);
            this.Controls.Add(this.OptionsTwitch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WinOptions";
            this.Text = "WinOptions";
            this.OptionsTwitch.ResumeLayout(false);
            this.OptionsTwitch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox OptionsTwitch;
        private System.Windows.Forms.Label OptionsTwitchUsername_L;
        private System.Windows.Forms.TextBox OptionsTwitchUsername_T;
        private System.Windows.Forms.Button OptionsTwitchCheck_B;
        private System.Windows.Forms.Label OptionsTwitchCheck_L;
    }
}