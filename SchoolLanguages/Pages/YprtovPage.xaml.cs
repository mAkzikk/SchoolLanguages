using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SchoolLanguages.Models;  // Убедись, что это правильно подключено.

namespace SchoolLanguages.Pages
{
    /// <summary>
    /// Логика взаимодействия для YprtovPage.xaml
    /// </summary>
    public partial class YprtovPage : Page
    {
        public Товар Product { get; private set; }
        private bool isEditMode;

        public YprtovPage(Товар product = null)
        {
            InitializeComponent();
            //LoadCategories();

            if (product != null)
            {
                isEditMode = true;
                Product = product;
                FillFields();
            }
            else
            {
                Product = new Товар();
            }
        }

        //private void LoadCategories()
        //{
        //    // Загружаем категории товаров
        //    CategoryComboBox.ItemsSource = db.Категория_товаров.ToList();
        //}

        private void FillFields()
        {
            // Заполняем поля на форме значениями из объекта Product
            NameTextBox.Text = Product.Наименование;
            CategoryComboBox.SelectedValue = Product.Id_категории_товара;
            PriceTextBox.Text = Product.Стоимость.ToString();
            CharTextBox.Text = Product.Характеристика;
            DescTextBox.Text = Product.Описание;
            WeightTextBox.Text = Product.Вес.ToString();
            WidthTextBox.Text = Product.Ширина.ToString();
            HeightTextBox.Text = Product.Высота.ToString();
            LengthTextBox.Text = Product.Длина.ToString();
            ManufacturerTextBox.Text = Product.Производитель;
            PhotoTextBox.Text = Product.Фото;
            WarehouseIdTextBox.Text = Product.Id_склада?.ToString();
            QuantityTextBox.Text = Product.Количество?.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Заполняем объект Product данными из формы
                Product.Наименование = NameTextBox.Text;
                Product.Id_категории_товара = (int)CategoryComboBox.SelectedValue;
                Product.Стоимость = decimal.Parse(PriceTextBox.Text);
                Product.Характеристика = CharTextBox.Text;
                Product.Описание = DescTextBox.Text;
                Product.Вес = int.Parse(WeightTextBox.Text);
                Product.Ширина = int.Parse(WidthTextBox.Text);
                Product.Высота = int.Parse(HeightTextBox.Text);
                Product.Длина = int.Parse(LengthTextBox.Text);
                Product.Производитель = ManufacturerTextBox.Text;
                Product.Фото = PhotoTextBox.Text;
                Product.Id_склада = string.IsNullOrWhiteSpace(WarehouseIdTextBox.Text) ? (int?)null : int.Parse(WarehouseIdTextBox.Text);
                Product.Количество = string.IsNullOrWhiteSpace(QuantityTextBox.Text) ? (int?)null : int.Parse(QuantityTextBox.Text);

                // Если режим редактирования, обновляем объект, если новый товар - добавляем
                //if (!isEditMode)
                //    db.Товар.Add(Product);  // Добавляем новый товар в базу

                //db.SaveChanges();  // Сохраняем изменения в базу данных

                NavigationService.GoBack();  // Переход к предыдущей странице
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);  // Выводим ошибку, если что-то пошло не так
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();  // Переход к предыдущей странице
        }
       
    }
}
