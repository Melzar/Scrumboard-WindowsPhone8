using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Models
{
    [DataContract]
    public class BadgesType: INotifyPropertyChanged
    {
   
        [DataMember(Name = "votes")]
        public string Votes {get; set;}

        [DataMember(Name = "viewingMemberVoted")]
        public string ViewingMemberVoted {get; set;}
        
        [DataMember(Name = "subscribed")]
        public string Subscribed {get; set;}
        
        [DataMember(Name = "fogbugz")]
        public string Fogbugz {get; set;}
        
        [DataMember(Name = "checkItems")]
        public string CheckItems {get; set;}
         
        [DataMember(Name = "checkItemsChecked")]
        public string CheckItemsChecked {get; set;}
        
        [DataMember(Name = "comments")]
        public string Comments {get;set;}
         
        [DataMember(Name = "attachments")]
        public string Attachments { get; set;}
        
        [DataMember(Name = "description")]
        public string Description {get; set;}
        
        [DataMember(Name = "due")]
        public string Due {get; set;}


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
