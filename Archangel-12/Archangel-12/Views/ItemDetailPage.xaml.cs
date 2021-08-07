using Archangel_12.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Archangel_12.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}