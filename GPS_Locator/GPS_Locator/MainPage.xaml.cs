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
        public MainPage()
        {
            InitializeComponent();
            GPSClass GPS = new GPSClass();
            AddressDataModel address = new AddressDataModel();
            address = GPS.DeserializeAdressObject();
            lblCity.Text = address.city;
            lblContinent.Text = address.continent;
            lblCountry.Text = address.countryName;
            lblLocality.Text = address.locality;
            lblPostCode.Text = address.postcode;
        }
    }
}
