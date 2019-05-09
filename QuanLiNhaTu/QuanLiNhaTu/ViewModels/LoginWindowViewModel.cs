using QuanLiNhaTu.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLiNhaTu.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand OpenHomeWindowCommand { get; set; }
        #endregion

        public LoginWindowViewModel()
        {
            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null? false : true; }, (p) => { p.Close(); });
            OpenHomeWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ManHinhChinh manHinh = new ManHinhChinh();
                manHinh.ShowDialog();
            });
        }


    }
}
