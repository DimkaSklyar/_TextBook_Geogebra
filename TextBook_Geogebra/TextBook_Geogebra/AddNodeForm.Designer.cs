namespace TextBook_Geogebra
{
    partial class AddNodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNodeForm));
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(23, 29);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.NullText = "Имя раздела";
            this.radTextBox1.Size = new System.Drawing.Size(336, 36);
            this.radTextBox1.TabIndex = 0;
            this.radTextBox1.ThemeName = "MaterialBlueGrey";
            this.radTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radTextBox1_KeyPress);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(239, 92);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(120, 36);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Добавить";
            this.radButton1.ThemeName = "MaterialBlueGrey";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // AddNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 157);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNodeForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить раздел";
            this.ThemeName = "MaterialBlueGrey";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox radTextBox1;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
