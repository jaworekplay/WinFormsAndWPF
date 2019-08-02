using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Models;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        private ICommand _deleteCommand;

        public MainViewModel()
        {
            Users = new ObservableCollection<User>();

            InitialiseComponents();

            DeleteCommand = new RelayCommand(deleteCommandMethod, canExecuteDeleteCommandMethod);
        }

        void InitialiseComponents()
        {
            using (var db = new CompanyContext())
            {
                foreach (var u in db.Users.ToList())
                {
                    Users.Add(u);
                }
            }
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChnaged();
            }
        }

        private User selectedUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChnaged();
                (DeleteCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }
        
        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
            set
            {
                _deleteCommand = value;
            }
        }

        private bool canExecuteDeleteCommandMethod(object parameter)
        {
            return SelectedUser != null;
        }

        private void deleteCommandMethod(object parameter)
        {
            if (parameter is ObservableCollection<object> users)
            {
                var items = users.Cast<User>().ToList();
                foreach (var user in items)
                {
                    Users.Remove(user);
                }
            }
            Users.Remove(SelectedUser);
        }
    }
}
