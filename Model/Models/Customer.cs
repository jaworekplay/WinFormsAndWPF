using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Customer : ObservableObject
    {
        private int _iD;

        public int ID
        {
            get => _iD;
            set
            {
                _iD = value;
                OnPropertyChnaged();
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChnaged(); }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChnaged(); }
        }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
