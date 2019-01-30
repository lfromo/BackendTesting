namespace JsonPlaceHolder.Models.Users
{
    public class Address
    {

        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geolocation geo { get; set; }

    }

    public class Geolocation
    {

        public string lat { get; set; }
        public string lng { get; set; }

    }
}