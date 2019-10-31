using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using WPF.UIMultiThreading;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel.MainViewModel vm;
        private readonly object semaphor = new object();
        public MainWindow()
        {
            InitializeComponent();
            vm = this.DataContext as ViewModel.MainViewModel;
        }

        public ObservableCollection<ViewModel.LargeDataViewModel> Collection { get; set; } = new ObservableCollection<ViewModel.LargeDataViewModel>();

        private async void btnRender_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Collection.Add(new ViewModel.LargeDataViewModel());
            }

            await Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(Collection,
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                    TaskScheduler = new StaTaskScheduler(Environment.ProcessorCount)
                }, vm =>
                {
                    //once they are done render!!!
                    Services.MessageBoxService service = new Services.MessageBoxService();
                    service.RenderOnly(vm);
                });
            }, CancellationToken.None, TaskCreationOptions.LongRunning, new StaTaskScheduler(1));
        }
    }
}
