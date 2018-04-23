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

using System;

namespace IPAddressEditor
{
	public class IPv4Addr
	{
		private byte ip1;
		private byte ip2;
		private byte ip3;
		private byte ip4;

		public IPv4Addr()
		{
			ip1 = 0;
			ip2 = 0;
			ip3 = 0;
			ip4 = 0;
		}
		public IPv4Addr(string ipAddress)
		{
			string[] ip = ipAddress.Split('.');

			ip1 = Convert.ToByte(ip[0]);
			ip2 = Convert.ToByte(ip[1]);
			ip3 = Convert.ToByte(ip[2]);
			ip4 = Convert.ToByte(ip[3]);
		}
		public IPv4Addr(byte AddressPart1, byte AddressPart2, byte AddressPart3, byte AddressPart4)
		{
			ip1 = AddressPart1;
			ip2 = AddressPart2;
			ip3 = AddressPart3;
			ip4 = AddressPart4;
		}

		public override string ToString()
		{
			return String.Format("{0}.{1}.{2}.{3}", ip1, ip2, ip3, ip4);
		}

		public string[] ToStringArray()
		{
			return new string[4] { ip1.ToString(), ip2.ToString(), ip3.ToString(), ip4.ToString() };
		}

		public byte[] ToByteArray()
		{
			return new byte[4] { ip1, ip2, ip3, ip4 };
		}
	}
}
