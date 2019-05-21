using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLiNhaTu.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            //Cac xu ly chung nam tai day
        }
    }
}
