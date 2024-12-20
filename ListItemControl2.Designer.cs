namespace Prototype
{
    partial class ListItemControl2
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
            this.artistLinkLabel = new System.Windows.Forms.LinkLabel();
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
            this.readedButton.Location = new System.Drawing.Point(172, 9);
            this.readedButton.Name = "readedButton";
            this.readedButton.Size = new System.Drawing.Size(22, 20);
            this.readedButton.TabIndex = 2;
            this.readedButton.Text = "button1";
            this.readedButton.UseVisualStyleBackColor = true;
            // 
            // artistLinkLabel
            // 
            this.artistLinkLabel.AutoEllipsis = true;
            this.artistLinkLabel.Location = new System.Drawing.Point(3, 37);
            this.artistLinkLabel.Name = "artistLinkLabel";
            this.artistLinkLabel.Size = new System.Drawing.Size(169, 17);
            this.artistLinkLabel.TabIndex = 3;
            this.artistLinkLabel.TabStop = true;
            this.artistLinkLabel.Text = "linkLabel1";
            // 
            // ListItemControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.artistLinkLabel);
            this.Controls.Add(this.readedButton);
            this.Controls.Add(this.eventLinkLabel);
            this.Controls.Add(this.textLabel);
            this.Name = "ListItemControl2";
            this.Size = new System.Drawing.Size(200, 54);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.LinkLabel eventLinkLabel;
        private System.Windows.Forms.Button readedButton;
        private System.Windows.Forms.LinkLabel artistLinkLabel;
    }
}
