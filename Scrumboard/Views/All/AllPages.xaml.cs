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
                AddNewBoardPage();
        }
     
        public void AddNewBoardPage()
        {
            InputPrompt popup = PhoneApplicationService.Current.State["Sender"] as InputPrompt;
            WebClient client = new WebClient();
            client.UploadStringCompleted += UploadCompleted;
            client.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.POSTConnections.AddBoard),IsolatedStorageSettings.ApplicationSettings["MyToken"],IsolatedStorageSettings.ApplicationSettings["Token"],popup.Value)),"POST");
        }

        public void UploadCompleted(object sender , UploadStringCompletedEventArgs e)
        {
            InputPrompt popup = PhoneApplicationService.Current.State["Sender"] as InputPrompt;
            //popup.
        }


    }
}