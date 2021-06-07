using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

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

        private Border breadcrumbBorder;

        public Border BreadcrumbBorder
        {
            get => breadcrumbBorder;
            set { breadcrumbBorder = value; OnPropertyChanged(); }
        }
    }
}
