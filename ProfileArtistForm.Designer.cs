namespace Prototype
{
    partial class ProfileArtistForm
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
            this.profileButton = new System.Windows.Forms.Button();
            this.feedButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.genresLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // profileButton
            // 
            this.profileButton.Enabled = false;
            this.profileButton.Location = new System.Drawing.Point(134, 415);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(106, 23);
            this.profileButton.TabIndex = 3;
            this.profileButton.Text = "Профиль";
            this.profileButton.UseVisualStyleBackColor = true;
            // 
            // feedButton
            // 
            this.feedButton.Location = new System.Drawing.Point(12, 415);
            this.feedButton.Name = "feedButton";
            this.feedButton.Size = new System.Drawing.Size(106, 23);
            this.feedButton.TabIndex = 2;
            this.feedButton.Text = "Лента";
            this.feedButton.UseVisualStyleBackColor = true;
            this.feedButton.Click += new System.EventHandler(this.feedButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameLabel.Location = new System.Drawing.Point(108, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 23);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Имя Фамилия";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Location = new System.Drawing.Point(12, 12);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(90, 90);
            this.avatarPictureBox.TabIndex = 5;
            this.avatarPictureBox.TabStop = false;
            // 
            // ageLabel
            // 
            this.ageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ageLabel.Location = new System.Drawing.Point(108, 35);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(131, 20);
            this.ageLabel.TabIndex = 6;
            this.ageLabel.Text = "18 лет";
            this.ageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editProfileButton
            // 
            this.editProfileButton.Location = new System.Drawing.Point(75, 386);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(100, 23);
            this.editProfileButton.TabIndex = 7;
            this.editProfileButton.Text = "Редактировать";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(13, 129);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(227, 242);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Описание";
            // 
            // genresLabel
            // 
            this.genresLabel.Location = new System.Drawing.Point(12, 110);
            this.genresLabel.Name = "genresLabel";
            this.genresLabel.Size = new System.Drawing.Size(227, 19);
            this.genresLabel.TabIndex = 9;
            this.genresLabel.Text = "Жанры:";
            // 
            // cityLabel
            // 
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cityLabel.Location = new System.Drawing.Point(108, 55);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(131, 20);
            this.cityLabel.TabIndex = 10;
            this.cityLabel.Text = "Город";
            this.cityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProfileArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.genresLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.editProfileButton);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.avatarPictureBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.feedButton);
            this.Name = "ProfileArtistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Прототип";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button feedButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label genresLabel;
        private System.Windows.Forms.Label cityLabel;
    }
}