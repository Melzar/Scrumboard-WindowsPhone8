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
            board_list.ItemRealized += board_list_ItemRealized;
        }

        private void StartPivot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            boardview.LoadMyBoardsPage();
            notificationview.LoadMyNotificationsPage();
            cardview.LoadMyCardsPage();
        }

        void board_list_ItemRealized(object sender, ItemRealizationEventArgs e)
        {
            //boardview.LoadPage();
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
     
    }
}