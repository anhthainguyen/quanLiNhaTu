﻿using QuanLiNhaTu.Views;
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

namespace QuanLiNhaTu
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void dangNhap_Click(object sender, RoutedEventArgs e)
        {
            ManHinhChinh manHinh = new ManHinhChinh();
            manHinh.ShowDialog();
        }

        private void thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
