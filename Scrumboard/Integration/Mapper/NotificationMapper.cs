using Scrumboard.Integration.Enums;
using Scrumboard.Integration.Utils;
using Scrumboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrumboard.Integration.Mapper
{
    public class NotificationMapper
    {
        public static void SetNotificationMessageForNotification(NotificationType notification, NotificationEnum.Notifications notificationtype)
        {
            switch (notificationtype)
            {
                case NotificationEnum.Notifications.addMemberToOrganization:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.addToOrganizationBoard:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.copyBoard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.BoardSource.Name.ToUpper(), notification.Data.Board.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.commentCard:
                case NotificationEnum.Notifications.copyCommentCard:
                case NotificationEnum.Notifications.createCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Card.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.convertToCardFromCheckItem:
                case NotificationEnum.Notifications.copyCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.CardSource.Name.ToUpper(), notification.Data.Card.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.addAttachmentToCard:
                case NotificationEnum.Notifications.deleteAttachmentFromCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Attachment.Name.ToUpper(), notification.Data.Card.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.createBoard:
                case NotificationEnum.Notifications.deleteBoardInvitation:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Board.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.createList:
                case NotificationEnum.Notifications.deleteCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.List.Name.ToUpper(), notification.Data.Board.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.deleteOrganizationInvitation:
                case NotificationEnum.Notifications.createOrganization:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Organization.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.disablePowerUp:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.emailCard:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.enablePowerUp:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.makeAdminOfBoard:
                case NotificationEnum.Notifications.makeObserverOfBoard:
                case NotificationEnum.Notifications.makeNormalMemberOfBoard:
                case NotificationEnum.Notifications.unconfirmedBoardInvitation:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Member.Username.ToUpper(), notification.Data.Board.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.addMemberToBoard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Board.Name.ToUpper());                    
                    if(notification.Member != null)
                        notification.Type = string.Format(EnumUtil.GetEnumDescription(NotificationEnum.Notifications.addMemberToBoardFull), notification.MemberCreator.Username.ToUpper(), notification.Member.Username, notification.Data.Board.Name.ToUpper());                 
                     ; break;
                case NotificationEnum.Notifications.unconfirmedOrganizationInvitation:
                case NotificationEnum.Notifications.makeNormalMemberOfOrganization:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Member.Username.ToUpper(), notification.Data.Organization.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.memberJoinedTrello:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.moveCardFromBoard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Card.Name.ToUpper(), notification.Data.Board.Name.ToUpper(), notification.Data.BoardTarget.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.moveListFromBoard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.List.Name.ToUpper(), notification.Data.Board.Name.ToUpper(), notification.Data.BoardTarget.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.moveCardToBoard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Card.Name.ToUpper(), notification.Data.BoardSource.Name.ToUpper(), notification.Data.Board.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.moveListToBoard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.List.Name.ToUpper(), notification.Data.BoardSource.Name.ToUpper(), notification.Data.Board.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.removeAdminFromBoard:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.removeAdminFromOrganization:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.addChecklistToCard:
                case NotificationEnum.Notifications.removeChecklistFromCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Checklist.Name.ToUpper(), notification.Data.Card.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.removeFromOrganizationBoard:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.removeMemberFromCard:
                case NotificationEnum.Notifications.addMemberToCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Member.Username.ToUpper(), notification.Data.Card.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.updateBoard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Board.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.updateCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Card.Name.ToUpper());
                    if (notification.Data.Card.Closed)
                        notification.Type = string.Format(EnumUtil.GetEnumDescription(NotificationEnum.Notifications.updateCardclosed), notification.MemberCreator.Username.ToUpper(), notification.Data.Card.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.updateCheckItemStateOnCard:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.CheckItem.Name.ToUpper(), notification.Data.Card.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.updateChecklist:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Checklist.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.updateList:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.List.Name.ToUpper());
                    if (notification.Data.List.Closed)
                        notification.Type = string.Format(EnumUtil.GetEnumDescription(NotificationEnum.Notifications.updateListclosed), notification.MemberCreator.Username.ToUpper(), notification.Data.List.Name.ToUpper());
                    ; break;
                case NotificationEnum.Notifications.updateMember:
                    notification.Type = "";
                    ; break;
                case NotificationEnum.Notifications.updateOrganization:
                    notification.Type = string.Format(EnumUtil.GetEnumDescription(notificationtype), notification.MemberCreator.Username.ToUpper(), notification.Data.Organization.Name.ToUpper());
                    ; break;
                //  case NotificationEnum.Notifications.updateCardidList: ; break;
                //  case NotificationEnum.Notifications.updateCarddesc: ; break;
                //  case NotificationEnum.Notifications.updateCardname: ; break;
                //  case NotificationEnum.Notifications.updateListname: ; break;
            }
        }
    }
}
