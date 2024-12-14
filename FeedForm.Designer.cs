namespace Prototype
{
    partial class FeedForm
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
            this.feedButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.feedListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // feedButton
            // 
            this.feedButton.Enabled = false;
            this.feedButton.Location = new System.Drawing.Point(12, 415);
            this.feedButton.Name = "feedButton";
            this.feedButton.Size = new System.Drawing.Size(106, 23);
            this.feedButton.TabIndex = 0;
            this.feedButton.Text = "Лента";
            this.feedButton.UseVisualStyleBackColor = true;
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(134, 415);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(106, 23);
            this.profileButton.TabIndex = 1;
            this.profileButton.Text = "Профиль";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // feedListView
            // 
            this.feedListView.HideSelection = false;
            this.feedListView.Location = new System.Drawing.Point(12, 12);
            this.feedListView.Name = "feedListView";
            this.feedListView.Size = new System.Drawing.Size(228, 388);
            this.feedListView.TabIndex = 2;
            this.feedListView.UseCompatibleStateImageBehavior = false;
            this.feedListView.ItemActivate += new System.EventHandler(this.feedListView_ItemActivate);
            // 
            // FeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.feedListView);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.feedButton);
            this.Name = "FeedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Прототип";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FeedForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button feedButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.ListView feedListView;
    }
}