Imports Microsoft.VisualBasic
Imports System
Namespace IPAddressEditor
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim iPv4Addr1 As New IPAddressEditor.IPv4Addr()
			Me.ipAddressEdit1 = New IPAddressEditor.IPAddressEdit()
			CType(Me.ipAddressEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ipAddressEdit1
			' 
			Me.ipAddressEdit1.EditValue = iPv4Addr1
			Me.ipAddressEdit1.IPAddress = "0.0.0.0"
			Me.ipAddressEdit1.Location = New System.Drawing.Point(81, 121)
			Me.ipAddressEdit1.Name = "ipAddressEdit1"
			Me.ipAddressEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton()})
			Me.ipAddressEdit1.Properties.DisplayFormat.FormatString = "d.h.m.s"
			Me.ipAddressEdit1.Properties.EditFormat.FormatString = "d.h.m.s"
			Me.ipAddressEdit1.Properties.Mask.EditMask = "d.h.m.s"
			Me.ipAddressEdit1.Size = New System.Drawing.Size(122, 20)
			Me.ipAddressEdit1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 262)
			Me.Controls.Add(Me.ipAddressEdit1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.ipAddressEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private ipAddressEdit1 As IPAddressEdit

	End Class
End Namespace

