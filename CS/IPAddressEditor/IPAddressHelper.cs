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
	public class IPAddressHelper
	{
		public static DateTime ToDateTime(IPv4Addr ip)
		{
			byte[] ipParts = ip.ToByteArray();
			string ipStr = "";

			for ( int i = 0; i < ipParts.Length; i++ )
				ipStr += String.Format("{0:d3}", ipParts[i]);

			return new DateTime(Int64.Parse(ipStr));
		}

		public static IPv4Addr ToIPAddress(DateTime dt)
		{
			if ( dt.Ticks == 0 )
				return new IPv4Addr("0.0.0.0");

			string ip = "";

			string strIP = dt.Ticks.ToString();
			while ( strIP.Length < 12 )
				strIP = "0" + strIP;

			while ( strIP != "" )
			{
				ip += Int16.Parse(strIP.Substring(0, 3)).ToString() + ".";
				strIP = strIP.Remove(0, 3);
			}
			ip = ip.Remove(ip.Length - 1);

			return new IPv4Addr(ip);
		}

		public static bool IsConvertible(DateTime dt)
		{
			if ( dt.Ticks > 255255255255 )
				return false;

			return true;
		}
	}
}