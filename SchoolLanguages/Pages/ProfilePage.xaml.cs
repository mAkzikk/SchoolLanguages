using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolLanguages.Models;

namespace SchoolLanguages.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private Клиент currentClient;

        public ProfilePage(Клиент client)
        {
            InitializeComponent();
            if (client == null)
            {
                MessageBox.Show("Ошибка: клиент не найден");
                return;
            }

            currentClient = client;
            LoadClientData();
        }
        private void LoadClientData()
        {
            LastNameText.Text = currentClient.Фамилия;
            FirstNameText.Text = currentClient.Имя;
            MiddleNameText.Text = currentClient.Отчество;
            GenderText.Text = currentClient.Пол;
            PhoneText.Text = currentClient.Номер_телефона;
            BirthDateText.Text = currentClient.Дата_рождения.ToShortDateString();
            EmailText.Text = currentClient.Электронная_почта;
        }
    }
}
