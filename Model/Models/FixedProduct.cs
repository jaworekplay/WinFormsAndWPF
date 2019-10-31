using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FixedProduct
    {
        public int ID { get; set; }
        public string LenderName { get; set; }
        public string PlanName { get; set; }
        public double FixedPayment { get; set; }
        public double FixedRate { get; set; }
        public int FixedTerm { get; set; }
        public double APR { get; set; }
        public double VariablePayment { get; set; }
        public decimal BrokerFee { get; set; }
        public decimal Commission { get; set; }
    }
}
