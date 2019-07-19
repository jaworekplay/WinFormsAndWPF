using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User : ObservableObject
    {
        private string _firstName;
        private string _surname;
        private int _iD;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChnaged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChnaged();
            }
        }

        public int ID
        {
            get { return _iD; }
            set
            {
                _iD = value;
                OnPropertyChnaged();
            }
        }
    }
}
