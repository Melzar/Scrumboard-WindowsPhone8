using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Models
{
    [DataContract]
    public class CardType : INotifyPropertyChanged
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }

        // check item states contract

        [DataMember(Name = "closed")]
        public bool Closed { get; set; }

        [DataMember(Name = "dateLastActivity")]
        public string DateLastActivity { get; set; }

        [DataMember(Name = "desc")]
        public string Desc { get; set; }

        //[DataMember(Name = "descData")]
        //public string DescData { get; set; }

        [DataMember(Name = "idBoard")]
        public string IdBoard { get; set; }

        [DataMember(Name = "idList")]
        public string IdList { get; set; }

        // members votedcontract 

        [DataMember(Name = "idShort")]
        public string IDShort { get; set; }

        [DataMember(Name = "idAttachmentCover")]
        public string IDAttachementCover { get; set; }

        [DataMember(Name = "manualCoverAttachment")]
        public bool ManualCoverAttachment { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "pos")]
        public string Pos { get; set; }

        [DataMember(Name = "shortLink")]
        public string ShortLink { get; set; }

        [DataMember(Name = "badges")]
        public BadgesType Badges { get; set; }

        public string _Due { get { return Due != null ? Due.Value.ToShortDateString() : null; } }

        [DataMember(Name = "due")]
        public DateTime? Due { get; set; }

        public string Due_Visibility { get { return Due != null ? "Visible" : "Collapsed"; } }

        // checklist contract
        [DataMember(Name = "members")]
        public MemberType[] Members { get; set; }

        [DataMember(Name = "labels")]
        public LabelType[] Labels { get; set; }

        [DataMember(Name = "shortUrl")]
        public string ShortUrl { get; set; }

        [DataMember(Name = "subscribed")]
        public bool Subscribed { get; set; }

        public string Subscribed_Visibility { get { return Subscribed ? "Visible" : "Collapsed"; } }

        public string Unsubscribed_Visibility { get { return Subscribed ? "Collapsed" : "Visible"; } }

        [DataMember(Name = "url")]
        public string URL { get; set; }

        [DataMember(Name= "actions")]
        public NotificationType[] Actions { get; set; }


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
