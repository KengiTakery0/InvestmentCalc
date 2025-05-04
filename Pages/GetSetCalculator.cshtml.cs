using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public decimal ________ { get; set; } // �������������� �����
        [BindProperty]
        public decimal InterestRate { get; set; } // ���������� ������
        [BindProperty]
        public int TermYears { get; set; } // ���� �������
        [BindProperty]
        public decimal MonthlyPayment { get; set; } // ����������� ������

        //// �������� �����
        //[BindProperty]
        //public decimal RentalIncome { get; set; } // �������� �����
        //[BindProperty]
        //public decimal OccupancyRate { get; set; } // ��������
        //[BindProperty]
        //public decimal AdditionalIncome { get; set; } // �������������� ������

        //// �������
        //[BindProperty]
        //public decimal PropertyTaxes { get; set; } // ������ �� ������������
        //[BindProperty]
        //public decimal Insurance { get; set; } // ���������
        //[BindProperty]
        //public decimal ManagementFees { get; set; } // ���������� � ������������

        public void OnGet()
        {
            Step = 1; // �������� � ������� ����
        }

        public IActionResult OnPostNext()
        {
            if (Step == 1)
            {
                // ��������� �������� ����������
                if (PurchasePrice <= 0 || ________ < 0 || InterestRate < 0 || TermYears <= 0)
                {
                    ModelState.AddModelError("PurchasePrice", "����������, ������� ���������� �������� ��� �������� ����������.");
                    return Page();
                }
                Step = 2; // ������� �� ������� ����
            }
            //else if (Step == 2)
            //{
            //    // ��������� �������� �����
            //    if (RentalIncome < 0 || OccupancyRate < 0 || AdditionalIncome < 0)
            //    {
            //        ModelState.AddModelError("RentalIncome", "����������, ������� ���������� �������� ��� �������� �����.");
            //        return Page();
            //    }
            //    Step = 3; // ������� � �������� ����
            //}
            //else if (Step == 3)
            //{
            //    // ��������� ��������
            //    if (PropertyTaxes < 0 || Insurance < 0 || ManagementFees < 0)
            //    {
            //        ModelState.AddModelError("PropertyTaxes", "����������, ������� ���������� �������� ��� ��������.");
            //        return Page();
            //    }
            //    // ����� ����� ��������� ������ ��� ��������� ������ ��������
            //    return RedirectToPage("Success"); // ��������������� �� �������� ������
            //}

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
