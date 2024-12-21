using Prototype.classes;

namespace Prototype
{
    partial class EditEventForm
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.removeAvatarButton = new System.Windows.Forms.Button();
            this.addAvatarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.seatsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.editEventTabControl = new System.Windows.Forms.TabControl();
            this.editEventTabPage1 = new System.Windows.Forms.TabPage();
            this.editEventTabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.genreCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seatsNumericUpDown)).BeginInit();
            this.editEventTabControl.SuspendLayout();
            this.editEventTabPage1.SuspendLayout();
            this.editEventTabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dateTimePicker);
            this.groupBox5.Location = new System.Drawing.Point(9, 189);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(228, 50);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Дата и время";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Checked = false;
            this.dateTimePicker.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(7, 20);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.errorLabel);
            this.groupBox3.Controls.Add(this.removeAvatarButton);
            this.groupBox3.Controls.Add(this.addAvatarButton);
            this.groupBox3.Controls.Add(this.imagePictureBox);
            this.groupBox3.Location = new System.Drawing.Point(9, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 121);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фото";
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(109, 87);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(113, 27);
            this.errorLabel.TabIndex = 11;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
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
            this.confirmButton.Location = new System.Drawing.Point(168, 415);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(73, 23);
            this.confirmButton.TabIndex = 15;
            this.confirmButton.Text = "Сохранить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(13, 415);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 23);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.Location = new System.Drawing.Point(67, 415);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(75, 23);
            this.deleteEventButton.TabIndex = 22;
            this.deleteEventButton.Text = "Удалить";
            this.deleteEventButton.UseVisualStyleBackColor = true;
            this.deleteEventButton.Click += new System.EventHandler(this.deleteEventButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.seatsNumericUpDown);
            this.groupBox4.Location = new System.Drawing.Point(9, 245);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 50);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Количество мест";
            // 
            // seatsNumericUpDown
            // 
            this.seatsNumericUpDown.Location = new System.Drawing.Point(7, 20);
            this.seatsNumericUpDown.Name = "seatsNumericUpDown";
            this.seatsNumericUpDown.Size = new System.Drawing.Size(215, 20);
            this.seatsNumericUpDown.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // editEventTabControl
            // 
            this.editEventTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.editEventTabControl.Controls.Add(this.editEventTabPage1);
            this.editEventTabControl.Controls.Add(this.editEventTabPage2);
            this.editEventTabControl.ItemSize = new System.Drawing.Size(125, 18);
            this.editEventTabControl.Location = new System.Drawing.Point(-1, 0);
            this.editEventTabControl.Name = "editEventTabControl";
            this.editEventTabControl.SelectedIndex = 0;
            this.editEventTabControl.Size = new System.Drawing.Size(254, 409);
            this.editEventTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.editEventTabControl.TabIndex = 23;
            // 
            // editEventTabPage1
            // 
            this.editEventTabPage1.Controls.Add(this.groupBox1);
            this.editEventTabPage1.Controls.Add(this.groupBox4);
            this.editEventTabPage1.Controls.Add(this.groupBox3);
            this.editEventTabPage1.Controls.Add(this.groupBox5);
            this.editEventTabPage1.Location = new System.Drawing.Point(4, 4);
            this.editEventTabPage1.Name = "editEventTabPage1";
            this.editEventTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.editEventTabPage1.Size = new System.Drawing.Size(246, 383);
            this.editEventTabPage1.TabIndex = 0;
            this.editEventTabPage1.Text = "Основное";
            this.editEventTabPage1.UseVisualStyleBackColor = true;
            // 
            // editEventTabPage2
            // 
            this.editEventTabPage2.Controls.Add(this.groupBox7);
            this.editEventTabPage2.Controls.Add(this.groupBox8);
            this.editEventTabPage2.Location = new System.Drawing.Point(4, 4);
            this.editEventTabPage2.Name = "editEventTabPage2";
            this.editEventTabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.editEventTabPage2.Size = new System.Drawing.Size(246, 383);
            this.editEventTabPage2.TabIndex = 1;
            this.editEventTabPage2.Text = "Жанры и описание";
            this.editEventTabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.genreCheckedListBox);
            this.groupBox7.Location = new System.Drawing.Point(9, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(228, 135);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Жанры";
            // 
            // genreCheckedListBox
            // 
            this.genreCheckedListBox.FormattingEnabled = true;
            this.genreCheckedListBox.Location = new System.Drawing.Point(6, 19);
            this.genreCheckedListBox.Name = "genreCheckedListBox";
            this.genreCheckedListBox.Size = new System.Drawing.Size(216, 109);
            this.genreCheckedListBox.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.descriptionRichTextBox);
            this.groupBox8.Location = new System.Drawing.Point(9, 147);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(228, 230);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Описание";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(216, 205);
            this.descriptionRichTextBox.TabIndex = 0;
            this.descriptionRichTextBox.Text = "";
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
            // EditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.editEventTabControl);
            this.Controls.Add(this.deleteEventButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.backButton);
            this.Name = "EditEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.EditEventForm_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seatsNumericUpDown)).EndInit();
            this.editEventTabControl.ResumeLayout(false);
            this.editEventTabPage1.ResumeLayout(false);
            this.editEventTabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button removeAvatarButton;
        private System.Windows.Forms.Button addAvatarButton;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button deleteEventButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown seatsNumericUpDown;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl editEventTabControl;
        private System.Windows.Forms.TabPage editEventTabPage1;
        private System.Windows.Forms.TabPage editEventTabPage2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.CheckedListBox genreCheckedListBox;
        private System.Windows.Forms.Label errorLabel;
    }
}