﻿using QuanLiNhaTu.ViewModels;
using QuanLiNhaTu.Views;
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
        public LoginWindowViewModel Viewmodel { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = Viewmodel = new LoginWindowViewModel();
        }
    }
}