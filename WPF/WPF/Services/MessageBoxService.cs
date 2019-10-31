using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPF.UIMultiThreading;

namespace WPF.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public bool? Render(ViewModel.BaseViewModel viewModel)
        { 
            RenderWindow wnd = new RenderWindow();
            wnd.DataContext = viewModel;
            return wnd.ShowDialog();
        }

        public void RenderOnly(ViewModel.BaseViewModel vm)
        {
            Debug.WriteLine($"Starting Render on Thread: {Thread.CurrentThread.ManagedThreadId}");
            RenderWindow wnd = new RenderWindow();
            wnd.ContentRendered += Wnd_ContentRendered;
            wnd.DataContext = vm;
            wnd.ShowDialog();
            wnd.ContentRendered -= Wnd_ContentRendered;
        }

        private void Wnd_ContentRendered(object sender, EventArgs e)
        {
            //get I am groot
            Thread.Sleep(250);
            if (sender is Window wnd)
            {
                Debug.WriteLine($"Finished render on Thread: {Thread.CurrentThread.ManagedThreadId}");
                wnd.Close();
                //wnd.DataContext = null;
                GC.Collect();
            }
        }
    }
}
