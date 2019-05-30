using QuanLiNhaTu.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        private ObservableCollection<THAN_NHAN> _ListTN;
        public ObservableCollection<THAN_NHAN> ListTN { get => _ListTN; set { _ListTN = value; OnPropertyChanged(); } }

       
        public List<THAN_NHAN> DanhsachThanNhan { get; set; } 

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
        public string Ma_Tu_N2 { set { _Ma_Tu_N = value; OnPropertyChanged(); } }

        private string _Ho_Ten;
        public string Ho_Ten { get => _Ho_Ten; set { _Ho_Ten = value; OnPropertyChanged(); } }
        public string Ho_Ten2 { set { _Ho_Ten = value; OnPropertyChanged(); } }


        private DateTime? _Ngay_Sinh;
        public DateTime? Ngay_Sinh { get => _Ngay_Sinh; set { _Ngay_Sinh = value; OnPropertyChanged(); } }
       

        private string _Gioi_Tinh;
        public string Gioi_Tinh { get => _Gioi_Tinh; set { _Gioi_Tinh = value; OnPropertyChanged(); } }
        public string Gioi_Tinh2 { set { _Gioi_Tinh = value; OnPropertyChanged(); } }

        private string _Toi_Danh;
        public string Toi_Danh { get => _Toi_Danh; set { _Toi_Danh = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Vao_Tu;
        public DateTime? Ngay_Vao_Tu { get => _Ngay_Vao_Tu; set { _Ngay_Vao_Tu = value; OnPropertyChanged(); } }

        private DateTime? _Ngay_Ra_Tu;
        public DateTime? Ngay_Ra_Tu { get => _Ngay_Ra_Tu; set { _Ngay_Ra_Tu = value; OnPropertyChanged(); } }

        private string _Mat_Khau;
        public string Mat_Khau { get => _Mat_Khau; set { _Mat_Khau = value; OnPropertyChanged(); } }

        private string _Ma_Than_Nhan;
        public string Ma_Than_Nhan { get => _Ma_Than_Nhan; set { _Ma_Than_Nhan = value; OnPropertyChanged(); } }

        


    public ICommand AddCommand { get; set; }
      

        public TiepNhanVaPhongThichViewModel()
        {
            List = new ObservableCollection<TU_NHAN>(DataProvider.Ins.DB.TU_NHAN);
            var item = db.THAN_NHAN.ToList();
            DanhsachThanNhan = item;
           
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
                    //Toi_Danh=_Toi_Danh,
                    //Ngay_Vao_Tu=_Ngay_Vao_Tu,
                    //Ngay_Ra_Tu=_Ngay_Ra_Tu,
                    //Mat_Khau= "6fd742a61bd034804c00c49b18045020",
                    //Ma_Than_N=_Ma_Than_Nhan
                };

                db.TU_NHAN.Add(tn);
                db.SaveChanges();

                List.Add(tn);
            });
        }
    }
}
