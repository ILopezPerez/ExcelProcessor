namespace ExcelProcessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFolderSearch = new System.Windows.Forms.TextBox();
            this.folderSearch = new System.Windows.Forms.PictureBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btFolderExplore = new System.Windows.Forms.Button();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.btStartDataDump = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.folderSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "GENERAR FE DE ERRATAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selecciona la carpeta donde están los excels";
            // 
            // tbFolderSearch
            // 
            this.tbFolderSearch.Location = new System.Drawing.Point(72, 123);
            this.tbFolderSearch.Name = "tbFolderSearch";
            this.tbFolderSearch.Size = new System.Drawing.Size(256, 20);
            this.tbFolderSearch.TabIndex = 2;
            // 
            // folderSearch
            // 
            this.folderSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.folderSearch.Image = ((System.Drawing.Image)(resources.GetObject("folderSearch.Image")));
            this.folderSearch.Location = new System.Drawing.Point(340, 123);
            this.folderSearch.Name = "folderSearch";
            this.folderSearch.Size = new System.Drawing.Size(21, 21);
            this.folderSearch.TabIndex = 3;
            this.folderSearch.TabStop = false;
            this.folderSearch.Click += new System.EventHandler(this.folderSearch_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(72, 219);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(289, 259);
            this.checkedListBox1.TabIndex = 4;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheckChanged);
            // 
            // btFolderExplore
            // 
            this.btFolderExplore.BackColor = System.Drawing.Color.LightGreen;
            this.btFolderExplore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btFolderExplore.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.btFolderExplore.FlatAppearance.BorderSize = 0;
            this.btFolderExplore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFolderExplore.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btFolderExplore.Location = new System.Drawing.Point(72, 149);
            this.btFolderExplore.Name = "btFolderExplore";
            this.btFolderExplore.Size = new System.Drawing.Size(127, 29);
            this.btFolderExplore.TabIndex = 5;
            this.btFolderExplore.Text = "Explorar carpeta";
            this.btFolderExplore.UseVisualStyleBackColor = false;
            this.btFolderExplore.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbInfo.Location = new System.Drawing.Point(492, 123);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(338, 415);
            this.tbInfo.TabIndex = 6;
            // 
            // btStartDataDump
            // 
            this.btStartDataDump.BackColor = System.Drawing.Color.LightGreen;
            this.btStartDataDump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btStartDataDump.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.btStartDataDump.FlatAppearance.BorderSize = 0;
            this.btStartDataDump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStartDataDump.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btStartDataDump.Location = new System.Drawing.Point(72, 496);
            this.btStartDataDump.Name = "btStartDataDump";
            this.btStartDataDump.Size = new System.Drawing.Size(289, 54);
            this.btStartDataDump.TabIndex = 7;
            this.btStartDataDump.Text = "Iniciar Volcado a la BBDD";
            this.btStartDataDump.UseVisualStyleBackColor = false;
            this.btStartDataDump.Click += new System.EventHandler(this.btStartDataDump_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(69, 191);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(287, 13);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "* Error al buscar en la carpeta. Compruebe que es correcta.";
            this.lblError.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(909, 587);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btStartDataDump);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.btFolderExplore);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.folderSearch);
            this.Controls.Add(this.tbFolderSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Fe Erratas";
            ((System.ComponentModel.ISupportInitialize)(this.folderSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.DirectoryServices.DirectoryEntry directoryEntry2;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TextBox tbFolderSearch;
        private System.Windows.Forms.PictureBox folderSearch;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btFolderExplore;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Button btStartDataDump;
        private System.Windows.Forms.Label lblError;
    }
}

