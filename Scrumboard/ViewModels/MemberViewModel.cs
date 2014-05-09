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
    public class MemberViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MemberType> MemberCollections { get; set; }

        public ObservableCollection<MemberType> SearchMemberCollections { get; set; }

        public bool _IsLoading;

        public bool IsLoading { get { return _IsLoading; } set { _IsLoading = value; NotifyPropertyChanged("IsLoading"); } }

        public string _Visible;

        public string Visible { get { return _Visible; } set { _Visible = value; NotifyPropertyChanged("Visible"); } }


        public MemberViewModel()
        {
            MemberCollections = new ObservableCollection<MemberType>();
            SearchMemberCollections = new ObservableCollection<MemberType>();
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void LoadBoardMembersPage()
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient client = new WebClient();
            BoardType currentboard = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            client.OpenReadCompleted += RenderListPage;
            client.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.BoardMembers), currentboard.ID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
        }

        public void SearchForUser(string query)
        {
            WebClient client = new WebClient();
            client.OpenReadCompleted += GetSearchResults;
            client.OpenReadAsync(new Uri(String.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.SearchUser), query)));
        }

        public void AddNewUserToBoard(string boardId, string userID)
        {
            IsLoading = true;
            Visible = "Visible";
            WebClient client = new WebClient();
            client.UploadStringCompleted += AddCompleted;
            client.UploadStringAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.PUTConnections.AddMemberToBoard), boardId, userID, IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])), "PUT", "");

        }

        public void AddCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            BoardType board = JsonConvert.DeserializeObject<BoardType>(e.Result);
            MemberCollections.Clear();
            foreach (MemberType member in board.Members)
            {
                member.Visible = "Visible";
                if (member.AvatarHash != null)
                {
                    member.AvatarURL = string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.UserAvatar), member.AvatarHash);
                    member.Visible = "Collapsed";
                }
                MemberCollections.Add(member);
            }
            IsLoading = false;
            Visible = "Collapsed";
        }

        public void GetSearchResults(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MemberType[]));
            MemberType[] members = serializer.ReadObject(e.Result) as MemberType[];
            SearchMemberCollections.Clear();
            foreach (MemberType member in members)
            {
                SearchMemberCollections.Add(member);
            }
        }

        public void RenderListPage(object sender, OpenReadCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MemberType[]));
            MemberType[] members = serializer.ReadObject(e.Result) as MemberType[];
            MemberCollections.Clear();
            foreach (MemberType member in members)
            {
                member.Visible = "Visible";
                if (member.AvatarHash != null)
                {
                    member.AvatarURL = string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.UserAvatar), member.AvatarHash);
                    member.Visible = "Collapsed";
                }
                MemberCollections.Add(member);
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
