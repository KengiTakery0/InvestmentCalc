using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InvestmentCalc.Pages
{
    public class GetSetCalculatorModel : PageModel
    {
        // Текущий шаг (1-3)
        [BindProperty]
        public int CurrentStep { get; set; } = 1;

        // Шаг 1: Основные параметры инвестиции
        [BindProperty]
        [Required(ErrorMessage = "Обязательное поле")]
        [Range(1000, 10000000, ErrorMessage = "Сумма должна быть от 1,000 до 10,000,000")]
        public decimal PurchasePrice { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Обязательное поле")]
        [Range(100, 10000000, ErrorMessage = "Сумма должна быть от 100 до 10,000,000")]
        public decimal InitialInvestment { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0.1, 50, ErrorMessage = "Ставка должна быть от 0.1% до 50%")]
        public decimal InterestRate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Обязательное поле")]
        [Range(1, 30, ErrorMessage = "Срок должен быть от 1 до 30 лет")]
        public int TermYears { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0, 100000, ErrorMessage = "Платеж должен быть от 0 до 100,000")]
        public decimal MonthlyPayment { get; set; }

        // Шаг 2: Доходы
        [BindProperty]
        [Required(ErrorMessage = "Выберите тип дохода")]
        public string IncomeType { get; set; }

        public List<SelectListItem> IncomeTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem("Аренда", "Rental"),
            new SelectListItem("Продажа", "Sale"),
            new SelectListItem("Дивиденды", "Dividends")
        };

        [BindProperty]
        [Required(ErrorMessage = "Введите сумму дохода")]
        [Range(1, 1000000, ErrorMessage = "Сумма должна быть от 1 до 1,000,000")]
        public decimal IncomeAmount { get; set; }

        // Шаг 3: Расходы
        [BindProperty]
        [Required(ErrorMessage = "Выберите тип расхода")]
        public string ExpenseType { get; set; }

        public List<SelectListItem> ExpenseTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem("Обслуживание", "Maintenance"),
            new SelectListItem("Налоги", "Taxes"),
            new SelectListItem("Страховка", "Insurance")
        };

        [BindProperty]
        [Required(ErrorMessage = "Введите сумму расхода")]
        [Range(1, 1000000, ErrorMessage = "Сумма должна быть от 1 до 1,000,000")]
        public decimal ExpenseAmount { get; set; }

        public void OnGet()
        {
            // Инициализация при необходимости
        }

        public IActionResult OnPostNext()
        {
            if (!ValidateCurrentStep())
            {
                return Page();
            }

            if (CurrentStep < 3)
            {
                CurrentStep++;
            }

            return Page();
        }

        public IActionResult OnPostBack()
        {
            if (CurrentStep > 1)
            {
                CurrentStep--;
            }
            return Page();
        }

        private bool ValidateCurrentStep()
        {
            // Очищаем только ошибки для текущего шага
            var keysToRemove = ModelState.Keys
                .Where(k => CurrentStep == 1 ? !k.StartsWith("PurchasePrice") &&
                                            !k.StartsWith("InitialInvestment") &&
                                            !k.StartsWith("InterestRate") &&
                                            !k.StartsWith("TermYears") &&
                                            !k.StartsWith("MonthlyPayment")
                       : CurrentStep == 2 ? !k.StartsWith("IncomeType") &&
                                            !k.StartsWith("IncomeAmount")
                                          : !k.StartsWith("ExpenseType") &&
                                            !k.StartsWith("ExpenseAmount"))
                .ToList();

            foreach (var key in keysToRemove)
            {
                ModelState.Remove(key);
            }

            // Валидация только текущего шага
            switch (CurrentStep)
            {
                case 1:
                    TryValidateModel(this, nameof(PurchasePrice));
                    TryValidateModel(this, nameof(InitialInvestment));
                    TryValidateModel(this, nameof(InterestRate));
                    TryValidateModel(this, nameof(TermYears));
                    TryValidateModel(this, nameof(MonthlyPayment));
                    break;
                case 2:
                    TryValidateModel(this, nameof(IncomeType));
                    TryValidateModel(this, nameof(IncomeAmount));
                    break;
                case 3:
                    TryValidateModel(this, nameof(ExpenseType));
                    TryValidateModel(this, nameof(ExpenseAmount));
                    break;
            }

            return ModelState.IsValid;
        }

        public IActionResult OnPostCalculate()
        {
            if (!ValidateCurrentStep())
            {
                return Page();
            }

            var result = CalculateResults();
            return RedirectToPage("Result", new
            {
                TotalProfit = result.TotalProfit,
                ROI = result.ROI,
                PaybackPeriod = result.PaybackPeriod
            });
        }

        private (decimal TotalProfit, decimal ROI, decimal PaybackPeriod) CalculateResults()
        {
            decimal totalInvestment = InitialInvestment + (MonthlyPayment * 12 * TermYears);
            decimal totalIncome = IncomeAmount * TermYears;
            decimal totalExpenses = ExpenseAmount * TermYears;

            decimal totalProfit = totalIncome - totalExpenses - totalInvestment;
            decimal roi = (totalProfit / totalInvestment) * 100;
            decimal paybackPeriod = totalInvestment / (IncomeAmount - ExpenseAmount);

            return (totalProfit, roi, paybackPeriod);
        }
    }
}