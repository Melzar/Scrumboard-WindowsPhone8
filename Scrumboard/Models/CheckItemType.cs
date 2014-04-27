using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Models
{
    [DataContract]
    public class CheckItemType
    {
        [DataMember(Name = "id")]
        public string ID {get;set;}

        ///textdata
        
        [DataMember(Name = "state")]
        public string State {get;set;}
        
        [DataMember(Name= "name")]
        public string Name {get;set;}

    }
}
