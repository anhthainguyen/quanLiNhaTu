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
    public class ThanNhanViewModel : BaseViewModel
    {
        public QUAN_LI_NHA_TUEntities1 db = new QUAN_LI_NHA_TUEntities1();

        private ObservableCollection<THAN_NHAN> _List;
        public ObservableCollection<THAN_NHAN> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private THAN_NHAN _SelectedItem;
        public THAN_NHAN SelectedItem
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
                        MaThanNhan = SelectedItem.Ma_Than_N;
                        HoTen = SelectedItem.Ho_Ten;
                        GioiTinh = SelectedItem.Gioi_Tinh;
                        NgaySinh = SelectedItem.Ngay_Sinh;
                        SDT = SelectedItem.SDT;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private string _MaThanNhan;
        public string MaThanNhan { get => _MaThanNhan; set { _MaThanNhan = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ThanNhanViewModel()
        {
            List = new ObservableCollection<THAN_NHAN>(db.THAN_NHAN);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (MaThanNhan != null & HoTen != null)
                    return true;
                return false;

            }, (p) =>
            {
                try
                {
                    var tn = new THAN_NHAN() { Ma_Than_N = MaThanNhan, Ho_Ten = _HoTen, Gioi_Tinh = GioiTinh, Ngay_Sinh = NgaySinh, SDT = SDT };

                    db.THAN_NHAN.Add(tn);
                    db.SaveChanges();

                    List.Add(tn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = db.THAN_NHAN.Where(x => x.Ma_Than_N == MaThanNhan);
                if (displayList != null || displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                try
                {
                    var tn = db.THAN_NHAN.Where(x => x.Ma_Than_N == SelectedItem.Ma_Than_N).SingleOrDefault();
                    tn.Ma_Than_N = MaThanNhan;
                    tn.Ho_Ten = HoTen;
                    tn.Gioi_Tinh = GioiTinh;
                    tn.Ngay_Sinh = NgaySinh;
                    tn.SDT = SDT;
                    if (db.SaveChanges() == 1)
                    {
                        List = new ObservableCollection<THAN_NHAN>(db.THAN_NHAN);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                try
                {
                    var tn = db.THAN_NHAN.Where(x => x.Ma_Than_N == SelectedItem.Ma_Than_N).SingleOrDefault();

                    db.THAN_NHAN.Remove(tn);
                    if (db.SaveChanges() == 1)
                    {
                        List.Remove(tn);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }
    }
}
