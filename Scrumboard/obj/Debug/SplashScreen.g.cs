﻿#pragma checksum "G:\WindowsPhoneApps\Scrumboard\Scrumboard\SplashScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4D1A4361B1A9553239290A2D203AF85A"
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
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Controls.PhoneApplicationPage SplashScreen;
        
        internal System.Windows.Media.Animation.Storyboard Splashscreen;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image CogTop;
        
        internal System.Windows.Controls.TextBlock Splash_Title;
        
        internal System.Windows.Controls.Image CogMid;
        
        internal System.Windows.Controls.Image CogBot;
        
        internal System.Windows.Controls.TextBlock PoweredBy;
        
        internal System.Windows.Controls.Image CogMid_Copy;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Scrumboard;component/SplashScreen.xaml", System.UriKind.Relative));
            this.SplashScreen = ((Microsoft.Phone.Controls.PhoneApplicationPage)(this.FindName("SplashScreen")));
            this.Splashscreen = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Splashscreen")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CogTop = ((System.Windows.Controls.Image)(this.FindName("CogTop")));
            this.Splash_Title = ((System.Windows.Controls.TextBlock)(this.FindName("Splash_Title")));
            this.CogMid = ((System.Windows.Controls.Image)(this.FindName("CogMid")));
            this.CogBot = ((System.Windows.Controls.Image)(this.FindName("CogBot")));
            this.PoweredBy = ((System.Windows.Controls.TextBlock)(this.FindName("PoweredBy")));
            this.CogMid_Copy = ((System.Windows.Controls.Image)(this.FindName("CogMid_Copy")));
        }
    }
}

