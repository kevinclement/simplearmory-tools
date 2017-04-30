namespace WowheadParser
{
    partial class AddAchievementCategory
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
            this.superCatsListBox = new System.Windows.Forms.ListBox();
            this.superCatLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.zoneLabel = new System.Windows.Forms.Label();
            this.zoneListBox = new System.Windows.Forms.ListBox();
            this.superCatAdd = new System.Windows.Forms.Button();
            this.superCatRemove = new System.Windows.Forms.Button();
            this.categoryRemove = new System.Windows.Forms.Button();
            this.categoryAdd = new System.Windows.Forms.Button();
            this.zoneRemove = new System.Windows.Forms.Button();
            this.zoneAdd = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.superCatUp = new System.Windows.Forms.Button();
            this.superCatDown = new System.Windows.Forms.Button();
            this.upCat = new System.Windows.Forms.Button();
            this.downCat = new System.Windows.Forms.Button();
            this.upZone = new System.Windows.Forms.Button();
            this.downZone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // superCatsListBox
            // 
            this.superCatsListBox.FormattingEnabled = true;
            this.superCatsListBox.Location = new System.Drawing.Point(15, 25);
            this.superCatsListBox.Name = "superCatsListBox";
            this.superCatsListBox.Size = new System.Drawing.Size(219, 277);
            this.superCatsListBox.TabIndex = 0;
            this.superCatsListBox.SelectedValueChanged += new System.EventHandler(this.superCatsListBox_SelectedValueChanged);
            // 
            // superCatLabel
            // 
            this.superCatLabel.AutoSize = true;
            this.superCatLabel.Location = new System.Drawing.Point(12, 9);
            this.superCatLabel.Name = "superCatLabel";
            this.superCatLabel.Size = new System.Drawing.Size(83, 13);
            this.superCatLabel.TabIndex = 1;
            this.superCatLabel.Text = "Super Category:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(265, 9);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(52, 13);
            this.categoryLabel.TabIndex = 3;
            this.categoryLabel.Text = "Category:";
            // 
            // categoryListBox
            // 
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.Location = new System.Drawing.Point(268, 25);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(219, 277);
            this.categoryListBox.TabIndex = 2;
            this.categoryListBox.SelectedValueChanged += new System.EventHandler(this.categoryListBox_SelectedValueChanged);
            // 
            // zoneLabel
            // 
            this.zoneLabel.AutoSize = true;
            this.zoneLabel.Location = new System.Drawing.Point(518, 9);
            this.zoneLabel.Name = "zoneLabel";
            this.zoneLabel.Size = new System.Drawing.Size(35, 13);
            this.zoneLabel.TabIndex = 5;
            this.zoneLabel.Text = "Zone:";
            // 
            // zoneListBox
            // 
            this.zoneListBox.FormattingEnabled = true;
            this.zoneListBox.Location = new System.Drawing.Point(521, 25);
            this.zoneListBox.Name = "zoneListBox";
            this.zoneListBox.Size = new System.Drawing.Size(219, 277);
            this.zoneListBox.TabIndex = 4;
            this.zoneListBox.SelectedValueChanged += new System.EventHandler(this.zoneListBox_SelectedValueChanged);
            // 
            // superCatAdd
            // 
            this.superCatAdd.Location = new System.Drawing.Point(15, 309);
            this.superCatAdd.Name = "superCatAdd";
            this.superCatAdd.Size = new System.Drawing.Size(33, 23);
            this.superCatAdd.TabIndex = 6;
            this.superCatAdd.Text = "+";
            this.superCatAdd.UseVisualStyleBackColor = true;
            this.superCatAdd.Click += new System.EventHandler(this.superCatAdd_Click);
            // 
            // superCatRemove
            // 
            this.superCatRemove.Enabled = false;
            this.superCatRemove.Location = new System.Drawing.Point(54, 309);
            this.superCatRemove.Name = "superCatRemove";
            this.superCatRemove.Size = new System.Drawing.Size(33, 23);
            this.superCatRemove.TabIndex = 7;
            this.superCatRemove.Text = "-";
            this.superCatRemove.UseVisualStyleBackColor = true;
            this.superCatRemove.Click += new System.EventHandler(this.superCatRemove_Click);
            // 
            // categoryRemove
            // 
            this.categoryRemove.Enabled = false;
            this.categoryRemove.Location = new System.Drawing.Point(307, 308);
            this.categoryRemove.Name = "categoryRemove";
            this.categoryRemove.Size = new System.Drawing.Size(33, 23);
            this.categoryRemove.TabIndex = 9;
            this.categoryRemove.Text = "-";
            this.categoryRemove.UseVisualStyleBackColor = true;
            this.categoryRemove.Click += new System.EventHandler(this.categoryRemove_Click);
            // 
            // categoryAdd
            // 
            this.categoryAdd.Location = new System.Drawing.Point(268, 308);
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
            this.zoneRemove.Location = new System.Drawing.Point(560, 308);
            this.zoneRemove.Name = "zoneRemove";
            this.zoneRemove.Size = new System.Drawing.Size(33, 23);
            this.zoneRemove.TabIndex = 11;
            this.zoneRemove.Text = "-";
            this.zoneRemove.UseVisualStyleBackColor = true;
            this.zoneRemove.Click += new System.EventHandler(this.zoneRemove_Click);
            // 
            // zoneAdd
            // 
            this.zoneAdd.Location = new System.Drawing.Point(521, 308);
            this.zoneAdd.Name = "zoneAdd";
            this.zoneAdd.Size = new System.Drawing.Size(33, 23);
            this.zoneAdd.TabIndex = 10;
            this.zoneAdd.Text = "+";
            this.zoneAdd.UseVisualStyleBackColor = true;
            this.zoneAdd.Click += new System.EventHandler(this.zoneAdd_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(665, 357);
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
            this.cancelButton.Location = new System.Drawing.Point(584, 357);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // superCatUp
            // 
            this.superCatUp.Enabled = false;
            this.superCatUp.Location = new System.Drawing.Point(162, 308);
            this.superCatUp.Name = "superCatUp";
            this.superCatUp.Size = new System.Drawing.Size(33, 23);
            this.superCatUp.TabIndex = 14;
            this.superCatUp.Text = "↑";
            this.superCatUp.UseVisualStyleBackColor = true;
            this.superCatUp.Click += new System.EventHandler(this.button1_Click);
            // 
            // superCatDown
            // 
            this.superCatDown.Enabled = false;
            this.superCatDown.Location = new System.Drawing.Point(201, 309);
            this.superCatDown.Name = "superCatDown";
            this.superCatDown.Size = new System.Drawing.Size(33, 23);
            this.superCatDown.TabIndex = 15;
            this.superCatDown.Text = "↓";
            this.superCatDown.UseVisualStyleBackColor = true;
            this.superCatDown.Click += new System.EventHandler(this.superCatDown_Click);
            // 
            // upCat
            // 
            this.upCat.Enabled = false;
            this.upCat.Location = new System.Drawing.Point(415, 308);
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
            this.downCat.Location = new System.Drawing.Point(454, 308);
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
            this.upZone.Location = new System.Drawing.Point(668, 308);
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
            this.downZone.Location = new System.Drawing.Point(707, 308);
            this.downZone.Name = "downZone";
            this.downZone.Size = new System.Drawing.Size(33, 23);
            this.downZone.TabIndex = 19;
            this.downZone.Text = "↓";
            this.downZone.UseVisualStyleBackColor = true;
            this.downZone.Click += new System.EventHandler(this.downZone_Click);
            // 
            // AddAchievementCategory
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(757, 392);
            this.Controls.Add(this.downZone);
            this.Controls.Add(this.upZone);
            this.Controls.Add(this.downCat);
            this.Controls.Add(this.upCat);
            this.Controls.Add(this.superCatDown);
            this.Controls.Add(this.superCatUp);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.zoneRemove);
            this.Controls.Add(this.zoneAdd);
            this.Controls.Add(this.categoryRemove);
            this.Controls.Add(this.categoryAdd);
            this.Controls.Add(this.superCatRemove);
            this.Controls.Add(this.superCatAdd);
            this.Controls.Add(this.zoneLabel);
            this.Controls.Add(this.zoneListBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryListBox);
            this.Controls.Add(this.superCatLabel);
            this.Controls.Add(this.superCatsListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAchievementCategory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Achievement Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox superCatsListBox;
        private System.Windows.Forms.Label superCatLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Label zoneLabel;
        private System.Windows.Forms.ListBox zoneListBox;
        private System.Windows.Forms.Button superCatAdd;
        private System.Windows.Forms.Button superCatRemove;
        private System.Windows.Forms.Button categoryRemove;
        private System.Windows.Forms.Button categoryAdd;
        private System.Windows.Forms.Button zoneRemove;
        private System.Windows.Forms.Button zoneAdd;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button superCatUp;
        private System.Windows.Forms.Button superCatDown;
        private System.Windows.Forms.Button upCat;
        private System.Windows.Forms.Button downCat;
        private System.Windows.Forms.Button upZone;
        private System.Windows.Forms.Button downZone;
    }
}