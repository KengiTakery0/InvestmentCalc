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

        // �������� ��������� ����������
        [BindProperty]
        public decimal PurchasePrice { get; set; } // ��������� �������
        [BindProperty]
        public decimal InitialInvestment { get; set; } // �������������� �����
        [BindProperty]
        public decimal InterestRate { get; set; } // ���������� ������
        [BindProperty]
        public int TermYears { get; set; } // ���� �������
        [BindProperty]
        public decimal MonthlyPayment { get; set; } // ����������� ������

        // ������
        [BindProperty]
        public string IncomeType { get; set; }
        [BindProperty]
        public decimal IncomeAmount { get; set; }
        public List<SelectListItem> IncomeTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem() { Value = "RentalIncome", Text = "�������� �����" },
            new SelectListItem() { Value = "OccupancyRate", Text = "�������� (Occupancy rate)" },
            new SelectListItem() { Value = "AdditionalIncome", Text = "�������������� ������" }
        };

        // �������
        [BindProperty]
        public string ExpenseType { get; set; }
        [BindProperty]
        public decimal ExpenseAmount { get; set; }
        public List<SelectListItem> ExpenseTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem() { Value = "PropertyTaxes", Text = "������ �� ������������" },
            new SelectListItem() { Value = "Insurance", Text = "���������" },
            new SelectListItem() { Value = "ManagementFees", Text = "���������� � ������������" }
        };

        public void OnGet()
        {
            Step = 1; // �������� � ������� ����
        }

        public IActionResult OnPostNext()
        {
            if (Step == 1)
            {
                // ��������� �������� ����������
                if (PurchasePrice <= 0 || InitialInvestment < 0 || InterestRate < 0 || TermYears <= 0)
                {
                    ModelState.AddModelError("PurchasePrice", "����������, ������� ���������� �������� ��� �������� ����������.");
                    return Page();
                }
                Step = 3; // ������� �� ������� ����
            }
            else if (Step == 2)
            {
                // ��������� �������� �����
                if (string.IsNullOrEmpty(IncomeType) || IncomeAmount < 0)
                {
                    ModelState.AddModelError("IncomeType", "����������, �������� ��� ������ � ������� ���������� �����.");
                    return Page();
                }
                Step = 3; // ������� � �������� ����
            }
            else if (Step == 3)
            {
                // ��������� ��������
                if (string.IsNullOrEmpty(ExpenseType) || ExpenseAmount < 0)
                {
                    ModelState.AddModelError("ExpenseType", "����������, �������� ��� ������� � ������� ���������� �����.");
                    return Page();
                }
                // ����� ����� ��������� ������ ��� ��������� ������ ��������
                return RedirectToPage("Success"); // ��������������� �� �������� ������
            }

            return Page(); // �������� �������� � ������� �����
        }

        public IActionResult OnPostBack()
        {
            if (Step > 1)
            {
                Step--; // ������� �� ���������� ���
            }
            return Page();
        }
    }
}