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
    public class MemberType : INotifyPropertyChanged
    {
        [DataMember(Name="id")]
        public string ID { get; set; }
        
        [DataMember(Name="avatarHash")]
        public string AvatarHash { get; set; }
        
        [DataMember(Name="fullName")]
        public string FullName { get; set; }

        [DataMember(Name="initials")]
        public string Initials { get; set; }

        [DataMember(Name="username")]
        public string Username { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged (string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
