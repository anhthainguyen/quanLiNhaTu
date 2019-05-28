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
using QuanLiNhaTu.Models;
using System.Windows.Controls;
using System.Security.Cryptography;

namespace QuanLiNhaTu.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        public QUAN_LI_NHA_TUEntities1 db = new QUAN_LI_NHA_TUEntities1();
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        public string Password;
        #region commands
        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        #endregion

        public LoginWindowViewModel()
        {
            IsLogin = false;
            Password = "";
            UserName = "";

            CloseCommand = new RelayCommand<Window>((p) => { return p == null? false : true; }, (p) => { p.Close(); });
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DoiMatKhau change = new DoiMatKhau();
                change.ShowDialog();
            });
        }
        void Login(Window p)
        {
            if (p == null)
                return;
            string passEncode = MD5Hash(Base64Encode(Password));
            var accCount = db.CAN_BO.Where(x => x.Ma_CB == UserName && x.Mat_Khau == passEncode).Count();
            var accCount2 = db.TU_NHAN.Where(x => x.Ma_Tu_N == UserName && x.Mat_Khau == passEncode).Count();
            if (accCount > 0)
            {
                IsLogin = true;
                MainWindow mainWindow = new MainWindow();
                p.Close();
                mainWindow.ShowDialog();
            }
            else if (accCount2 > 0)
            {
                IsLogin = true;
                ThanNhan thanNhan = new ThanNhan();
                p.Close();
                thanNhan.ShowDialog();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
