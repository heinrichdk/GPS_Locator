using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace GPS_Locator
{
    public  class GPSClass
    {
        static HttpClient client = new HttpClient();
        private async Task<string> getAddress()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                string address = null;
                if (location != null)
                {
                    HttpResponseMessage response = await client.GetAsync(String.Format("https://api.bigdatacloud.net/data/reverse-geocode-client?latitude={0}&longitude={1}&localityLanguage=en", location.Latitude, location.Longitude));
                    if (response.IsSuccessStatusCode)
                    {
                        address = await response.Content.ReadAsStringAsync();
                    }
                }
                return address;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public  AddressDataModel DeserializeAdressObject()
        {

            AddressDataModel address = new AddressDataModel();
            string json = getAddress().ToString();
            if(json != null)
            {
                address = JsonSerializer.Deserialize<AddressDataModel>(json);
            }
            return address;
        }
    }
  
}
