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
