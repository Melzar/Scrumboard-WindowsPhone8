﻿#pragma checksum "G:\WindowsPhoneApps\Scrumboard\Scrumboard\Views\Authorization\Failed.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF0B1353F5E416C2E7C4705C90F9323B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Scrumboard.Views.Authorization {
    
    
    public partial class Failed : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel_Copy;
        
        internal System.Windows.Controls.TextBlock Status_Title;
        
        internal System.Windows.Controls.TextBlock Status_Body;
        
        internal System.Windows.Controls.Button Go_Back_Authorization;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Scrumboard;component/Views/Authorization/Failed.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel_Copy = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel_Copy")));
            this.Status_Title = ((System.Windows.Controls.TextBlock)(this.FindName("Status_Title")));
            this.Status_Body = ((System.Windows.Controls.TextBlock)(this.FindName("Status_Body")));
            this.Go_Back_Authorization = ((System.Windows.Controls.Button)(this.FindName("Go_Back_Authorization")));
        }
    }
}
