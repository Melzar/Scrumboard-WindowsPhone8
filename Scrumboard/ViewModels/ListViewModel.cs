using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using Scrumboard.Integration.Enums;
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
    public class ListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ListType> ListCollections { get; set; }

        public bool _IsLoading;

        public bool IsLoading { get { return _IsLoading; } set { _IsLoading = value; NotifyPropertyChanged("IsLoading"); } }

        public string _Visible;

        public string Visible { get { return _Visible; } set { _Visible = value; NotifyPropertyChanged("Visible"); } }

        public ListViewModel()
        {
            ListCollections = new ObservableCollection<ListType>();
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void LoadBoardListPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient client = new WebClient();
            BoardType currentboard = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            client.OpenReadCompleted += RenderListPage;
            client.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.BoardLists), currentboard.ID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void LoadBoardListPageWithCards()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient client = new WebClient();
            BoardType currentboard = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            client.OpenReadCompleted += RenderListPage;
            client.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.BoardListsWithCards), currentboard.ID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void AddNewListPage(string boardID)
        {
            InputPrompt popup = PhoneApplicationService.Current.State["Sender"] as InputPrompt;
            WebClient client = new WebClient();
            client.UploadStringCompleted += UploadCompleted;
            client.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.POSTConnections.AddList), boardID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], popup.Value)), "POST");
        }

        public void AddNewCardToList(string listID, string cardname)
        {
            WebClient client = new WebClient();
            client.UploadStringCompleted += CardUploadCompleted;
            client.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.POSTConnections.AddCard), listID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], cardname)), "POST");
        }

        private void UploadCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            ListType list = JsonConvert.DeserializeObject<ListType>(e.Result);
            ListCollections.Add(list);
        }

        private void CardUploadCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            CardType card = JsonConvert.DeserializeObject<CardType>(e.Result);
            ListType list = ListCollections.Where(x => x.ID == card.IdList).FirstOrDefault();
            if (list != null)
                list.Cards_Observable.Add(card);
        }

        public void RenderListPage(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ListType[]));
            ListType[] lists = serializer.ReadObject(e.Result) as ListType[];
            ListCollections.Clear();
            foreach (ListType list in lists)
            {
                if (list.Cards != null)
                {
                    list.Cards_Observable = new ObservableCollection<CardType>();
                    list.Cards.ToList().ForEach(list.Cards_Observable.Add);
                }
                ListCollections.Add(list);
            }
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
