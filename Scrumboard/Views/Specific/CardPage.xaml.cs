using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Scrumboard.ViewModels;
using System.Windows.Data;
using Scrumboard.Models;
using Coding4Fun.Toolkit.Controls;

namespace Scrumboard.Views.Specific
{
    public partial class CardPage : PhoneApplicationPage
    {
        CardViewModel cardView;
        ListViewModel listView;
        BoardViewModel boardView;

        public CardPage()
        {
            InitializeComponent();
            cardView = (CardViewModel)Resources["cardView"];
            listView = (ListViewModel)Resources["listView"];
            boardView = (BoardViewModel)Resources["boardView"];
            SetBindings();
        }

        private void SetBindings()
        {
            Binding cardbinding = new Binding("IsLoading") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingDetails, ProgressBar.IsIndeterminateProperty, cardbinding);

            Binding vcardbinding = new Binding("Visible") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingDetails, ProgressBar.VisibilityProperty, vcardbinding);

            Binding memberbinding = new Binding("IsLoading") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingMembers, ProgressBar.IsIndeterminateProperty, memberbinding);

            Binding vmemberbinding = new Binding("Visible") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingMembers, ProgressBar.VisibilityProperty, vmemberbinding);

            Binding commentbinding = new Binding("IsLoading") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingComments, ProgressBar.IsIndeterminateProperty, commentbinding);

            Binding vcommentbinding = new Binding("Visible") { Source = cardView };
            BindingOperations.SetBinding(
                LoadingComments, ProgressBar.VisibilityProperty, vcommentbinding);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CardType card = PhoneApplicationService.Current.State["CurrentCard"] as CardType;
            CardPivot.Title = "Scrumboard : Card : " + card.Name;
            cardView.SelectedCard = card;
            cardView.LoadCardPage(card.ID);
            cardView.LoadUsersAutocomplete();
            boardView.LoadAllMyBoardsPage();
            listView.LoadBoardListPage();
        }

        private void Edit_Description_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            InputPrompt input = new InputPrompt();
            input.Completed += Edited_Description;
            input.Title = "Edit Card Description";
            input.Message = "Insert new description for card";
            input.IsCancelVisible = true;
            input.Show();
        }

        private void Edited_Description(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            InputPrompt input = sender as InputPrompt;
            CardType card = PhoneApplicationService.Current.State["CurrentCard"] as CardType;
            if (e.PopUpResult == PopUpResult.Ok)
            {
                cardView.EditCardDescripton(card.ID, input.Value);
                Card_Description.Text = input.Value;
            }
        }

        private void MemberAutocomplete_Populating(object sender, PopulatingEventArgs e)
        {
           
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MemberType member = cardView.CardSearchMemberCollection.Where(x => x.Username == MemberAutocomplete.Text).FirstOrDefault();
            MemberType isattached = cardView.CardMemberCollection.Where(x => x.Username == MemberAutocomplete.Text).FirstOrDefault();
            CardType card = PhoneApplicationService.Current.State["CurrentCard"] as CardType;
            if (member != null && isattached == null)
            {
                cardView.AddNewUserToCard(card.ID, member.ID);
            }
            else if (isattached != null)
            {
                MessageBox.Show("Selected member is already attached to this card");
            }
        }

        private void Add_Comment_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            InputPrompt input = new InputPrompt();
            input.Completed += Add_Complete;
            input.Title = "Add comment to card";
            input.Message = "Insert your comment";
            input.IsCancelVisible = true;
            input.Show();
        }

        private void Add_Complete(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            InputPrompt input = sender as InputPrompt;
            CardType card = PhoneApplicationService.Current.State["CurrentCard"] as CardType;
            if (e.PopUpResult == PopUpResult.Ok)
            {
                if(input.Value.Length > 0)
                {
                    cardView.AddCommentToCard(card.ID, input.Value);
                }
                else
                {
                    MessageBox.Show("Minimum comment character length is 1");
                }
            }
        }
    }
}