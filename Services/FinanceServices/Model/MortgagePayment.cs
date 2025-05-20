namespace InvestmentCalc.Services.FinanceServices.Model
{
    public class MortgagePayment
    {
        public int MortgagePaymentId { get; set; }
        public int MortgageId { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Principal { get; set; }   // Основной долг
        public decimal Interest { get; set; }     // Проценты
        public bool IsCompleted { get; set; } // Завершон

        public required Mortgage Mortgage { get; set; }
    }
}
