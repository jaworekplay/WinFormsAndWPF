using Microsoft.Xaml.Behaviors;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_UserControls.DragAndDrop.Behaviours
{
    public class DragWithPreviewBehaviour : Behavior<FrameworkElement>
    {
        public const double DPIx = 96, DPIy = 96;
        private Window wnd, activeWindow;

        protected override void OnAttached()
        {
            wnd = new Window();
            wnd.AllowsTransparency = true;
            wnd.WindowStyle = WindowStyle.None;
            wnd.Topmost = true;
            wnd.ShowInTaskbar = false;
            wnd.AllowDrop = false;
            wnd.IsHitTestVisible = false;
            wnd.SizeToContent = SizeToContent.WidthAndHeight;
            wnd.Background = new SolidColorBrush(Colors.Red);

            AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp += AssociatedObject_PreviewMouseLeftButtonUp;
            //AssociatedObject.Drop += AssociatedObject_Drop;
            AssociatedObject.GiveFeedback += AssociatedObject_GiveFeedback;
        }

        private void AssociatedObject_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            wnd.Close();
        }

        private void AssociatedObject_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            var pos = Mouse.GetPosition(activeWindow);
            wnd.Left = pos.X;
            wnd.Top = pos.Y;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AssociatedObject_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            activeWindow = Application.Current.Windows.OfType<Window>().Single(w => w.IsActive);
            var content = new RenderTargetBitmap((int)AssociatedObject.ActualWidth, (int)AssociatedObject.ActualHeight, DPIx, DPIy, PixelFormats.Pbgra32);

            content.Render(AssociatedObject);
            //wnd.Content = content;
            wnd.Show();
        }
    }
}
