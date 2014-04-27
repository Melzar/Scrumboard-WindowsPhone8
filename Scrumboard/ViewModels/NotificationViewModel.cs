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
        public bool isLoading { get; set; }

        public NotificationViewModel()
        {
            NotificationCollection = new ObservableCollection<NotificationType>();
            isLoading = false;
        }

        public void LoadAllNotificationsPage()
        {
            isLoading = true;
            WebClient notificationclient = new WebClient();
            notificationclient.OpenReadCompleted += RenderMyNotifications;
            notificationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyNotifications), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void LoadMyNotificationsPage()
        {
            isLoading = true;
            WebClient notficationclient = new WebClient();
            notficationclient.OpenReadCompleted += RenderMyNotifications;
            notficationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyNotificationsWithLimit), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], 2)));
        }

        public void RenderMyNotifications(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NotificationType[]));
            NotificationType[] notifications = serializer.ReadObject(e.Result) as NotificationType[];
            EnumMapper mapper = new EnumMapper("NotificationMappings.map");
            NotificationCollection.Clear();
            foreach(NotificationType type in notifications)
            {               
                NotificationMapper.SetNotificationMessageForNotification(type,(NotificationEnum.Notifications)mapper.GetMappedValue(type.RawType));
                NotificationCollection.Add(type);
            }
            isLoading = false;
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
