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
using SchoolLanguages.Pages;

namespace SchoolLanguages.Windows
{
    /// <summary>
    /// Логика взаимодействия для SotrudnikWindow.xaml
    /// </summary>
    public partial class SotrudnikWindow : Window
    {
        public SotrudnikWindow()
        {
            InitializeComponent();
        }

        private void Yprysl_Click(object sender, RoutedEventArgs e)
        {
            SotFrame.Navigate(new YpryslPage());
        }

        private void YprTov_Click(object sender, RoutedEventArgs e)
        {
            SotFrame.Navigate(new YprtovPage());
        }

        private void Zapnaysl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BlizZap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Historyzak_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
