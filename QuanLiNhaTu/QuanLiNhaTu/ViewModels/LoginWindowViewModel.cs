using QuanLiNhaTu.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLiNhaTu.Models;
using System.Windows.Controls;
using System.Security.Cryptography;

namespace QuanLiNhaTu.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        public QUAN_LI_NHA_TUEntities db = new QUAN_LI_NHA_TUEntities();

        public static string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        public string Password;
        public string RadioStringChecked;
        public string _Massage;
        public string Massage { get => _Massage; set { _Massage = value; OnPropertyChanged(); } }
        #region commands
        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand PasswordCommand { get; set; }
        public ICommand RadioCommand { get; set; }
        #endregion

        public LoginWindowViewModel()
        {
            Password = "";
            UserName = "";

            CloseCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) => { p.Close(); });
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { PasswordChan(p); });
            RadioCommand = new RelayCommand<string>((p) => { return true; }, (p) => { RadioStringChecked = p.ToString(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            //ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) =>

            //{
            //    DoiMatKhau change = new DoiMatKhau();
            //    change.ShowDialog();
            //});
        }

        private void PasswordChan(Window p)
        {
            DoiMatKhau mainWindow = new DoiMatKhau();
            p.Close();
            mainWindow.ShowDialog();
        }

        void Login(Window p)
        {
            if (p == null)
                return;
            string passEncode = MD5Hash(Base64Encode(Password));
            int accCount = 0;
            if (RadioStringChecked == null || RadioStringChecked == "CanBo")
            {
                accCount = db.CAN_BO.Where(x => x.Ma_CB == UserName && x.Mat_Khau == passEncode).Count();
                if (accCount > 0)
                {
                    TuNhan mainWindow = new TuNhan();
                    p.Close();
                    mainWindow.ShowDialog();
                }
                else
                {
                    Massage = "Sai tài khoản hoặc mật khẩu !";
                }
            }
            else if (RadioStringChecked == "ThanNhan")
            {
                accCount = db.THAN_NHAN.Where(x => x.Ma_Than_N == UserName && x.Mat_Khau == passEncode).Count();
                if (accCount > 0)
                {
                    MainThanNhan tnwindow = new MainThanNhan();
                    p.Close();
                    tnwindow.ShowDialog();
                }
                else
                {
                    Massage = "Sai tài khoản hoặc mật khẩu !";
                }
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
