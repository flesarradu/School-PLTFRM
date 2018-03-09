﻿namespace Biologie
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rezultatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rezultateBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dB_A36E0C_flesarraduDataSet = new Biologie.DB_A36E0C_flesarraduDataSet();
            this.rezultateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Database_EFBioDataSet = new Biologie._Database_EFBioDataSet();
            this.testeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testeTableAdapter = new Biologie._Database_EFBioDataSetTableAdapters.testeTableAdapter();
            this.rezultateTableAdapter = new Biologie._Database_EFBioDataSetTableAdapters.rezultateTableAdapter();
            this.rezultateTableAdapter1 = new Biologie.DB_A36E0C_flesarraduDataSetTableAdapters.rezultateTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezultateBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_A36E0C_flesarraduDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezultateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Database_EFBioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(200)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userDataGridViewTextBoxColumn,
            this.rezultatDataGridViewTextBoxColumn,
            this.testDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.rezultateBindingSource1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(925, 723);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userDataGridViewTextBoxColumn.DataPropertyName = "user";
            this.userDataGridViewTextBoxColumn.HeaderText = "Utilizator";
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rezultatDataGridViewTextBoxColumn
            // 
            this.rezultatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rezultatDataGridViewTextBoxColumn.DataPropertyName = "rezultat";
            this.rezultatDataGridViewTextBoxColumn.HeaderText = "Rezultat";
            this.rezultatDataGridViewTextBoxColumn.Name = "rezultatDataGridViewTextBoxColumn";
            this.rezultatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testDataGridViewTextBoxColumn
            // 
            this.testDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.testDataGridViewTextBoxColumn.DataPropertyName = "test";
            this.testDataGridViewTextBoxColumn.HeaderText = "Testul";
            this.testDataGridViewTextBoxColumn.Name = "testDataGridViewTextBoxColumn";
            this.testDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rezultateBindingSource1
            // 
            this.rezultateBindingSource1.DataMember = "rezultate";
            this.rezultateBindingSource1.DataSource = this.dB_A36E0C_flesarraduDataSet;
            // 
            // dB_A36E0C_flesarraduDataSet
            // 
            this.dB_A36E0C_flesarraduDataSet.DataSetName = "DB_A36E0C_flesarraduDataSet";
            this.dB_A36E0C_flesarraduDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rezultateBindingSource
            // 
            this.rezultateBindingSource.DataMember = "rezultate";
            this.rezultateBindingSource.DataSource = this._Database_EFBioDataSet;
            // 
            // _Database_EFBioDataSet
            // 
            this._Database_EFBioDataSet.DataSetName = "_Database_EFBioDataSet";
            this._Database_EFBioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testeBindingSource
            // 
            this.testeBindingSource.DataMember = "teste";
            this.testeBindingSource.DataSource = this._Database_EFBioDataSet;
            // 
            // testeTableAdapter
            // 
            this.testeTableAdapter.ClearBeforeFill = true;
            // 
            // rezultateTableAdapter
            // 
            this.rezultateTableAdapter.ClearBeforeFill = true;
            // 
            // rezultateTableAdapter1
            // 
            this.rezultateTableAdapter1.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 34);
            this.panel1.TabIndex = 1;
            // 
            // VizualizareRezultate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "VizualizareRezultate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VizualizareRezultate";
            this.Load += new System.EventHandler(this.VizualizareRezultate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezultateBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_A36E0C_flesarraduDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezultateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Database_EFBioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private _Database_EFBioDataSet _Database_EFBioDataSet;
        private System.Windows.Forms.BindingSource testeBindingSource;
        private _Database_EFBioDataSetTableAdapters.testeTableAdapter testeTableAdapter;
        private System.Windows.Forms.BindingSource rezultateBindingSource;
        private _Database_EFBioDataSetTableAdapters.rezultateTableAdapter rezultateTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rezultatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testDataGridViewTextBoxColumn;
        private DB_A36E0C_flesarraduDataSet dB_A36E0C_flesarraduDataSet;
        private System.Windows.Forms.BindingSource rezultateBindingSource1;
        private DB_A36E0C_flesarraduDataSetTableAdapters.rezultateTableAdapter rezultateTableAdapter1;
        private System.Windows.Forms.Panel panel1;
    }
}