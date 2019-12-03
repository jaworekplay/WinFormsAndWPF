using System.Collections.ObjectModel;
using Models;

namespace ViewModel
{
    public class ClientCreditReportViewModel : BaseViewModel
    {
        private ObservableCollection<FixedProduct> _products;

        public ClientCreditReportViewModel()
        {
            Products = new ObservableCollection<FixedProduct>();

            for (int i = 1; i <= 1_000; i++)
            {
                if (i % 2 == 0)
                {
                    Products.Add(new FixedProduct
                    {
                        Index = i,
                        LenderName = "1st Stop",
                        PlanName = "PF Something 2yr Emp OCT",
                        FixedRepayment = 100,
                        FixedRate = 9.0,
                        ReversionRate = 9.5,
                        BrokerFee = 200m,
                        Commission = 250m,
                        LenderFee = 300m,
                        FixedTerm = i,
                        APR = 9.8,
                        ReversionRepayment = 250m,
                        CheapestFixedRepayment = true
                    });
                }
                if (i % 3 == 0)
                {
                    Products.Add(new FixedProduct
                    {
                        Index = i,
                        LenderName = "1st Stop",
                        PlanName = "PF Something 2yr Emp OCT",
                        FixedRepayment = 100,
                        FixedRate = 9.0,
                        ReversionRate = 9.5,
                        BrokerFee = 200m,
                        Commission = 250m,
                        LenderFee = 300m,
                        FixedTerm = i,
                        APR = 9.8,
                        ReversionRepayment = 250m,
                        CheapestFixedRate = true
                    });
                }
                if (i % 4 == 0)
                {
                    Products.Add(new FixedProduct
                    {
                        Index = i,
                        LenderName = "1st Stop",
                        PlanName = "PF Something 2yr Emp OCT",
                        FixedRepayment = 100,
                        FixedRate = 9.0,
                        ReversionRate = 9.5,
                        BrokerFee = 200m,
                        Commission = 250m,
                        LenderFee = 300m,
                        FixedTerm = i,
                        APR = 9.8,
                        ReversionRepayment = 250m,
                        CheapestReversionRate = true
                    });
                }
                if (i % 5 == 0)
                {
                    Products.Add(new FixedProduct
                    {
                        Index = i,
                        LenderName = "1st Stop",
                        PlanName = "PF Something 2yr Emp OCT",
                        FixedRepayment = 100,
                        FixedRate = 9.0,
                        ReversionRate = 9.5,
                        BrokerFee = 200m,
                        Commission = 250m,
                        LenderFee = 300m,
                        FixedTerm = i,
                        APR = 9.8,
                        ReversionRepayment = 250m,
                        CheapestBrokerFee = true
                    });
                }
                if (i % 6 == 0)
                {
                    Products.Add(new FixedProduct
                    {
                        Index = i,
                        LenderName = "1st Stop",
                        PlanName = "PF Something 2yr Emp OCT",
                        FixedRepayment = 100,
                        FixedRate = 9.0,
                        ReversionRate = 9.5,
                        BrokerFee = 200m,
                        Commission = 250m,
                        LenderFee = 300m,
                        FixedTerm = i,
                        APR = 9.8,
                        ReversionRepayment = 250m,
                        CheapestCommission = true
                    });
                }
                else
                {
                    Products.Add(new FixedProduct
                    {
                        Index = i,
                        LenderName = "Santander",
                        PlanName = "PF Something 2yr Emp OCT",
                        FixedRepayment = 1000,
                        FixedRate = 9.0,
                        ReversionRate = 9.5,
                        BrokerFee = 200m,
                        Commission = 250m,
                        LenderFee = 300m,
                        FixedTerm = i,
                        APR = 9.8,
                        ReversionRepayment = 250m
                    });
                }
            }
        }

        public ObservableCollection<FixedProduct> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }
    }
}