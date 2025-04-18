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
using SchoolLanguages.Windows;

namespace SchoolLanguages.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;
            string lastName = LastNameBox.Text.Trim();
            string firstName = FirstNameBox.Text.Trim();
            string middleName = MiddleNameBox.Text.Trim();
            string gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string phone = PhoneBox.Text.Trim();
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            string email = EmailBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) ||
                birthDate == null)
            {
                StatusText.Text = "Заполните все поля корректно.";
                StatusText.Foreground = Brushes.Red;
                return;
            }

            using (var db = new SchoolLanguagesEntities())
            {
            
                if (db.Авторизация.Any(a => a.Логин == login))
                {
                    StatusText.Text = "Такой логин уже существует.";
                    StatusText.Foreground = Brushes.Red;
                    return;
                }
                var newAuth = new Авторизация
                {
                    Логин = login,
                    пароль = password
                };
                db.Авторизация.Add(newAuth);
                db.SaveChanges();

                int userId = newAuth.Id_user;
                var newClient = new Клиент
                {
                    Id_user = userId,
                    Фамилия = lastName,
                    Имя = firstName,
                    Отчество = middleName,
                    Пол = gender,
                    Номер_телефона = phone,
                    Дата_рождения = birthDate.Value,
                    Электронная_почта = email,
                    Дата_регистрации = DateTime.Now,
                    Фото = null,
                    Id_тип_клиента = 1
                };
                db.Клиент.Add(newClient);
                db.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!");
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Window.GetWindow(this)?.Close();
            }
        }
    }
}
