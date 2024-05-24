using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
	// [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiaryPage : ContentPage
	{
		public DiaryPage ()
		{
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            ShowItems();
        }
        private void ShowItems()
        {
            sugarList.ItemsSource = App.Db.GetItems();
        }

        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*Diary selectedNote = (Diary)e.SelectedItem;
            SeeNotePage seenotePage = new SeeNotePage();
            seenotePage.BindingContext = selectedNote;
            await Navigation.PushAsync(seenotePage);*/
            Diary selectedNote = (Diary)e.SelectedItem;
            SeeNotePage seenotePage = new SeeNotePage();
            seenotePage.BindingContext = selectedNote;
            await Navigation.PushAsync(seenotePage);
        }

        private async void ToCommonPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNotePage());
        }
    }
}