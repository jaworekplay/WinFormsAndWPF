using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ParentViewModel : BaseViewModel
    {
        private ObservableCollection<string> items;

        public ParentViewModel()
        {
            PrintCommand = new Commands.RelayCommand(Print);
            Items = new ObservableCollection<string>();
            for (int i = 0; i < 5; i++)
            {
                Items.Add($"{i}");
            }
        }

        public ObservableCollection<string> Items
        {
            get { return items; }
            set { items = value; OnPropertyChanged(); }
        }

        public ICommand PrintCommand { get; set; }

        private void Print(object parameter)
        {

        }
    }
}
