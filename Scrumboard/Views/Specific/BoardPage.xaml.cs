using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Scrumboard.ViewModels;
using System.Windows.Data;
using Scrumboard.Models;
using Coding4Fun.Toolkit.Controls;
using System.Collections.ObjectModel;
using Scrumboard.Integration.Utils;
using Scrumboard.Integration.Enums;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;

namespace Scrumboard
{
    public partial class BoardPage : PhoneApplicationPage
    {

        NotificationViewModel notificationView;
        ListViewModel listView;
        MemberViewModel memberView;

        public BoardPage()
        {
            InitializeComponent();
            notificationView = (NotificationViewModel)Resources["notificationView"];
            listView = (ListViewModel)Resources["listView"];
            memberView = (MemberViewModel)Resources["memberView"];
            SetBindings();
        }

        private void SetBindings()
        {
            Binding notificationsbinding = new Binding("IsLoading") { Source = notificationView };
            BindingOperations.SetBinding(
                LoadingNotifications, ProgressBar.IsIndeterminateProperty, notificationsbinding);

            Binding vnotificationsbinding = new Binding("Visible") { Source = notificationView };
            BindingOperations.SetBinding(
                LoadingNotifications, ProgressBar.VisibilityProperty, vnotificationsbinding);

            Binding listbinding = new Binding("IsLoading") { Source = listView };
            BindingOperations.SetBinding(
                LoadingLists, ProgressBar.IsIndeterminateProperty, listbinding);

            Binding vlistbinding = new Binding("Visible") { Source = listView };
            BindingOperations.SetBinding(
                LoadingLists, ProgressBar.VisibilityProperty, vlistbinding);

            Binding memberbinding = new Binding("IsLoading") { Source = memberView };
            BindingOperations.SetBinding(
                LoadingMembers, ProgressBar.IsIndeterminateProperty, memberbinding);

            Binding vmemberbinding = new Binding("Visible") { Source = memberView };
            BindingOperations.SetBinding(
                LoadingMembers, ProgressBar.VisibilityProperty, vmemberbinding);
        }

        private void StartPivot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            notificationView.LoadBoardNotificationsPage();
            listView.LoadBoardListPage();
            memberView.LoadBoardMembersPage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SpecificPivot.SelectedIndex = 0;
            BoardType board = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            SpecificPivot.Title = "Scrumboard / Board : " + board.Name;
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MemberType member = memberView.SearchMemberCollections.Where(x => x.Username == MemberAutocomplete.Text).FirstOrDefault();
            BoardType board = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            if (member != null)
                memberView.AddNewUserToBoard(board.ID, member.ID);

        }

        private void MemberAutocomplete_Populating(object sender, PopulatingEventArgs e)
        {
            if (MemberAutocomplete.Text.Length > 2)
            memberView.SearchForUser(MemberAutocomplete.Text);
        }

        private void Add_List_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            InputPrompt input = new InputPrompt();
            input.Completed += Add_Completed;
            input.Title = "Add new List";
            input.Message = "Insert new list name";
            input.IsCancelVisible = true;
            input.Show();
        }

        private void Add_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            PhoneApplicationService.Current.State["Sender"] = sender;
            BoardType board = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            if (e.PopUpResult == PopUpResult.Ok)
                listView.AddNewListPage(board.ID);
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid grid = sender as Grid;
            ListType list = listView.ListCollections.Where(x => x.ID == (string)grid.Tag).FirstOrDefault();
            PhoneApplicationService.Current.State["SelectedList"] = list != null ? listView.ListCollections.IndexOf(list) : 0;
            NavigationService.Navigate(new Uri("/Views/Specific/BoardListPage.xaml", UriKind.Relative));
        }

    }
}