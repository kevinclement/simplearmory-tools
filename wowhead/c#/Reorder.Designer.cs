namespace WowheadParser
{
    partial class Reorder
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
            this.zoneLabel = new System.Windows.Forms.Label();
            this.itemListBox = new System.Windows.Forms.ListBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.downItem = new System.Windows.Forms.Button();
            this.upItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zoneLabel
            // 
            this.zoneLabel.AutoSize = true;
            this.zoneLabel.Location = new System.Drawing.Point(9, 10);
            this.zoneLabel.Name = "zoneLabel";
            this.zoneLabel.Size = new System.Drawing.Size(32, 13);
            this.zoneLabel.TabIndex = 5;
            this.zoneLabel.Text = "Items";
            // 
            // itemListBox
            // 
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.Location = new System.Drawing.Point(12, 26);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(219, 277);
            this.itemListBox.TabIndex = 4;
            this.itemListBox.SelectedValueChanged += new System.EventHandler(this.itemListBox_SelectedValueChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(156, 358);
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
            this.cancelButton.Location = new System.Drawing.Point(75, 358);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // downItem
            // 
            this.downItem.Enabled = false;
            this.downItem.Location = new System.Drawing.Point(198, 309);
            this.downItem.Name = "downItem";
            this.downItem.Size = new System.Drawing.Size(33, 23);
            this.downItem.TabIndex = 21;
            this.downItem.Text = "↓";
            this.downItem.UseVisualStyleBackColor = true;
            this.downItem.Click += new System.EventHandler(this.downItem_Click);
            // 
            // upItem
            // 
            this.upItem.Enabled = false;
            this.upItem.Location = new System.Drawing.Point(159, 309);
            this.upItem.Name = "upItem";
            this.upItem.Size = new System.Drawing.Size(33, 23);
            this.upItem.TabIndex = 20;
            this.upItem.Text = "↑";
            this.upItem.UseVisualStyleBackColor = true;
            this.upItem.Click += new System.EventHandler(this.upItem_Click);
            // 
            // Reorder
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(243, 395);
            this.Controls.Add(this.downItem);
            this.Controls.Add(this.upItem);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.zoneLabel);
            this.Controls.Add(this.itemListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reorder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reorder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label zoneLabel;
        private System.Windows.Forms.ListBox itemListBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button downItem;
        private System.Windows.Forms.Button upItem;
    }
}