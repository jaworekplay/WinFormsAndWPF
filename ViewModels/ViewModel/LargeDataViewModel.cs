﻿using System;
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
            Title = "Large Data View Model";
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
                          ID = i,
                          LenderName = $"Lender Name {i}",
                          PlanName = $"Plan {i}",
                          APR = i % 2 == 0 ? 4d : 6d
                      });
                  }
                  Debug.WriteLine($"Finished creating items from Thread: {Thread.CurrentThread.ManagedThreadId}");
              });
        }

        public ObservableCollection<Models.FixedProduct> Products { get; set; }
    }
}
