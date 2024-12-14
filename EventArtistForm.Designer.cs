namespace Prototype
{
    partial class EventArtistForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.adressLabel = new System.Windows.Forms.Label();
            this.platformLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.genresLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // adressLabel
            // 
            this.adressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.adressLabel.Location = new System.Drawing.Point(109, 55);
            this.adressLabel.Name = "adressLabel";
            this.adressLabel.Size = new System.Drawing.Size(131, 47);
            this.adressLabel.TabIndex = 13;
            this.adressLabel.Text = "Адрес";
            this.adressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // platformLabel
            // 
            this.platformLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.platformLabel.Location = new System.Drawing.Point(109, 35);
            this.platformLabel.Name = "platformLabel";
            this.platformLabel.Size = new System.Drawing.Size(131, 20);
            this.platformLabel.TabIndex = 12;
            this.platformLabel.Text = "Организатор";
            this.platformLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.nameLabel.Location = new System.Drawing.Point(109, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 23);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Название";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // genresLabel
            // 
            this.genresLabel.Location = new System.Drawing.Point(12, 126);
            this.genresLabel.Name = "genresLabel";
            this.genresLabel.Size = new System.Drawing.Size(227, 19);
            this.genresLabel.TabIndex = 15;
            this.genresLabel.Text = "Жанры:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(13, 145);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(227, 255);
            this.descriptionLabel.TabIndex = 14;
            this.descriptionLabel.Text = "Описание";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 415);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 23);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(164, 415);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(75, 23);
            this.signButton.TabIndex = 17;
            this.signButton.Text = "Записаться";
            this.signButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "Дата";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EventArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.genresLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.adressLabel);
            this.Controls.Add(this.platformLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EventArtistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Прототип";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventArtistForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label adressLabel;
        private System.Windows.Forms.Label platformLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label genresLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Label label1;
    }
}