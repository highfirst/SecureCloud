namespace SecureCloud
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.upload = new System.Windows.Forms.TabPage();
            this.threshold = new System.Windows.Forms.NumericUpDown();
            this.buttonCancelUpload = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.uploadState = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inFileBrowse = new System.Windows.Forms.Button();
            this.inFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.localPathBrowse = new System.Windows.Forms.Button();
            this.localPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkLocal = new System.Windows.Forms.CheckBox();
            this.checkOneDrive = new System.Windows.Forms.CheckBox();
            this.checkMega = new System.Windows.Forms.CheckBox();
            this.checkCopy = new System.Windows.Forms.CheckBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.checkDropbox = new System.Windows.Forms.CheckBox();
            this.download = new System.Windows.Forms.TabPage();
            this.outPathBrowseButton = new System.Windows.Forms.Button();
            this.outPath = new System.Windows.Forms.TextBox();
            this.outputPath = new System.Windows.Forms.Label();
            this.downloadState = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelDownloadButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.fileViewer = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.n = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dropbox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.box = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onedrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manageAccount = new System.Windows.Forms.TabPage();
            this.accountRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.accountAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.accountName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.onedriveState = new System.Windows.Forms.PictureBox();
            this.megaState = new System.Windows.Forms.PictureBox();
            this.copyState = new System.Windows.Forms.PictureBox();
            this.boxState = new System.Windows.Forms.PictureBox();
            this.dropboxState = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyImg = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dropboxImg = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxImg = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.megaImg = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.onedriveImg = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.upload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threshold)).BeginInit();
            this.download.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileViewer)).BeginInit();
            this.manageAccount.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.onedriveState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.megaState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropboxState)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropboxImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.megaImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onedriveImg)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.upload);
            this.tabControl1.Controls.Add(this.download);
            this.tabControl1.Controls.Add(this.manageAccount);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(657, 446);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // upload
            // 
            this.upload.Controls.Add(this.threshold);
            this.upload.Controls.Add(this.buttonCancelUpload);
            this.upload.Controls.Add(this.buttonUpload);
            this.upload.Controls.Add(this.uploadState);
            this.upload.Controls.Add(this.label4);
            this.upload.Controls.Add(this.inFileBrowse);
            this.upload.Controls.Add(this.inFilePath);
            this.upload.Controls.Add(this.label3);
            this.upload.Controls.Add(this.label2);
            this.upload.Controls.Add(this.localPathBrowse);
            this.upload.Controls.Add(this.localPath);
            this.upload.Controls.Add(this.label1);
            this.upload.Controls.Add(this.checkLocal);
            this.upload.Controls.Add(this.checkOneDrive);
            this.upload.Controls.Add(this.checkMega);
            this.upload.Controls.Add(this.checkCopy);
            this.upload.Controls.Add(this.checkBox);
            this.upload.Controls.Add(this.checkDropbox);
            this.upload.Location = new System.Drawing.Point(4, 22);
            this.upload.Name = "upload";
            this.upload.Padding = new System.Windows.Forms.Padding(3);
            this.upload.Size = new System.Drawing.Size(649, 420);
            this.upload.TabIndex = 1;
            this.upload.Text = "Upload";
            this.upload.UseVisualStyleBackColor = true;
            // 
            // threshold
            // 
            this.threshold.Location = new System.Drawing.Point(117, 117);
            this.threshold.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.threshold.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.threshold.Name = "threshold";
            this.threshold.Size = new System.Drawing.Size(54, 20);
            this.threshold.TabIndex = 18;
            this.threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.threshold.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.threshold.ValueChanged += new System.EventHandler(this.threshold_ValueChanged);
            // 
            // buttonCancelUpload
            // 
            this.buttonCancelUpload.Location = new System.Drawing.Point(428, 368);
            this.buttonCancelUpload.Name = "buttonCancelUpload";
            this.buttonCancelUpload.Size = new System.Drawing.Size(75, 26);
            this.buttonCancelUpload.TabIndex = 17;
            this.buttonCancelUpload.Text = "Cancel";
            this.buttonCancelUpload.UseVisualStyleBackColor = true;
            this.buttonCancelUpload.Click += new System.EventHandler(this.buttonCancelUpload_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(313, 368);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 26);
            this.buttonUpload.TabIndex = 16;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // uploadState
            // 
            this.uploadState.BackColor = System.Drawing.SystemColors.Control;
            this.uploadState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uploadState.Location = new System.Drawing.Point(24, 226);
            this.uploadState.Name = "uploadState";
            this.uploadState.ReadOnly = true;
            this.uploadState.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.uploadState.Size = new System.Drawing.Size(601, 122);
            this.uploadState.TabIndex = 15;
            this.uploadState.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "State :";
            // 
            // inFileBrowse
            // 
            this.inFileBrowse.Location = new System.Drawing.Point(478, 158);
            this.inFileBrowse.Name = "inFileBrowse";
            this.inFileBrowse.Size = new System.Drawing.Size(81, 25);
            this.inFileBrowse.TabIndex = 13;
            this.inFileBrowse.Text = "Browse...";
            this.inFileBrowse.UseVisualStyleBackColor = true;
            this.inFileBrowse.Click += new System.EventHandler(this.inFileBrowse_Click);
            // 
            // inFilePath
            // 
            this.inFilePath.Location = new System.Drawing.Point(93, 161);
            this.inFilePath.Name = "inFilePath";
            this.inFilePath.Size = new System.Drawing.Size(363, 20);
            this.inFilePath.TabIndex = 12;
            this.inFilePath.Text = "e:\\test\\test.txt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Input File :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Threshold Value :";
            // 
            // localPathBrowse
            // 
            this.localPathBrowse.Enabled = false;
            this.localPathBrowse.Location = new System.Drawing.Point(478, 68);
            this.localPathBrowse.Name = "localPathBrowse";
            this.localPathBrowse.Size = new System.Drawing.Size(81, 25);
            this.localPathBrowse.TabIndex = 8;
            this.localPathBrowse.Text = "Browse...";
            this.localPathBrowse.UseVisualStyleBackColor = true;
            this.localPathBrowse.Click += new System.EventHandler(this.localPathBrowse_Click);
            // 
            // localPath
            // 
            this.localPath.Enabled = false;
            this.localPath.Location = new System.Drawing.Point(93, 71);
            this.localPath.Name = "localPath";
            this.localPath.Size = new System.Drawing.Size(363, 20);
            this.localPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Local Path : ";
            // 
            // checkLocal
            // 
            this.checkLocal.AutoSize = true;
            this.checkLocal.Location = new System.Drawing.Point(24, 26);
            this.checkLocal.Name = "checkLocal";
            this.checkLocal.Size = new System.Drawing.Size(52, 17);
            this.checkLocal.TabIndex = 5;
            this.checkLocal.Text = "Local";
            this.checkLocal.UseVisualStyleBackColor = true;
            this.checkLocal.CheckedChanged += new System.EventHandler(this.checkLocal_CheckedChanged);
            // 
            // checkOneDrive
            // 
            this.checkOneDrive.AutoSize = true;
            this.checkOneDrive.Location = new System.Drawing.Point(435, 26);
            this.checkOneDrive.Name = "checkOneDrive";
            this.checkOneDrive.Size = new System.Drawing.Size(71, 17);
            this.checkOneDrive.TabIndex = 4;
            this.checkOneDrive.Text = "OneDrive";
            this.checkOneDrive.UseVisualStyleBackColor = true;
            this.checkOneDrive.CheckedChanged += new System.EventHandler(this.checkOneDrive_CheckedChanged);
            // 
            // checkMega
            // 
            this.checkMega.AutoSize = true;
            this.checkMega.Location = new System.Drawing.Point(351, 26);
            this.checkMega.Name = "checkMega";
            this.checkMega.Size = new System.Drawing.Size(53, 17);
            this.checkMega.TabIndex = 3;
            this.checkMega.Text = "Mega";
            this.checkMega.UseVisualStyleBackColor = true;
            this.checkMega.CheckedChanged += new System.EventHandler(this.checkMega_CheckedChanged);
            // 
            // checkCopy
            // 
            this.checkCopy.AutoSize = true;
            this.checkCopy.Location = new System.Drawing.Point(273, 26);
            this.checkCopy.Name = "checkCopy";
            this.checkCopy.Size = new System.Drawing.Size(50, 17);
            this.checkCopy.TabIndex = 2;
            this.checkCopy.Text = "Copy";
            this.checkCopy.UseVisualStyleBackColor = true;
            this.checkCopy.CheckedChanged += new System.EventHandler(this.checkCopy_CheckedChanged);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(201, 26);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(44, 17);
            this.checkBox.TabIndex = 1;
            this.checkBox.Text = "Box";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkDropbox
            // 
            this.checkDropbox.AutoSize = true;
            this.checkDropbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkDropbox.Location = new System.Drawing.Point(105, 26);
            this.checkDropbox.Name = "checkDropbox";
            this.checkDropbox.Size = new System.Drawing.Size(66, 17);
            this.checkDropbox.TabIndex = 0;
            this.checkDropbox.Text = "Dropbox";
            this.checkDropbox.UseVisualStyleBackColor = true;
            this.checkDropbox.CheckedChanged += new System.EventHandler(this.checkDropbox_CheckedChanged);
            // 
            // download
            // 
            this.download.Controls.Add(this.outPathBrowseButton);
            this.download.Controls.Add(this.outPath);
            this.download.Controls.Add(this.outputPath);
            this.download.Controls.Add(this.downloadState);
            this.download.Controls.Add(this.label5);
            this.download.Controls.Add(this.cancelDownloadButton);
            this.download.Controls.Add(this.removeButton);
            this.download.Controls.Add(this.downloadButton);
            this.download.Controls.Add(this.fileViewer);
            this.download.Location = new System.Drawing.Point(4, 22);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(649, 420);
            this.download.TabIndex = 2;
            this.download.Text = "Download";
            this.download.UseVisualStyleBackColor = true;
            // 
            // outPathBrowseButton
            // 
            this.outPathBrowseButton.Location = new System.Drawing.Point(476, 223);
            this.outPathBrowseButton.Name = "outPathBrowseButton";
            this.outPathBrowseButton.Size = new System.Drawing.Size(81, 25);
            this.outPathBrowseButton.TabIndex = 16;
            this.outPathBrowseButton.Text = "Browse...";
            this.outPathBrowseButton.UseVisualStyleBackColor = true;
            this.outPathBrowseButton.Click += new System.EventHandler(this.outPathBrowseButton_Click);
            // 
            // outPath
            // 
            this.outPath.Location = new System.Drawing.Point(92, 226);
            this.outPath.Name = "outPath";
            this.outPath.Size = new System.Drawing.Size(363, 20);
            this.outPath.TabIndex = 15;
            this.outPath.Text = "e:\\result";
            // 
            // outputPath
            // 
            this.outputPath.AutoSize = true;
            this.outputPath.Location = new System.Drawing.Point(13, 229);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(73, 13);
            this.outputPath.TabIndex = 14;
            this.outputPath.Text = "Output Path  :";
            // 
            // downloadState
            // 
            this.downloadState.Location = new System.Drawing.Point(16, 285);
            this.downloadState.Name = "downloadState";
            this.downloadState.Size = new System.Drawing.Size(617, 116);
            this.downloadState.TabIndex = 6;
            this.downloadState.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "State :";
            // 
            // cancelDownloadButton
            // 
            this.cancelDownloadButton.Location = new System.Drawing.Point(491, 176);
            this.cancelDownloadButton.Name = "cancelDownloadButton";
            this.cancelDownloadButton.Size = new System.Drawing.Size(81, 25);
            this.cancelDownloadButton.TabIndex = 4;
            this.cancelDownloadButton.Text = "Cancel";
            this.cancelDownloadButton.UseVisualStyleBackColor = true;
            this.cancelDownloadButton.Click += new System.EventHandler(this.cancelDownloadButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(396, 176);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(81, 25);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(300, 176);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(81, 25);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // fileViewer
            // 
            this.fileViewer.AllowUserToAddRows = false;
            this.fileViewer.AllowUserToDeleteRows = false;
            this.fileViewer.AllowUserToResizeColumns = false;
            this.fileViewer.AllowUserToResizeRows = false;
            this.fileViewer.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileViewer.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.fileViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.name,
            this.n,
            this.k,
            this.local,
            this.dropbox,
            this.box,
            this.copy,
            this.mega,
            this.onedrive});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fileViewer.DefaultCellStyle = dataGridViewCellStyle1;
            this.fileViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.fileViewer.Location = new System.Drawing.Point(16, 13);
            this.fileViewer.MultiSelect = false;
            this.fileViewer.Name = "fileViewer";
            this.fileViewer.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fileViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fileViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fileViewer.Size = new System.Drawing.Size(617, 152);
            this.fileViewer.TabIndex = 1;
            // 
            // Number
            // 
            this.Number.HeaderText = "No";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 30;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // n
            // 
            this.n.HeaderText = "N";
            this.n.Name = "n";
            this.n.ReadOnly = true;
            this.n.Width = 30;
            // 
            // k
            // 
            this.k.HeaderText = "K";
            this.k.Name = "k";
            this.k.ReadOnly = true;
            this.k.Width = 30;
            // 
            // local
            // 
            this.local.HeaderText = "Local";
            this.local.Name = "local";
            this.local.ReadOnly = true;
            this.local.Width = 50;
            // 
            // dropbox
            // 
            this.dropbox.HeaderText = "Dropbox";
            this.dropbox.Name = "dropbox";
            this.dropbox.ReadOnly = true;
            this.dropbox.Width = 60;
            // 
            // box
            // 
            this.box.HeaderText = "Box";
            this.box.Name = "box";
            this.box.ReadOnly = true;
            this.box.Width = 50;
            // 
            // copy
            // 
            this.copy.HeaderText = "Copy";
            this.copy.Name = "copy";
            this.copy.ReadOnly = true;
            this.copy.Width = 50;
            // 
            // mega
            // 
            this.mega.HeaderText = "Mega";
            this.mega.Name = "mega";
            this.mega.ReadOnly = true;
            this.mega.Width = 50;
            // 
            // onedrive
            // 
            this.onedrive.HeaderText = "OneDrive";
            this.onedrive.Name = "onedrive";
            this.onedrive.ReadOnly = true;
            this.onedrive.Width = 60;
            // 
            // manageAccount
            // 
            this.manageAccount.Controls.Add(this.accountRemove);
            this.manageAccount.Controls.Add(this.btnCancel);
            this.manageAccount.Controls.Add(this.accountAdd);
            this.manageAccount.Controls.Add(this.label11);
            this.manageAccount.Controls.Add(this.accountName);
            this.manageAccount.Controls.Add(this.groupBox2);
            this.manageAccount.Controls.Add(this.groupBox1);
            this.manageAccount.Location = new System.Drawing.Point(4, 22);
            this.manageAccount.Name = "manageAccount";
            this.manageAccount.Padding = new System.Windows.Forms.Padding(3);
            this.manageAccount.Size = new System.Drawing.Size(649, 420);
            this.manageAccount.TabIndex = 0;
            this.manageAccount.Text = "ManageAccount";
            this.manageAccount.UseVisualStyleBackColor = true;
            // 
            // accountRemove
            // 
            this.accountRemove.Location = new System.Drawing.Point(404, 338);
            this.accountRemove.Name = "accountRemove";
            this.accountRemove.Size = new System.Drawing.Size(81, 25);
            this.accountRemove.TabIndex = 16;
            this.accountRemove.Text = "Remove";
            this.accountRemove.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(509, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 25);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // accountAdd
            // 
            this.accountAdd.Location = new System.Drawing.Point(299, 338);
            this.accountAdd.Name = "accountAdd";
            this.accountAdd.Size = new System.Drawing.Size(81, 25);
            this.accountAdd.TabIndex = 14;
            this.accountAdd.Text = "Add";
            this.accountAdd.UseVisualStyleBackColor = true;
            this.accountAdd.Click += new System.EventHandler(this.accountAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Account Name : ";
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(162, 341);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(100, 20);
            this.accountName.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.onedriveState);
            this.groupBox2.Controls.Add(this.megaState);
            this.groupBox2.Controls.Add(this.copyState);
            this.groupBox2.Controls.Add(this.boxState);
            this.groupBox2.Controls.Add(this.dropboxState);
            this.groupBox2.Location = new System.Drawing.Point(19, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 62);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current State";
            // 
            // onedriveState
            // 
            this.onedriveState.Image = global::SecureCloud.Properties.Resources._checked;
            this.onedriveState.Location = new System.Drawing.Point(533, 21);
            this.onedriveState.Name = "onedriveState";
            this.onedriveState.Size = new System.Drawing.Size(26, 26);
            this.onedriveState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.onedriveState.TabIndex = 16;
            this.onedriveState.TabStop = false;
            // 
            // megaState
            // 
            this.megaState.Image = global::SecureCloud.Properties.Resources._checked;
            this.megaState.Location = new System.Drawing.Point(414, 21);
            this.megaState.Name = "megaState";
            this.megaState.Size = new System.Drawing.Size(26, 26);
            this.megaState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.megaState.TabIndex = 15;
            this.megaState.TabStop = false;
            // 
            // copyState
            // 
            this.copyState.Image = global::SecureCloud.Properties.Resources._checked;
            this.copyState.Location = new System.Drawing.Point(301, 21);
            this.copyState.Name = "copyState";
            this.copyState.Size = new System.Drawing.Size(26, 26);
            this.copyState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.copyState.TabIndex = 14;
            this.copyState.TabStop = false;
            // 
            // boxState
            // 
            this.boxState.Image = global::SecureCloud.Properties.Resources._checked;
            this.boxState.Location = new System.Drawing.Point(174, 21);
            this.boxState.Name = "boxState";
            this.boxState.Size = new System.Drawing.Size(26, 26);
            this.boxState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boxState.TabIndex = 13;
            this.boxState.TabStop = false;
            // 
            // dropboxState
            // 
            this.dropboxState.Image = global::SecureCloud.Properties.Resources._checked;
            this.dropboxState.Location = new System.Drawing.Point(57, 21);
            this.dropboxState.Name = "dropboxState";
            this.dropboxState.Size = new System.Drawing.Size(26, 26);
            this.dropboxState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dropboxState.TabIndex = 12;
            this.dropboxState.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.copyImg);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dropboxImg);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.boxImg);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.megaImg);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.onedriveImg);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(17, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 168);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cloud Storages";
            // 
            // copyImg
            // 
            this.copyImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.copyImg.Image = ((System.Drawing.Image)(resources.GetObject("copyImg.Image")));
            this.copyImg.InitialImage = global::SecureCloud.Properties.Resources.dropbox;
            this.copyImg.Location = new System.Drawing.Point(266, 44);
            this.copyImg.Name = "copyImg";
            this.copyImg.Size = new System.Drawing.Size(85, 76);
            this.copyImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.copyImg.TabIndex = 2;
            this.copyImg.TabStop = false;
            this.copyImg.Click += new System.EventHandler(this.copyImg_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(300, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Copy";
            // 
            // dropboxImg
            // 
            this.dropboxImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dropboxImg.Image = global::SecureCloud.Properties.Resources.dropbox;
            this.dropboxImg.InitialImage = global::SecureCloud.Properties.Resources.dropbox;
            this.dropboxImg.Location = new System.Drawing.Point(30, 44);
            this.dropboxImg.Name = "dropboxImg";
            this.dropboxImg.Size = new System.Drawing.Size(85, 76);
            this.dropboxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dropboxImg.TabIndex = 0;
            this.dropboxImg.TabStop = false;
            this.dropboxImg.Click += new System.EventHandler(this.dropboxImg_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Mega";
            // 
            // boxImg
            // 
            this.boxImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boxImg.Image = global::SecureCloud.Properties.Resources.box_icon;
            this.boxImg.InitialImage = global::SecureCloud.Properties.Resources.dropbox;
            this.boxImg.Location = new System.Drawing.Point(148, 44);
            this.boxImg.Name = "boxImg";
            this.boxImg.Size = new System.Drawing.Size(85, 76);
            this.boxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boxImg.TabIndex = 1;
            this.boxImg.TabStop = false;
            this.boxImg.Click += new System.EventHandler(this.boxImg_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(521, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "OneDrive";
            // 
            // megaImg
            // 
            this.megaImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.megaImg.Image = ((System.Drawing.Image)(resources.GetObject("megaImg.Image")));
            this.megaImg.InitialImage = global::SecureCloud.Properties.Resources.dropbox;
            this.megaImg.Location = new System.Drawing.Point(384, 44);
            this.megaImg.Name = "megaImg";
            this.megaImg.Size = new System.Drawing.Size(85, 76);
            this.megaImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.megaImg.TabIndex = 3;
            this.megaImg.TabStop = false;
            this.megaImg.Click += new System.EventHandler(this.megaImg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Box";
            // 
            // onedriveImg
            // 
            this.onedriveImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.onedriveImg.Image = ((System.Drawing.Image)(resources.GetObject("onedriveImg.Image")));
            this.onedriveImg.InitialImage = global::SecureCloud.Properties.Resources.dropbox;
            this.onedriveImg.Location = new System.Drawing.Point(502, 44);
            this.onedriveImg.Name = "onedriveImg";
            this.onedriveImg.Size = new System.Drawing.Size(85, 76);
            this.onedriveImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.onedriveImg.TabIndex = 4;
            this.onedriveImg.TabStop = false;
            this.onedriveImg.Click += new System.EventHandler(this.onedriveImg_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dropbox";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 470);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SecureCloud";
            this.tabControl1.ResumeLayout(false);
            this.upload.ResumeLayout(false);
            this.upload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threshold)).EndInit();
            this.download.ResumeLayout(false);
            this.download.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileViewer)).EndInit();
            this.manageAccount.ResumeLayout(false);
            this.manageAccount.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.onedriveState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.megaState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropboxState)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropboxImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.megaImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onedriveImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage manageAccount;
        private System.Windows.Forms.TabPage upload;
        private System.Windows.Forms.TabPage download;
        private System.Windows.Forms.CheckBox checkDropbox;
        private System.Windows.Forms.CheckBox checkLocal;
        private System.Windows.Forms.CheckBox checkOneDrive;
        private System.Windows.Forms.CheckBox checkMega;
        private System.Windows.Forms.CheckBox checkCopy;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.RichTextBox uploadState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button inFileBrowse;
        private System.Windows.Forms.TextBox inFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button localPathBrowse;
        private System.Windows.Forms.TextBox localPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelUpload;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.NumericUpDown threshold;
        private System.Windows.Forms.RichTextBox downloadState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelDownloadButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button outPathBrowseButton;
        private System.Windows.Forms.TextBox outPath;
        private System.Windows.Forms.Label outputPath;
        private System.Windows.Forms.PictureBox onedriveImg;
        private System.Windows.Forms.PictureBox megaImg;
        private System.Windows.Forms.PictureBox copyImg;
        private System.Windows.Forms.PictureBox boxImg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox onedriveState;
        private System.Windows.Forms.PictureBox megaState;
        private System.Windows.Forms.PictureBox copyState;
        private System.Windows.Forms.PictureBox boxState;
        private System.Windows.Forms.PictureBox dropboxState;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button accountAdd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox accountName;
        private System.Windows.Forms.PictureBox dropboxImg;
        private System.Windows.Forms.Button accountRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn n;
        private System.Windows.Forms.DataGridViewTextBoxColumn k;
        private System.Windows.Forms.DataGridViewTextBoxColumn local;
        private System.Windows.Forms.DataGridViewTextBoxColumn dropbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn box;
        private System.Windows.Forms.DataGridViewTextBoxColumn copy;
        private System.Windows.Forms.DataGridViewTextBoxColumn mega;
        private System.Windows.Forms.DataGridViewTextBoxColumn onedrive;
        private System.Windows.Forms.DataGridView fileViewer;
    }
}

