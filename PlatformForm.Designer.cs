namespace Prototype
{
    partial class PlatformForm
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
            this.feedListView = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.eventsTabPage = new System.Windows.Forms.TabPage();
            this.addEventButton = new System.Windows.Forms.Button();
            this.profileTabPage = new System.Windows.Forms.TabPage();
            this.addressLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.notificationTabPage = new System.Windows.Forms.TabPage();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.readFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Прочитанные = new System.Windows.Forms.GroupBox();
            this.unreadFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.eventsTabPage.SuspendLayout();
            this.profileTabPage.SuspendLayout();
            this.notificationTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Прочитанные.SuspendLayout();
            this.SuspendLayout();
            // 
            // feedListView
            // 
            this.feedListView.HideSelection = false;
            this.feedListView.Location = new System.Drawing.Point(-4, -4);
            this.feedListView.Name = "feedListView";
            this.feedListView.Size = new System.Drawing.Size(252, 393);
            this.feedListView.TabIndex = 3;
            this.feedListView.UseCompatibleStateImageBehavior = false;
            this.feedListView.ItemActivate += new System.EventHandler(this.feedListView_ItemActivate);
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
            this.tabControl1.TabIndex = 1;
            // 
            // eventsTabPage
            // 
            this.eventsTabPage.Controls.Add(this.addEventButton);
            this.eventsTabPage.Controls.Add(this.feedListView);
            this.eventsTabPage.Location = new System.Drawing.Point(4, 4);
            this.eventsTabPage.Name = "eventsTabPage";
            this.eventsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.eventsTabPage.Size = new System.Drawing.Size(244, 424);
            this.eventsTabPage.TabIndex = 0;
            this.eventsTabPage.Text = "Мероприятия";
            this.eventsTabPage.UseVisualStyleBackColor = true;
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(69, 395);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(106, 23);
            this.addEventButton.TabIndex = 27;
            this.addEventButton.Text = "Добавить";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // profileTabPage
            // 
            this.profileTabPage.Controls.Add(this.addressLabel);
            this.profileTabPage.Controls.Add(this.descriptionLabel);
            this.profileTabPage.Controls.Add(this.editProfileButton);
            this.profileTabPage.Controls.Add(this.nameLabel);
            this.profileTabPage.Controls.Add(this.avatarPictureBox);
            this.profileTabPage.Location = new System.Drawing.Point(4, 4);
            this.profileTabPage.Name = "profileTabPage";
            this.profileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.profileTabPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.profileTabPage.Size = new System.Drawing.Size(244, 424);
            this.profileTabPage.TabIndex = 1;
            this.profileTabPage.Text = "Профиль";
            this.profileTabPage.UseVisualStyleBackColor = true;
            // 
            // addressLabel
            // 
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.addressLabel.Location = new System.Drawing.Point(104, 56);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(131, 40);
            this.addressLabel.TabIndex = 25;
            this.addressLabel.Text = "Адрес";
            this.addressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel.Location = new System.Drawing.Point(9, 99);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(227, 293);
            this.descriptionLabel.TabIndex = 24;
            this.descriptionLabel.Text = "Описание";
            // 
            // editProfileButton
            // 
            this.editProfileButton.Location = new System.Drawing.Point(70, 395);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(105, 23);
            this.editProfileButton.TabIndex = 23;
            this.editProfileButton.Text = "Редактировать";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameLabel.Location = new System.Drawing.Point(104, 6);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 50);
            this.nameLabel.TabIndex = 21;
            this.nameLabel.Text = "Название";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // avatarPictureBox
            // 
            this.avatarPictureBox.Location = new System.Drawing.Point(8, 6);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(90, 90);
            this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarPictureBox.TabIndex = 22;
            this.avatarPictureBox.TabStop = false;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(85, 396);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readFlowLayoutPanel);
            this.groupBox2.Location = new System.Drawing.Point(3, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 184);
            this.groupBox2.TabIndex = 6;
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
            this.Прочитанные.Location = new System.Drawing.Point(3, 5);
            this.Прочитанные.Name = "Прочитанные";
            this.Прочитанные.Size = new System.Drawing.Size(238, 195);
            this.Прочитанные.TabIndex = 5;
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
            // PlatformForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "PlatformForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PlatfromForm";
            this.Activated += new System.EventHandler(this.PlatformForm_Activated);
            this.tabControl1.ResumeLayout(false);
            this.eventsTabPage.ResumeLayout(false);
            this.profileTabPage.ResumeLayout(false);
            this.notificationTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.Прочитанные.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView feedListView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage eventsTabPage;
        private System.Windows.Forms.TabPage profileTabPage;
        private System.Windows.Forms.TabPage notificationTabPage;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel readFlowLayoutPanel;
        private System.Windows.Forms.GroupBox Прочитанные;
        private System.Windows.Forms.FlowLayoutPanel unreadFlowLayoutPanel;
    }
}