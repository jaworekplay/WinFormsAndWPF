using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Address : ObservableObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChnaged(); }
        }


        private string postCode;

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; OnPropertyChnaged(); }
        }


        private string line1;

        public string Line1
        {
            get { return line1; }
            set { line1 = value; OnPropertyChnaged(); }
        }


        private string townCity;

        public string TownCity
        {
            get { return townCity; }
            set { townCity = value; OnPropertyChnaged(); }
        }


        private string county;

        public string County
        {
            get { return county; }
            set { county = value; OnPropertyChnaged(); }
        }


        private string streetName;

        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; OnPropertyChnaged(); }
        }

        public virtual Customer Customer { get; set; }
    }
}
