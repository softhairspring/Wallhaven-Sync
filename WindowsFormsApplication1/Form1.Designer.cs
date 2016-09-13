namespace WallhavenSyncNm
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

        public void setDebugText(string str)
        {
            //this.labelDebug.Text = str;
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.listBoxFavCategories = new System.Windows.Forms.ListBox();
            this.listBoxVerbose = new System.Windows.Forms.ListBox();
            this.textBoxSaveDir = new System.Windows.Forms.TextBox();
            this.labelSaveDir = new System.Windows.Forms.Label();
            this.folderBrowserDialogSaveDir = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonChangeDir = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonDownloadAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(172, 162);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(137, 23);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Download Selected";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxFavCategories
            // 
            this.listBoxFavCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxFavCategories.FormattingEnabled = true;
            this.listBoxFavCategories.Location = new System.Drawing.Point(12, 12);
            this.listBoxFavCategories.Name = "listBoxFavCategories";
            this.listBoxFavCategories.Size = new System.Drawing.Size(154, 173);
            this.listBoxFavCategories.TabIndex = 4;
            // 
            // listBoxVerbose
            // 
            this.listBoxVerbose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxVerbose.FormattingEnabled = true;
            this.listBoxVerbose.Location = new System.Drawing.Point(12, 191);
            this.listBoxVerbose.Name = "listBoxVerbose";
            this.listBoxVerbose.Size = new System.Drawing.Size(597, 56);
            this.listBoxVerbose.TabIndex = 5;
            // 
            // textBoxSaveDir
            // 
            this.textBoxSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSaveDir.Location = new System.Drawing.Point(193, 41);
            this.textBoxSaveDir.Name = "textBoxSaveDir";
            this.textBoxSaveDir.Size = new System.Drawing.Size(416, 20);
            this.textBoxSaveDir.TabIndex = 6;
            this.textBoxSaveDir.Text = "C:/temp";
            // 
            // labelSaveDir
            // 
            this.labelSaveDir.AutoSize = true;
            this.labelSaveDir.Location = new System.Drawing.Point(190, 15);
            this.labelSaveDir.Name = "labelSaveDir";
            this.labelSaveDir.Size = new System.Drawing.Size(73, 13);
            this.labelSaveDir.TabIndex = 7;
            this.labelSaveDir.Text = "save directory";
            // 
            // buttonChangeDir
            // 
            this.buttonChangeDir.Location = new System.Drawing.Point(269, 12);
            this.buttonChangeDir.Name = "buttonChangeDir";
            this.buttonChangeDir.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeDir.TabIndex = 8;
            this.buttonChangeDir.Text = "change directory";
            this.buttonChangeDir.UseVisualStyleBackColor = true;
            this.buttonChangeDir.Click += new System.EventHandler(this.buttonChangeDir_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(350, 12);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFolder.TabIndex = 9;
            this.buttonOpenFolder.Text = "Open Folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonDownloadAll
            // 
            this.buttonDownloadAll.Enabled = false;
            this.buttonDownloadAll.Location = new System.Drawing.Point(315, 162);
            this.buttonDownloadAll.Name = "buttonDownloadAll";
            this.buttonDownloadAll.Size = new System.Drawing.Size(75, 23);
            this.buttonDownloadAll.TabIndex = 10;
            this.buttonDownloadAll.Text = "Sync All";
            this.buttonDownloadAll.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 259);
            this.Controls.Add(this.buttonDownloadAll);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.buttonChangeDir);
            this.Controls.Add(this.labelSaveDir);
            this.Controls.Add(this.textBoxSaveDir);
            this.Controls.Add(this.listBoxVerbose);
            this.Controls.Add(this.listBoxFavCategories);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Wallhaven Sync";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ListBox listBoxFavCategories;
        private System.Windows.Forms.ListBox listBoxVerbose;
        private System.Windows.Forms.TextBox textBoxSaveDir;
        private System.Windows.Forms.Label labelSaveDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSaveDir;
        private System.Windows.Forms.Button buttonChangeDir;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonDownloadAll;
    }
}


