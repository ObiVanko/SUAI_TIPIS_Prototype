namespace Prototype
{
    partial class ArtistsFeedForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.inviteButton = new System.Windows.Forms.Button();
            this.artistsListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(5, 420);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 23);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // inviteButton
            // 
            this.inviteButton.Location = new System.Drawing.Point(155, 420);
            this.inviteButton.Name = "inviteButton";
            this.inviteButton.Size = new System.Drawing.Size(90, 23);
            this.inviteButton.TabIndex = 16;
            this.inviteButton.Text = "Пригласить";
            this.inviteButton.UseVisualStyleBackColor = true;
            this.inviteButton.Click += new System.EventHandler(this.inviteButton_Click);
            // 
            // artistsListView
            // 
            this.artistsListView.HideSelection = false;
            this.artistsListView.Location = new System.Drawing.Point(5, 6);
            this.artistsListView.Name = "artistsListView";
            this.artistsListView.Size = new System.Drawing.Size(240, 408);
            this.artistsListView.TabIndex = 17;
            this.artistsListView.UseCompatibleStateImageBehavior = false;
            // 
            // ArtistsFeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 450);
            this.Controls.Add(this.artistsListView);
            this.Controls.Add(this.inviteButton);
            this.Controls.Add(this.backButton);
            this.Name = "ArtistsFeedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button inviteButton;
        private System.Windows.Forms.ListView artistsListView;
    }
}