namespace QuanLiNhaTu.Commands
{
    using System.Windows.Input;
    using QuanLiNhaTu.ViewModels;

    internal class CustomerUpdateCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the CustomerUpdateCommand class.
        /// </summary>
        /// <param name="viewModel"></param>
        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        private CustomerViewModel _ViewModel;

        #region Icommand Members

        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _ViewModel.SaveChanges();
        }
        #endregion
    }
}
