using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public decimal ________ { get; set; } // Первоначальный взнос
        [BindProperty]
        public decimal InterestRate { get; set; } // Процентная ставка
        [BindProperty]
        public int TermYears { get; set; } // Срок кредита
        [BindProperty]
        public decimal MonthlyPayment { get; set; } // Ежемесячный платеж

        //// Доходная часть
        //[BindProperty]
        //public decimal RentalIncome { get; set; } // Арендный доход
        //[BindProperty]
        //public decimal OccupancyRate { get; set; } // Загрузка
        //[BindProperty]
        //public decimal AdditionalIncome { get; set; } // Дополнительные доходы

        //// Расходы
        //[BindProperty]
        //public decimal PropertyTaxes { get; set; } // Налоги на недвижимость
        //[BindProperty]
        //public decimal Insurance { get; set; } // Страховка
        //[BindProperty]
        //public decimal ManagementFees { get; set; } // Управление и обслуживание

        public void OnGet()
        {
            Step = 1; // Начинаем с первого шага
        }

        public IActionResult OnPostNext()
        {
            if (Step == 1)
            {
                // Валидация основных параметров
                if (PurchasePrice <= 0 || ________ < 0 || InterestRate < 0 || TermYears <= 0)
                {
                    ModelState.AddModelError("PurchasePrice", "Пожалуйста, введите корректные значения для основных параметров.");
                    return Page();
                }
                Step = 2; // Переход ко второму шагу
            }
            //else if (Step == 2)
            //{
            //    // Валидация доходной части
            //    if (RentalIncome < 0 || OccupancyRate < 0 || AdditionalIncome < 0)
            //    {
            //        ModelState.AddModelError("RentalIncome", "Пожалуйста, введите корректные значения для доходной части.");
            //        return Page();
            //    }
            //    Step = 3; // Переход к третьему шагу
            //}
            //else if (Step == 3)
            //{
            //    // Валидация расходов
            //    if (PropertyTaxes < 0 || Insurance < 0 || ManagementFees < 0)
            //    {
            //        ModelState.AddModelError("PropertyTaxes", "Пожалуйста, введите корректные значения для расходов.");
            //        return Page();
            //    }
            //    // Здесь можно сохранить данные или выполнить другие действия
            //    return RedirectToPage("Success"); // Перенаправление на страницу успеха
            //}

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
