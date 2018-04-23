Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports DevExpress.Data.Mask
Imports DevExpress.XtraEditors.Mask

Namespace IPAddressEditor
	Public Class IPAddressEditMaskProperties
		Inherits TimeEditMaskProperties
		Public Sub New()
			MyBase.New()
		End Sub

		Public Overridable Function CreatePatchedMaskManager() As MaskManager
			Dim managerCultureInfo As CultureInfo = Me.Culture
			If managerCultureInfo Is Nothing Then
				managerCultureInfo = CultureInfo.CurrentCulture
			End If

			Dim editMask As String = Me.EditMask
			If editMask Is Nothing Then
				editMask = String.Empty
			End If

			Return New IPAddressMaskManager(editMask, False, managerCultureInfo, True)
		End Function
	End Class

	Public Class IPAddressMaskManager
		Inherits DateTimeMaskManager
		Public Sub New(ByVal mask As String, ByVal isOperatorMask As Boolean, ByVal culture As CultureInfo, ByVal allowNull As Boolean)
			MyBase.New(mask, isOperatorMask, culture, allowNull)
			fFormatInfo = New IPAddressMaskFormatInfo(mask, Me.fInitialDateTimeFormatInfo)
		End Sub

		Public Overrides Sub SetInitialEditText(ByVal initialEditText As String)
			KillCurrentElementEditor()
			Dim initialEditValue As Nullable(Of DateTime) = New DateTime(0)

			If (Not String.IsNullOrEmpty(initialEditText)) Then
				Try
					initialEditValue = IPAddressHelper.ToDateTime(New IPv4Addr(initialEditText))
				Catch
				End Try
			End If

			SetInitialEditValue(initialEditValue)
		End Sub
	End Class

	Public Class IPAddressMaskFormatInfo
		Inherits DateTimeMaskFormatInfo
		Public Sub New(ByVal mask As String, ByVal dateTimeFormatInfo As DateTimeFormatInfo)
			MyBase.New(mask, dateTimeFormatInfo)
			For i As Integer = 0 To Count - 1
				If TypeOf innerList(i) Is DateTimeMaskFormatElement_d Then
					innerList(i) = New IPAddressMaskFormatElement("d", dateTimeFormatInfo, 1)
				End If

				If TypeOf innerList(i) Is DateTimeMaskFormatElement_h12 Then
					innerList(i) = New IPAddressMaskFormatElement("h", dateTimeFormatInfo, 2)
				End If

				If TypeOf innerList(i) Is DateTimeMaskFormatElement_Min Then
					innerList(i) = New IPAddressMaskFormatElement("m", dateTimeFormatInfo, 3)
				End If

				If TypeOf innerList(i) Is DateTimeMaskFormatElement_s Then
					innerList(i) = New IPAddressMaskFormatElement("s", dateTimeFormatInfo, 4)
				End If
			Next i
		End Sub
	End Class

	Public Class IPAddressMaskFormatElement
		Inherits DateTimeNumericRangeFormatElementEditable
		Private ipAddressPart As Integer = -1

		Public Sub New(ByVal mask As String, ByVal datetimeFormatInfo As DateTimeFormatInfo, ByVal IPAddressPartNumber As Integer)
			MyBase.New(mask, datetimeFormatInfo, DateTimePart.Time)
			ipAddressPart = IPAddressPartNumber - 1
		End Sub

		Public Overrides Function CreateElementEditor(ByVal editedDateTime As DateTime) As DateTimeElementEditor
			Return New DateTimeNumericRangeElementEditor(GetIpAddressPart(editedDateTime, ipAddressPart), 0, 255, 1, 3)
		End Function

		Public Overrides Function ApplyElement(ByVal result As Integer, ByVal editedDateTime As DateTime) As DateTime
			Dim ipSplitted() As String = IPAddressHelper.ToIPAddress(editedDateTime).ToStringArray()

			For i As Integer = 0 To ipSplitted.Length - 1
				If i = ipAddressPart Then
					ipSplitted(i) = String.Format("{0:d3}", result)
				Else
					ipSplitted(i) = String.Format("{0:d3}", Convert.ToInt16(ipSplitted(i)))
				End If
			Next i

			Return IPAddressHelper.ToDateTime(New IPv4Addr(String.Join(".", ipSplitted)))
		End Function

		Public Overrides Function Format(ByVal formattedDateTime As DateTime) As String
			Return GetIpAddressPart(formattedDateTime, ipAddressPart).ToString()
		End Function

		Protected Overridable Function GetIpAddressPart(ByVal dt As DateTime, ByVal partNumber As Integer) As Integer
			If partNumber < 0 OrElse partNumber > 3 Then
				Throw New Exception("Given part number is out of IPv4 address parts")
			End If

			Dim ipSplitted() As String = IPAddressHelper.ToIPAddress(dt).ToStringArray()
			Return Convert.ToInt16(ipSplitted(partNumber))
		End Function
	End Class
End Namespace