// Developer Express Code Central Example:
// How to create an IP address editor with the capability of cycling through every part of an IP address
// 
// If you need an IP address editor with a spin edit capable to change values in
// cycle from 0 to 255 for every single part of an IP address this example explains
// how to obtain it. This editor corresponds to a descendant of the TimeEdit
// control and its behavior is based on storing an IP address as a value of type
// DateTime. The IP address is simply transformed to a value of type Int64 and
// assigned to the Ticks property of the DateTime value. The ability to cycle
// through IP address parts is achieved by assigning a mask of type "d.h.m.s" (Day,
// Hour, Minute, Second) and changing the low and high cycle bounds in theTimeEdit
// descendant to 0 and 255 respectively.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2443

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

