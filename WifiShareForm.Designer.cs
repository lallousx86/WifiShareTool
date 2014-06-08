namespace WifiShare
{
    partial class WifiShareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WifiShareForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbSourceNetworks = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartSharing = new System.Windows.Forms.Button();
            this.btnStopSharing = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnRefreshNetworks = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connection to share from:";
            // 
            // cbSourceNetworks
            // 
            this.cbSourceNetworks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSourceNetworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceNetworks.FormattingEnabled = true;
            this.cbSourceNetworks.Location = new System.Drawing.Point(150, 83);
            this.cbSourceNetworks.Margin = new System.Windows.Forms.Padding(2);
            this.cbSourceNetworks.Name = "cbSourceNetworks";
            this.cbSourceNetworks.Size = new System.Drawing.Size(230, 21);
            this.cbSourceNetworks.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter access point name:";
            // 
            // txtApName
            // 
            this.txtApName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApName.Location = new System.Drawing.Point(150, 25);
            this.txtApName.Name = "txtApName";
            this.txtApName.Size = new System.Drawing.Size(259, 20);
            this.txtApName.TabIndex = 1;
            this.txtApName.Text = "WifiShareTool";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(150, 54);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(259, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "lallouslab";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter access point password:";
            // 
            // btnStartSharing
            // 
            this.btnStartSharing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStartSharing.Location = new System.Drawing.Point(238, 108);
            this.btnStartSharing.Name = "btnStartSharing";
            this.btnStartSharing.Size = new System.Drawing.Size(87, 60);
            this.btnStartSharing.TabIndex = 9;
            this.btnStartSharing.Text = "&Start sharing";
            this.btnStartSharing.UseVisualStyleBackColor = true;
            this.btnStartSharing.Click += new System.EventHandler(this.btnStartSharing_Click);
            // 
            // btnStopSharing
            // 
            this.btnStopSharing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStopSharing.Location = new System.Drawing.Point(331, 109);
            this.btnStopSharing.Name = "btnStopSharing";
            this.btnStopSharing.Size = new System.Drawing.Size(78, 59);
            this.btnStopSharing.TabIndex = 10;
            this.btnStopSharing.Text = "S&top Sharing";
            this.btnStopSharing.UseVisualStyleBackColor = true;
            this.btnStopSharing.Click += new System.EventHandler(this.btnStopSharing_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAbout.Location = new System.Drawing.Point(44, 111);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(48, 59);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnRefreshNetworks
            // 
            this.btnRefreshNetworks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshNetworks.Location = new System.Drawing.Point(385, 81);
            this.btnRefreshNetworks.Name = "btnRefreshNetworks";
            this.btnRefreshNetworks.Size = new System.Drawing.Size(25, 23);
            this.btnRefreshNetworks.TabIndex = 6;
            this.btnRefreshNetworks.Text = "&R";
            this.btnRefreshNetworks.UseVisualStyleBackColor = true;
            this.btnRefreshNetworks.Click += new System.EventHandler(this.btnRefreshNetworks_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::WifiShare.Properties.Resources.Icon;
            this.pictureBox1.Location = new System.Drawing.Point(7, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnStatus.Location = new System.Drawing.Point(96, 111);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(50, 59);
            this.btnStatus.TabIndex = 8;
            this.btnStatus.Text = "Stat&us";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // WifiShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 182);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRefreshNetworks);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnStopSharing);
            this.Controls.Add(this.btnStartSharing);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSourceNetworks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WifiShareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wifi Sharing tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WifiShareForm_FormClosed);
            this.Load += new System.EventHandler(this.WifiShareForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSourceNetworks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartSharing;
        private System.Windows.Forms.Button btnStopSharing;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnRefreshNetworks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStatus;
    }
}

