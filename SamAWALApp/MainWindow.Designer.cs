namespace SamAWALApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.recordingRightsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distributedAmountDataGrid = new System.Windows.Forms.DataGridView();
            this.iSRCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackTitleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackSubtitleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distributedAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackBundle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distributedAmountClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelFilename = new System.Windows.Forms.Label();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnExportSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.runningTotalBoxBundles = new System.Windows.Forms.Panel();
            this.runningTotalBoxTracks = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.recordingRightsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributedAmountDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributedAmountClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnOpenFile.FlatAppearance.BorderSize = 2;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(104, 35);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open .csv File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // recordingRightsBindingSource
            // 
            this.recordingRightsBindingSource.DataSource = typeof(SamAWALApp.Form1.RecordingRights);
            // 
            // distributedAmountDataGrid
            // 
            this.distributedAmountDataGrid.AllowUserToAddRows = false;
            this.distributedAmountDataGrid.AutoGenerateColumns = false;
            this.distributedAmountDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.distributedAmountDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.distributedAmountDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iSRCDataGridViewTextBoxColumn,
            this.TrackArtist,
            this.trackTitleDataGridViewTextBoxColumn1,
            this.trackSubtitleDataGridViewTextBoxColumn1,
            this.distributedAmountDataGridViewTextBoxColumn1,
            this.Label,
            this.TrackBundle});
            this.distributedAmountDataGrid.DataSource = this.distributedAmountClassBindingSource;
            this.distributedAmountDataGrid.GridColor = System.Drawing.Color.SteelBlue;
            this.distributedAmountDataGrid.Location = new System.Drawing.Point(13, 53);
            this.distributedAmountDataGrid.Name = "distributedAmountDataGrid";
            this.distributedAmountDataGrid.ReadOnly = true;
            this.distributedAmountDataGrid.Size = new System.Drawing.Size(794, 294);
            this.distributedAmountDataGrid.TabIndex = 2;
            // 
            // iSRCDataGridViewTextBoxColumn
            // 
            this.iSRCDataGridViewTextBoxColumn.DataPropertyName = "ISRC";
            this.iSRCDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iSRCDataGridViewTextBoxColumn.Name = "iSRCDataGridViewTextBoxColumn";
            this.iSRCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TrackArtist
            // 
            this.TrackArtist.DataPropertyName = "TrackArtist";
            this.TrackArtist.HeaderText = "Artist";
            this.TrackArtist.Name = "TrackArtist";
            this.TrackArtist.ReadOnly = true;
            // 
            // trackTitleDataGridViewTextBoxColumn1
            // 
            this.trackTitleDataGridViewTextBoxColumn1.DataPropertyName = "TrackTitle";
            this.trackTitleDataGridViewTextBoxColumn1.HeaderText = "Title";
            this.trackTitleDataGridViewTextBoxColumn1.Name = "trackTitleDataGridViewTextBoxColumn1";
            this.trackTitleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // trackSubtitleDataGridViewTextBoxColumn1
            // 
            this.trackSubtitleDataGridViewTextBoxColumn1.DataPropertyName = "TrackSubtitle";
            this.trackSubtitleDataGridViewTextBoxColumn1.HeaderText = "Subtitle";
            this.trackSubtitleDataGridViewTextBoxColumn1.Name = "trackSubtitleDataGridViewTextBoxColumn1";
            this.trackSubtitleDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // distributedAmountDataGridViewTextBoxColumn1
            // 
            this.distributedAmountDataGridViewTextBoxColumn1.DataPropertyName = "DistributedAmount";
            this.distributedAmountDataGridViewTextBoxColumn1.HeaderText = "Distributed Amount";
            this.distributedAmountDataGridViewTextBoxColumn1.Name = "distributedAmountDataGridViewTextBoxColumn1";
            this.distributedAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            this.distributedAmountDataGridViewTextBoxColumn1.Width = 130;
            // 
            // Label
            // 
            this.Label.DataPropertyName = "Label";
            this.Label.HeaderText = "Label";
            this.Label.Name = "Label";
            this.Label.ReadOnly = true;
            // 
            // TrackBundle
            // 
            this.TrackBundle.DataPropertyName = "TrackBundle";
            this.TrackBundle.HeaderText = "Track / Bundle";
            this.TrackBundle.Name = "TrackBundle";
            this.TrackBundle.ReadOnly = true;
            this.TrackBundle.Width = 120;
            // 
            // distributedAmountClassBindingSource
            // 
            this.distributedAmountClassBindingSource.DataSource = typeof(SamAWALApp.Form1.DistributedAmountClass);
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.labelFilename.Location = new System.Drawing.Point(122, 23);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(0, 13);
            this.labelFilename.TabIndex = 3;
            this.labelFilename.Visible = false;
            // 
            // btnPDF
            // 
            this.btnPDF.Enabled = false;
            this.btnPDF.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnPDF.FlatAppearance.BorderSize = 2;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Location = new System.Drawing.Point(702, 12);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(104, 35);
            this.btnPDF.TabIndex = 0;
            this.btnPDF.Text = "Export All";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnExportSelected
            // 
            this.btnExportSelected.Enabled = false;
            this.btnExportSelected.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnExportSelected.FlatAppearance.BorderSize = 2;
            this.btnExportSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSelected.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportSelected.Location = new System.Drawing.Point(592, 12);
            this.btnExportSelected.Name = "btnExportSelected";
            this.btnExportSelected.Size = new System.Drawing.Size(104, 35);
            this.btnExportSelected.TabIndex = 0;
            this.btnExportSelected.Text = "Export Selected";
            this.btnExportSelected.UseVisualStyleBackColor = true;
            this.btnExportSelected.Click += new System.EventHandler(this.btnExportSelected_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tracks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(426, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bundles";
            // 
            // runningTotalBoxBundles
            // 
            this.runningTotalBoxBundles.AutoSize = true;
            this.runningTotalBoxBundles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.runningTotalBoxBundles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.runningTotalBoxBundles.Location = new System.Drawing.Point(430, 369);
            this.runningTotalBoxBundles.MaximumSize = new System.Drawing.Size(377, 150);
            this.runningTotalBoxBundles.MinimumSize = new System.Drawing.Size(377, 47);
            this.runningTotalBoxBundles.Name = "runningTotalBoxBundles";
            this.runningTotalBoxBundles.Size = new System.Drawing.Size(377, 47);
            this.runningTotalBoxBundles.TabIndex = 7;
            // 
            // runningTotalBoxTracks
            // 
            this.runningTotalBoxTracks.AutoSize = true;
            this.runningTotalBoxTracks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.runningTotalBoxTracks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.runningTotalBoxTracks.Location = new System.Drawing.Point(15, 369);
            this.runningTotalBoxTracks.MaximumSize = new System.Drawing.Size(408, 150);
            this.runningTotalBoxTracks.MinimumSize = new System.Drawing.Size(408, 47);
            this.runningTotalBoxTracks.Name = "runningTotalBoxTracks";
            this.runningTotalBoxTracks.Size = new System.Drawing.Size(408, 47);
            this.runningTotalBoxTracks.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(824, 428);
            this.Controls.Add(this.runningTotalBoxTracks);
            this.Controls.Add(this.runningTotalBoxBundles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFilename);
            this.Controls.Add(this.distributedAmountDataGrid);
            this.Controls.Add(this.btnExportSelected);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Recording Rights Export";
            ((System.ComponentModel.ISupportInitialize)(this.recordingRightsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributedAmountDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributedAmountClassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.BindingSource recordingRightsBindingSource;
        private System.Windows.Forms.DataGridView distributedAmountDataGrid;
        private System.Windows.Forms.BindingSource distributedAmountClassBindingSource;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSRCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackTitleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackSubtitleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn distributedAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackBundle;
        private System.Windows.Forms.Button btnExportSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel runningTotalBoxBundles;
        private System.Windows.Forms.Panel runningTotalBoxTracks;
    }
}

