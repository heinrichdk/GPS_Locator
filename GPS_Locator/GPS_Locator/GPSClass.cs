using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace GPS_Locator
{
    public  class GPSClass
    {
        static HttpClient client = new HttpClient();
        public async Task<string> getAddress()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                string json = null;
                if (location != null)
                {
                    //Regional settings returned deacimals with , where api needs .
                    string sLong = location.Longitude.ToString().Replace(',', '.');
                    string sLat = location.Latitude.ToString().Replace(',', '.');
                    string rstring = String.Format("https://api.bigdatacloud.net/data/reverse-geocode-client?latitude={0}&longitude={1}&localityLanguage=en", sLat, sLong);
                    HttpResponseMessage response = await client.GetAsync(rstring);
                    if (response.IsSuccessStatusCode)
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }
                }
                return json;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public  Root DeserializeAdressObject(string json)
        {

            Root address = new Root();
            if(json != null)
            {
                address = JsonSerializer.Deserialize<Root>(json);
            }
            return address;
        }
    }
  
}
