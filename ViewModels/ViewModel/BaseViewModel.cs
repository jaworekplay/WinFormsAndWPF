using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;

        public string Title
        {
            get => title;
            protected set { title = value; OnPropertyChanged(); }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(); }
        }
    }
}
