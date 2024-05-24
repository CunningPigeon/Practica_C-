using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using System.Net.NetworkInformation;
using App2.Models;

using SQLite;
using System.Xml.XPath;
using System.Diagnostics;
using System.Xml;
using Xamarin.Essentials;

namespace App2.Views
{
    //  [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        string birthday;
        public ProfilePage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            DateTime Day = DateTime.Today;
            string name = Preferences.Get("name", "Не установлено");
            string surname = Preferences.Get("surname", "Не установлено");
            int idgender = Preferences.Get("idgender", 3);
            birthday = Preferences.Get("birthday", Day.ToString("dd/MM/yyyy"));
            string[] mass = birthday.Split('/');
            
            birthdayField.Date = new DateTime(int.Parse(mass[2]), int.Parse(mass[1]), int.Parse(mass[0]));
            nameField.Text = name;
            surnameField.Text = surname;
            genderField.SelectedIndex = idgender;

            base.OnAppearing();
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            birthday = "" + e.NewDate.ToString("dd/MM/yyyy");
        }
        public async void SaveItemButton_Clicked(object sender, EventArgs e)
        {
            string name = "" + nameField.Text;
            string surname = "" + surnameField.Text;
            int idgender = genderField.SelectedIndex;


            if (name.Length <= 1)
            {
                await DisplayAlert("Ошибка ввода данных", "В поле \"Имя\"  не может быть меньше 1 символа", "Ок");
                return;
            }
            else if (birthday == "")
            {
                await DisplayAlert("Ошибка ввода данных", "Введите дату", "Ок");
            }
            else
            {
                if (name != "")
                {
                    name = name.Trim();
                }
                if (surname != "")
                {
                    surname = surname.Trim();
                }
                if (idgender == -1)
                {
                    idgender = 3;
                }
                string gender = genderField.Items[idgender];

                Preferences.Set("name", name);
                Preferences.Set("surname", surname);
                Preferences.Set("idgender", idgender);
                // Preferences.Set("gender", gender);
                Preferences.Set("birthday", birthday);
            }
        }
        

        public async void ShowCardButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MedCardPage());
        }
        private void OnImageButtonClicked(object sender, EventArgs e)
        {

        }
    }
}