using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LoanPurposeType : ObservableObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChnaged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChnaged(); }
        }
    }
}
