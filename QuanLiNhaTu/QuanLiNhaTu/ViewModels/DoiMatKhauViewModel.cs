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
    public class DoiMatKhauViewModel : BaseViewModel
    {
        public QUAN_LI_NHA_TUEntities db = new QUAN_LI_NHA_TUEntities();

        public static string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        public string PasswordNow;

        public string PasswordBoxNew;

        public string PasswordBoxAgain;

        public string _Massage;
        public string Massage { get => _Massage; set { _Massage = value; OnPropertyChanged(); } }

        private string RadioStringChecked;
         
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand RadioCommand { get; set; }

        public ICommand PasswordNowCommand { get; set; }
        public ICommand PasswordBoxNewCommand { get; set; }
        public ICommand PasswordBoxAgainCommand { get; set; }

        public DoiMatKhauViewModel()
        {
            PasswordNowCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PasswordNow = p.Password; });
            PasswordBoxNewCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PasswordBoxNew = p.Password; });
            PasswordBoxAgainCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { PasswordBoxAgain = p.Password; });

            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            RadioCommand = new RelayCommand<string>((p) => { return true; }, (p) => { RadioStringChecked = p.ToString(); });

            SaveCommand = new RelayCommand<Window>((p) => 
            {
                if (UserName != null & PasswordNow != null & PasswordBoxNew != null & PasswordBoxAgain != null)
                    return true;
                return false;
            }
            , (p) => { Luu(p); });
            
            //else if (RadioStringChecked == "ThanNhan")
            //{
            //    accCount = db.THAN_NHAN.Where(x => x.Ma_Than_N == UserName && x.Mat_Khau == passEncode).Count();
            //    if (accCount == 0)
            //    {
            //        Massage = "Sai tài khoản hoặc mật khẩu !";
            //    }
            //}
        }
        private void Luu(Window p)
        {
            if (PasswordBoxNew != PasswordBoxAgain)
            {
                Massage = "Mật khẩu mới không trùng khớp !!!";
                return;
            }
            
            string passEncode = MD5Hash(Base64Encode(PasswordNow));
            string passNew = MD5Hash(Base64Encode(PasswordBoxNew));
            string passNewAgain = MD5Hash(Base64Encode(PasswordBoxAgain));
            int accCount = 0;
            if (RadioStringChecked == null || RadioStringChecked == "CanBo")
            {
                accCount = db.CAN_BO.Where(x => x.Ma_CB == UserName && x.Mat_Khau == passEncode).Count();
                if (accCount > 0)
                {
                    if (PasswordBoxNew == PasswordNow)
                    {
                        Massage = "Mật khẩu mới không được trùng mật khẩu cũ !!!";
                        return;
                    }
                    var cb = db.CAN_BO.Where(x => x.Ma_CB == UserName).SingleOrDefault();
                    cb.Mat_Khau = passNew;
                    if (db.SaveChanges() == 1)
                    {
                        Massage = "Đổi mật khẩu thành công.";
                    }
                }
                else
                {
                    Massage = "Sai tài khoản hoặc mật khẩu !";
                }
            }
            else
            {
                accCount = db.THAN_NHAN.Where(x => x.Ma_Than_N == UserName && x.Mat_Khau == passEncode).Count();
                if (accCount > 0)
                {
                    if (PasswordBoxNew == PasswordNow)
                    {
                        Massage = "Mật khẩu mới không được trùng mật khẩu cũ !!!";
                        return;
                    }
                    var tn = db.THAN_NHAN.Where(x => x.Ma_Than_N == UserName).SingleOrDefault();
                    tn.Mat_Khau = passNew;
                    if (db.SaveChanges() == 1)
                    {
                        Massage = "Đổi mật khẩu thành công.";
                    }
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
