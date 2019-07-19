using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Models.User> _users;
        private ICommand _deleteCommand;

        public MainViewModel()
        {
            Users = new ObservableCollection<Models.User>();

            for (int i = 0; i < 100; i++)
            {
                Users.Add(new Models.User { ID = i, FirstName = "John", Surname = "Connor" });
            }

            DeleteCommand = new RelayCommand(deleteCommandMethod);
        }

        public ObservableCollection<Models.User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChnaged();
            }
        }

        private Models.User selectedUser;

        public Models.User SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChnaged(); }
        }
        
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
            set
            {
                _deleteCommand = value;
            }
        }

        private void deleteCommandMethod(object parameter)
        {
            Users.Remove(SelectedUser);
        }
    }
}
