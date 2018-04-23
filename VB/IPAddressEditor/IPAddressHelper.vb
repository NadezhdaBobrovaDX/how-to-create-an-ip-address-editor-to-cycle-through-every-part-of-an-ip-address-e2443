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
	Public Class IPAddressHelper
		Public Shared Function ToDateTime(ByVal ip As IPv4Addr) As DateTime
			Dim ipParts() As Byte = ip.ToByteArray()
			Dim ipStr As String = ""

			For i As Integer = 0 To ipParts.Length - 1
				ipStr &= String.Format("{0:d3}", ipParts(i))
			Next i

			Return New DateTime(Int64.Parse(ipStr))
		End Function

		Public Shared Function ToIPAddress(ByVal dt As DateTime) As IPv4Addr
			If dt.Ticks = 0 Then
				Return New IPv4Addr("0.0.0.0")
			End If

			Dim ip As String = ""

			Dim strIP As String = dt.Ticks.ToString()
			Do While strIP.Length < 12
				strIP = "0" & strIP
			Loop

			Do While strIP <> ""
				ip &= Int16.Parse(strIP.Substring(0, 3)).ToString() & "."
				strIP = strIP.Remove(0, 3)
			Loop
			ip = ip.Remove(ip.Length - 1)

			Return New IPv4Addr(ip)
		End Function

		Public Shared Function IsConvertible(ByVal dt As DateTime) As Boolean
			If dt.Ticks > 255255255255 Then
				Return False
			End If

			Return True
		End Function
	End Class
End Namespace