using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Scrumboard.Resources;
using System.IO.IsolatedStorage;

namespace Scrumboard
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Splashscreen.Begin();
            Splashscreen.Completed += new EventHandler(SplashScreenComplete);
        }  

        public void SplashScreenComplete(object sender, EventArgs args)
        {
           if( IsolatedStorageSettings.ApplicationSettings.Contains("Token"))
               NavigationService.Navigate(new Uri("/Views/Main/StartPage.xaml", UriKind.Relative));
            else
               NavigationService.Navigate(new Uri("/Views/Authorization/Authorization.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                App.Current.Terminate();
        }
		
	}
}