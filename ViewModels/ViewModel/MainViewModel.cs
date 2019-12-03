using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            PrintCommand = new RelayCommand(printCommandMethod);
            HidePanelCommand = new RelayCommand(HidePanelCommandMethod);
            printingService = new Services.Printing.Service();
            Panel1Visibile = Panel2Visible = Panel3Visible = true;
            ColumnIndex = 0;

            CurrentViewModel = new ParentViewModel();
            longRunningTask();
        }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; OnPropertyChanged(); }
        }


        private ICommand printCommand;
        private bool _panel1Visibile;
        private bool _panel2Visible;
        private bool _panel3Visible;
        private int _columnIndex;

        public ICommand PrintCommand
        {
            get { return printCommand; }
            set { printCommand = value; OnPropertyChanged(); }
        }

        private async void printCommandMethod(object parameter)
        {
            await Task.Run(() =>
            {
                if (parameter is FlowDocument fd)
                {
                    printingService.Print(fd, "Loan Confirmation Letter");
                }
            });
        }

        private async void longRunningTask()
        {
            Debug.Write("Starting long task");
            await Task.Delay(10_000);
            Debug.Write("Finished long task");
        }

        public ICommand HidePanelCommand { get; set; }

        private void HidePanelCommandMethod(object parameter)
        {
            Panel3Visible = false;
            ColumnIndex = 1;
        }

        public bool Panel1Visibile
        {
            get { return _panel1Visibile; }
            set { _panel1Visibile = value; OnPropertyChanged(); }
        }

        public bool Panel2Visible
        {
            get { return _panel2Visible; }
            set { _panel2Visible = value; OnPropertyChanged(); }
        }

        public bool Panel3Visible
        {
            get { return _panel3Visible; }
            set { _panel3Visible = value; OnPropertyChanged(); }
        }

        public int ColumnIndex
        {
            get { return _columnIndex; }
            set { _columnIndex = value; OnPropertyChanged(); }
        }
    }
}
