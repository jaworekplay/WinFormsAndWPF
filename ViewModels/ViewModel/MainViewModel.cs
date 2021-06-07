using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using ViewModel.Commands;
using System.Windows.Media;

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
            CurrentViewModel.BreadcrumbBorder = new Border { BorderBrush = Brushes.LightCoral, BorderThickness = new Thickness(2)};
        }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => currentViewModel;
            set { currentViewModel = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BaseViewModel> vms;

        public ObservableCollection<BaseViewModel> VMs
        {
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
            CurrentViewModel = VMs[CurrentIndex];
            SetBreadcrumbBorder(CurrentViewModel.Title);

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
            var title = parameter.Title;
            SetBreadcrumbBorder(title);
        }

        private void SetBreadcrumbBorder(string vmTitle)
        {
            foreach (var t in VMs)
            {
                if (t.Title == vmTitle)
                {
                    CurrentViewModel = t;
                    var newBorder = new Border
                    {
                        BorderBrush = Brushes.LightCoral,
                        BorderThickness = new Thickness(2)
                    };
                    t.BreadcrumbBorder = newBorder;
                }
                else
                {
                    var newBorder = new Border
                    {
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(2)
                    };
                    t.BreadcrumbBorder = newBorder;
                }
            }
        }
    }
}
