using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DiscussionSheetApp.Areas.Toolbox.Data
{
    public class DSCRInputs
    {
        [Display(Name = "Net Income (Pre Tax): ")]
        [Required(ErrorMessage = "Amount is required.")]
        public double PreTaxNetIncome { get; set; }
        [Display(Name = "Interest Expense: ")]
        public double InterestExpense { get; set; }
        [Display(Name = "Depreciation: ")]
        public double DepreciationExpense { get; set; }
        [Display(Name = "Amortization: ")]
        public double AmortizationExpense { get; set; }
        [Display(Name = "Principal Payment: ")]
        public double AnnualPrincipalPayment { get; set; }   
        //public double? EBITDA { get; set; }
        
        //public List<DSCRInputs> mylist { get; set; }

    }
}