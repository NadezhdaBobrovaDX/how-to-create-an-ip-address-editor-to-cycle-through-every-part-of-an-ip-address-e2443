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
