﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Service.MessageBoxService service = new Service.MessageBoxService();
            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine($"Generating letter {(i + 1)}");
                service.Show(new ClientCreditReportViewModel());
                Debug.WriteLine("Finished");
            }
            Debug.WriteLine("Documents generated");
        }
    }
}
