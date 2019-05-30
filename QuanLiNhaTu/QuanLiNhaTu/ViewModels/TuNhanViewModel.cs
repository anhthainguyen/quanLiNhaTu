using QuanLiNhaTu.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLiNhaTu.ViewModels
{
    public class TuNhanViewModel : BaseViewModel
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
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaTuNhan = SelectedItem.Ma_Tu_N;
                    HoTen = SelectedItem.Ho_Ten;
                    NgaySinh = SelectedItem.Ngay_Sinh;
                    GioiTinh = SelectedItem.Gioi_Tinh;
                    ToiDanh = SelectedItem.Toi_Danh;
                    NgayVaoTu = SelectedItem.Ngay_Vao_Tu;
                    NgayRaTu = SelectedItem.Ngay_Ra_Tu;
                    TinhTrangSucKhoe = SelectedItem.Tinh_Trang_suc_Khoe;
                    NgayDuocThamNuoi = SelectedItem.Ngay_Duoc_Tham_Nuoi;
                    MucDoCaiTao = SelectedItem.Muc_Do_Cai_Tao;
                    TinhTrangGiamGiu = SelectedItem.Tinh_Trang_Giam_Giu;
                    NgayKham = SelectedItem.Ngay_Kham;
                    NgayTaiKham = SelectedItem.Ngay_Tai_Kham;
                    ThanNhan = SelectedItem.Ma_Than_N;
                }
            }
        }

        private string _MaTuNhan;
        public string MaTuNhan { get => _MaTuNhan; set { _MaTuNhan = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        private string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }

        private string _ToiDanh;
        public string ToiDanh { get => _ToiDanh; set { _ToiDanh = value; OnPropertyChanged(); } }

        private DateTime? _NgayVaoTu;
        public DateTime? NgayVaoTu { get => _NgayVaoTu; set { _NgayVaoTu = value; OnPropertyChanged(); } }

        private DateTime? _NgayRaTu;
        public DateTime? NgayRaTu { get => _NgayRaTu; set { _NgayRaTu = value; OnPropertyChanged(); } }

        private string _TinhTrangSucKhoe;
        public string TinhTrangSucKhoe { get => _TinhTrangSucKhoe; set { _TinhTrangSucKhoe = value; OnPropertyChanged(); } }

        private DateTime? _NgayDuocThamNuoi;
        public DateTime? NgayDuocThamNuoi { get => _NgayDuocThamNuoi; set { _NgayDuocThamNuoi = value; OnPropertyChanged(); } }

        private string _MucDoCaiTao;
        public string MucDoCaiTao { get => _MucDoCaiTao; set { _MucDoCaiTao = value; OnPropertyChanged(); } }

        private string _TinhTrangGiamGiu;
        public string TinhTrangGiamGiu { get => _TinhTrangGiamGiu; set { _TinhTrangGiamGiu = value; OnPropertyChanged(); } }

        private DateTime? _NgayKham;
        public DateTime? NgayKham { get => _NgayKham; set { _NgayKham = value; OnPropertyChanged(); } }

        private DateTime? _NgayTaiKham;
        public DateTime? NgayTaiKham { get => _NgayTaiKham; set { _NgayTaiKham = value; OnPropertyChanged(); } }

        private string _ThanNhan;
        public string ThanNhan { get => _ThanNhan; set { _ThanNhan = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public TuNhanViewModel()
        {
            List = new ObservableCollection<TU_NHAN>(db.TU_NHAN);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (MaTuNhan != null & HoTen != null)
                    return true;
                return false;

            }, (p) =>
            {
                var tn = new TU_NHAN()
                {
                    Ma_Tu_N= MaTuNhan
                    ,
                    Ho_Ten = _HoTen
                    ,
                    Ngay_Sinh = NgaySinh
                    ,
                    Gioi_Tinh = GioiTinh
                    ,
                    Toi_Danh = ToiDanh
                    ,
                    Ngay_Vao_Tu = NgayVaoTu
                    ,
                    Ngay_Ra_Tu = NgayRaTu
                    ,
                    Tinh_Trang_suc_Khoe = TinhTrangSucKhoe
                    ,
                    Ngay_Duoc_Tham_Nuoi = NgayDuocThamNuoi
                    ,
                    Muc_Do_Cai_Tao = MucDoCaiTao
                    ,
                    Tinh_Trang_Giam_Giu = TinhTrangGiamGiu
                    ,
                    Ngay_Kham = NgayKham
                    ,
                    Ngay_Tai_Kham = NgayTaiKham
                };
                db.TU_NHAN.Add(tn);
                if (db.SaveChanges() == 1)
                {
                    List.Add(tn);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = db.TU_NHAN.Where(x => x.Ma_Than_N == MaTuNhan);
                if (displayList != null || displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var tn = db.TU_NHAN.Where(x => x.Ma_Than_N == SelectedItem.Ma_Than_N).SingleOrDefault();
                tn.Ma_Than_N = MaTuNhan;
                tn.Ho_Ten = HoTen;
                tn.Ngay_Sinh = NgaySinh;
                tn.Gioi_Tinh = GioiTinh;
                tn.Toi_Danh = ToiDanh;
                tn.Ngay_Vao_Tu = NgayVaoTu;
                tn.Ngay_Ra_Tu = NgayRaTu;
                tn.Tinh_Trang_suc_Khoe = TinhTrangSucKhoe;
                tn.Ngay_Duoc_Tham_Nuoi = NgayDuocThamNuoi;
                tn.Muc_Do_Cai_Tao = MucDoCaiTao;
                tn.Tinh_Trang_Giam_Giu = TinhTrangGiamGiu;
                tn.Ngay_Kham = NgayKham;
                tn.Ngay_Tai_Kham = NgayTaiKham;
                if (db.SaveChanges() == 1)
                {
                    List = new ObservableCollection<TU_NHAN>(db.TU_NHAN);
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                var tn = db.TU_NHAN.Where(x => x.Ma_Than_N == SelectedItem.Ma_Than_N).SingleOrDefault();

                db.TU_NHAN.Remove(tn);
                if (db.SaveChanges() == 1)
                {
                    List.Remove(tn);
                }
            });
        }
    }
}
