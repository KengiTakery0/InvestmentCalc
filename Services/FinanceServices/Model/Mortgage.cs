using InvestmentCalc.Services.PropertyServices.Model;

namespace InvestmentCalc.Services.FinanceServices.Model
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public int PropertyId { get; set; }

        public decimal InitialAmount { get; set; }   
        public decimal CurrentBalance { get; set; }  
        public decimal InterestRate { get; set; }    
        public int TermYears { get; set; }         
        public DateTime StartDate { get; set; }    
        public required string BankName { get; set; }        

        public required Property Property { get; set; }
        public ICollection<MortgagePayment> Payments { get; set; } = new List<MortgagePayment>();
    }
}
