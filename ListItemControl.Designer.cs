﻿namespace Prototype
{
    partial class ListItemControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textLabel = new System.Windows.Forms.Label();
            this.eventLinkLabel = new System.Windows.Forms.LinkLabel();
            this.readedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(4, 3);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(168, 17);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "textLabel";
            // 
            // eventLinkLabel
            // 
            this.eventLinkLabel.AutoEllipsis = true;
            this.eventLinkLabel.Location = new System.Drawing.Point(3, 20);
            this.eventLinkLabel.Name = "eventLinkLabel";
            this.eventLinkLabel.Size = new System.Drawing.Size(169, 17);
            this.eventLinkLabel.TabIndex = 1;
            this.eventLinkLabel.TabStop = true;
            this.eventLinkLabel.Text = "linkLabel1";
            // 
            // readedButton
            // 
            this.readedButton.BackColor = System.Drawing.SystemColors.Control;
            this.readedButton.BackgroundImage = global::Prototype.Properties.Resources.icon;
            this.readedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.readedButton.Location = new System.Drawing.Point(172, 9);
            this.readedButton.Margin = new System.Windows.Forms.Padding(0);
            this.readedButton.Name = "readedButton";
            this.readedButton.Size = new System.Drawing.Size(22, 20);
            this.readedButton.TabIndex = 2;
            this.readedButton.UseVisualStyleBackColor = false;
            // 
            // ListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.readedButton);
            this.Controls.Add(this.eventLinkLabel);
            this.Controls.Add(this.textLabel);
            this.Name = "ListItemControl";
            this.Size = new System.Drawing.Size(200, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.LinkLabel eventLinkLabel;
        private System.Windows.Forms.Button readedButton;
    }
}
