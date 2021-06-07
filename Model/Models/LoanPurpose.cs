using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LoanPurpose : ObservableObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChnaged(); }
        }

        private string notes;

        public string Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChnaged(); }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChnaged(); }
        }
        
        public virtual Application Application { get; set; }
        public virtual LoanPurposeType LoanPurposeType { get; set; }
    }
}
