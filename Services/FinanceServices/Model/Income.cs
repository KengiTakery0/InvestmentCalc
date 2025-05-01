using InvestmentCalc.Services.PropertyServices.Model;

namespace InvestmentCalc.Services.FinanceServices.Model
{
    public enum IncomeType
    {
        Rent,          
        Sale,           
        GovernmentGrant, 
        Other           
    }
    public class Income
    {
        public int IncomeId { get; set; }
        public int PropertyId { get; set; }

        public IncomeType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public bool IsRecurring { get; set; }
        public RecurrencePeriod? Recurrence { get; set; }

        public required Property Property { get; set; }
    }
}
