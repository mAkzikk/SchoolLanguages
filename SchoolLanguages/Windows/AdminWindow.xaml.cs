﻿using System;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Yprysl_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new YprClientPage());
        }

        private void YprTov_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BlizZap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YprSot_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
