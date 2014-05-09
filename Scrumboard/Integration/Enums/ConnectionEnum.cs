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
            [Description("https://trello.com/1/members/my/boards?key={0}&token={1}&lists=all")]
            MyBoards,
            [Description("https://trello.com/1/members/my/actions?key={0}&token={1}")]
            MyNotifications,    
            [Description("https://trello.com/1/members/my/actions?key={0}&token={1}&limit={2}")]
            MyNotificationsWithLimit,
            [Description("https://trello.com/1/members/my/cards?key={0}&token={1}")]
            MyCards,
            [Description("https://trello.com/1/members/my/cards?key={0}&token={1}&limit={2}")]
            MyCardsWithLimit,
            [Description("https://trello.com/1/cards/{0}?key={1}&token={2}&fields=all&members=true&member_fields=all&actions=commentCard")]
            LoadSpecificCard,
            [Description("https://trello.com/1/boards/{0}/lists?key={1}&token={2}&fields=all")]
            BoardLists,
            [Description("https://trello.com/1/boards/{0}/lists?key={1}&token={2}&fields=all&cards=all")]
            BoardListsWithCards,
            [Description("https://trello.com/1/boards/{0}/actions?key={1}&token={2}")]
            BoardActivities,
            [Description("https://trello.com/1/boards/{0}/members?key={1}&token={2}&fields=all")]
            BoardMembers,
            [Description("https://trello-avatars.s3.amazonaws.com/{0}/170.png")]
            UserAvatar,
            [Description("https://trello.com/1/search/members/?query={0}")]
            SearchUser
        }

        public enum POSTConnections
        {
            [Description("https://trello.com/1/boards?key={0}&token={1}&name={2}")]
            AddBoard,
            [Description("https://trello.com/1/boards/{0}/lists?key={1}&token={2}&name={3}")]
            AddList,
            [Description("https://trello.com/1/lists/{0}/cards?key={1}&token={2}&name={3}")]
            AddCard,
            [Description("https://trello.com/1/cards/{0}/idMembers?key={1}&token={2}&value={3}")]
            AddMemberToCard,
            [Description("https://trello.com/1/cards/{0}/actions/comments?key={1}&token={2}&text={3}")]
            AddCommentToCard,
        }

        public enum PUTConnections
        {
            [Description("https://trello.com/1/boards/{0}/members/{1}?key={2}&token={3}&type=normal")]
            AddMemberToBoard,
            [Description("https://trello.com/1/cards/{0}/desc?key={1}&token={2}&value={3}")]
            EditCardDescription,

        }

        public enum DELETEConnections
        {

        }
    }
}
