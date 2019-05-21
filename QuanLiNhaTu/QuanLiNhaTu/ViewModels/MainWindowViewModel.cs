using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLiNhaTu.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public MainWindowViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginWindowViewModel;
                if (loginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
                
            });
            //Cac xu ly chung nam tai day
        }
    }
}
