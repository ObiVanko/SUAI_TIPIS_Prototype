namespace Prototype
{
    partial class EditProfilePlatformForm
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.removeAvatarButton = new System.Windows.Forms.Button();
            this.addAvatarButton = new System.Windows.Forms.Button();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.descriptionRichTextBox);
            this.groupBox6.Location = new System.Drawing.Point(12, 251);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(228, 158);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Описание";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(216, 133);
            this.descriptionRichTextBox.TabIndex = 0;
            this.descriptionRichTextBox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.errorLabel);
            this.groupBox3.Controls.Add(this.removeAvatarButton);
            this.groupBox3.Controls.Add(this.addAvatarButton);
            this.groupBox3.Controls.Add(this.imagePictureBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 121);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фото";
            // 
            // removeAvatarButton
            // 
            this.removeAvatarButton.Location = new System.Drawing.Point(131, 61);
            this.removeAvatarButton.Name = "removeAvatarButton";
            this.removeAvatarButton.Size = new System.Drawing.Size(75, 23);
            this.removeAvatarButton.TabIndex = 10;
            this.removeAvatarButton.Text = "Удалить";
            this.removeAvatarButton.UseVisualStyleBackColor = true;
            this.removeAvatarButton.Click += new System.EventHandler(this.removeAvatarButton_Click);
            // 
            // addAvatarButton
            // 
            this.addAvatarButton.Location = new System.Drawing.Point(131, 32);
            this.addAvatarButton.Name = "addAvatarButton";
            this.addAvatarButton.Size = new System.Drawing.Size(75, 23);
            this.addAvatarButton.TabIndex = 9;
            this.addAvatarButton.Text = "Изменить";
            this.addAvatarButton.UseVisualStyleBackColor = true;
            this.addAvatarButton.Click += new System.EventHandler(this.addAvatarButton_Click);
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(13, 19);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(90, 90);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePictureBox.TabIndex = 8;
            this.imagePictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 50);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(6, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(216, 20);
            this.nameTextBox.TabIndex = 9;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(167, 415);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(73, 23);
            this.confirmButton.TabIndex = 15;
            this.confirmButton.Text = "Сохранить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 415);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 23);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(6, 19);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(216, 20);
            this.addressTextBox.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addressTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 50);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Адрес";
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(109, 87);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(113, 27);
            this.errorLabel.TabIndex = 12;
            // 
            // EditProfilePlatformForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.backButton);
            this.Name = "EditProfilePlatformForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Прототип";
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button removeAvatarButton;
        private System.Windows.Forms.Button addAvatarButton;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label errorLabel;
    }
}