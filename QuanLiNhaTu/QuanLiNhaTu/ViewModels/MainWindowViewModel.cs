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
                try
                {
                    Isloaded = true;
                    if (p == null)
                        return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
              );
            UpdateStatistic = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    soLuongTuNhan = db.TU_NHAN.Count();
                    soLuongCanBo = db.CAN_BO.Count();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            MoThanNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    ThanNhan ThanNhanWin = new ThanNhan();
                    ThanNhanWin.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            MoTiepNhanPhongThichCommand=new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    TiepNhanPhongTich TNPT = new TiepNhanPhongTich();
                    TNPT.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            MoCanBoCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    QuanGiao QuanGiaoWin = new QuanGiao();
                    QuanGiaoWin.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            MoQuanLyCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    MainQuanLy QL = new MainQuanLy();
                    QL.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            MoChiaLichTrucCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    ChiaLichTruc ChiaLich = new ChiaLichTruc();
                    ChiaLich.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            LogOutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    p.Hide();
                    LoginWindow logInWin = new LoginWindow();
                    logInWin.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            MoYTeCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    YTe yTeWin = new YTe();
                    yTeWin.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            MoTuNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    TuNhan tuNhan = new TuNhan();
                    tuNhan.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }
    }
}
