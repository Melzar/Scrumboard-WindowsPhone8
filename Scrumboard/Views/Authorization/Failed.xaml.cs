using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Scrumboard.Views.Authorization
{
    public partial class Failed : PhoneApplicationPage
    {
        public Failed()
        {
            InitializeComponent();
        }

        private void Go_Back_Authorization_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	NavigationService.Navigate(new Uri("/Views/Authorization/Authorization.xaml", UriKind.Relative));
        }
    }
}