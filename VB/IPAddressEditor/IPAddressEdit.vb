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
