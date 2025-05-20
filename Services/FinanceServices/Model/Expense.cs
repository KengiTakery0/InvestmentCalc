using InvestmentCalc.Services.PropertyServices.Model;

namespace InvestmentCalc.Services.FinanceServices.Model
{
    public enum ExpenseType
    {
        Utilities,      // Коммунальные услуги
        Maintenance,    // Обслуживание
        Repair,         // Ремонт
        Insurance,      // Страховка
        Tax,            // Налоги
        Management,     // Управление
        Other           // Другое
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

        public ExpenseType Type { get; set; } // тип платежа
        public decimal Amount { get; set; } // Цена
        public DateTime Date { get; set; } // Дата
        public string? Description { get; set; } // Описание
        public bool IsRecurring { get; set; }   // Регулярный платеж
        public RecurrencePeriod? Recurrence { get; set; } // Периодичность

        public required Property Property { get; set; }
    }
}
