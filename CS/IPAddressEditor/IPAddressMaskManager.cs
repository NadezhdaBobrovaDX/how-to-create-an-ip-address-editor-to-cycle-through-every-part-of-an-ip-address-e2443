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
using System.Globalization;
using DevExpress.Data.Mask;
using DevExpress.XtraEditors.Mask;

namespace IPAddressEditor
{
	public class IPAddressEditMaskProperties : TimeEditMaskProperties
	{
		public IPAddressEditMaskProperties()
			: base()
		{
		}

		public virtual MaskManager CreatePatchedMaskManager()
		{
			CultureInfo managerCultureInfo = this.Culture;
			if ( managerCultureInfo == null )
				managerCultureInfo = CultureInfo.CurrentCulture;

			string editMask = this.EditMask;
			if ( editMask == null )
				editMask = string.Empty;

			return new IPAddressMaskManager(editMask, false, managerCultureInfo, true);
		}
	}

	public class IPAddressMaskManager : DateTimeMaskManagerCore
	{
		public IPAddressMaskManager(string mask, bool isOperatorMask, CultureInfo culture, bool allowNull)
			: base(mask, isOperatorMask, culture, allowNull)
		{
			fFormatInfo = new IPAddressMaskFormatInfo(mask, this.fInitialDateTimeFormatInfo);
		}

		public override void SetInitialEditText(string initialEditText)
		{
			KillCurrentElementEditor();
			DateTime? initialEditValue = new DateTime(0);

			if ( !string.IsNullOrEmpty(initialEditText) )
				try
				{
					initialEditValue = IPAddressHelper.ToDateTime(new IPv4Addr(initialEditText));
				}
				catch
				{
				}

			SetInitialEditValue(initialEditValue);
		}
	}

	public class IPAddressMaskFormatInfo : DateTimeMaskFormatInfo
	{
		public IPAddressMaskFormatInfo(string mask, DateTimeFormatInfo dateTimeFormatInfo)
			: base(mask, dateTimeFormatInfo)
		{
			for ( int i = 0; i < Count; i++ )
			{
				if ( innerList[i] is DateTimeMaskFormatElement_d )
					innerList[i] = new IPAddressMaskFormatElement("d", dateTimeFormatInfo, 1);

				if ( innerList[i] is DateTimeMaskFormatElement_h12 )
					innerList[i] = new IPAddressMaskFormatElement("h", dateTimeFormatInfo, 2);

				if ( innerList[i] is DateTimeMaskFormatElement_Min )
					innerList[i] = new IPAddressMaskFormatElement("m", dateTimeFormatInfo, 3);

				if ( innerList[i] is DateTimeMaskFormatElement_s )
					innerList[i] = new IPAddressMaskFormatElement("s", dateTimeFormatInfo, 4);
			}
		}
	}

	public class IPAddressMaskFormatElement : DateTimeNumericRangeFormatElementEditable
	{
		private int ipAddressPart = -1;

		public IPAddressMaskFormatElement(string mask, DateTimeFormatInfo datetimeFormatInfo, int IPAddressPartNumber)
			: base(mask, datetimeFormatInfo, DateTimePart.Time)
		{
			ipAddressPart = IPAddressPartNumber - 1;
		}

		public override DateTimeElementEditor CreateElementEditor(DateTime editedDateTime)
		{
			return new DateTimeNumericRangeElementEditor(GetIpAddressPart(editedDateTime, ipAddressPart), 0, 255, 1, 3);
		}

		public override DateTime ApplyElement(int result, DateTime editedDateTime)
		{
			string[] ipSplitted = IPAddressHelper.ToIPAddress(editedDateTime).ToStringArray();

			for ( int i = 0; i < ipSplitted.Length; i++ )
			{
				if ( i == ipAddressPart )
					ipSplitted[i] = String.Format("{0:d3}", result);
				else
					ipSplitted[i] = String.Format("{0:d3}", Convert.ToInt16(ipSplitted[i]));
			}

			return IPAddressHelper.ToDateTime(new IPv4Addr(String.Join(".", ipSplitted)));
		}

		public override string Format(DateTime formattedDateTime)
		{
			return GetIpAddressPart(formattedDateTime, ipAddressPart).ToString();
		}

		protected virtual int GetIpAddressPart(DateTime dt, int partNumber)
		{
			if ( partNumber < 0 || partNumber > 3 )
				throw new Exception("Given part number is out of IPv4 address parts");

			string[] ipSplitted = IPAddressHelper.ToIPAddress(dt).ToStringArray();
			return Convert.ToInt16(ipSplitted[partNumber]);
		}
	}
}