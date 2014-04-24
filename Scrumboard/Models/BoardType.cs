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
    public class BoardType : INotifyPropertyChanged
    {
        [DataMember(Name="id")]
        public string ID { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="desc")]
        public string Desc { get; set; }

        [DataMember(Name="descData")]
        public string DescData { get; set; }
        
        [DataMember(Name="closed")]
        public bool Closed { get; set; }

        [DataMember(Name="idOrganization")]
        public string IdOrganization { get; set; }

        [DataMember(Name="invited")]
        public bool Invited { get; set; }

        [DataMember(Name="pinned")]
        public bool Pinned { get; set; }

        [DataMember(Name="starred")]
        public bool Starred { get; set; }

        [DataMember(Name="url")]
        public string URL { get; set; }

        //preferences contract

        //invitations contract

        //memberships contract

        [DataMember(Name="shortLink")]
        public string ShortLink { get; set; }

        [DataMember(Name="subscribed")]
        public string Subscribed { get; set; }

        //label contract

        //powerUp cotract

        [DataMember(Name="dateLastActivity")]
        public string DateLastActivity { get; set; }

        [DataMember(Name="dateLastView")]
        public string DateLastView { get; set; }

        [DataMember(Name="shortUrl")]
        public string ShortUrl { get; set; }

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
