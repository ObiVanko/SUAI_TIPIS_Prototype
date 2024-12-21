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
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.readFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Прочитанные = new System.Windows.Forms.GroupBox();
            this.unreadFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.eventsTabPage.SuspendLayout();
            this.profileTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.notificationTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Прочитанные.SuspendLayout();
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
            this.genresLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.genresLabel.Location = new System.Drawing.Point(8, 112);
            this.genresLabel.Name = "genresLabel";
            this.genresLabel.Size = new System.Drawing.Size(227, 40);
            this.genresLabel.TabIndex = 16;
            this.genresLabel.Text = "Жанры:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel.Location = new System.Drawing.Point(8, 163);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(228, 229);
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
            this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.notificationTabPage.Controls.Add(this.clearButton);
            this.notificationTabPage.Controls.Add(this.groupBox2);
            this.notificationTabPage.Controls.Add(this.Прочитанные);
            this.notificationTabPage.Location = new System.Drawing.Point(4, 4);
            this.notificationTabPage.Name = "notificationTabPage";
            this.notificationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.notificationTabPage.Size = new System.Drawing.Size(244, 424);
            this.notificationTabPage.TabIndex = 2;
            this.notificationTabPage.Text = "Уведомления";
            this.notificationTabPage.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(85, 394);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readFlowLayoutPanel);
            this.groupBox2.Location = new System.Drawing.Point(3, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 184);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Прочитанные";
            // 
            // readFlowLayoutPanel
            // 
            this.readFlowLayoutPanel.AutoScroll = true;
            this.readFlowLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.readFlowLayoutPanel.Name = "readFlowLayoutPanel";
            this.readFlowLayoutPanel.Size = new System.Drawing.Size(226, 159);
            this.readFlowLayoutPanel.TabIndex = 1;
            // 
            // Прочитанные
            // 
            this.Прочитанные.Controls.Add(this.unreadFlowLayoutPanel);
            this.Прочитанные.Location = new System.Drawing.Point(3, 3);
            this.Прочитанные.Name = "Прочитанные";
            this.Прочитанные.Size = new System.Drawing.Size(238, 195);
            this.Прочитанные.TabIndex = 2;
            this.Прочитанные.TabStop = false;
            this.Прочитанные.Text = "Непрочитанные";
            // 
            // unreadFlowLayoutPanel
            // 
            this.unreadFlowLayoutPanel.AutoScroll = true;
            this.unreadFlowLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.unreadFlowLayoutPanel.Name = "unreadFlowLayoutPanel";
            this.unreadFlowLayoutPanel.Size = new System.Drawing.Size(226, 170);
            this.unreadFlowLayoutPanel.TabIndex = 1;
            // 
            // ArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "ArtistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.ArtistForm_Activated);
            this.tabControl1.ResumeLayout(false);
            this.eventsTabPage.ResumeLayout(false);
            this.profileTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.notificationTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.Прочитанные.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel unreadFlowLayoutPanel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel readFlowLayoutPanel;
        private System.Windows.Forms.GroupBox Прочитанные;
    }
}