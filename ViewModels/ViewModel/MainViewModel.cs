using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private Services.Printing.IService printingService;
        public MainViewModel()
        {
            Title = "Main View Model";
            CycleVmsCommand = new RelayCommand(cycleVMs);
            VMs = new ObservableCollection<BaseViewModel>() { new CustomerViewModel(), new LargeDataViewModel(), new LoanConfirmationViewModel() };
            Breadcrumbs = new ObservableCollection<BaseViewModel>();
            CurrentIndex = 0;
            CurrentViewModel = VMs[CurrentIndex];
            Breadcrumbs.Add(CurrentViewModel);
        }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BaseViewModel> vms;

        public ObservableCollection<BaseViewModel> VMs
        {
            get { return vms; }
            set { vms = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BaseViewModel> breadcrumbs;

        public ObservableCollection<BaseViewModel> Breadcrumbs
        {
            get { return breadcrumbs; }
            set { breadcrumbs = value; OnPropertyChanged(); }
        }

        private ICommand cycleVmsCommand;

        public ICommand CycleVmsCommand
        {
            get { return cycleVmsCommand; }
            set { cycleVmsCommand = value; OnPropertyChanged(); }
        }

        private int currentIndex;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; OnPropertyChanged(); }
        }


        private void cycleVMs(object parameter)
        {
            if (CurrentIndex < (VMs.Count - 1))
            {
                ++CurrentIndex;
            }
            else
            {
                CurrentIndex = 0;
            }
            CurrentViewModel = VMs[CurrentIndex];
            Breadcrumbs.Add(CurrentViewModel);
        }
    }
}
