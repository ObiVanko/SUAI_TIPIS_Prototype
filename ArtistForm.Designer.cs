namespace Prototype
{
    partial class ArtistForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.eventsTabPage = new System.Windows.Forms.TabPage();
            this.feedListView = new System.Windows.Forms.ListView();
            this.profileTabPage = new System.Windows.Forms.TabPage();
            this.cityLabel = new System.Windows.Forms.Label();
            this.genresLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.ageLabel = new System.Windows.Forms.Label();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.notificationTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.eventsTabPage.SuspendLayout();
            this.profileTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.eventsTabPage);
            this.tabControl1.Controls.Add(this.profileTabPage);
            this.tabControl1.Controls.Add(this.notificationTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(83, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(252, 450);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // eventsTabPage
            // 
            this.eventsTabPage.Controls.Add(this.feedListView);
            this.eventsTabPage.Location = new System.Drawing.Point(4, 4);
            this.eventsTabPage.Name = "eventsTabPage";
            this.eventsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTabPage.Size = new System.Drawing.Size(244, 424);
            this.eventsTabPage.TabIndex = 0;
            this.eventsTabPage.Text = "Мероприятия";
            this.eventsTabPage.UseVisualStyleBackColor = true;
            // 
            // feedListView
            // 
            this.feedListView.HideSelection = false;
            this.feedListView.Location = new System.Drawing.Point(-4, -4);
            this.feedListView.Name = "feedListView";
            this.feedListView.Size = new System.Drawing.Size(252, 428);
            this.feedListView.TabIndex = 3;
            this.feedListView.UseCompatibleStateImageBehavior = false;
            this.feedListView.ItemActivate += new System.EventHandler(this.feedListView_ItemActivate);
            // 
            // profileTabPage
            // 
            this.profileTabPage.Controls.Add(this.cityLabel);
            this.profileTabPage.Controls.Add(this.genresLabel);
            this.profileTabPage.Controls.Add(this.descriptionLabel);
            this.profileTabPage.Controls.Add(this.editProfileButton);
            this.profileTabPage.Controls.Add(this.ageLabel);
            this.profileTabPage.Controls.Add(this.avatarPictureBox);
            this.profileTabPage.Controls.Add(this.nameLabel);
            this.profileTabPage.Location = new System.Drawing.Point(4, 4);
            this.profileTabPage.Name = "profileTabPage";
            this.profileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.profileTabPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.profileTabPage.Size = new System.Drawing.Size(244, 424);
            this.profileTabPage.TabIndex = 1;
            this.profileTabPage.Text = "Профиль";
            this.profileTabPage.UseVisualStyleBackColor = true;
            // 
            // cityLabel
            // 
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cityLabel.Location = new System.Drawing.Point(104, 57);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(131, 20);
            this.cityLabel.TabIndex = 17;
            this.cityLabel.Text = "Город";
            this.cityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // genresLabel
            // 
            this.genresLabel.Location = new System.Drawing.Point(8, 112);
            this.genresLabel.Name = "genresLabel";
            this.genresLabel.Size = new System.Drawing.Size(227, 19);
            this.genresLabel.TabIndex = 16;
            this.genresLabel.Text = "Жанры:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(9, 131);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(227, 242);
            this.descriptionLabel.TabIndex = 15;
            this.descriptionLabel.Text = "Описание";
            // 
            // editProfileButton
            // 
            this.editProfileButton.Location = new System.Drawing.Point(71, 395);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(100, 23);
            this.editProfileButton.TabIndex = 14;
            this.editProfileButton.Text = "Редактировать";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // ageLabel
            // 
            this.ageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ageLabel.Location = new System.Drawing.Point(104, 37);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(131, 20);
            this.ageLabel.TabIndex = 13;
            this.ageLabel.Text = "18 лет";
            this.ageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Location = new System.Drawing.Point(8, 14);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(90, 90);
            this.avatarPictureBox.TabIndex = 12;
            this.avatarPictureBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameLabel.Location = new System.Drawing.Point(104, 14);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 23);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Имя Фамилия";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notificationTabPage
            // 
            this.notificationTabPage.Location = new System.Drawing.Point(4, 4);
            this.notificationTabPage.Name = "notificationTabPage";
            this.notificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.notificationTabPage.Size = new System.Drawing.Size(244, 424);
            this.notificationTabPage.TabIndex = 2;
            this.notificationTabPage.Text = "Уведомления";
            this.notificationTabPage.UseVisualStyleBackColor = true;
            // 
            // ArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "ArtistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Прототип";
            this.tabControl1.ResumeLayout(false);
            this.eventsTabPage.ResumeLayout(false);
            this.profileTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage eventsTabPage;
        private System.Windows.Forms.TabPage profileTabPage;
        private System.Windows.Forms.TabPage notificationTabPage;
        private System.Windows.Forms.ListView feedListView;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label genresLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.Label nameLabel;
    }
}