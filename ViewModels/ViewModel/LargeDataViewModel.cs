using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LargeDataViewModel : BaseViewModel
    {
        public LargeDataViewModel()
        {
            Products = new ObservableCollection<Models.FixedProduct>();
            Init();
        }

        void Init()
        {
            _ = Task.Run(() =>
              {
                  Debug.WriteLine($"Creating items from Thread: {Thread.CurrentThread.ManagedThreadId}");
                  for (int i = 0; i < 10_000; i++)
                  {
                      Products.Add(new Models.FixedProduct
                      {
                          LenderName = $"Lender Name {i}",
                          PlanName = $"Plan {i}"
                      });
                  }
                  Debug.WriteLine($"Finished creating items from Thread: {Thread.CurrentThread.ManagedThreadId}");
              });
        }

        public ObservableCollection<Models.FixedProduct> Products { get; set; }
    }
}
