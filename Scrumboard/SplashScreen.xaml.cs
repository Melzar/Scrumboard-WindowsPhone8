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
            //if Authenticated application ---> move to main page or pivot with my page etc
            // else move to authentication
            NavigationService.Navigate(new Uri("/Views/Authorization/Authorization.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                App.Current.Terminate();
        }
		
	}
}