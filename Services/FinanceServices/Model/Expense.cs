using InvestmentCalc.Services.PropertyServices.Model;

namespace InvestmentCalc.Services.FinanceServices.Model
{
    public enum ExpenseType
    {
        Utilities,     
        Maintenance,    
        Repair,       
        Insurance,      
        Tax,            
        Management,  
        Other           
    }

    public enum RecurrencePeriod
    {
        Monthly,
        Quarterly,
        Yearly
    }
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int PropertyId { get; set; }

        public ExpenseType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public bool IsRecurring { get; set; }   
        public RecurrencePeriod? Recurrence { get; set; } 

        public required Property Property { get; set; }
    }
}
