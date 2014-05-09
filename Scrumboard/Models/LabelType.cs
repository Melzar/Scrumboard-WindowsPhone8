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
    public class LabelType : INotifyPropertyChanged
    {
        public string _Color;

        [DataMember(Name = "color")]
        public string Color { get { return _Color == "yellow" ? "#dbdb57" : _Color; } set { _Color = value; } }

        [DataMember(Name = "name")]
        public string Name { get; set; }

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
