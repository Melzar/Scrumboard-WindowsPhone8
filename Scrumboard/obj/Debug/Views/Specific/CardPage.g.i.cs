﻿#pragma checksum "G:\WindowsPhoneApps\Scrumboard\Scrumboard\Views\Specific\CardPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "402D0180F3AC4B9C6009AA43696BA9C8"
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


namespace Scrumboard.Views.Specific {
    
    
    public partial class CardPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot CardPivot;
        
        internal Microsoft.Phone.Controls.PivotItem Details;
        
        internal System.Windows.Controls.Grid Details_Content;
        
        internal System.Windows.Controls.Image Due_Img;
        
        internal System.Windows.Controls.TextBlock DueDate;
        
        internal System.Windows.Controls.ProgressBar LoadingDetails;
        
        internal Microsoft.Phone.Controls.LongListSelector badges_list;
        
        internal System.Windows.Controls.TextBlock Card_Description;
        
        internal System.Windows.Controls.Button Edit_Description;
        
        internal Microsoft.Phone.Controls.PivotItem Members;
        
        internal System.Windows.Controls.Grid Boards_Content;
        
        internal Microsoft.Phone.Controls.AutoCompleteBox MemberAutocomplete;
        
        internal System.Windows.Controls.ProgressBar LoadingMembers;
        
        internal Microsoft.Phone.Controls.LongListSelector member_list;
        
        internal Microsoft.Phone.Controls.PivotItem Comments;
        
        internal System.Windows.Controls.Grid Comment_Content;
        
        internal System.Windows.Controls.Button Add_Comment;
        
        internal System.Windows.Controls.ProgressBar LoadingComments;
        
        internal Microsoft.Phone.Controls.LongListSelector list_list;
        
        internal Microsoft.Phone.Controls.PivotItem Actions;
        
        internal System.Windows.Controls.Grid Actions_Content;
        
        internal System.Windows.Controls.ProgressBar LoadingActions;
        
        internal System.Windows.Controls.Button Date_save;
        
        internal Microsoft.Phone.Controls.DatePicker datePicker;
        
        internal System.Windows.Controls.TextBox Label_Input;
        
        internal System.Windows.Controls.Button Move_board;
        
        internal Microsoft.Phone.Controls.ListPicker board_picker;
        
        internal System.Windows.Controls.Button Move_list;
        
        internal Microsoft.Phone.Controls.ListPicker list_picker;
        
        internal System.Windows.Controls.Button Delete_button;
        
        internal System.Windows.Controls.Button Archive_button;
        
        internal System.Windows.Controls.Button Subscribe_button;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Scrumboard;component/Views/Specific/CardPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CardPivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("CardPivot")));
            this.Details = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Details")));
            this.Details_Content = ((System.Windows.Controls.Grid)(this.FindName("Details_Content")));
            this.Due_Img = ((System.Windows.Controls.Image)(this.FindName("Due_Img")));
            this.DueDate = ((System.Windows.Controls.TextBlock)(this.FindName("DueDate")));
            this.LoadingDetails = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingDetails")));
            this.badges_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("badges_list")));
            this.Card_Description = ((System.Windows.Controls.TextBlock)(this.FindName("Card_Description")));
            this.Edit_Description = ((System.Windows.Controls.Button)(this.FindName("Edit_Description")));
            this.Members = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Members")));
            this.Boards_Content = ((System.Windows.Controls.Grid)(this.FindName("Boards_Content")));
            this.MemberAutocomplete = ((Microsoft.Phone.Controls.AutoCompleteBox)(this.FindName("MemberAutocomplete")));
            this.LoadingMembers = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingMembers")));
            this.member_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("member_list")));
            this.Comments = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Comments")));
            this.Comment_Content = ((System.Windows.Controls.Grid)(this.FindName("Comment_Content")));
            this.Add_Comment = ((System.Windows.Controls.Button)(this.FindName("Add_Comment")));
            this.LoadingComments = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingComments")));
            this.list_list = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("list_list")));
            this.Actions = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Actions")));
            this.Actions_Content = ((System.Windows.Controls.Grid)(this.FindName("Actions_Content")));
            this.LoadingActions = ((System.Windows.Controls.ProgressBar)(this.FindName("LoadingActions")));
            this.Date_save = ((System.Windows.Controls.Button)(this.FindName("Date_save")));
            this.datePicker = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("datePicker")));
            this.Label_Input = ((System.Windows.Controls.TextBox)(this.FindName("Label_Input")));
            this.Move_board = ((System.Windows.Controls.Button)(this.FindName("Move_board")));
            this.board_picker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("board_picker")));
            this.Move_list = ((System.Windows.Controls.Button)(this.FindName("Move_list")));
            this.list_picker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("list_picker")));
            this.Delete_button = ((System.Windows.Controls.Button)(this.FindName("Delete_button")));
            this.Archive_button = ((System.Windows.Controls.Button)(this.FindName("Archive_button")));
            this.Subscribe_button = ((System.Windows.Controls.Button)(this.FindName("Subscribe_button")));
        }
    }
}
