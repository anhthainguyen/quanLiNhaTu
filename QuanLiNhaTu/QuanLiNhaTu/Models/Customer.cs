namespace QuanLiNhaTu.Models
{
    using System;
    using System.ComponentModel;

    public class Customer : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializers a new instance of the Customer class;
        /// </summary>
        public Customer(String customerName)
        {
            Name = customerName;
        }

        private string _Name;

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name"); //Thong bao ve viec co su thay doi
            }
        }

        #region InotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
