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
    /// Логика взаимодействия для YprClientPage.xaml
    /// </summary>
    public partial class YprClientPage : Page
    {
        public YprClientPage()
        {
            InitializeComponent();
            LoadClients();
    }
        private void LoadClients()
        {
            ClientsDataGrid.ItemsSource = SchoolLanguagesEntities.GetContext().Клиент.ToList();
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
