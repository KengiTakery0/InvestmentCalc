using InvestmentCalc.Services.PropertyServices.Model;

namespace InvestmentCalc.Services.FinanceServices.Model
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public int PropertyId { get; set; }

        public decimal InitialAmount { get; set; }    // Начальная сумма ипотеки
        public decimal CurrentBalance { get; set; }  // Текущий остаток
        public decimal InterestRate { get; set; }     // Процентная ставка
        public int TermYears { get; set; }           // Срок в годах
        public DateTime StartDate { get; set; }      // Дата начала
        public required string  BankName { get; set; }         // Название банка 

        public required Property Property { get; set; }
        public ICollection<MortgagePayment> Payments { get; set; } = new List<MortgagePayment>();
    }
}
