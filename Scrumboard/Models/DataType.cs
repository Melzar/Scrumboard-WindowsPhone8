using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Models
{
    [DataContract]
    public class DataType
    {
        [DataMember(Name = "board")]
        public BoardType Board { get; set; }

        [DataMember(Name = "boardSource")]
        public BoardType BoardSource { get; set; }

        [DataMember(Name = "boardTarget")]
        public BoardType BoardTarget { get; set; }

        [DataMember(Name = "card")]
        public CardType Card { get; set; }

        [DataMember(Name = "cardSource")]
        public CardType CardSource { get; set; }

        [DataMember(Name = "checkItem")]
        public CheckItemType CheckItem { get; set; }

        [DataMember(Name = "attachment")]
        public AttachmentType Attachment { get; set; }

        [DataMember(Name = "checklist")]
        public ChecklistType Checklist { get; set; }

        [DataMember(Name = "list")]
        public ListType List { get; set; }

        [DataMember(Name = "listAfter")]
        public ListType ListAfter { get; set; }

        [DataMember(Name = "listBefore")]
        public ListType ListBefore { get; set; }

        [DataMember(Name = "organization")]
        public OrganizationType Organization { get; set; }
    }
}
