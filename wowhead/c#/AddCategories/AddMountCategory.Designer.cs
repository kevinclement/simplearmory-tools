namespace WowheadParser
{
    partial class AddMountCategory
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
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.zoneLabel = new System.Windows.Forms.Label();
            this.zoneListBox = new System.Windows.Forms.ListBox();
            this.categoryRemove = new System.Windows.Forms.Button();
            this.categoryAdd = new System.Windows.Forms.Button();
            this.zoneRemove = new System.Windows.Forms.Button();
            this.zoneAdd = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.upCat = new System.Windows.Forms.Button();
            this.downCat = new System.Windows.Forms.Button();
            this.upZone = new System.Windows.Forms.Button();
            this.downZone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(10, 10);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(52, 13);
            this.categoryLabel.TabIndex = 3;
            this.categoryLabel.Text = "Category:";
            // 
            // categoryListBox
            // 
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.Location = new System.Drawing.Point(13, 26);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(219, 277);
            this.categoryListBox.TabIndex = 2;
            this.categoryListBox.SelectedValueChanged += new System.EventHandler(this.categoryListBox_SelectedValueChanged);
            // 
            // zoneLabel
            // 
            this.zoneLabel.AutoSize = true;
            this.zoneLabel.Location = new System.Drawing.Point(263, 10);
            this.zoneLabel.Name = "zoneLabel";
            this.zoneLabel.Size = new System.Drawing.Size(45, 13);
            this.zoneLabel.TabIndex = 5;
            this.zoneLabel.Text = "SubCat:";
            // 
            // zoneListBox
            // 
            this.zoneListBox.FormattingEnabled = true;
            this.zoneListBox.Location = new System.Drawing.Point(266, 26);
            this.zoneListBox.Name = "zoneListBox";
            this.zoneListBox.Size = new System.Drawing.Size(219, 277);
            this.zoneListBox.TabIndex = 4;
            this.zoneListBox.SelectedValueChanged += new System.EventHandler(this.zoneListBox_SelectedValueChanged);
            // 
            // categoryRemove
            // 
            this.categoryRemove.Enabled = false;
            this.categoryRemove.Location = new System.Drawing.Point(52, 309);
            this.categoryRemove.Name = "categoryRemove";
            this.categoryRemove.Size = new System.Drawing.Size(33, 23);
            this.categoryRemove.TabIndex = 9;
            this.categoryRemove.Text = "-";
            this.categoryRemove.UseVisualStyleBackColor = true;
            this.categoryRemove.Click += new System.EventHandler(this.categoryRemove_Click);
            // 
            // categoryAdd
            // 
            this.categoryAdd.Location = new System.Drawing.Point(13, 309);
            this.categoryAdd.Name = "categoryAdd";
            this.categoryAdd.Size = new System.Drawing.Size(33, 23);
            this.categoryAdd.TabIndex = 8;
            this.categoryAdd.Text = "+";
            this.categoryAdd.UseVisualStyleBackColor = true;
            this.categoryAdd.Click += new System.EventHandler(this.categoryAdd_Click);
            // 
            // zoneRemove
            // 
            this.zoneRemove.Enabled = false;
            this.zoneRemove.Location = new System.Drawing.Point(305, 309);
            this.zoneRemove.Name = "zoneRemove";
            this.zoneRemove.Size = new System.Drawing.Size(33, 23);
            this.zoneRemove.TabIndex = 11;
            this.zoneRemove.Text = "-";
            this.zoneRemove.UseVisualStyleBackColor = true;
            this.zoneRemove.Click += new System.EventHandler(this.zoneRemove_Click);
            // 
            // zoneAdd
            // 
            this.zoneAdd.Location = new System.Drawing.Point(266, 309);
            this.zoneAdd.Name = "zoneAdd";
            this.zoneAdd.Size = new System.Drawing.Size(33, 23);
            this.zoneAdd.TabIndex = 10;
            this.zoneAdd.Text = "+";
            this.zoneAdd.UseVisualStyleBackColor = true;
            this.zoneAdd.Click += new System.EventHandler(this.zoneAdd_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(410, 358);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(329, 358);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // upCat
            // 
            this.upCat.Enabled = false;
            this.upCat.Location = new System.Drawing.Point(160, 309);
            this.upCat.Name = "upCat";
            this.upCat.Size = new System.Drawing.Size(33, 23);
            this.upCat.TabIndex = 16;
            this.upCat.Text = "↑";
            this.upCat.UseVisualStyleBackColor = true;
            this.upCat.Click += new System.EventHandler(this.upCat_Click);
            // 
            // downCat
            // 
            this.downCat.Enabled = false;
            this.downCat.Location = new System.Drawing.Point(199, 309);
            this.downCat.Name = "downCat";
            this.downCat.Size = new System.Drawing.Size(33, 23);
            this.downCat.TabIndex = 17;
            this.downCat.Text = "↓";
            this.downCat.UseVisualStyleBackColor = true;
            this.downCat.Click += new System.EventHandler(this.downCat_Click);
            // 
            // upZone
            // 
            this.upZone.Enabled = false;
            this.upZone.Location = new System.Drawing.Point(413, 309);
            this.upZone.Name = "upZone";
            this.upZone.Size = new System.Drawing.Size(33, 23);
            this.upZone.TabIndex = 18;
            this.upZone.Text = "↑";
            this.upZone.UseVisualStyleBackColor = true;
            this.upZone.Click += new System.EventHandler(this.upZone_Click);
            // 
            // downZone
            // 
            this.downZone.Enabled = false;
            this.downZone.Location = new System.Drawing.Point(452, 309);
            this.downZone.Name = "downZone";
            this.downZone.Size = new System.Drawing.Size(33, 23);
            this.downZone.TabIndex = 19;
            this.downZone.Text = "↓";
            this.downZone.UseVisualStyleBackColor = true;
            this.downZone.Click += new System.EventHandler(this.downZone_Click);
            // 
            // AddMountCategory
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(506, 392);
            this.Controls.Add(this.downZone);
            this.Controls.Add(this.upZone);
            this.Controls.Add(this.downCat);
            this.Controls.Add(this.upCat);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.zoneRemove);
            this.Controls.Add(this.zoneAdd);
            this.Controls.Add(this.categoryRemove);
            this.Controls.Add(this.categoryAdd);
            this.Controls.Add(this.zoneLabel);
            this.Controls.Add(this.zoneListBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMountCategory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Mount Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Label zoneLabel;
        private System.Windows.Forms.ListBox zoneListBox;
        private System.Windows.Forms.Button categoryRemove;
        private System.Windows.Forms.Button categoryAdd;
        private System.Windows.Forms.Button zoneRemove;
        private System.Windows.Forms.Button zoneAdd;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button upCat;
        private System.Windows.Forms.Button downCat;
        private System.Windows.Forms.Button upZone;
        private System.Windows.Forms.Button downZone;
    }
}