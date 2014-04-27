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
    public class CardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CardType> CardCollection { get; set; }

        public bool isLoading {get;set;}

        public CardViewModel()
        {
            CardCollection = new ObservableCollection<CardType>();
            isLoading = false;
        }
       
        public void LoadAllMyCardsPage()
        {
            isLoading = true;
            WebClient notificationclient = new WebClient();
            notificationclient.OpenReadCompleted += RenderCards;
            notificationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyCards), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void LoadMyCardsPage()
        {
            isLoading = true;
            WebClient cards = new WebClient();
            cards.OpenReadCompleted += RenderCards;
            cards.OpenReadAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyCardsWithLimit), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], 4)));
        }

        private void RenderCards(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CardType[]));
            CardType[] cards = serializer.ReadObject(e.Result) as CardType[];
            CardCollection.Clear();
            cards.ToList().ForEach(CardCollection.Add);
            isLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler !=null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
