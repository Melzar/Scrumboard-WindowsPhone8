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
using Coding4Fun.Toolkit.Controls;
using Scrumboard.Integration.Utils;
using Scrumboard.Integration.Enums;
using System.IO.IsolatedStorage;
using System.Windows.Data;
using Scrumboard.Models;
using Newtonsoft.Json;

namespace Scrumboard.Views.All
{
    public partial class AllPages : PhoneApplicationPage
    {

        BoardViewModel boardView;
        CardViewModel cardView;
        NotificationViewModel notificationView;

        public AllPages()
        {
            InitializeComponent();
            boardView = (BoardViewModel)Resources["boardView"];
            cardView = (CardViewModel)Resources["cardView"];
            notificationView = (NotificationViewModel)Resources["notificationView"];
            SetBindings();
        }

        private void AllPivot_Loaded(object sender, RoutedEventArgs e)
        {
            boardView.LoadAllMyBoardsPage();
            cardView.LoadAllMyCardsPage();
            notificationView.LoadAllNotificationsPage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            AllPivot.SelectedIndex = (int?)PhoneApplicationService.Current.State["Active"] ?? 0;
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            InputPrompt input = new InputPrompt();
            input.Completed += Add_Completed;
            input.Title = "Add new Board";
            input.Message = "Insert new board name";
            input.IsCancelVisible = true;
            input.Show();
        }

        private void Add_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            PhoneApplicationService.Current.State["Sender"] = sender;
            if (e.PopUpResult == PopUpResult.Ok)
                boardView.AddNewBoardPage();
        }

        private void SetBindings()
        {
            Binding boardsbinding = new Binding("IsLoading") { Source = boardView };
            BindingOperations.SetBinding(
                LoadingBoards, ProgressBar.IsIndeterminateProperty, boardsbinding);

            Binding vboardsbinding = new Binding("Visible") { Source = boardView };
            BindingOperations.SetBinding(
                LoadingBoards, ProgressBar.VisibilityProperty, vboardsbinding);

            Binding notificationsbinding = new Binding("IsLoading") { Source = notificationView };
            BindingOperations.SetBinding(
                LoadingNotifications, ProgressBar.IsIndeterminateProperty, notificationsbinding);

            Binding vnotificationsbinding = new Binding("Visible") { Source = notificationView };
            BindingOperations.SetBinding(
                LoadingNotifications, ProgressBar.VisibilityProperty, vnotificationsbinding);

            Binding cardsbinding = new Binding("IsLoading") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingCards, ProgressBar.IsIndeterminateProperty, cardsbinding);

            Binding vcardsbinding = new Binding("Visible") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingCards, ProgressBar.VisibilityProperty, vcardsbinding);
        }

        private void board_grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid source = sender as Grid;
            PhoneApplicationService.Current.State["CurrentBoard"] = boardView.BoardCollections.Where(x => x.ID == (string) source.Tag).FirstOrDefault();
            NavigationService.Navigate(new Uri("/Views/Specific/BoardPage.xaml", UriKind.Relative));
        }

    }
}