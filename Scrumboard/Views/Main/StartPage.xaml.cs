using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Scrumboard.Integration.Enums;
using Scrumboard.Integration.Utils;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Json;
using Scrumboard.Models;
using Scrumboard.ViewModels;
using System.Windows.Data;

namespace Scrumboard
{
    public partial class StartPage : PhoneApplicationPage
    {

        BoardViewModel boardview;
        NotificationViewModel notificationview;
        CardViewModel cardview;

        public StartPage()
        {
            InitializeComponent();
            boardview = (BoardViewModel)Resources["boardView"];
            notificationview = (NotificationViewModel)Resources["notificationView"];
            cardview = (CardViewModel)Resources["cardView"];
            SetBindings();
        }

        private void StartPivot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            boardview.LoadMyBoardsPage();
            notificationview.LoadMyNotificationsPage();
            cardview.LoadMyCardsPage();
        }

        private void AllBoards_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneApplicationService.Current.State["Active"] = 0;
            NavigationService.Navigate(new Uri("/Views/All/AllPages.xaml", UriKind.Relative));
        }

        private void AllNotifications_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneApplicationService.Current.State["Active"] = 1;
            NavigationService.Navigate(new Uri("/Views/All/AllPages.xaml", UriKind.Relative));
        }
        private void AllCards_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneApplicationService.Current.State["Active"] = 2;
            NavigationService.Navigate(new Uri("/Views/All/AllPages.xaml", UriKind.Relative));
        }

        private void SetBindings()
        {
            Binding boardsbinding = new Binding("IsLoading") { Source = boardview };
            BindingOperations.SetBinding(
                LoadingBoards, ProgressBar.IsIndeterminateProperty, boardsbinding);

            Binding vboardsbinding = new Binding("Visible") { Source = boardview };
            BindingOperations.SetBinding(
                LoadingBoards, ProgressBar.VisibilityProperty, vboardsbinding);

            Binding notificationsbinding = new Binding("IsLoading") { Source = notificationview };
            BindingOperations.SetBinding(
                LoadingNotifications, ProgressBar.IsIndeterminateProperty, notificationsbinding);

            Binding vnotificationsbinding = new Binding("Visible") { Source = notificationview };
            BindingOperations.SetBinding(
                LoadingNotifications, ProgressBar.VisibilityProperty, vnotificationsbinding);

            Binding cardsbinding = new Binding("IsLoading") { Source = cardview };
            BindingOperations.SetBinding(
                LoadingCards, ProgressBar.IsIndeterminateProperty, cardsbinding);

            Binding vcardsbinding = new Binding("Visible") { Source = cardview };
            BindingOperations.SetBinding(
                LoadingCards, ProgressBar.VisibilityProperty, vcardsbinding);
        }

        private void board_grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid source = sender as Grid;
            PhoneApplicationService.Current.State["CurrentBoard"] = boardview.BoardCollections.Where(x => x.ID == (string)source.Tag).FirstOrDefault();
            NavigationService.Navigate(new Uri("/Views/Specific/BoardPage.xaml", UriKind.Relative));
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid grid = sender as Grid;
            PhoneApplicationService.Current.State["CurrentCard"] = grid.DataContext;
            NavigationService.Navigate(new Uri("/Views/Specific/CardPage.xaml", UriKind.Relative));
        }
     
    }
}