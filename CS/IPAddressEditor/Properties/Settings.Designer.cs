﻿// Developer Express Code Central Example:
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

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPAddressEditor.Properties
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }
    }
}
