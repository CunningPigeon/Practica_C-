using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using static Xamarin.Forms.Internals.Profile;

namespace App2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SeeNotePage : ContentPage
	{
        string sugar = "???";
        string date;
        string time;
        string feeling;
        string when;

        public SeeNotePage ()
        {
			InitializeComponent ();
        }
        protected override void OnAppearing()
        {
            date = label_date.Text;
            time = label_time.Text;
            string[] mass = date.Split('/');
            string[] massT = time.Split(':');
            // Debug.WriteLine(mass[0] + "/" + mass[1] + "/" + mass[2]);
            // Перевести в целое срезами в строке определенные найти индексом /
            dateField.Date = new DateTime(int.Parse(mass[2]), int.Parse(mass[1]), int.Parse(mass[0]));
            timeField.Time = new TimeSpan(int.Parse(massT[0]), int.Parse(massT[1]), 00);
        }
        /*public async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }*/

               
        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (header_slider != null)
            {
                header_slider.Text = String.Format("{0:F1}", e.NewValue);
                sugar = String.Format("{0:F1}", e.NewValue);
                // label.Text = "" + timeField.Time;
            }
        }
        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            date = "" + e.NewDate.ToString("dd/MM/yyyy");
        }

        private async void SaveItemButt_Clicked(object sender, EventArgs ex)
        {
            string time = "" + timeField.Time;
            
            // feeling =  feelingField.Items[feelingField.SelectedIndex];
            int idfeeling = feelingField.SelectedIndex;
            // when =  mealField.Items[mealField.SelectedIndex];
            int idwhen = mealField.SelectedIndex;
            string note = "" + noteField.Text;

            if (sugar == "???")
            {
                await DisplayAlert("Ошибка ввода данных", "Введите значние сахара", "Ок");
            }
            else if (date == "")
            {
                await DisplayAlert("Ошибка ввода данных", "Введите дату", "Ок");
            }
            else if (time == "00:00:00")
            {
                await DisplayAlert("Ошибка ввода данных", "Введите время", "Ок");
            }
            else
            {
                if (idfeeling == -1)
                {
                    idfeeling = 0;
                }
                if (idwhen == -1)
                {
                    idwhen = 0;
                }
                if (note != "")
                {
                    note = noteField.Text.Trim();
                }
                feeling = feelingField.Items[idfeeling];
                when = mealField.Items[idwhen];
                Diary diary = new Diary
                {
                    Sugar = double.Parse(sugar),
                    Date = date,
                    Time = time,
                    Feeling = feeling,
                    idFeeling = idfeeling,
                    When = when,
                    idWhen = idwhen,
                    Note = note,
                };
                App.Db.SaveItem(diary);

                await Navigation.PopAsync();
            }
        }
        private void DelItemButt_Clicked(object sender, EventArgs e)
        {
            var diary = (Diary)BindingContext;
            App.Db.DeleteItem(diary.ID);
            this.Navigation.PopAsync();
        }
        private void UpItemButt_Clicked(object sender, EventArgs e)
        {
            var diary = (Diary)BindingContext;
            App.Db.UpdateItem(diary);
            this.Navigation.PopAsync();
        }
    }
}