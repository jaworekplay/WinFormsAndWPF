using System;
using System.Collections.Generic;
using System.Text;
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
            PrintCommand = new RelayCommand(printCommandMethod);
            printingService = new Services.Printing.Service();

            CurrentViewModel = new LargeDataViewModel();
        }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; OnPropertyChanged(); }
        }


        private ICommand printCommand;

        public ICommand PrintCommand
        {
            get { return printCommand; }
            set { printCommand = value; OnPropertyChanged(); }
        }

        private void printCommandMethod(object parameter)
        {
            if (parameter is FlowDocument fd)
            {
                printingService.Print(fd, "Loan Confirmation Letter");
            }
        }
    }
}
