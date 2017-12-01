using System;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace KundePortal.ViewModel
{
    public class ProGPSViewModel
    {
        public string longi { get; set; }
        public string lat { get; set; }

        public ProGPSViewModel()
        {
            hello();
        }

        async void hello(){
            await GetfirstPosition();
        }

        async Task GetfirstPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));

            longi = position.Longitude.ToString();
            lat = position.Latitude.ToString();
        }
    }
}
