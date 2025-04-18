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
    public partial class YpryslPage : Page
    {
        private SchoolLanguagesEntities db = new SchoolLanguagesEntities();
        public Услуги CurrentService { get; private set; }
        private bool isEditMode;

        public YpryslPage(Услуги service = null)
        {
            InitializeComponent();
            LoadServices();

            if (service != null)
            {
                isEditMode = true;
                CurrentService = service;
                FillFields();
            }
            else
            {
                CurrentService = new Услуги();
            }
        }

        private void FillFields()
        {
            NameTextBox.Text = CurrentService.Наименование;
            DescTextBox.Text = CurrentService.Описание;
            PhotoTextBox.Text = CurrentService.Фото;
            DurationTextBox.Text = CurrentService.Продолжительность.ToString();
            PriceTextBox.Text = CurrentService.Стоимость.ToString("F2");
            DiscountTextBox.Text = CurrentService.Скидка?.ToString("F2");
        }

        private void ClearFields()
        {
            NameTextBox.Clear();
            DescTextBox.Clear();
            PhotoTextBox.Clear();
            DurationTextBox.Clear();
            PriceTextBox.Clear();
            DiscountTextBox.Clear();
            CurrentService = new Услуги();
            isEditMode = false;
        }

        private void LoadServices(string search = "")
        {
            var services = db.Услуги
                .Where(s => s.Наименование.Contains(search))
                .ToList();
            ServicesDataGrid.ItemsSource = services;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentService.Наименование = NameTextBox.Text;
                CurrentService.Описание = DescTextBox.Text;
                CurrentService.Фото = PhotoTextBox.Text;
                CurrentService.Продолжительность = int.Parse(DurationTextBox.Text);
                CurrentService.Стоимость = double.Parse(PriceTextBox.Text);
                CurrentService.Скидка = string.IsNullOrWhiteSpace(DiscountTextBox.Text)
                                            ? (double?)null
                                            : double.Parse(DiscountTextBox.Text);

                if (!isEditMode)
                {
                    db.Услуги.Add(CurrentService);
                }

                db.SaveChanges();
                MessageBox.Show("Услуга сохранена!");
                LoadServices();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentService == null || CurrentService.Id_услуги == 0)
            {
                MessageBox.Show("Выберите услугу для удаления.");
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту услугу?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                db.Услуги.Remove(CurrentService);
                db.SaveChanges();
                MessageBox.Show("Услуга удалена.");
                LoadServices();
                ClearFields();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ServicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem is Услуги selectedService)
            {
                CurrentService = selectedService;
                isEditMode = true;
                FillFields();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadServices(SearchTextBox.Text);
        }
    }
}
