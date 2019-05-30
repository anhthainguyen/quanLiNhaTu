using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QuanLiNhaTu.Models;
using System.Windows.Input;
using System.Windows;

namespace QuanLiNhaTu.ViewModels
{
    public class MainThanNhanViewModel : BaseViewModel
    {
        public QUAN_LI_NHA_TUEntities1 db = new QUAN_LI_NHA_TUEntities1();

        private ObservableCollection<TU_NHAN> _List;
        public ObservableCollection<TU_NHAN> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private TU_NHAN _SelectedItem;
        public TU_NHAN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                try
                {
                    _SelectedItem = value;
                    OnPropertyChanged();
                    if (SelectedItem != null)
                    {
                        MaTuNhan = SelectedItem.Ma_Tu_N;
                        HoTen = SelectedItem.Ho_Ten;
                        GioiTinh = SelectedItem.Gioi_Tinh;
                        NgaySinh = SelectedItem.Ngay_Sinh;
                        SucKhoe = SelectedItem.Tinh_Trang_suc_Khoe;
                        NgayVao = SelectedItem.Ngay_Vao_Tu;
                        NgayRa = SelectedItem.Ngay_Ra_Tu;
                        NgayThamNuoi = SelectedItem.Ngay_Duoc_Tham_Nuoi;
                        MucDoCaiTao = SelectedItem.Muc_Do_Cai_Tao;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private string _MaThanNhan;
        public string MaThanNhan { get => _MaThanNhan; set {
                try
                {
                    _MaThanNhan = value; OnPropertyChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }

        private string _HoTen;

        public string MaTuNhan { get; private set; }

        public string HoTen { get => _HoTen; set { try
                {
                    _HoTen = value; OnPropertyChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }

        private string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { try
                {
                    _GioiTinh = value; OnPropertyChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { try
                {
                    _NgaySinh = value; OnPropertyChanged();
                }
                                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }} }

        private string _SucKhoe;
        public string SucKhoe { get => _SucKhoe; set { try { _SucKhoe = value; OnPropertyChanged(); }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }
        public DateTime? _NgayVao { get; private set; }
        public DateTime? NgayVao { get => _NgayVao; set { try { _NgayVao = value; OnPropertyChanged(); }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }
        public DateTime? _NgayRa { get; private set; }
        public DateTime? NgayRa { get => _NgayRa; set { try { _NgayRa = value; OnPropertyChanged(); }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }
        public DateTime? _NgayThamNuoi { get; private set; }
        public DateTime? NgayThamNuoi { get => _NgayThamNuoi; set { try { _NgayThamNuoi = value; OnPropertyChanged(); }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }
        public string _MucDoCaiTao { get; private set; }
        public string MucDoCaiTao { get => _MucDoCaiTao; set { try { _MucDoCaiTao = value; OnPropertyChanged(); }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }
        private string _SDT;
        public string SDT { get => _SDT; set { try { _SDT = value; OnPropertyChanged(); }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public MainThanNhanViewModel()
        {
            List = new ObservableCollection<TU_NHAN>(db.TU_NHAN);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (MaThanNhan != null & HoTen != null)
                    return true;
                return false;

            }, (p) =>
            {
                try
                {
                    var tn = new TU_NHAN() { Ho_Ten = HoTen, Ngay_Sinh = NgaySinh, Gioi_Tinh = GioiTinh, Tinh_Trang_suc_Khoe = SucKhoe, Ngay_Vao_Tu = NgayVao, Ngay_Ra_Tu = NgayRa, Ngay_Duoc_Tham_Nuoi = NgayThamNuoi, Muc_Do_Cai_Tao = MucDoCaiTao };

                    db.TU_NHAN.Add(tn);
                    db.SaveChanges();

                    List.Add(tn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            //EditCommand = new RelayCommand<object>((p) =>
            //{
            //    if (SelectedItem == null)
            //        return false;

            //    var displayList = db.THAN_NHAN.Where(x => x.Ma_Than_N == MaThanNhan);
            //    if (displayList != null || displayList.Count() != 0)
            //        return true;

            //    return false;

            //}, (p) =>
            //{
            //    var tn = db.TU_NHAN.Where(x => x.Ma_Tu_N == SelectedItem.Ma_Tu_N).SingleOrDefault();
            //    //tn.Ma_Than_N = MaThanNhan;
            //    tn.Ho_Ten = HoTen;
            //    tn.Ngay_Sinh = NgaySinh;
            //    tn.Gioi_Tinh = GioiTinh;
                
            //    tn.Tinh_Trang_suc_Khoe = SucKhoe;
            //    tn.Ngay_Vao_Tu = NgayVao;
            //    tn.Ngay_Ra_Tu= NgayRa;
            //    tn.Ngay_Duoc_Tham_Nuoi = NgayThamNuoi;
            //    tn.Muc_Do_Cai_Tao = MucDoCaiTao;
            //    if (db.SaveChanges() == 1)
            //    {
            //        List = new ObservableCollection<TU_NHAN>(db.TU_NHAN);
            //    }
            //});

            //DeleteCommand = new RelayCommand<object>((p) =>
            //{
            //    if (SelectedItem == null)
            //        return false;
            //    return true;

            //}, (p) =>
            //{
            //    var tn = db.THAN_NHAN.Where(x => x.Ma_Than_N == SelectedItem.Ma_Than_N).SingleOrDefault();

            //    db.THAN_NHAN.Remove(tn);
            //    if (db.SaveChanges() == 1)
            //    {
            //        List.Remove(tn);
            //    }
            //});
        }
    }
}
