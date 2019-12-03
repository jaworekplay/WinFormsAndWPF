namespace Models
{
    public class FixedProduct
    {
        public int Index { get; set; }
        public string LenderName { get; set; }
        public string PlanName { get; set; }
        public decimal FixedRepayment { get; set; }
        public double FixedRate { get; set; }
        public double ReversionRate { get; set; }
        public decimal BrokerFee { get; set; }
        public decimal Commission { get; set; }
        public decimal LenderFee { get; set; }
        public double APR { get; set; }
        public int FixedTerm { get; set; }
        public decimal ReversionRepayment { get; set; }

        public bool CheapestFixedRepayment { get; set; }
        public bool CheapestFixedRate { get; set; }
        public bool CheapestReversionRate { get; set; }
        public bool CheapestBrokerFee { get; set; }
        public bool CheapestCommission { get; set; }
        public bool CheapestLenderFee { get; set; }
        public bool CheapestAPR { get; set; }
        public bool ShortestFixedTerm { get; set; }
        public bool CheapestReversionRepayment { get; set; }
    }
}