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
    public class CardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CardType> CardCollection { get; set; }

        public ObservableCollection<LabelType> CardLabelCollection { get; set; }

        public ObservableCollection<MemberType> CardMemberCollection { get; set; }

        public ObservableCollection<MemberType> CardSearchMemberCollection { get; set; }

        public ObservableCollection<NotificationType> CardCommentCollection { get; set; }

        public CardType SelectedCard { get; set; }

        private bool _IsLoading;
        public bool IsLoading { get { return _IsLoading; } set { _IsLoading = value; NotifyPropertyChanged("IsLoading"); } }

        private string _Visible;
        public string Visible { get { return _Visible; } set { _Visible = value; NotifyPropertyChanged("Visible"); } }

        public CardViewModel()
        {
            CardCollection = new ObservableCollection<CardType>();
            CardLabelCollection = new ObservableCollection<LabelType>();
            CardMemberCollection = new ObservableCollection<MemberType>();
            CardSearchMemberCollection = new ObservableCollection<MemberType>();
            CardCommentCollection = new ObservableCollection<NotificationType>();
            SelectedCard = new CardType();
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void LoadAllMyCardsPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient notificationclient = new WebClient();
            notificationclient.OpenReadCompleted += RenderCards;
            notificationclient.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyCards), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void LoadMyCardsPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient cards = new WebClient();
            cards.OpenReadCompleted += RenderCards;
            cards.OpenReadAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyCardsWithLimit), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], 4)));
        }

        public void LoadCardPage(string cardID)
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient card = new WebClient();
            card.OpenReadCompleted += SetCurrentCard;
            card.OpenReadAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.LoadSpecificCard), cardID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void EditCardDescripton(string cardID, string description)
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient card = new WebClient();
            card.UploadStringCompleted += UpdateCurrentCard;
            card.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.PUTConnections.EditCardDescription), cardID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], description)), "PUT", "");
        }

        public void LoadUsersAutocomplete()
        {
            WebClient card = new WebClient();
            card.OpenReadCompleted += LoadQueryResults;
            card.OpenReadAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.BoardMembers), SelectedCard.IdBoard, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void LoadQueryResults(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MemberType[]));
            MemberType[] members = serializer.ReadObject(e.Result) as MemberType[];
            CardSearchMemberCollection.Clear();
            members.ToList().ForEach(CardSearchMemberCollection.Add);
        }

        public void AddNewUserToCard(string cardId, string userID)
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient client = new WebClient();
            client.UploadStringCompleted += AddCompleted;
            client.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.POSTConnections.AddMemberToCard), cardId, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], userID)), "POST", "");

        }

        public void AddCommentToCard(string cardID, string commentValue)
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient client = new WebClient();
            client.UploadStringCompleted += AddCommentCompleted;
            client.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.POSTConnections.AddCommentToCard), cardID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"], commentValue)), "POST", "");
        }

        public void AddCommentCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            NotificationType comment = JsonConvert.DeserializeObject<NotificationType>(e.Result);
            CardCommentCollection.Insert(0, comment);
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void AddCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            MemberType[] cardmembers = JsonConvert.DeserializeObject<MemberType[]>(e.Result);
            CardMemberCollection.Clear();
            foreach (MemberType member in cardmembers)
            {
                member.Visible = "Visible";
                if (member.AvatarHash != null)
                {
                    member.AvatarURL = string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.UserAvatar), member.AvatarHash);
                    member.Visible = "Collapsed";
                }
                CardMemberCollection.Add(member);
            }
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void UpdateCurrentCard(object sender, UploadStringCompletedEventArgs e)
        {
            CardType card = JsonConvert.DeserializeObject<CardType>(e.Result);
            SelectedCard.Desc = card.Desc;
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void SetCurrentCard(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CardType));
            CardType card = serializer.ReadObject(e.Result) as CardType;
            CardCommentCollection.Clear();
            CardMemberCollection.Clear();
            CardLabelCollection.Clear();
            card.Actions.ToList().ForEach(CardCommentCollection.Add);
            card.Members.ToList().ForEach(CardMemberCollection.Add);
            card.Labels.ToList().ForEach(CardLabelCollection.Add);
            IsLoading = false;
            Visible = "Collapsed";
        }

        private void RenderCards(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CardType[]));
            CardType[] cards = serializer.ReadObject(e.Result) as CardType[];
            CardCollection.Clear();
            cards.ToList().ForEach(CardCollection.Add);
            IsLoading = false;
            Visible = "Collapsed";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
