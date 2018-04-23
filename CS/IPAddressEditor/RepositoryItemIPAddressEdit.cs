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
