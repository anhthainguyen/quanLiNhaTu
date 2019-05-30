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
    public class ControlBarViewModel : BaseViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand RestoreWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        #endregion
        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                try
                {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
         );
            RestoreWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                try
                {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        if (w.WindowState != WindowState.Maximized)
                        {
                            w.WindowState = WindowState.Maximized;
                        }
                        else
                        {
                            w.WindowState = WindowState.Normal;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
         );
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                try
                {

                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w.WindowState != WindowState.Minimized)
                    {
                        w.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        w.WindowState = WindowState.Maximized;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
         );
            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                try
                {
                    FrameworkElement window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.DragMove();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred: " + ex.InnerException, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
         );
        }
        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}
