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
    public partial class ClientWindow : Window
    {
        private Клиент currentClient;
        public ClientWindow(Models.Клиент client)
        {
            InitializeComponent();
            currentClient = client;

        }

        public ClientWindow()
        {
        }

        private void Yslyg_Click(object sender, RoutedEventArgs e)
        {
            ClientFrame.NavigationService.Navigate(new UslugiPage());
        }

        private void Tovary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zapisnaysl_Click(object sender, RoutedEventArgs e)
        {
            ClientFrame.Navigate(new ZapNaYslPage());
        }

        private void Myzapis_Click(object sender, RoutedEventArgs e)
        {
           ClientFrame.Navigate(new MyZapisiPage());
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            ClientFrame.Navigate(new ProfilePage(currentClient));
        }
    }
}
