namespace PickingTheStones
{
    partial class log
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSingle = new System.Windows.Forms.Button();
            this.btnMultiple = new System.Windows.Forms.Button();
            this.cbxDama = new System.Windows.Forms.ComboBox();
            this.cbxDif = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSingle
            // 
            this.btnSingle.Location = new System.Drawing.Point(41, 115);
            this.btnSingle.Name = "btnSingle";
            this.btnSingle.Size = new System.Drawing.Size(118, 23);
            this.btnSingle.TabIndex = 0;
            this.btnSingle.Text = "Single Player";
            this.btnSingle.UseVisualStyleBackColor = true;
            this.btnSingle.Click += new System.EventHandler(this.btnSingle_Click);
            // 
            // btnMultiple
            // 
            this.btnMultiple.Enabled = false;
            this.btnMultiple.Location = new System.Drawing.Point(183, 115);
            this.btnMultiple.Name = "btnMultiple";
            this.btnMultiple.Size = new System.Drawing.Size(141, 23);
            this.btnMultiple.TabIndex = 1;
            this.btnMultiple.Text = "Multiple";
            this.btnMultiple.UseVisualStyleBackColor = true;
            // 
            // cbxDama
            // 
            this.cbxDama.FormattingEnabled = true;
            this.cbxDama.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10"});
            this.cbxDama.Location = new System.Drawing.Point(115, 67);
            this.cbxDama.Name = "cbxDama";
            this.cbxDama.Size = new System.Drawing.Size(121, 21);
            this.cbxDama.TabIndex = 2;
            // 
            // cbxDif
            // 
            this.cbxDif.FormattingEnabled = true;
            this.cbxDif.Items.AddRange(new object[] {
            "Easy",
            "Middle",
            "Hard"});
            this.cbxDif.Location = new System.Drawing.Point(115, 29);
            this.cbxDif.Name = "cbxDif";
            this.cbxDif.Size = new System.Drawing.Size(121, 21);
            this.cbxDif.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Difficulity";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X-X";
            // 
            // log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(350, 190);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxDif);
            this.Controls.Add(this.cbxDama);
            this.Controls.Add(this.btnMultiple);
            this.Controls.Add(this.btnSingle);
            this.Name = "log";
            this.Text = "PickingTheStone";
            this.Load += new System.EventHandler(this.log_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSingle;
        private System.Windows.Forms.Button btnMultiple;
        private System.Windows.Forms.ComboBox cbxDama;
        private System.Windows.Forms.ComboBox cbxDif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

