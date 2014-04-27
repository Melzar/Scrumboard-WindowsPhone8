using Scrumboard.Integration.Enums;
using Scrumboard.Integration.Mapper;
using Scrumboard.Integration.Utils;
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
    public class NotificationType : INotifyPropertyChanged
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }

        [DataMember(Name = "unread")]
        public string Unread { get; set; }

        [DataMember(Name = "type")]
        public string RawType { get; set; }

        public string Type { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "idMemberCreator")]
        public string IdMemberCreator { get; set; }

        [DataMember(Name = "data")]
        public DataType Data { get; set; }

        [DataMember(Name = "member")]
        public MemberType Member { get; set; }

        [DataMember(Name = "memberCreator")]
        public MemberType MemberCreator { get; set; }

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
