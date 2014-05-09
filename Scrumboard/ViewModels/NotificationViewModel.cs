using Microsoft.Phone.Shell;
using Scrumboard.Integration.Enums;
using Scrumboard.Integration.Mapper;
using Scrumboard.Integration.Utils;
using Scrumboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.ViewModels
{
    public class NotificationViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NotificationType> NotificationCollection { get; set; }

        private bool _IsLoading;
        public bool IsLoading { get { return _IsLoading; } set { _IsLoading = value; NotifyPropertyChanged("IsLoading"); } }

        private string _Visible;
        public string Visible { get { return _Visible; } set { _Visible = value; NotifyPropertyChanged("Visible"); } }

        public NotificationViewModel()
        {
            NotificationCollection = new ObservableCollection<NotificationType>();
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void LoadAllNotificationsPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient notificationclient = new WebClient();
            notificationclient.OpenReadCompleted += RenderMyNotifications;
            notificationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyNotifications), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void LoadMyNotificationsPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient notficationclient = new WebClient();
            notficationclient.OpenReadCompleted += RenderMyNotifications;
            notficationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyNotificationsWithLimit), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], 2)));
        }

        public void LoadBoardNotificationsPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient notificationclient = new WebClient();
            BoardType currentboard = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            notificationclient.OpenReadCompleted += RenderMyNotifications;
            notificationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.BoardActivities), currentboard.ID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
            
        }

        public void RenderMyNotifications(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NotificationType[]));
            NotificationType[] notifications = serializer.ReadObject(e.Result) as NotificationType[];
            EnumMapper mapper = new EnumMapper("NotificationMappings.map");
            NotificationCollection.Clear();
            foreach (NotificationType type in notifications)
            {
                NotificationMapper.SetNotificationMessageForNotification(type, (NotificationEnum.Notifications)mapper.GetMappedValue(type.RawType));
                NotificationCollection.Add(type);
            }
            IsLoading = false;
            Visible = "Collapsed";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
