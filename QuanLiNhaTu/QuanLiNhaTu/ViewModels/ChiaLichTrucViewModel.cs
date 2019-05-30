using QuanLiNhaTu.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLiNhaTu.ViewModels
{
    public class ChiaLichTrucViewModel : BaseViewModel
    {
        public QUAN_LI_NHA_TUEntities1 db = new QUAN_LI_NHA_TUEntities1();

        private ObservableCollection<CAN_BO> _lstCanBo;
        public ObservableCollection<CAN_BO> lstCanBo { get => _lstCanBo; set { _lstCanBo = value; OnPropertyChanged(); } }

        private ObservableCollection<CONG_VIEC> _lstCongViec;
        public ObservableCollection<CONG_VIEC> lstCongViec { get => _lstCongViec; set { _lstCongViec = value; OnPropertyChanged(); } }

        private ObservableCollection<DTOCanBoCongViec> _lstCanBoCongViec;
        public ObservableCollection<DTOCanBoCongViec> lstCanBoCongViec { get => _lstCanBoCongViec; set { _lstCanBoCongViec = value; OnPropertyChanged(); } }

        private ObservableCollection<BO_PHAN> _BoPhan;
        public ObservableCollection<BO_PHAN> BoPhan { get => _BoPhan; set { _BoPhan = value; OnPropertyChanged(); } }

        private CAN_BO _SelectedItemCanBo;
        public CAN_BO SelectedItemCanBo
        {
            get => _SelectedItemCanBo;
            set
            {
                _SelectedItemCanBo = value;
                OnPropertyChanged();
                if (SelectedItemCanBo != null)
                {
                    MaCanBo = SelectedItemCanBo.Ma_CB;
                    HoTen = SelectedItemCanBo.Ho_Ten;
                    SDT = SelectedItemCanBo.SDT;
                    NgaySinh = SelectedItemCanBo.Ngay_Sinh;
                    SelectedBoPhan = _SelectedItemCanBo.BO_PHAN;
                    Binding_CanBo_CongViec();
                }
            }
        }

        private CONG_VIEC _SelectedItemCongViec;
        public CONG_VIEC SelectedItemCongViec
        {
            get => _SelectedItemCongViec;
            set
            {
                _SelectedItemCongViec = value;
                OnPropertyChanged();
                if (SelectedItemCongViec != null)
                {
                    MaCongViec = SelectedItemCongViec.Ma_CV;
                    TenCongViec = SelectedItemCongViec.Ten_CV;
                }
            }
        }

        private DTOCanBoCongViec _SelectedItemCanBoCongViec;
        public DTOCanBoCongViec SelectedItemCanBoCongViec
        {
            get => _SelectedItemCanBoCongViec;
            set
            {
                _SelectedItemCanBoCongViec = value;
                OnPropertyChanged();
                if (SelectedItemCanBoCongViec != null)
                {
                    Ma = SelectedItemCanBoCongViec.Ma;
                    Ten_CongViec = SelectedItemCanBoCongViec.Ten_CongViec;
                    Ten_CanBo = SelectedItemCanBoCongViec.Ten_CanBo;
                }
            }
        }

        private BO_PHAN _SelectedBoPhan;
        public BO_PHAN SelectedBoPhan
        {
            get => _SelectedBoPhan;
            set
            {
                _SelectedBoPhan = value;
                OnPropertyChanged();
            }
        }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        #region binding data Can Bo
        private string _MaCanBo;
        public string MaCanBo { get => _MaCanBo; set { _MaCanBo = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }

        private DateTime? _NgaySinh;
        public DateTime? NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }
        #endregion

        #region binding data Công việc
        private string _MaCongViec;
        public string MaCongViec { get => _MaCongViec; set { _MaCongViec = value; OnPropertyChanged(); } }

        private string _TenCongViec;
        public string TenCongViec { get => _TenCongViec; set { _TenCongViec = value; OnPropertyChanged(); } }
        #endregion

        #region binding data Cán bộ - Công việc
        private string _Ma;
        public string Ma { get => _Ma; set { _Ma = value; OnPropertyChanged(); } }

        private string _Ten_CongViec;
        public string Ten_CongViec { get => _Ten_CongViec; set { _Ten_CongViec = value; OnPropertyChanged(); } }

        private string _Ten_CanBo;
        public string Ten_CanBo { get => _Ten_CanBo; set { _Ten_CanBo = value; OnPropertyChanged(); } }
        #endregion

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand AddWorkCommand { get; set; }
        public ICommand EditWorkCommand { get; set; }
        public ICommand DeleteWorkCommand { get; set; }

        public ICommand CBCVAddCommand { get; set; }
        public ICommand CBCVDeleteCommand { get; set; }

        public ICommand ControlMaCanBo { get; set; }
        public ChiaLichTrucViewModel()
        {
            BoPhan = new ObservableCollection<BO_PHAN>(db.BO_PHAN);

            #region ViewModel Cán bộ
            lstCanBo = new ObservableCollection<CAN_BO>(db.CAN_BO);

            ControlMaCanBo = new RelayCommand<object>((q) =>
            {
                if (SelectedItemCanBo != null)
                    return false;
                return true;
            }, (q) => { });

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (MaCanBo != null & HoTen != null)
                    return true;
                return false;

            }, (p) =>
            {
                var tn = new CAN_BO()
                {
                    Ma_CB = MaCanBo
                    ,
                    Ho_Ten = _HoTen
                    ,
                    SDT = SDT
                    ,
                    Ngay_Sinh = NgaySinh
                    ,
                    Ma_BP = SelectedBoPhan.Ma_BP
                };
                db.CAN_BO.Add(tn);
                if (db.SaveChanges() == 1)
                {
                    lstCanBo.Add(tn);
                }
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemCanBo == null)
                    return false;

                var displayList = db.CAN_BO.Where(x => x.Ma_CB == MaCanBo);
                if (displayList != null || displayList.Count() != 0)
                {
                    return true;
                }

                return false;

            }, (p) =>
            {
                var tn = db.CAN_BO.Where(x => x.Ma_CB == SelectedItemCanBo.Ma_CB).SingleOrDefault();
                tn.Ma_CB = MaCanBo;
                tn.Ho_Ten = HoTen;
                tn.SDT = SDT;
                tn.Ngay_Sinh = NgaySinh;
                tn.Ma_BP = SelectedBoPhan.Ma_BP;
                if (db.SaveChanges() == 1)
                {
                    lstCanBo = new ObservableCollection<CAN_BO>(db.CAN_BO);
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemCanBo == null)
                    return false;
                return true;

            }, (p) =>
            {
                var tn = db.CAN_BO.Where(x => x.Ma_CB == SelectedItemCanBo.Ma_CB).SingleOrDefault();

                db.CAN_BO.Remove(tn);
                if (db.SaveChanges() == 1)
                {
                    lstCanBo.Remove(tn);
                }
            });
            #endregion

            #region ViewModel Công việc
            lstCongViec = new ObservableCollection<CONG_VIEC>(db.CONG_VIEC);

            AddWorkCommand = new RelayCommand<object>((p) =>
            {
                if (MaCongViec != null & TenCongViec != null)
                    if (lstCongViec.Where(x => x.Ma_CV == MaCongViec).Count() == 0)
                        return true;
                return false;

            }, (p) =>
            {
                var tn = new CONG_VIEC()
                {
                    Ma_CV = MaCongViec
                    ,
                    Ten_CV = TenCongViec
                };
                db.CONG_VIEC.Add(tn);
                if (db.SaveChanges() == 1)
                {
                    lstCongViec.Add(tn);
                }
            });

            EditWorkCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemCongViec == null)
                    return false;

                var displayList = db.CONG_VIEC.Where(x => x.Ma_CV == MaCongViec);
                if (displayList != null || displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var tn = db.CONG_VIEC.Where(x => x.Ma_CV == SelectedItemCongViec.Ma_CV).SingleOrDefault();
                tn.Ma_CV = MaCongViec;
                tn.Ten_CV = TenCongViec;
                if (db.SaveChanges() == 1)
                {
                    lstCongViec = new ObservableCollection<CONG_VIEC>(db.CONG_VIEC);
                }
            });

            DeleteWorkCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemCongViec == null)
                    return false;
                return true;

            }, (p) =>
            {
                var tn = db.CONG_VIEC.Where(x => x.Ma_CV == SelectedItemCongViec.Ma_CV).SingleOrDefault();

                db.CONG_VIEC.Remove(tn);
                if (db.SaveChanges() == 1)
                {
                    lstCongViec.Remove(tn);
                }
            });
            #endregion

            #region ViewModel Cán bộ - Công Việc
            CBCVAddCommand = new RelayCommand<object>((p) =>
            {
                if (MaCanBo != null & MaCongViec != null)
                    if (lstCanBoCongViec.Where(x => x.Ma == MaCongViec).Count() == 0)
                        return true;
                return false;

            }, (p) =>
            {
                using (QUAN_LI_NHA_TUEntities1 conn = new QUAN_LI_NHA_TUEntities1())
                {
                    CAN_BO cb = new CAN_BO { Ma_CB = MaCanBo };
                    conn.CAN_BO.Add(cb);
                    conn.CAN_BO.Attach(cb);
                    CONG_VIEC cv = new CONG_VIEC { Ma_CV = MaCongViec };
                    conn.CONG_VIEC.Add(cv);
                    conn.CONG_VIEC.Attach(cv);
                    cb.CONG_VIEC.Add(cv);
                    if (conn.SaveChanges() == 1)
                    {
                        Binding_CanBo_CongViec();
                    }
                }
            });

            CBCVDeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemCanBoCongViec == null)
                    return false;
                return true;

            }, (p) =>
            {
                var cb = db.CAN_BO.FirstOrDefault(e => e.Ma_CB == MaCanBo);
                var cv = db.CONG_VIEC.FirstOrDefault(s => s.Ma_CV == Ma);
                //cb.CONG_VIEC.Remove(cv);
                cv.CAN_BO.Remove(cb);
                if (db.SaveChanges() == 1)
                {
                    Binding_CanBo_CongViec();
                }
            });
            #endregion
        }

        private void Binding_CanBo_CongViec()
        {
            lstCanBoCongViec = new ObservableCollection<DTOCanBoCongViec>(from a in db.CAN_BO
                                                                          from b in a.CONG_VIEC
                                                                          join c in db.CONG_VIEC on b.Ma_CV equals c.Ma_CV
                                                                          where a.Ma_CB == SelectedItemCanBo.Ma_CB
                                                                          select new DTOCanBoCongViec
                                                                          {
                                                                              Ten_CanBo = a.Ho_Ten,
                                                                              Ten_CongViec = c.Ten_CV
                                                                          });
        }
    }
}
