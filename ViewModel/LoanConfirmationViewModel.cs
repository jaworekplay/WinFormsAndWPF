using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModel
{
    public class LoanConfirmationViewModel : BaseViewModel
    {
        private Models.Application application;

        public LoanConfirmationViewModel()
        {
            Application = new Models.Application();
            Application.Breakdown = new ObservableCollection<Models.LoanPurpose>();
            for (int i = 0; i < 10; i++)
            {
                Application.Breakdown.Add(new Models.LoanPurpose { ID = i, Amount = (i + 1) * 100, Notes = $"{i}" });
            }

            GreetingTitle = "Mr. L Banach";
        }

        public Models.Application Application
        {
            get { return application; }
            set { application = value; OnPropertyChnaged(); }
        }

        private string greetingTitle;

        public string GreetingTitle
        {
            get { return greetingTitle; }
            set { greetingTitle = value; OnPropertyChnaged(); }
        }
    }
}
