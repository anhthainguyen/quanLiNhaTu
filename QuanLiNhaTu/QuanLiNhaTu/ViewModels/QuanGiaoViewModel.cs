using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QuanLiNhaTu.Models;
using System.Windows.Input;

namespace QuanLiNhaTu.ViewModels
{
    public class QuanGiaoViewModel : BaseViewModel
    {
        public QUAN_LI_NHA_TUEntities1 db = new QUAN_LI_NHA_TUEntities1();

        private ObservableCollection<CAN_BO> _List;
        public ObservableCollection<CAN_BO> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private CAN_BO _SelectedItem;
        public CAN_BO SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    MaCanBo = SelectedItem.Ma_CB;
                    HoTen = SelectedItem.Ho_Ten;
                    NgaySinh = SelectedItem.Ngay_Sinh;
                    SDT = SelectedItem.SDT;
                }
            }
        }
        private string _MaCanBo;
        public string MaCanBo { get => _MaCanBo; set { _MaCanBo = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public QuanGiaoViewModel()
        {
            List = new ObservableCollection<CAN_BO>(db.CAN_BO);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (MaCanBo != null & HoTen != null)
                    return true;
                return false;
            }, (p) =>
            {
                var cb = new CAN_BO() { Ma_CB = MaCanBo, Ho_Ten = _HoTen, Ngay_Sinh = NgaySinh, SDT = SDT };

                db.CAN_BO.Add(cb);
                db.SaveChanges();

                List.Add(cb);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = db.CAN_BO.Where(x => x.Ma_CB == MaCanBo);
                if (displayList != null || displayList.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var tn = db.CAN_BO.Where(x => x.Ma_CB == SelectedItem.Ma_CB).SingleOrDefault();
                tn.Ma_CB = MaCanBo;
                tn.Ho_Ten = HoTen;
                tn.Ngay_Sinh = NgaySinh;
                tn.SDT = SDT;
                if (db.SaveChanges() == 1)
                {
                    List = new ObservableCollection<CAN_BO>(db.CAN_BO);
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                var cb = db.CAN_BO.Where(x => x.Ma_CB == SelectedItem.Ma_CB).SingleOrDefault();

                db.CAN_BO.Remove(cb);
                if (db.SaveChanges() == 1)
                {
                    List.Remove(cb);
                }
            });
        }
    }
}
