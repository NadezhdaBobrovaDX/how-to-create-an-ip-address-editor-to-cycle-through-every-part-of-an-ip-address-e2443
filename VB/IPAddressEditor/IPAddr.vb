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
	Public Class IPv4Addr
		Private ip1 As Byte
		Private ip2 As Byte
		Private ip3 As Byte
		Private ip4 As Byte

		Public Sub New()
			ip1 = 0
			ip2 = 0
			ip3 = 0
			ip4 = 0
		End Sub
		Public Sub New(ByVal ipAddress As String)
			Dim ip() As String = ipAddress.Split("."c)

			ip1 = Convert.ToByte(ip(0))
			ip2 = Convert.ToByte(ip(1))
			ip3 = Convert.ToByte(ip(2))
			ip4 = Convert.ToByte(ip(3))
		End Sub
		Public Sub New(ByVal AddressPart1 As Byte, ByVal AddressPart2 As Byte, ByVal AddressPart3 As Byte, ByVal AddressPart4 As Byte)
			ip1 = AddressPart1
			ip2 = AddressPart2
			ip3 = AddressPart3
			ip4 = AddressPart4
		End Sub

		Public Overrides Function ToString() As String
			Return String.Format("{0}.{1}.{2}.{3}", ip1, ip2, ip3, ip4)
		End Function

		Public Function ToStringArray() As String()
			Return New String(3) { ip1.ToString(), ip2.ToString(), ip3.ToString(), ip4.ToString() }
		End Function

		Public Function ToByteArray() As Byte()
			Return New Byte(3) { ip1, ip2, ip3, ip4 }
		End Function
	End Class
End Namespace
