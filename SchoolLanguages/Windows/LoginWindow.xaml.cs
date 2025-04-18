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
using System.Windows.Shapes;
using SchoolLanguages.Models;
using SchoolLanguages.Pages;

namespace SchoolLanguages.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                StatusText.Text = "Введите логин и пароль.";
                return;
            }

            using (var db = new SchoolLanguagesEntities())
            {
                Авторизация user = db.Авторизация.FirstOrDefault(u => u.Логин == login && u.пароль == password);

                if (user != null)
                {
                    Клиент client = db.Клиент.FirstOrDefault(c => c.Id_user == user.Id_user);
                    if (client != null)
                    {
                        Manage.currentUser = user;
                        MessageBox.Show($"Добро пожаловать, {client.Имя}!");
                        var clientWindow = new ClientWindow(client);
                        clientWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        StatusText.Text = "Клиент не найден.";
                    }
                }
                else
                {
                    StatusText.Text = "Неверный логин или пароль.";
                }
                if (LoginBox.Text == "admin" && PasswordBox.Password == "1111")
                {
                    var AdminWindow = new AdminWindow();
                    this.Close();
                    AdminWindow.Show();
                }
                else if (LoginBox.Text == "client" && PasswordBox.Password == "1111")
                {
                    var ClientWindow = new ClientWindow();
                    this.Close();
                    ClientWindow.Show();
                }
                else if (LoginBox.Text == "sotrudnik" && PasswordBox.Password == "1111")
                {
                    var SotrunikWindow = new SotrudnikWindow();
                    this.Close();
                    SotrunikWindow.Show();
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrationPage());
        }
    }
}
