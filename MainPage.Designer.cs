namespace PickingTheStones
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.pbstn = new System.Windows.Forms.PictureBox();
            this.pbwall = new System.Windows.Forms.PictureBox();
            this.pbgstn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbstn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbwall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbgstn)).BeginInit();
            this.SuspendLayout();
            // 
            // pbstn
            // 
            this.pbstn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbstn.BackgroundImage")));
            this.pbstn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbstn.Image = ((System.Drawing.Image)(resources.GetObject("pbstn.Image")));
            this.pbstn.Location = new System.Drawing.Point(586, 39);
            this.pbstn.Name = "pbstn";
            this.pbstn.Size = new System.Drawing.Size(100, 50);
            this.pbstn.TabIndex = 0;
            this.pbstn.TabStop = false;
            this.pbstn.Visible = false;
            // 
            // pbwall
            // 
            this.pbwall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbwall.BackgroundImage")));
            this.pbwall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbwall.Location = new System.Drawing.Point(586, 151);
            this.pbwall.Name = "pbwall";
            this.pbwall.Size = new System.Drawing.Size(100, 50);
            this.pbwall.TabIndex = 1;
            this.pbwall.TabStop = false;
            this.pbwall.Visible = false;
            // 
            // pbgstn
            // 
            this.pbgstn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbgstn.BackgroundImage")));
            this.pbgstn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbgstn.Location = new System.Drawing.Point(586, 95);
            this.pbgstn.Name = "pbgstn";
            this.pbgstn.Size = new System.Drawing.Size(100, 50);
            this.pbgstn.TabIndex = 2;
            this.pbgstn.TabStop = false;
            this.pbgstn.Visible = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 536);
            this.Controls.Add(this.pbgstn);
            this.Controls.Add(this.pbwall);
            this.Controls.Add(this.pbstn);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbstn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbwall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbgstn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbstn;
        public System.Windows.Forms.PictureBox pbwall;
        public System.Windows.Forms.PictureBox pbgstn;
    }
}