namespace TextBook_Geogebra
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.radLabelProductName = new Telerik.WinControls.UI.RadLabel();
            this.radTextBoxDescription = new Telerik.WinControls.UI.RadTextBox();
            this.okRadButton = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.okRadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.radLabelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.radTextBoxDescription, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.okRadButton, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(392, 267);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::TextBook_Geogebra.Properties.Resources.about;
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 3);
            this.logoPictureBox.Size = new System.Drawing.Size(123, 261);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // radLabelProductName
            // 
            this.radLabelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelProductName.Location = new System.Drawing.Point(135, 0);
            this.radLabelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.radLabelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.radLabelProductName.Name = "radLabelProductName";
            // 
            // 
            // 
            this.radLabelProductName.RootElement.MaxSize = new System.Drawing.Size(0, 17);
            this.radLabelProductName.Size = new System.Drawing.Size(113, 17);
            this.radLabelProductName.TabIndex = 19;
            this.radLabelProductName.Text = "Наименование:";
            this.radLabelProductName.ThemeName = "MaterialBlueGrey";
            // 
            // radTextBoxDescription
            // 
            this.radTextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBoxDescription.Location = new System.Drawing.Point(135, 41);
            this.radTextBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.radTextBoxDescription.Multiline = true;
            this.radTextBoxDescription.Name = "radTextBoxDescription";
            this.radTextBoxDescription.ReadOnly = true;
            // 
            // 
            // 
            this.radTextBoxDescription.RootElement.StretchVertically = true;
            this.radTextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.radTextBoxDescription.Size = new System.Drawing.Size(254, 184);
            this.radTextBoxDescription.TabIndex = 23;
            this.radTextBoxDescription.TabStop = false;
            this.radTextBoxDescription.Text = "Учебный практикум по Geogebra, предназначенный для обучения студентов, а так же п" +
    "роведения практических занятий.";
            this.radTextBoxDescription.ThemeName = "MaterialBlueGrey";
            // 
            // okRadButton
            // 
            this.okRadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okRadButton.BackColor = System.Drawing.Color.Transparent;
            this.okRadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okRadButton.ForeColor = System.Drawing.Color.White;
            this.okRadButton.Location = new System.Drawing.Point(314, 231);
            this.okRadButton.Name = "okRadButton";
            this.okRadButton.Size = new System.Drawing.Size(75, 33);
            this.okRadButton.TabIndex = 24;
            this.okRadButton.Text = "&OK";
            this.okRadButton.ThemeName = "MaterialBlueGrey";
            this.okRadButton.Click += new System.EventHandler(this.okRadButton_Click);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okRadButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 285);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.ThemeName = "MaterialBlueGrey";
            this.TopMost = true;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabelProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.okRadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private Telerik.WinControls.UI.RadLabel radLabelProductName;
        private Telerik.WinControls.UI.RadTextBox radTextBoxDescription;
        private Telerik.WinControls.UI.RadButton okRadButton;
    }
}
