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
            SwitchVmCommand = new RelayCommand<BaseViewModel>(switchVM);
            VMs = new ObservableCollection<BaseViewModel>() { new CustomerViewModel(), new LargeDataViewModel(), new LoanConfirmationViewModel() };
            Breadcrumbs = new ObservableCollection<BaseViewModel>();
            CurrentIndex = 0;
            CurrentViewModel = VMs[CurrentIndex];
            Breadcrumbs.Add(CurrentViewModel);
            CurrentViewModel.IsSelected = true;
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
            get => vms;
            set { vms = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BaseViewModel> breadcrumbs;

        public ObservableCollection<BaseViewModel> Breadcrumbs
        {
            get => breadcrumbs;
            set { breadcrumbs = value; OnPropertyChanged(); }
        }

        private ICommand cycleVmsCommand;

        public ICommand CycleVmsCommand
        {
            get => cycleVmsCommand;
            private set { cycleVmsCommand = value; OnPropertyChanged(); }
        }

        private int currentIndex;

        public int CurrentIndex
        {
            get => currentIndex;
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
            CurrentViewModel.IsSelected = false;
            CurrentViewModel = VMs[CurrentIndex];
            CurrentViewModel.IsSelected = true;

            if (!Breadcrumbs.Contains(CurrentViewModel))
            {
                Breadcrumbs.Add(CurrentViewModel);
            }
        }

        private ICommand switchVmCommand;

        public ICommand SwitchVmCommand
        {
            get => switchVmCommand;
            private set { switchVmCommand = value; OnPropertyChanged(); }
        }

        private void switchVM(BaseViewModel parameter)
        {
            CurrentViewModel.IsSelected = false;
            CurrentViewModel = parameter;
            CurrentViewModel.IsSelected = true;
        }
    }
}
