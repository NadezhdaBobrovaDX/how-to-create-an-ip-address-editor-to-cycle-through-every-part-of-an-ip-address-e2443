Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Mask
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo

Namespace IPAddressEditor
	Friend Class RepositoryItemIPAddressEdit
		Inherits RepositoryItemTimeEdit
		Friend Const IPAddressEditName As String = "IPAddressEdit"

		Shared Sub New()
			Register()
		End Sub
		Public Sub New()
			UpdateFormats()
		End Sub

		Public Shared Sub Register()
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(IPAddressEditName, GetType(IPAddressEdit), GetType(RepositoryItemIPAddressEdit), GetType(BaseSpinEditViewInfo), New ButtonEditPainter(), True))
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return IPAddressEditName
			End Get
		End Property

		<Browsable(False)> _
		Public Overrides ReadOnly Property EditFormat() As FormatInfo
			Get
				Return MyBase.EditFormat
			End Get
		End Property
		<Browsable(False)> _
		Public Overrides ReadOnly Property DisplayFormat() As FormatInfo
			Get
				Return MyBase.DisplayFormat
			End Get
		End Property
		<Browsable(False)> _
		Public Overrides ReadOnly Property Mask() As MaskProperties
			Get
				Return MyBase.Mask
			End Get
		End Property
		<Browsable(False)> _
		Public Shadows Overridable ReadOnly Property EditMask() As String
			Get
				Return "d.h.m.s"
			End Get
		End Property

		Protected Overridable Sub UpdateFormats()
			EditFormat.FormatString = EditMask
			DisplayFormat.FormatString = EditMask
			Mask.EditMask = EditMask
		End Sub
		Public Overrides Overloads Function GetDisplayText(ByVal format As FormatInfo, ByVal editValue As Object) As String
			If TypeOf editValue Is DateTime AndAlso IPAddressHelper.IsConvertible(CDate(editValue)) Then
				Return IPAddressHelper.ToIPAddress(CDate(editValue)).ToString()
			End If

			If TypeOf editValue Is IPv4Addr OrElse TypeOf editValue Is String Then
				Return editValue.ToString()
			End If

			Return GetDisplayText(Nothing, New IPv4Addr("0.0.0.0"))
		End Function
		Protected Friend Overridable Function GetFormatMaskAccessFunction(ByVal editMask As String, ByVal managerCultureInfo As CultureInfo) As String
			Return GetFormatMask(editMask, managerCultureInfo)
		End Function
	End Class
End Namespace
