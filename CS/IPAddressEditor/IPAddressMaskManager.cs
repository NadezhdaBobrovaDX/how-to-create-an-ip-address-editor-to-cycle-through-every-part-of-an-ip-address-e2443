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

	public class IPAddressMaskManager : DateTimeMaskManager
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