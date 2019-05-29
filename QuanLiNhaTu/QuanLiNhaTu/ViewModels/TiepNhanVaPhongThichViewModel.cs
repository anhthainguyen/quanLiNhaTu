using QuanLiNhaTu.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaTu.ViewModels
{
    public class TiepNhanVaPhongThichViewModel : BaseViewModel
    {
        private ObservableCollection<TU_NHAN> _List;
        public ObservableCollection<TU_NHAN> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private TU_NHAN _SelectedItem;
        public TU_NHAN SelectedItem { get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                   // DisplayName=SelectedItem.Dis
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public TiepNhanVaPhongThichViewModel()
        {
            List = new ObservableCollection<TU_NHAN>(DataProvider.Ins.DB.TU_NHAN);
        }
    }
}
