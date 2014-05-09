using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Scrumboard.Models;
using System.Net;
using Scrumboard.Integration.Utils;
using Scrumboard.Integration.Enums;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Json;
using Microsoft.Phone.Shell;
using Coding4Fun.Toolkit.Controls;
using Newtonsoft.Json;

namespace Scrumboard.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BoardType> BoardCollections { get; set; }

        private bool _IsLoading;
        public bool IsLoading { get { return _IsLoading; } set { _IsLoading = value; NotifyPropertyChanged("IsLoading"); } }

        private string _Visible;
        public string Visible { get { return _Visible; } set { _Visible = value; NotifyPropertyChanged("Visible"); } }

        public BoardViewModel()
        {
            BoardCollections = new ObservableCollection<BoardType>();
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void LoadAllMyBoardsPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient notificationclient = new WebClient();
            notificationclient.OpenReadCompleted += RenderBoards;
            notificationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyBoards), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void LoadMyBoardsPage()
        {
            IsLoading = true;
            Visible = "Visible";
            PhoneApplicationService.Current.State["Limited"] = true;
            WebClient clientMyBoards = new WebClient();
            clientMyBoards.OpenReadCompleted += RenderBoards;
            clientMyBoards.OpenReadAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyBoards), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], 4)));
        }

        public void AddNewBoardPage()
        {
            InputPrompt popup = PhoneApplicationService.Current.State["Sender"] as InputPrompt;
            WebClient client = new WebClient();
            client.UploadStringCompleted += UploadCompleted;
            client.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.POSTConnections.AddBoard), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], popup.Value)), "POST");
        }

        public void UploadCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            BoardType list = JsonConvert.DeserializeObject<BoardType>(e.Result);
            BoardCollections.Add(list);
        }

        private void RenderBoards(object sender, OpenReadCompletedEventArgs args)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BoardType[]));
            BoardType[] boards = serializer.ReadObject(args.Result) as BoardType[];
            BoardCollections.Clear();
            if (PhoneApplicationService.Current.State.ContainsKey("Limited") && (bool)PhoneApplicationService.Current.State["Limited"])
                boards.Take(4).ToList().ForEach(BoardCollections.Add);
            else
                boards.ToList().ForEach(BoardCollections.Add);

            PhoneApplicationService.Current.State["Limited"] = false;
            IsLoading = false;
            Visible = "Collapsed";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
