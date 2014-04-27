using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Integration.Enums
{
    public class NotificationEnum
    {

        public enum Notifications
        {
            //Member Creator Full Name added [att_file_name.ext](https://example.com/url) attachment to card [Card Name]"
            [Description("{0} added {1} attachment to card {2}")]
            addAttachmentToCard = 0,
            //Member Creator Full Name added checklist **Checklist Name** to card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} added checklist {1} to card {2}")]
            addChecklistToCard = 1,
            //Member Creator Full Name added **Member Full Name** to board [board Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} added new user to board {1}")]
            addMemberToBoard = 2,
            [Description("{0} added user {1} to board {2}")]
            addMemberToBoardFull,
            //Member Creator Full Name added **Member Full Name** to card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} added {1} to card {2}")]
            addMemberToCard = 3,
            //Member Creator Full Name added **Member Full Name** to organization [Organization Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} added {1} to organization {2}")]
            addMemberToOrganization = 4,
            //Member Creator Full Name added organization **Organization Name** to board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} added organization {1} to board {2}")]
            addToOrganizationBoard = 5,
            //Member Creator Full Name commented on card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid) 
            //>Some data text that has a number of words in it.
            [Description("{0} commented on card {1}")]
            commentCard = 6,
            [Description("{0} copied comment to card {1}")]
            copyCommentCard = 7,
            //Member Creator Full Name converted checklist item from **Card Source Name** to card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} converted checklist item from {1} to card {2}")]
            convertToCardFromCheckItem = 8,
            //Member Creator Full Name copied board **Board Source Name** to [Board Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} copied board {1} to {2}")]
            copyBoard = 9,
            //Member Creator Full Name created board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} created board {1}")]
            createBoard = 10,
            //Member Creator Full Name created card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} created card {1}")]
            createCard = 11,
            //Member Creator Full Name copied card **Card Source Name** to [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} copied card {1} to {2}")]
            copyCard = 12,
            //Member Creator Full Name created list **List Name** on board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} created list {1} on board {2}")]
            createList = 13,
            //Member Creator Full Name created organization **Organization Name**(https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} created organization {1}")]
            createOrganization = 14,
            //Member Creator Full Name deleted attachment **att_file_name.ext** from card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{1} deleted attachment {1} from card {2}")]
            deleteAttachmentFromCard = 15,
            //Member Creator Full Name deleted invitation to board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} deleted invitation to board {1}")]
            deleteBoardInvitation = 16,
            //Member Creator Full Name deleted card from list **List Name** on board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} deleted card from list {1} on board {2}")]
            deleteCard = 17,
            //Member Creator Full Name deleted invitation to organization [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} deleted invitation to organization {1}")]
            deleteOrganizationInvitation = 18,

            disablePowerUp = 19,
            emailCard = 20,
            enablePowerUp = 21,
            //Member Creator Full Name made **Member Full Name** an admin of board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} made {1} an admin of board {2}")]
            makeAdminOfBoard = 22,
            //Member Creator Full Name made **Member Full Name** an normal member of board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} made {1} an normal member of board {2}")]
            makeNormalMemberOfBoard = 23,
            //Member Creator Full Name made **Member Full Name** an normal member of organization [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} made {1} an normal member of organization {2}")]
            makeNormalMemberOfOrganization = 24,
            //Member Creator Full Name made **Member Full Name** an observer of organization [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} made {1} an observer of board {2}")]
            makeObserverOfBoard = 25,
            //Member Creator Full Name Joined Trello
            [Description("{0} Joined Trello")]
            memberJoinedTrello = 26,
            //Member Creator Full Name moved card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid) from **Board One** to **Board Target Name**
            [Description("{0} moved card {1} from {2} to {3}")]
            moveCardFromBoard = 27,
            //Member Creator Full Name moved list **List Name** from **Board One** to **Board Target Name**
            [Description("{0} moved list {1} from {2} to {3}")]
            moveListFromBoard = 28,
            //Member Creator Full Name moved card **Card Name** from list **List One** to **List Target Name**
            [Description("{0} moved card {1} from board {2} to board {3}")]
            moveCardToBoard = 29,
            //Member Creator Full Name moved list **Card Name** from board **Board One** to **Board Target Name**
            [Description("{0} moved list {1} from board {2} to board {3}")]
            moveListToBoard = 30,

            //Member Creator Full Name removed admin **Admin Name** from board [Board Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} removed admin {1} from board {2}")]
            removeAdminFromBoard = 31,
            //Member Creator Full Name removed Admin **Admin Name** from organization [Organization Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} removed admin {1} from organization {2}")]
            removeAdminFromOrganization = 32,
            //Member Creator Full Name removed checklist **Checklist Name** from card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} removed checklist {1} from card {2}")]
            removeChecklistFromCard = 33,
            removeFromOrganizationBoard = 34,
            //Member Creator Full Name removed **Member Full Name** from card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} removed {1} from card {2}")]
            removeMemberFromCard = 35,
            //Member Creator Full Name invited (unconfirmed) **Member Creator Full Name** to board [Board One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} invited (unconfirmed) {1} to board {2}")]
            unconfirmedBoardInvitation = 36,
            //Member Creator Full Name invited (unconfirmed) **Member Creator Full Name** to organization [Organization One](https://trello.com/board/b1idb1idb1idb1idb1idb1id)
            [Description("{0} invited (unconfirmed) {1} to organization {2}")]
            unconfirmedOrganizationInvitation = 37,
            [Description("{0} updated board {1}")]
            updateBoard = 38,
            [Description("{0} updated card {1}")]
            updateCard = 39,
            //Member Creator Full Name checked **Check Item Name** on card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} checked {1} on card {2}")]
            updateCheckItemStateOnCard = 40,
            [Description("{0} updated checklist {1}")]
            updateChecklist = 41,
            [Description("{0} updated list {1}")]
            updateList = 42,
            [Description("{0} updated member {1}")]
            updateMember = 43,
            [Description("{0} updated organization {1}")]
            updateOrganization = 44,
            //Member Creator Full Name moved card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid) from **List Before Name** to **List After Name**
            [Description("{0} moved card {1} from {2} to {3}")]
            updateCardidList = 45,
            //Member Creator Full Name archived card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} archived card {1}")]
            updateCardclosed = 46,
            //Member Creator Full Name updated description for card [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} updated description for card {1}")]
            updateCarddesc = 47,
            //Member Creator Full Name renamed card from **Old Name** to [Card Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} renamed card from {1} to {2}")]
            updateCardname = 48,
            //Member Creator Full Name archived list [List Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} archived list {1}")]
            updateListclosed = 49,
            //Member Creator Full Name renamed list from **Old Name** to [List Name](https://trello.com/c/cidcidcidcidcidcidcidcid)
            [Description("{0} renamed list from {1} to {2}")]
            updateListname = 50,
        }




    }
}
