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
        public PropertyType Type { get; set; } // Жилая/коммерческая
        public double TotalArea { get; set; } // Общая площадь (м²)
        public int RoomsCount { get; set; }   // Количество комнат/офисов
        public int Floors { get; set; }       // Этажность
        public int BuildYear { get; set; }    // Год постройки

        // Финансовая информация
        public decimal PurchasePrice { get; set; }  // Цена покупки
        public DateTime PurchaseDate { get; set; }   // Дата покупки
        public decimal CurrentValue { get; set; }   // Текущая стоимость


        public required User User { get; set; }
        public Mortgage? Mortgage { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();

    }
}
