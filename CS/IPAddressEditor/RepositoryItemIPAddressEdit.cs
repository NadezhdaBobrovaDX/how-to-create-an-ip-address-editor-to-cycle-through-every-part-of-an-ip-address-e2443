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
using System.ComponentModel;
using System.Globalization;
using DevExpress.Utils;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace IPAddressEditor
{
	class RepositoryItemIPAddressEdit : RepositoryItemTimeEdit
	{
		internal const string IPAddressEditName = "IPAddressEdit";

		static RepositoryItemIPAddressEdit()
		{
			Register();
		}
		public RepositoryItemIPAddressEdit()
		{
			UpdateFormats();
		}

		public static void Register()
		{
			EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(IPAddressEditName,
			  typeof(IPAddressEdit), typeof(RepositoryItemIPAddressEdit),
				typeof(BaseSpinEditViewInfo), new ButtonEditPainter(), true));
		}

		public override string EditorTypeName
		{
			get
			{
				return IPAddressEditName;
			}
		}

		[Browsable(false)]
		public override FormatInfo EditFormat
		{
			get
			{
				return base.EditFormat;
			}
		}
		[Browsable(false)]
		public override FormatInfo DisplayFormat
		{
			get
			{
				return base.DisplayFormat;
			}
		}
		[Browsable(false)]
		public override MaskProperties Mask
		{
			get
			{
				return base.Mask;
			}
		}
		[Browsable(false)]
		public new virtual string EditMask
		{
			get
			{
				return "d.h.m.s";
			}
		}

		protected virtual void UpdateFormats()
		{
			EditFormat.FormatString = EditMask;
			DisplayFormat.FormatString = EditMask;
			Mask.EditMask = EditMask;
		}
		public override string GetDisplayText(FormatInfo format, object editValue)
		{
			if ( editValue is DateTime && IPAddressHelper.IsConvertible((DateTime)editValue) )
				return IPAddressHelper.ToIPAddress((DateTime)editValue).ToString();

			if ( editValue is IPv4Addr || editValue is string )
				return editValue.ToString();

			return GetDisplayText(null, new IPv4Addr("0.0.0.0"));
		}
		protected internal virtual string GetFormatMaskAccessFunction(string editMask, CultureInfo managerCultureInfo)
		{
			return GetFormatMask(editMask, managerCultureInfo);
		}
	}
}
