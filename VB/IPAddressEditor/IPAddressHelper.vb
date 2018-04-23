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