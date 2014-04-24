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
        private static EnumMapper mapper;

        [DataMember(Name = "id")]
        public string ID {get; set;}

        [DataMember(Name = "unread")]
        public string Unread {get; set;}

        [DataMember(Name = "type")]
        public string RawType { get; set; }

        public string _Type;

        public string Type { 
        get
        {
            mapper = mapper ?? new EnumMapper("NotificationMappings.map");
            return EnumUtil.GetEnumDescription((NotificationEnum.Notifications)mapper.GetMappedValue(RawType));
        }
            set { _Type = value; }
        }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "idMemberCreator")]
        public string IdMemberCreator { get; set; }

        //"data": {
        //    "board": {
        //        "shortLink": "qO9Cj5rA",
        //        "name": "Project 1",
        //        "id": "5325fa0e3051920573824e7f"
        //    }
        //},

        [DataMember(Name="memberCreator")]
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
