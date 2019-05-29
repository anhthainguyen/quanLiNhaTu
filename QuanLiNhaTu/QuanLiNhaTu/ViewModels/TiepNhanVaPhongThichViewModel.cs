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
    public class TiepNhanVaPhongThichViewModel : BaseViewModel
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
                    Ma_Tu_N = SelectedItem.Ma_Tu_N;
                    Ho_Ten = SelectedItem.Ho_Ten;
                   
                }
            }
        }
        private string _Ma_Tu_N;
        public string Ma_Tu_N { get => _Ma_Tu_N; set { _Ma_Tu_N = value; OnPropertyChanged(); } }

        private string _Ho_Ten;
        public string Ho_Ten { get => _Ho_Ten; set { _Ho_Ten = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Sinh;
        public DateTime? Ngay_Sinh { get => _Ngay_Sinh; set { _Ngay_Sinh = value; OnPropertyChanged(); } }

        private string _Gioi_Tinh;
        public string Gioi_Tinh { get => _Gioi_Tinh; set { _Gioi_Tinh = value; OnPropertyChanged(); } }

        private string _Toi_Danh;
        public string Toi_Danh { get => _Toi_Danh; set { _Toi_Danh = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Vao_Tu;
        public DateTime? Ngay_Vao_Tu { get => _Ngay_Vao_Tu; set { _Ngay_Vao_Tu = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Ra_Tu;
        public DateTime? Ngay_Ra_Tu { get => _Ngay_Ra_Tu; set { _Ngay_Ra_Tu = value; OnPropertyChanged(); } }

        private string _Tinh_Trang_Suc_Khoe;
        public string Tinh_Trang_Suc_Khoe { get => _Tinh_Trang_Suc_Khoe; set { _Tinh_Trang_Suc_Khoe = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Duoc_Tham_Nuoi;
        public DateTime? Ngay_Duoc_Tham_Nuoi { get => _Ngay_Duoc_Tham_Nuoi; set { _Ngay_Duoc_Tham_Nuoi = value; OnPropertyChanged(); } }

        private string _Muc_Do_Cai_Tao;
        public string Muc_Do_Cai_Tao { get => _Muc_Do_Cai_Tao; set { _Muc_Do_Cai_Tao = value; OnPropertyChanged(); } }

        private string _Tinh_Trang_Giam_Giu;
        public string Tinh_Trang_Giam_Giu { get => _Tinh_Trang_Giam_Giu; set { _Tinh_Trang_Giam_Giu = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Kham;
        public DateTime? Ngay_Kham { get => _Ngay_Kham; set { _Ngay_Kham = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Tai_Kham;
        public DateTime? Ngay_Tai_Kham { get => _Ngay_Tai_Kham; set { _Ngay_Tai_Kham = value; OnPropertyChanged(); } }

        private string _Mat_Khau;
        public string Mat_Khau { get => _Mat_Khau; set { _Mat_Khau = value; OnPropertyChanged(); } }

        private string _Ma_Than_Nhan;
        public string Ma_Than_Nhan { get => _Ma_Than_Nhan; set { _Ma_Than_Nhan = value; OnPropertyChanged(); } }




        public ICommand AddCommand { get; set; }
       
        public TiepNhanVaPhongThichViewModel()
        {
            List = new ObservableCollection<TU_NHAN>(db.TU_NHAN);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (Ma_Tu_N != null & Ho_Ten != null)
                    return true;
                return false;

            }, (p) =>
            {
                var tn = new TU_NHAN()
                {
                    Ma_Tu_N = _Ma_Tu_N,
                    Ho_Ten = _Ho_Ten,
                    Ngay_Sinh = _Ngay_Sinh,
                    Gioi_Tinh=_Gioi_Tinh,
                    Toi_Danh=_Toi_Danh,
                    Ngay_Vao_Tu=_Ngay_Vao_Tu,
                    Ngay_Ra_Tu=_Ngay_Ra_Tu,
                    Tinh_Trang_suc_Khoe=_Tinh_Trang_Suc_Khoe,
                    Ngay_Duoc_Tham_Nuoi=_Ngay_Duoc_Tham_Nuoi,
                    Muc_Do_Cai_Tao=_Muc_Do_Cai_Tao,
                    Tinh_Trang_Giam_Giu=_Tinh_Trang_Giam_Giu,
                    Ngay_Kham=_Ngay_Kham,
                    Ngay_Tai_Kham=_Ngay_Tai_Kham,
                    Mat_Khau= "6fd742a61bd034804c00c49b18045020",
                    Ma_Than_N=_Ma_Than_Nhan

                };

                db.TU_NHAN.Add(tn);
                db.SaveChanges();

                List.Add(tn);
            });
        }
    }
}
