﻿#pragma checksum "G:\WindowsPhoneApps\Scrumboard\Scrumboard\Views\Specific\BoardPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7B30629A3F7C18F9AEF1CC414C6DAFF7"
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
    
    
    public partial class BoardPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot SpecificPivot;
        
        internal Microsoft.Phone.Controls.PivotItem Activities;
        
        internal System.Windows.Controls.Grid Notification_Content;
        
        internal System.Windows.Controls.ProgressBar LoadingNotifications;
        
        internal Microsoft.Phone.Controls.LongListSelector activities_list;
        
        internal Microsoft.Phone.Controls.PivotItem Members;
        
        internal System.Windows.Controls.Grid Boards_Content;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox MemberAutocomplete;
        
        internal System.Windows.Controls.ProgressBar LoadingMembers;
        
        internal Microsoft.Phone.Controls.LongListSelector member_list;
        
        internal Microsoft.Phone.Controls.PivotItem Lists;
        
        internal System.Windows.Controls.Grid List_Content;
        
        internal System.Windows.Controls.Button Add_List;
        
        internal System.Windows.Controls.ProgressBar LoadingLists;
        
        internal Microsoft.Phone.Controls.LongListSelector list_list;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Scrumboard;component/Views/Specific/BoardPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.SpecificPivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("SpecificPivot")));
            this.Activities = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Activities")));
            this.Notification_Content = ((System.Windows.Controls.Grid)(this.FindName("Notification_Content")));
            this.LoadingNotifications = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingNotifications")));
            this.activities_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("activities_list")));
            this.Members = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Members")));
            this.Boards_Content = ((System.Windows.Controls.Grid)(this.FindName("Boards_Content")));
            this.MemberAutocomplete = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("MemberAutocomplete")));
            this.LoadingMembers = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingMembers")));
            this.member_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("member_list")));
            this.Lists = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Lists")));
            this.List_Content = ((System.Windows.Controls.Grid)(this.FindName("List_Content")));
            this.Add_List = ((System.Windows.Controls.Button)(this.FindName("Add_List")));
            this.LoadingLists = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingLists")));
            this.list_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("list_list")));
        }
    }
}

