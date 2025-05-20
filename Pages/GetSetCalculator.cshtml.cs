using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace InvestmentCalc.Pages
{
    public class GetSetCalculatorModel : PageModel
    {
        [BindProperty]
        public int Step { get; set; } = 1;

        // �������� ��� ������ ��������
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

        // �������� ��� ������ ��������
        [BindProperty]
        public string IncomeType { get; set; }
        public List<SelectListItem> IncomeTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Rental", Text = "������" },
            new SelectListItem { Value = "Sale", Text = "�������" }
        };
        [BindProperty]
        public decimal IncomeAmount { get; set; }

        // �������� ��� ������� ��������
        [BindProperty]
        public string ExpenseType { get; set; }
        public List<SelectListItem> ExpenseTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Maintenance", Text = "������������" },
            new SelectListItem { Value = "Taxes", Text = "������" }
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
                // ������ ���������� ������ ��� ��������� ���������� ����� ���������� ����
                // ��������, ��������� ��������� � �������� �������� � ��������������
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
