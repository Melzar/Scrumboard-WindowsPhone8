﻿#pragma checksum "G:\WindowsPhoneApps\Scrumboard\Scrumboard\Views\Main\StartPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "814C5EEB4C96A6405500F6F73F32CF1C"
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
    
    
    public partial class StartPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot StartPivot;
        
        internal Microsoft.Phone.Controls.PivotItem Boards;
        
        internal System.Windows.Controls.Grid Boards_Content;
        
        internal System.Windows.Controls.ProgressBar LoadingBoards;
        
        internal Microsoft.Phone.Controls.LongListSelector board_list;
        
        internal System.Windows.Controls.TextBlock AllBoards;
        
        internal Microsoft.Phone.Controls.PivotItem Notifications;
        
        internal System.Windows.Controls.Grid Notification_Content;
        
        internal System.Windows.Controls.ProgressBar LoadingNotifications;
        
        internal Microsoft.Phone.Controls.LongListSelector notification_list;
        
        internal System.Windows.Controls.TextBlock AllNotifications;
        
        internal Microsoft.Phone.Controls.PivotItem Cards;
        
        internal System.Windows.Controls.Grid Card_Content;
        
        internal System.Windows.Controls.ProgressBar LoadingCards;
        
        internal Microsoft.Phone.Controls.LongListSelector card_list;
        
        internal System.Windows.Controls.TextBlock AllCards;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Scrumboard;component/Views/Main/StartPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.StartPivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("StartPivot")));
            this.Boards = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Boards")));
            this.Boards_Content = ((System.Windows.Controls.Grid)(this.FindName("Boards_Content")));
            this.LoadingBoards = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingBoards")));
            this.board_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("board_list")));
            this.AllBoards = ((System.Windows.Controls.TextBlock)(this.FindName("AllBoards")));
            this.Notifications = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Notifications")));
            this.Notification_Content = ((System.Windows.Controls.Grid)(this.FindName("Notification_Content")));
            this.LoadingNotifications = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingNotifications")));
            this.notification_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("notification_list")));
            this.AllNotifications = ((System.Windows.Controls.TextBlock)(this.FindName("AllNotifications")));
            this.Cards = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Cards")));
            this.Card_Content = ((System.Windows.Controls.Grid)(this.FindName("Card_Content")));
            this.LoadingCards = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingCards")));
            this.card_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("card_list")));
            this.AllCards = ((System.Windows.Controls.TextBlock)(this.FindName("AllCards")));
        }
    }
}

