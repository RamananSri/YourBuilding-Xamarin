using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KundePortal.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridPro : ContentPage
    {
        public GridPro()
        {
            InitializeComponent();
        }

        async void messageTapped(object sender, EventArgs args)
        {          
            var imageSender = (Image)sender;
            await imageSender.Navigation.PushAsync(new questionPagePro());
        }

        async void searchTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            await imageSender.Navigation.PushAsync(new questionPagePro());
        }

    }
}