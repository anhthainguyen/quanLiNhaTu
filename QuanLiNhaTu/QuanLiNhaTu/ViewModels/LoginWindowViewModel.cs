using QuanLiNhaTu.Models;
using QuanLiNhaTu.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLiNhaTu.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand QuanGiaoWindowCommand { get; set; }
        public ICommand ChangePasswordWindowCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        #endregion

        public LoginWindowViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p)=> { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null? false : true; }, (p) => { p.Close(); });
            QuanGiaoWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>

            {
                QuanGiao qg = new QuanGiao();
                qg.ShowDialog();
          
            });
            ChangePasswordWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>

            {
                DoiMatKhau change = new DoiMatKhau();
                change.ShowDialog();
            });
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            var accCount = DataProvider.Ins.DB.CAN_BO.Where(x => x.Ma_CB == UserName && x.Mat_Khau == Password).Count() +
                DataProvider.Ins.DB.TU_NHAN.Where(x=>x.Ma_Tu_N == UserName && x.Mat_Khau == Password).Count();
            if(accCount>0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Wrong username or password");
            }
            
        }
    }
}
