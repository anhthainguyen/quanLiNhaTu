using QuanLiNhaTu.Models;
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
        public ICommand UpdateStatistic { get; set; }
        public ICommand MoThanNhanCommand { get; set; }
        public ICommand MoTiepNhanPhongThichCommand { get; set; }
        public ICommand MoCanBoCommand { get; set; }
        public ICommand MoQuanLyCommand { get; set; }
        public ICommand MoChiaLichTrucCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand MoYTeCommand { get; set; }
        public ICommand MoTuNhanCommand { get; set; }
        public QUAN_LI_NHA_TUEntities1 db = new QUAN_LI_NHA_TUEntities1();
        private int _soLuongTuNhan = 0;
        public int soLuongTuNhan { get => _soLuongTuNhan; set { _soLuongTuNhan = value; OnPropertyChanged(); } }
        private int _soLuongCanBo = 0;
        public int soLuongCanBo { get => _soLuongCanBo; set { _soLuongCanBo = value; OnPropertyChanged(); } }
        public int _soLuongPhongThichHomNay = 0;
        public int soLuongPhongThichHomNay { get => _soLuongPhongThichHomNay; set { _soLuongPhongThichHomNay = value; OnPropertyChanged(); } }
        public MainWindowViewModel()
        {
            soLuongTuNhan = db.TU_NHAN.Count();
            soLuongCanBo = db.CAN_BO.Count();
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                if (p == null)
                    return;
            }
              );
            UpdateStatistic = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                soLuongTuNhan = db.TU_NHAN.Count();
                soLuongCanBo = db.CAN_BO.Count();
            });
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
            MoYTeCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                YTe yTeWin = new YTe();
                yTeWin.Show();
            });
            MoTuNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                TuNhan tuNhan = new TuNhan();
                tuNhan.Show();
            });
        }
    }
}
