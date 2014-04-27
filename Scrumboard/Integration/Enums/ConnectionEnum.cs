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
            [Description("https://trello.com/1/members/my/actions?key={0}&token={1}")]
            MyNotifications,
            [Description("https://trello.com/1/members/my/cards?key={0}&token={1}")]
            MyCards,
            [Description("https://trello.com/1/members/my/boards?key={0}&token={1}&limit={2}")]
            MyBoardsWithLimit,
            [Description("https://trello.com/1/members/my/actions?key={0}&token={1}&limit={2}")]
            MyNotificationsWithLimit,
            [Description("https://trello.com/1/members/my/cards?key={0}&token={1}&limit={2}")]
            MyCardsWithLimit
        }

        public enum POSTConnections
        {
            [Description("https://trello.com/1/boards?key={0}&token={1}&name={2}")]
            AddBoard
        }

        public enum PUTConnections
        {

        }

        public enum DELETEConnections
        {

        }
    }
}
