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