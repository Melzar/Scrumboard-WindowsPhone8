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

namespace Scrumboard.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged  
    {
        public ObservableCollection<BoardType> BoardCollections { get; set; }

        public bool isLoading { get; set; }

        public BoardViewModel()
        {
            BoardCollections = new ObservableCollection<BoardType>();
            isLoading = false;
        }

        public void LoadMyBoardsPage()
        {
            isLoading = true;
            WebClient clientMyBoards = new WebClient();
            clientMyBoards.OpenReadCompleted += new OpenReadCompletedEventHandler(RenderMyBoards);
            clientMyBoards.OpenReadAsync(new Uri(string.Format(EnumUtil.GetEnumDescription(ConnectionEnum.GETConnections.MyBoards), IsolatedStorageSettings.ApplicationSettings["MyToken"], IsolatedStorageSettings.ApplicationSettings["Token"])));
                    
        }

        private void RenderMyBoards(object sender, OpenReadCompletedEventArgs args)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BoardType[]));
            BoardType[] boards = serializer.ReadObject(args.Result) as BoardType[];
            boards.Take(4).ToList().ForEach(BoardCollections.Add);
            isLoading = false;
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
