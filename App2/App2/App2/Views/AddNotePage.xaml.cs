using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class AddNotePage : ContentPage
    {
        public AddNotePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            DateTime Day = DateTime.Today;
            // date = Day.ToString("d");
            date = Day.ToString("dd/MM/yyyy"); // "MMMM dd, yyyy" June 10, 2011
            // Debug.WriteLine(date);
            time = Day.ToString("H:mm:ss"); // {0:MM/dd/yy H:mm:ss zzz}",
            string thisTime = Day.ToString("s");
            label.Text = time;
        }


        string sugar = "???";
        string date;
        string time;
        string feeling;
        string when;

       /* private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (header_slider != null)
                header_slider.Text = String.Format("{0:F1}", e.NewValue);
        }*/
        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (header_slider != null)
            {
                header_slider.Text = String.Format("{0:F1}", e.NewValue);
                sugar = String.Format("{0:F1}", e.NewValue);
                label.Text = date;
            }  
        }
        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            date = "" + e.NewDate.ToString("dd/MM/yyyy");
            // date2 = "" + e.NewDate.ToString("yyyy/MM/dd");

        }


        private async void AddItemButt_Clicked(object sender, EventArgs ex)
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
                    Time = time, // time,
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

        /*private async void NoteModal_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить элемент?", "Да", "Нет");
            await DisplayAlert("Уведомление", "Вы выбрали: " + (result ? "Удалить" : "Отменить"), "OK");
        }*/
    }
}