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
Imports System.ComponentModel
Imports DevExpress.Data.Mask
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Mask
Imports DevExpress.XtraEditors.Repository

Namespace IPAddressEditor
	Friend Class IPAddressEdit
		Inherits TimeEdit
		Shared Sub New()
			RepositoryItemIPAddressEdit.Register()
		End Sub
		Public Sub New()
			MyBase.New()
			Me.fEditValue = New DateTime(0)
			Me.fOldEditValue = Me.fEditValue
		End Sub

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemIPAddressEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemIPAddressEdit)
			End Get
		End Property
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemIPAddressEdit.IPAddressEditName
			End Get
		End Property

		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Overrides Property EditValue() As Object
			Get
				If Properties.ExportMode = ExportMode.DisplayText Then
					Return Properties.GetDisplayText(Nothing, MyBase.EditValue)
				End If

				If TypeOf MyBase.EditValue Is DateTime AndAlso IPAddressHelper.IsConvertible(CDate(MyBase.EditValue)) Then
					Return IPAddressHelper.ToIPAddress(CDate(MyBase.EditValue))
				End If

				If TypeOf MyBase.EditValue Is IPv4Addr Then
					Return MyBase.EditValue
				End If

				If TypeOf MyBase.EditValue Is String Then
					Return New IPv4Addr(CStr(MyBase.EditValue))
				End If

				Return New IPv4Addr("0.0.0.0")
			End Get
			Set(ByVal value As Object)
				If TypeOf value Is IPv4Addr Then
					MyBase.EditValue = value
				ElseIf TypeOf value Is String AndAlso CStr(value) <> "" Then
					MyBase.EditValue = New IPv4Addr(CStr(value))
				ElseIf TypeOf value Is DateTime AndAlso IPAddressHelper.IsConvertible(CDate(value)) Then
					MyBase.EditValue = IPAddressHelper.ToIPAddress(CDate(value))
				Else
					MyBase.EditValue = New IPv4Addr("0.0.0.0")
				End If
			End Set
		End Property
		<Browsable(False)> _
		Public Shadows Property Time() As DateTime
			Get
				Return MyBase.Time
			End Get
			Set(ByVal value As DateTime)
				MyBase.Time = value
			End Set
		End Property
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
		Public Property IPAddress() As String
			Get
				Return EditValue.ToString()
			End Get
			Set(ByVal value As String)
				EditValue = value
			End Set
		End Property

		Protected Overrides Function CreateMaskManager(ByVal mask As MaskProperties) As MaskManager
			Dim patchedMask As New IPAddressEditMaskProperties()
			patchedMask.Assign(mask)
			patchedMask.EditMask = Properties.GetFormatMaskAccessFunction(mask.EditMask, mask.Culture)

			Return patchedMask.CreatePatchedMaskManager()
		End Function
	End Class
End Namespace
