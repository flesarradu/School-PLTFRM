namespace Biologie
{
    partial class Testare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Testare));
            this.labelCerinta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCerinta
            // 
            this.labelCerinta.AutoSize = true;
            this.labelCerinta.Location = new System.Drawing.Point(98, 46);
            this.labelCerinta.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelCerinta.Name = "labelCerinta";
            this.labelCerinta.Size = new System.Drawing.Size(174, 54);
            this.labelCerinta.TabIndex = 0;
            this.labelCerinta.Text = "Cerinta";
            // 
            // Testare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(27F, 54F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1804, 941);
            this.Controls.Add(this.labelCerinta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.Name = "Testare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testare";
            this.Load += new System.EventHandler(this.Testare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCerinta;
    }
}