using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Application : ObservableObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChnaged(); }
        }

        private decimal advance;

        public decimal Advance
        {
            get { return advance; }
            set { advance = value; OnPropertyChnaged(); }
        }
        
        public virtual ICollection<LoanPurpose> Breakdown { get; set; }

    }
}
