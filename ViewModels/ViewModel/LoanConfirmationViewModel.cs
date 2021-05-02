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
    public class LoanConfirmationViewModel : BaseViewModel
    {
        private Models.Application application;
        private Services.Printing.IService printingService;

        public LoanConfirmationViewModel()
        {
            Application = new Models.Application();
            Application.Breakdown = new ObservableCollection<Models.LoanPurpose>();
            for (int i = 0; i < 100; i++)
            {
                Application.Breakdown.Add(new Models.LoanPurpose { ID = i, Amount = (i + 1) * 100, Notes = $"{i}" });
            }

            GreetingTitle = "Mr. L Banach";
            Title = "Loan Confirmation View Model";

            PrintCommand = new RelayCommand(printCommandMethod);
            printingService = new Services.Printing.Service();
        }

        public Models.Application Application
        {
            get { return application; }
            set { application = value; OnPropertyChanged(); }
        }

        private string greetingTitle;

        public string GreetingTitle
        {
            get { return greetingTitle; }
            set { greetingTitle = value; OnPropertyChanged(); }
        }

        private ICommand printCommand;

        public ICommand PrintCommand
        {
            get { return printCommand; }
            set { printCommand = value; OnPropertyChanged(); }
        }

        private void printCommandMethod(object parameter)
        {
            if (parameter is object[] printParams)
            {
                var doc = (FixedDocument)printParams[0];
                var content = (PageContent)printParams[1];

                doc.Pages.Add(content);
            }
            if (parameter is FlowDocument fd)
            {
                printingService.AutoPrint(fd, "Report", "Loan Confirmation");
                printingService.Print(fd, "Loan Confirmation Letter");
            }
        }
    }
}
