using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WPF.Service
{
    public class MessageBoxService
    {
        AutoResetEvent _renderComplete = new AutoResetEvent(false);
        DispatcherFrame frame;

        public object Show(ViewModel.BaseViewModel vm)
        {
            Windows.Modal wnd = new Windows.Modal();
            wnd.ContentRendered += Wnd_ContentRendered;
            wnd.DataContext = vm;            
            // Flush the dispatcher queue
            //wnd.Dispatcher.Invoke(DispatcherPriority.Send, new System.Action(() => { }));
            wnd.Show();

            frame = new DispatcherFrame(true);
            frame.Continue = true;
            Dispatcher.PushFrame(frame);

            _renderComplete.WaitOne();
            _renderComplete.Reset();
            wnd.DataContext = null;
            wnd.Close();

            frame.Continue = false;
            return vm;
        }

        private void Wnd_ContentRendered(object sender, EventArgs e)
        {
            _renderComplete.Set();
            frame.Continue = false;
        }
    }
}
