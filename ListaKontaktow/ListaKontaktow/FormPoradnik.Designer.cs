namespace ListaKontaktow
{
    partial class FormPoradnik
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.rtbPoradnik = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbPoradnik
            // 
            this.rtbPoradnik.Location = new System.Drawing.Point(15, 15);
            this.rtbPoradnik.Name = "rtbPoradnik";
            this.rtbPoradnik.ReadOnly = true;
            this.rtbPoradnik.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbPoradnik.Size = new System.Drawing.Size(480, 360);
            this.rtbPoradnik.TabIndex = 0;
            this.rtbPoradnik.Text = "";
            this.rtbPoradnik.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbPoradnik.BackColor = System.Drawing.Color.FromArgb(250, 248, 240);
            this.rtbPoradnik.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.rtbPoradnik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPoradnik.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            // 
            // FormPoradnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 390);
            this.Controls.Add(this.rtbPoradnik);
            this.Name = "FormPoradnik";
            this.Text = "Numeracja międzynarodowa";
            this.MinimumSize = new System.Drawing.Size(530, 430);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbPoradnik;
    }
}
