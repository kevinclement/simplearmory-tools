namespace WowheadParser
{
    partial class App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.urlBox = new System.Windows.Forms.TextBox();
            this.getButton = new System.Windows.Forms.Button();
            this.fetchedItems = new System.Windows.Forms.ListBox();
            this.categoryList = new System.Windows.Forms.ListBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.categoriesFile = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.totalFound = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.reorderButton = new System.Windows.Forms.Button();
            this.checkDupe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlBox.Location = new System.Drawing.Point(12, 12);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(290, 20);
            this.urlBox.TabIndex = 0;
            // 
            // getButton
            // 
            this.getButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getButton.Location = new System.Drawing.Point(308, 10);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(75, 23);
            this.getButton.TabIndex = 1;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // fetchedItems
            // 
            this.fetchedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fetchedItems.FormattingEnabled = true;
            this.fetchedItems.Location = new System.Drawing.Point(12, 39);
            this.fetchedItems.Name = "fetchedItems";
            this.fetchedItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fetchedItems.Size = new System.Drawing.Size(371, 433);
            this.fetchedItems.Sorted = true;
            this.fetchedItems.TabIndex = 2;
            this.fetchedItems.SelectedValueChanged += new System.EventHandler(this.fetchedItems_SelectedValueChanged);
            this.fetchedItems.DoubleClick += new System.EventHandler(this.fetchedItems_DoubleClick);
            // 
            // categoryList
            // 
            this.categoryList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(479, 39);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(450, 433);
            this.categoryList.TabIndex = 4;
            this.categoryList.SelectedIndexChanged += new System.EventHandler(this.categoryList_SelectedIndexChanged);
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.Enabled = false;
            this.moveButton.Location = new System.Drawing.Point(389, 182);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(84, 23);
            this.moveButton.TabIndex = 5;
            this.moveButton.Text = "==>";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // categoriesFile
            // 
            this.categoriesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.categoriesFile.Location = new System.Drawing.Point(479, 12);
            this.categoriesFile.Name = "categoriesFile";
            this.categoriesFile.Size = new System.Drawing.Size(412, 20);
            this.categoriesFile.TabIndex = 6;
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileButton.Location = new System.Drawing.Point(897, 10);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(32, 23);
            this.openFileButton.TabIndex = 7;
            this.openFileButton.Text = "...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "json files|*.json";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(854, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addCategoryButton.Location = new System.Drawing.Point(389, 449);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(75, 23);
            this.addCategoryButton.TabIndex = 10;
            this.addCategoryButton.Text = "Add";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(13, 478);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Auto clear dupes";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // totalFound
            // 
            this.totalFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalFound.AutoSize = true;
            this.totalFound.Location = new System.Drawing.Point(325, 479);
            this.totalFound.Name = "totalFound";
            this.totalFound.Size = new System.Drawing.Size(52, 13);
            this.totalFound.TabIndex = 12;
            this.totalFound.Text = "Found:  0";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(389, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Legacy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // reorderButton
            // 
            this.reorderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reorderButton.Enabled = false;
            this.reorderButton.Location = new System.Drawing.Point(479, 474);
            this.reorderButton.Name = "reorderButton";
            this.reorderButton.Size = new System.Drawing.Size(75, 23);
            this.reorderButton.TabIndex = 14;
            this.reorderButton.Text = "Reorder";
            this.reorderButton.UseVisualStyleBackColor = true;
            this.reorderButton.Click += new System.EventHandler(this.reorder_Click);
            // 
            // checkDupe
            // 
            this.checkDupe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDupe.Location = new System.Drawing.Point(389, 420);
            this.checkDupe.Name = "checkDupe";
            this.checkDupe.Size = new System.Drawing.Size(75, 23);
            this.checkDupe.TabIndex = 15;
            this.checkDupe.Text = "Check Dupe";
            this.checkDupe.UseVisualStyleBackColor = true;
            this.checkDupe.Click += new System.EventHandler(this.checkDupe_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 508);
            this.Controls.Add(this.checkDupe);
            this.Controls.Add(this.reorderButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.totalFound);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.addCategoryButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.categoriesFile);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.fetchedItems);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.urlBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App";
            this.Text = "Wowhead Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.ListBox fetchedItems;
        private System.Windows.Forms.ListBox categoryList;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.TextBox categoriesFile;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label totalFound;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button reorderButton;
        private System.Windows.Forms.Button checkDupe;
    }
}

