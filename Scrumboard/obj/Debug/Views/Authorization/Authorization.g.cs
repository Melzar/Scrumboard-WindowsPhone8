﻿#pragma checksum "G:\WindowsPhoneApps\Scrumboard\Scrumboard\Views\Authorization\Authorization.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A2FE6835FB00EB187415E9C0EFAE1062"
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


namespace Scrumboard {
    
    
    public partial class Authorization : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Controls.PhoneApplicationPage Authorization1;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Application_Title;
        
        internal System.Windows.Controls.TextBlock Page_Title;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock Authorize_Message;
        
        internal System.Windows.Controls.HyperlinkButton Authorize_Button;
        
        internal System.Windows.Controls.HyperlinkButton Authorize_again_Button;
        
        internal System.Windows.Controls.TextBox Token;
        
        internal System.Windows.Controls.Button Save;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Scrumboard;component/Views/Authorization/Authorization.xaml", System.UriKind.Relative));
            this.Authorization1 = ((Microsoft.Phone.Controls.PhoneApplicationPage)(this.FindName("Authorization1")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Application_Title = ((System.Windows.Controls.TextBlock)(this.FindName("Application_Title")));
            this.Page_Title = ((System.Windows.Controls.TextBlock)(this.FindName("Page_Title")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Authorize_Message = ((System.Windows.Controls.TextBlock)(this.FindName("Authorize_Message")));
            this.Authorize_Button = ((System.Windows.Controls.HyperlinkButton)(this.FindName("Authorize_Button")));
            this.Authorize_again_Button = ((System.Windows.Controls.HyperlinkButton)(this.FindName("Authorize_again_Button")));
            this.Token = ((System.Windows.Controls.TextBox)(this.FindName("Token")));
            this.Save = ((System.Windows.Controls.Button)(this.FindName("Save")));
        }
    }
}

