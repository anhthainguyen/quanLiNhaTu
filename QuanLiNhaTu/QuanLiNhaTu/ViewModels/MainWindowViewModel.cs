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
    public class MainWindowViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand MoThanNhanCommand { get; set; }
        public ICommand MoTiepNhanPhongThichCommand { get; set; }
        public ICommand MoCanBoCommand { get; set; }
        public ICommand MoQuanLyCommand { get; set; }
        public ICommand MoChiaLichTrucCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public MainWindowViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                if (p == null)
                    return;
            }
              );
            MoThanNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ThanNhan ThanNhanWin = new ThanNhan();
                ThanNhanWin.ShowDialog();
            });
            MoTiepNhanPhongThichCommand=new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
               TiepNhanPhongTich TNPT = new TiepNhanPhongTich();
                TNPT.ShowDialog();
            });
            MoCanBoCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                QuanGiao QuanGiaoWin = new QuanGiao();
                QuanGiaoWin.ShowDialog();
            });
            MoQuanLyCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                MainQuanLy QL = new MainQuanLy();
                QL.ShowDialog();
            });
            MoChiaLichTrucCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ChiaLichTruc ChiaLich = new ChiaLichTruc();
                ChiaLich.ShowDialog();
            });
            LogOutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Hide();
                LoginWindow logInWin = new LoginWindow();
                logInWin.Show();
            });
        }
    }
}
