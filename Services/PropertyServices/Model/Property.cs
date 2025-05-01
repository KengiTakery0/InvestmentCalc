using InvestmentCalc.Services.FinanceServices.Model;
using InvestmentCalc.Services.UserServices.Model;

namespace InvestmentCalc.Services.PropertyServices.Model
{
    public enum PropertyType
    {
        Comerce,
        Residential,    
        Industrial,
        Land
    }
    public class Property
    {
        public  int PropertyId {  get; set; }
        public  int UserId {  get; set; }

        // Основная информация
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public string? PostalCode { get; set; }
        public PropertyType Type { get; set; } 
        public double TotalArea { get; set; } 
        public int RoomsCount { get; set; }  
        public int Floors { get; set; }      
        public int BuildYear { get; set; } 

        // Финансовая информация
        public decimal PurchasePrice { get; set; }  
        public DateTime PurchaseDate { get; set; }   
        public decimal CurrentValue { get; set; }   

        
        public required User User { get; set; }
        public Mortgage? Mortgage { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();

    }
}
