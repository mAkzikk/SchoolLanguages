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
    /// Логика взаимодействия для ZapNaYslPage.xaml
    /// </summary>
    public partial class ZapNaYslPage : Page
    {
        private Услуги selectedService;
        public ZapNaYslPage()
        {
            InitializeComponent();
            //if (NavigationService != null && NavigationService.Content ==)
            //{
                ServiceComboBox.ItemsSource = SchoolLanguagesEntities.GetContext().Услуги.Where(p => p.Id_услуги == Manage.currentServices.Id_услуги).ToList();
            //}
            //else
            //    ServiceComboBox.ItemsSource = SchoolLanguagesEntities.GetContext().Услуги.ToList();
        }
       
        private void Zapisat_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
