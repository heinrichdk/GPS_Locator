using System;
using System.Collections.Generic;
using System.Text;

namespace GPS_Locator
{
    public class AddressDataModel
    {
        public string continent { get => continent; set => continent = value; }
        public string countryName { get => countryName; set => countryName = value; }
        public string city { get => city; set => city = value; }
        public string locality { get => locality; set => locality = value; }
        public string postcode { get => postcode; set => postcode = value; }
    }
}
