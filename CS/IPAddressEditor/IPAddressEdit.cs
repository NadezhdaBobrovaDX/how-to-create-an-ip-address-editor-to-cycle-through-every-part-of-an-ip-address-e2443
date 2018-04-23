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
using DevExpress.Data.Mask;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;

namespace IPAddressEditor
{
	class IPAddressEdit : TimeEdit
	{
		static IPAddressEdit()
		{
			RepositoryItemIPAddressEdit.Register();
		}
		public IPAddressEdit()
			: base()
		{
			this.fOldEditValue = this.fEditValue = new DateTime(0);
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemIPAddressEdit Properties
		{
			get
			{
				return base.Properties as RepositoryItemIPAddressEdit;
			}
		}
		public override string EditorTypeName
		{
			get
			{
				return RepositoryItemIPAddressEdit.IPAddressEditName;
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override object EditValue
		{
			get
			{
				if ( Properties.ExportMode == ExportMode.DisplayText )
					return Properties.GetDisplayText(null, base.EditValue);

				if ( base.EditValue is DateTime && IPAddressHelper.IsConvertible((DateTime)base.EditValue) )
					return IPAddressHelper.ToIPAddress((DateTime)base.EditValue);

				if ( base.EditValue is IPv4Addr )
					return base.EditValue;

				if ( base.EditValue is string)
					return new IPv4Addr((string)base.EditValue);

				return new IPv4Addr("0.0.0.0");
			}
			set
			{
				if ( value is IPv4Addr )
					base.EditValue = value;
				else if ( value is string && (string)value != "" )
					base.EditValue = new IPv4Addr((string)value);
				else if ( value is DateTime && IPAddressHelper.IsConvertible((DateTime)value) )
					base.EditValue = IPAddressHelper.ToIPAddress((DateTime)value);
				else
					base.EditValue = new IPv4Addr("0.0.0.0");
			}
		}
		[Browsable(false)]
		public new DateTime Time
		{
			get
			{
				return base.Time;
			}
			set
			{
				base.Time = value;
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string IPAddress
		{
			get
			{
				return EditValue.ToString();
			}
			set
			{
				EditValue = value;
			}
		}

		protected override MaskManager CreateMaskManager(MaskProperties mask)
		{
			IPAddressEditMaskProperties patchedMask = new IPAddressEditMaskProperties();
			patchedMask.Assign(mask);
			patchedMask.EditMask = Properties.GetFormatMaskAccessFunction(mask.EditMask, mask.Culture);

			return patchedMask.CreatePatchedMaskManager();
		}
	}
}
