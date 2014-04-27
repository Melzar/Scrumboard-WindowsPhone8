using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace Scrumboard
{
    public partial class Authorization : PhoneApplicationPage
    {
        public Authorization()
        {
            InitializeComponent();
            Authorize_Button.NavigateUri = new Uri("https://trello.com/1/authorize?key=cdbaafab040e4588feb88455f3a792f8&name=Scrumboard&expiration=never&response_type=token&scope=read,write", UriKind.Absolute);
            Authorize_Button.TargetName = "_blank";
            Authorize_again_Button.NavigateUri = new Uri("https://trello.com/1/authorize?key=cdbaafab040e4588feb88455f3a792f8&name=Scrumboard&expiration=never&response_type=token&scope=read,write", UriKind.Absolute);
            Authorize_again_Button.TargetName = "_blank";
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {


        }

        private void Authorize_Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Token.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Visible;
            Authorize_again_Button.Visibility = Visibility.Visible;
            Authorize_Button.Visibility = Visibility.Collapsed;
        }

        private void Save_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Token.Text.Length > 0)
            {
                WebClient client = new WebClient();
                client.OpenReadCompleted += new OpenReadCompletedEventHandler(AsyncTestCompleted);
                client.OpenReadAsync(new Uri(String.Format("https://trello.com/1/members/my/boards?key={0}&token={1}", "cdbaafab040e4588feb88455f3a792f8", Token.Text)));
            }
            else
                MessageBox.Show("Token input cannot be empty!");
        }

        private void AsyncTestCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                IsolatedStorageSettings.ApplicationSettings["MyToken"] = "cdbaafab040e4588feb88455f3a792f8";
                IsolatedStorageSettings.ApplicationSettings["Token"] = Token.Text;
                IsolatedStorageSettings.ApplicationSettings.Save();
                NavigationService.Navigate(new Uri("/Views/Authorization/Successful.xaml", UriKind.Relative));
            }
            else
                NavigationService.Navigate(new Uri("/Views/Authorization/Failed.xaml", UriKind.Relative));
        }
    }
}