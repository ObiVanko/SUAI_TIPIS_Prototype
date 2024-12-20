namespace Prototype
{
    partial class EventPlatformForm
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
            this.editButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.adressLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.genresLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.seatsLabel = new System.Windows.Forms.Label();
            this.platformLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(142, 415);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(97, 23);
            this.editButton.TabIndex = 25;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 415);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 23);
            this.backButton.TabIndex = 24;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // adressLabel
            // 
            this.adressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.adressLabel.Location = new System.Drawing.Point(107, 55);
            this.adressLabel.Name = "adressLabel";
            this.adressLabel.Size = new System.Drawing.Size(131, 47);
            this.adressLabel.TabIndex = 21;
            this.adressLabel.Text = "Адрес";
            this.adressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameLabel.Location = new System.Drawing.Point(108, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 23);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Название";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(11, 12);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(90, 90);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePictureBox.TabIndex = 18;
            this.imagePictureBox.TabStop = false;
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dateTimeLabel.Location = new System.Drawing.Point(11, 103);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(227, 21);
            this.dateTimeLabel.TabIndex = 28;
            this.dateTimeLabel.Text = "Дата";
            this.dateTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // genresLabel
            // 
            this.genresLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.genresLabel.Location = new System.Drawing.Point(11, 124);
            this.genresLabel.Name = "genresLabel";
            this.genresLabel.Size = new System.Drawing.Size(227, 42);
            this.genresLabel.TabIndex = 27;
            this.genresLabel.Text = "Жанры:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 174);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(227, 215);
            this.descriptionLabel.TabIndex = 26;
            this.descriptionLabel.Text = "Описание";
            // 
            // seatsLabel
            // 
            this.seatsLabel.Location = new System.Drawing.Point(12, 389);
            this.seatsLabel.Name = "seatsLabel";
            this.seatsLabel.Size = new System.Drawing.Size(227, 23);
            this.seatsLabel.TabIndex = 29;
            this.seatsLabel.Text = "Свободных мест:";
            this.seatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // platformLinkLabel
            // 
            this.platformLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.platformLinkLabel.Location = new System.Drawing.Point(107, 32);
            this.platformLinkLabel.Name = "platformLinkLabel";
            this.platformLinkLabel.Size = new System.Drawing.Size(132, 23);
            this.platformLinkLabel.TabIndex = 30;
            this.platformLinkLabel.TabStop = true;
            this.platformLinkLabel.Text = "Площадка";
            this.platformLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.platformLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.platformLinkLabel_LinkClicked);
            // 
            // EventPlatformForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.platformLinkLabel);
            this.Controls.Add(this.seatsLabel);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.genresLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.adressLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.imagePictureBox);
            this.Name = "EventPlatformForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Прототип";
            this.Activated += new System.EventHandler(this.EventPlatformForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label adressLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Label genresLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label seatsLabel;
        private System.Windows.Forms.LinkLabel platformLinkLabel;
    }
}