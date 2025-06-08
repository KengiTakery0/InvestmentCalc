using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InvestmentCalc.Pages
{
    public class GetSetCalculatorModel : PageModel
    {
        // ������� ��� (1-3)
        [BindProperty]
        public int CurrentStep { get; set; } = 1;

        // ��� 1: �������� ��������� ����������
        [BindProperty]
        [Required(ErrorMessage = "������������ ����")]
        [Range(1000, 10000000, ErrorMessage = "����� ������ ���� �� 1,000 �� 10,000,000")]
        public decimal PurchasePrice { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������������ ����")]
        [Range(100, 10000000, ErrorMessage = "����� ������ ���� �� 100 �� 10,000,000")]
        public decimal InitialInvestment { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������������ ����")]
        [Range(0.1, 50, ErrorMessage = "������ ������ ���� �� 0.1% �� 50%")]
        public decimal InterestRate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������������ ����")]
        [Range(1, 30, ErrorMessage = "���� ������ ���� �� 1 �� 30 ���")]
        public int TermYears { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������������ ����")]
        [Range(0, 100000, ErrorMessage = "������ ������ ���� �� 0 �� 100,000")]
        public decimal MonthlyPayment { get; set; }

        // ��� 2: ������
        [BindProperty]
        [Required(ErrorMessage = "�������� ��� ������")]
        public string IncomeType { get; set; }

        public List<SelectListItem> IncomeTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem("������", "Rental"),
            new SelectListItem("�������", "Sale"),
            new SelectListItem("���������", "Dividends")
        };

        [BindProperty]
        [Required(ErrorMessage = "������� ����� ������")]
        [Range(1, 1000000, ErrorMessage = "����� ������ ���� �� 1 �� 1,000,000")]
        public decimal IncomeAmount { get; set; }

        // ��� 3: �������
        [BindProperty]
        [Required(ErrorMessage = "�������� ��� �������")]
        public string ExpenseType { get; set; }

        public List<SelectListItem> ExpenseTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem("������������", "Maintenance"),
            new SelectListItem("������", "Taxes"),
            new SelectListItem("���������", "Insurance")
        };

        [BindProperty]
        [Required(ErrorMessage = "������� ����� �������")]
        [Range(1, 1000000, ErrorMessage = "����� ������ ���� �� 1 �� 1,000,000")]
        public decimal ExpenseAmount { get; set; }

        public void OnGet()
        {
            // ������������� ��� �������������
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
            // ������� ������ ������ ��� �������� ����
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

            // ��������� ������ �������� ����
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