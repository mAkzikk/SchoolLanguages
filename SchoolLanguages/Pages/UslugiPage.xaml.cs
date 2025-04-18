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
    /// Логика взаимодействия для UslugiPage.xaml
    /// </summary>
    public partial class UslugiPage : Page
    {
        public UslugiPage()
        {
            InitializeComponent();
            ServiceList.ItemsSource = SchoolLanguagesEntities.GetContext().Услуги.ToList();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySorting();
        }

        private void ApplySorting()
        {
            var selected = SchoolLanguagesEntities.GetContext().Услуги.OrderBy(p =>p.Id_услуги).ToList();
            if (SortComboBox.SelectedIndex >= 0)
            {
                switch (SortComboBox.SelectedIndex)
                {
                    case 0:
                        selected = selected.OrderBy(s => s.Стоимость).ToList();
                        break;
                    case 1:
                        selected = selected.OrderByDescending(s => s.Стоимость).ToList();
                        break;
                    case 2:
                        selected = selected.OrderBy(s => s.Продолжительность).ToList();
                        break;
                    case 3:
                        selected = selected.OrderByDescending(s => s.Продолжительность).ToList();
                        break;
                }
            }

            ServiceList.ItemsSource = selected.ToList();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedServices = ServiceList.SelectedItems.Cast<Услуги>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Выбрать {selectedServices.Count()} услуг?", "Выбор", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if(messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Услуги x = selectedServices[0];
                    Manage.currentServices = x;
                    NavigationService.Navigate(new Pages.ZapNaYslPage());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }
    }
}
