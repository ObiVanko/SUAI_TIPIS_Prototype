namespace Prototype
{
    partial class ProfilePlatformForm
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
            this.cityLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.profileButton = new System.Windows.Forms.Button();
            this.feedButton = new System.Windows.Forms.Button();
            this.newEventButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cityLabel
            // 
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cityLabel.Location = new System.Drawing.Point(108, 35);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(131, 67);
            this.cityLabel.TabIndex = 19;
            this.cityLabel.Text = "Адрес";
            this.cityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(13, 105);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(227, 269);
            this.descriptionLabel.TabIndex = 17;
            this.descriptionLabel.Text = "Описание";
            // 
            // editProfileButton
            // 
            this.editProfileButton.Location = new System.Drawing.Point(134, 386);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(105, 23);
            this.editProfileButton.TabIndex = 16;
            this.editProfileButton.Text = "Редактировать";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Location = new System.Drawing.Point(12, 12);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(90, 90);
            this.avatarPictureBox.TabIndex = 14;
            this.avatarPictureBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameLabel.Location = new System.Drawing.Point(108, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 23);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "Название";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // profileButton
            // 
            this.profileButton.Enabled = false;
            this.profileButton.Location = new System.Drawing.Point(134, 415);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(106, 23);
            this.profileButton.TabIndex = 12;
            this.profileButton.Text = "Профиль";
            this.profileButton.UseVisualStyleBackColor = true;
            // 
            // feedButton
            // 
            this.feedButton.Location = new System.Drawing.Point(12, 415);
            this.feedButton.Name = "feedButton";
            this.feedButton.Size = new System.Drawing.Size(106, 23);
            this.feedButton.TabIndex = 11;
            this.feedButton.Text = "Лента";
            this.feedButton.UseVisualStyleBackColor = true;
            this.feedButton.Click += new System.EventHandler(this.feedButton_Click);
            // 
            // newEventButton
            // 
            this.newEventButton.Location = new System.Drawing.Point(12, 386);
            this.newEventButton.Name = "newEventButton";
            this.newEventButton.Size = new System.Drawing.Size(106, 23);
            this.newEventButton.TabIndex = 20;
            this.newEventButton.Text = "+ Мероприятие";
            this.newEventButton.UseVisualStyleBackColor = true;
            // 
            // ProfilePlatformForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.newEventButton);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.editProfileButton);
            this.Controls.Add(this.avatarPictureBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.feedButton);
            this.Name = "ProfilePlatformForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Прототип";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfilePlatformForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button feedButton;
        private System.Windows.Forms.Button newEventButton;
    }
}