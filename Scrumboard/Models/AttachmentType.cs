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
    public class AttachmentType : INotifyPropertyChanged
    {
        [DataMember(Name="id")]
        public string ID {get;set;}

        [DataMember(Name="previewUrl2x")]
        public string PreviewUrl2x {get;set;}

        [DataMember(Name="previewUrl")]
        public string PreviewUrl {get;set;}

        [DataMember(Name="url")]
        public string Url {get;set;}

        [DataMember(Name="name")]
        public string Name {get; set;}
       
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
               handler(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
