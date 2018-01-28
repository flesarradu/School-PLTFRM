namespace Biologie
{
    partial class VizualizareRezultate
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
            this.components = new System.ComponentModel.Container();
            this._Database_EFBioDataSet = new Biologie._Database_EFBioDataSet();
            this.databaseEFBioDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._Database_EFBioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseEFBioDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _Database_EFBioDataSet
            // 
            this._Database_EFBioDataSet.DataSetName = "_Database_EFBioDataSet";
            this._Database_EFBioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // databaseEFBioDataSetBindingSource
            // 
            this.databaseEFBioDataSetBindingSource.DataSource = this._Database_EFBioDataSet;
            this.databaseEFBioDataSetBindingSource.Position = 0;
            // 
            // VizualizareRezultate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 754);
            this.Name = "VizualizareRezultate";
            this.Text = "VizualizareRezultate";
            ((System.ComponentModel.ISupportInitialize)(this._Database_EFBioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseEFBioDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private _Database_EFBioDataSet _Database_EFBioDataSet;
        private System.Windows.Forms.BindingSource databaseEFBioDataSetBindingSource;
    }
}