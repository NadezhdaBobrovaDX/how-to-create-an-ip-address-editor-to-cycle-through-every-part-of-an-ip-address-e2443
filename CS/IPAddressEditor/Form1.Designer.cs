namespace IPAddressEditor
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
            IPAddressEditor.IPv4Addr iPv4Addr1 = new IPAddressEditor.IPv4Addr();
            this.ipAddressEdit1 = new IPAddressEditor.IPAddressEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ipAddressEdit1
            // 
            this.ipAddressEdit1.EditValue = iPv4Addr1;
            this.ipAddressEdit1.IPAddress = "0.0.0.0";
            this.ipAddressEdit1.Location = new System.Drawing.Point(81, 121);
            this.ipAddressEdit1.Name = "ipAddressEdit1";
            this.ipAddressEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ipAddressEdit1.Properties.DisplayFormat.FormatString = "d.h.m.s";
            this.ipAddressEdit1.Properties.EditFormat.FormatString = "d.h.m.s";
            this.ipAddressEdit1.Properties.Mask.EditMask = "d.h.m.s";
            this.ipAddressEdit1.Size = new System.Drawing.Size(122, 20);
            this.ipAddressEdit1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ipAddressEdit1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IPAddressEdit ipAddressEdit1;

    }
}

