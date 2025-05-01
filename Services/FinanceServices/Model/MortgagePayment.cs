namespace InvestmentCalc.Services.FinanceServices.Model
{
    public class MortgagePayment
    {
        public int PaymentId { get; set; }
        public int MortgageId { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Principal { get; set; }  
        public decimal Interest { get; set; }     
        public bool IsCompleted { get; set; }

        public required Mortgage Mortgage { get; set; }
    }
}
