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
    public partial class BoardListPage : PhoneApplicationPage
    {

        ListViewModel listView;
        CardViewModel cardView;

        public BoardListPage()
        {
            InitializeComponent();
            listView = (ListViewModel)Resources["listView"];
            cardView = (CardViewModel)Resources["cardView"];
            SetBindings();
        }

        private void SetBindings()
        {

            //Binding listbinding = new Binding("SelectedIndex") { Source = listView };
            //BindingOperations.SetBinding(
            //    ListPivot, Pivot.SelectedIndexProperty, listbinding);

            //Binding vlistbinding = new Binding("Visible") { Source = listView };
            //BindingOperations.SetBinding(
            //    LoadingLists, ProgressBar.VisibilityProperty, vlistbinding);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            BoardType board = PhoneApplicationService.Current.State["CurrentBoard"] as BoardType;
            ListPivot.Title = "Scrumboard / Board : " + board.Name;
            listView.LoadBoardListPageWithCards(); 
        }

        private void Add_card_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Button button = sender as Button;
            InputPrompt input = new InputPrompt();
            input.Tag = button.Tag;
            input.Completed += Add_Completed;
            input.Title = "Add new card to this list";
            input.Message = "Insert new card name";
            input.IsCancelVisible = true;
            input.Show();
        }

        private void Add_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            InputPrompt input = sender as InputPrompt;
            PhoneApplicationService.Current.State["CurrentListID"] = input.Tag ;
            if (e.PopUpResult == PopUpResult.Ok && input.Value != null)
                listView.AddNewCardToList((string)input.Tag, input.Value);
            else if (input.Value != null)
                MessageBox.Show("Card name cannot be empty");
        }

        private void list_list_Loaded(object sender, RoutedEventArgs e)
        {
            if (ListPivot.SelectedIndex != (int)PhoneApplicationService.Current.State["SelectedList"])
                ListPivot.SelectedIndex = (int)PhoneApplicationService.Current.State["SelectedList"];
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid grid = sender as Grid;
            CardType card = (CardType) grid.DataContext;
            PhoneApplicationService.Current.State["CurrentCard"] = card;
            ListType list = listView.ListCollections.Where(x => x.ID == card.IdList).FirstOrDefault();
            PhoneApplicationService.Current.State["SelectedList"] = listView.ListCollections.IndexOf(list);
            NavigationService.Navigate(new Uri("/Views/Specific/CardPage.xaml", UriKind.Relative));
        }

    }
}