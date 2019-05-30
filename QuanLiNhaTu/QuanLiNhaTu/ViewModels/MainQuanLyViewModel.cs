using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLiNhaTu.Views;
using QuanLiNhaTu.Models;
using System.Windows;

namespace QuanLiNhaTu.ViewModels
{
    public class MainQuanLyViewModel : BaseViewModel
    {
        public ICommand ThanNhanCommand { get; set; }
        public ICommand TuNhanCommand { get; set; }
        public ICommand CanBoCommand { get; set; }
        public MainQuanLyViewModel()
        {
            try
            {
                ThanNhanCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ThanNhan wd = new ThanNhan(); wd.ShowDialog(); });
                TuNhanCommand = new RelayCommand<object>((p) => { return true; }, (p) => { TuNhan wd = new TuNhan(); wd.ShowDialog(); });
                CanBoCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ChiaLichTruc wd = new ChiaLichTruc(); wd.ShowDialog(); });
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
