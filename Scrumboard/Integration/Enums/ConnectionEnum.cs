using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Integration.Enums
{
    public class ConnectionEnum
    {
            public enum GETConnections
            {
                [Description("https://trello.com/1/members/my/boards?key={0}&token={1}")]
                MyBoards,
                [Description("https://trello.com/1/members/my/notifications?key={0}&token={1}")]
                MyNotifications,
                [Description("https://trello.com/1/membets/my/?key={0}&token={1}&cards=all")]
                MyCards
            }

            public enum POSTConnections
            {

            }

            public enum PUTConnections
            {

            }

            public enum DELETEConnections
            {

            }
    }
}
