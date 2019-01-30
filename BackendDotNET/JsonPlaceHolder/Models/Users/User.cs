using System;
using System.Collections.Generic;
using System.Text;

namespace JsonPlaceHolder.Models.Users
{
    public class User
    {

        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }

    }
}
