using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InvestmentCalc.Pages
{
    public class GetSetCalculatorModel : PageModel
    {
        [BindProperty]
        public int Step { get; set; } = 1;

        // Основные параметры инвестиции
        [BindProperty]
        public decimal PurchasePrice { get; set; } // Стоимость объекта
        [BindProperty]
        public decimal InitialInvestment { get; set; } // Первоначальный взнос
        [BindProperty]
        public decimal InterestRate { get; set; } // Процентная ставка
        [BindProperty]
        public int TermYears { get; set; } // Срок кредита
        [BindProperty]
        public decimal MonthlyPayment { get; set; } // Ежемесячный платеж

        // Доходы
        [BindProperty]
        public string IncomeType { get; set; }
        [BindProperty]
        public decimal IncomeAmount { get; set; }
        public List<SelectListItem> IncomeTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem() { Value = "RentalIncome", Text = "Арендный доход" },
            new SelectListItem() { Value = "OccupancyRate", Text = "Загрузка (Occupancy rate)" },
            new SelectListItem() { Value = "AdditionalIncome", Text = "Дополнительные доходы" }
        };

        // Расходы
        [BindProperty]
        public string ExpenseType { get; set; }
        [BindProperty]
        public decimal ExpenseAmount { get; set; }
        public List<SelectListItem> ExpenseTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem() { Value = "PropertyTaxes", Text = "Налоги на недвижимость" },
            new SelectListItem() { Value = "Insurance", Text = "Страховка" },
            new SelectListItem() { Value = "ManagementFees", Text = "Управление и обслуживание" }
        };

        public void OnGet()
        {
            Step = 1; // Начинаем с первого шага
        }

        public IActionResult OnPostNext()
        {
            if (Step == 1)
            {
                // Валидация основных параметров
                if (PurchasePrice <= 0 || InitialInvestment < 0 || InterestRate < 0 || TermYears <= 0)
                {
                    ModelState.AddModelError("PurchasePrice", "Пожалуйста, введите корректные значения для основных параметров.");
                    return Page();
                }
                Step = 3; // Переход ко второму шагу
            }
            else if (Step == 2)
            {
                // Валидация доходной части
                if (string.IsNullOrEmpty(IncomeType) || IncomeAmount < 0)
                {
                    ModelState.AddModelError("IncomeType", "Пожалуйста, выберите тип дохода и введите корректную сумму.");
                    return Page();
                }
                Step = 3; // Переход к третьему шагу
            }
            else if (Step == 3)
            {
                // Валидация расходов
                if (string.IsNullOrEmpty(ExpenseType) || ExpenseAmount < 0)
                {
                    ModelState.AddModelError("ExpenseType", "Пожалуйста, выберите тип расхода и введите корректную сумму.");
                    return Page();
                }
                // Здесь можно сохранить данные или выполнить другие действия
                return RedirectToPage("Success"); // Перенаправление на страницу успеха
            }

            return Page(); // Показать страницу с текущим шагом
        }

        public IActionResult OnPostBack()
        {
            if (Step > 1)
            {
                Step--; // Переход на предыдущий шаг
            }
            return Page();
        }
    }
}