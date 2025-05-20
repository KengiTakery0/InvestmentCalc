using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace InvestmentCalc.Pages
{
    public class GetSetCalculatorModel : PageModel
    {
        [BindProperty]
        public int Step { get; set; } = 1;

        // Свойства для первой страницы
        [BindProperty]
        public decimal PurchasePrice { get; set; }
        [BindProperty]
        public decimal InitialInvestment { get; set; }
        [BindProperty]
        public decimal InterestRate { get; set; }
        [BindProperty]
        public int TermYears { get; set; }
        [BindProperty]
        public decimal MonthlyPayment { get; set; }

        // Свойства для второй страницы
        [BindProperty]
        public string IncomeType { get; set; }
        public List<SelectListItem> IncomeTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Rental", Text = "Аренда" },
            new SelectListItem { Value = "Sale", Text = "Продажа" }
        };
        [BindProperty]
        public decimal IncomeAmount { get; set; }

        // Свойства для третьей страницы
        [BindProperty]
        public string ExpenseType { get; set; }
        public List<SelectListItem> ExpenseTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Maintenance", Text = "Обслуживание" },
            new SelectListItem { Value = "Taxes", Text = "Налоги" }
        };
        [BindProperty]
        public decimal ExpenseAmount { get; set; }

        public void OnGet()
        {
            if (Step == 0)
                Step = 1;
        }

        public IActionResult OnPostNext()
        {
            if (Step < 3)
            {
                Step++;
            }
            else
            {
                // Логика сохранения данных или обработки результата после последнего шага
                // Например, сохранить результат и показать страницу с подтверждением
            }

            return Page();
        }

        public IActionResult OnPostBack()
        {
            if (Step > 1)
            {
                Step--;
            }
            return Page();
        }
    }
}
