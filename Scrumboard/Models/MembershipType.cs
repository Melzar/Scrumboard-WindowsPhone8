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
    public class MembershipType : INotifyPropertyChanged
    {
        [DataMember(Name="id")]
        public string ID {get;set;}

        [DataMember(Name="idMember")]
        public string IdMember {get;set;}

        [DataMember(Name="memberType")]
        public string MemberType {get;set;}

        [DataMember(Name="unconfirmed")]
        public bool Unconfirmed {get;set;}

        [DataMember(Name="deactivated")]
        public bool Deactivated {get;set;}

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
