using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPS_Locator
{
    public partial class MainPage : ContentPage
    {
        public  MainPage()
        {
            Run();
        }
        public async void Run()
        {
            InitializeComponent();
            GPSClass GPS = new GPSClass();
            Root adress = new Root();
            string fullstring = await GPS.getAddress();
            adress = GPS.DeserializeAdressObject(fullstring);
            lblCity.Text = adress.city;
            lblContinent.Text = adress.continent;
            lblCountry.Text = adress.countryName;
            lblLocality.Text = adress.locality;
            
        }
    }
}
