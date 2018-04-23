' Developer Express Code Central Example:
' How to create an IP address editor with the capability of cycling through every part of an IP address
' 
' If you need an IP address editor with a spin edit capable to change values in
' cycle from 0 to 255 for every single part of an IP address this example explains
' how to obtain it. This editor corresponds to a descendant of the TimeEdit
' control and its behavior is based on storing an IP address as a value of type
' DateTime. The IP address is simply transformed to a value of type Int64 and
' assigned to the Ticks property of the DateTime value. The ability to cycle
' through IP address parts is achieved by assigning a mask of type "d.h.m.s" (Day,
' Hour, Minute, Second) and changing the low and high cycle bounds in theTimeEdit
' descendant to 0 and 255 respectively.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2443


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

