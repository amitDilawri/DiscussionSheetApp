using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime;
using System.ComponentModel.DataAnnotations;
using DiscussionSheetClassLibrary.ToolBoxClasses;
using System.Data;


namespace DiscussionSheetApp.Areas.Toolbox.Data
{
    public class LoanPaymentInputs 
    {

        [Display(Name = "Loan Amount: ")]
        [Required(ErrorMessage = "Amount is required.")]
        [Range(1000, 1000000000, ErrorMessage = "Loan amount value must be between 1,000 and 1,000,000,000")]
        public double LoanAmount { get; set; }

        [Display(Name = "Amortization (in months): ")]
        [Required(ErrorMessage = "Amortization in months is required.")]
        [Range(12, 360, ErrorMessage = "Amortization value must be between 12 and 360")]
        public int Amortization { get; set; }

        [Display(Name = "Interest Rate: ")]
        [Required(ErrorMessage = "Rate is required. ")]
        [Range(1, 10, ErrorMessage = "Interest rate must be between 1.00 and 10.00")]
        public double InterestRate { get; set; }

        [Display(Name = "Principal and Interest Amortization Table")]
        public string PrincipalAndInterestLabel { get; set; }


        [Display(Name = "Principal plus Interest Amortization Table")]
        public string PrincipalPlusInterestLabel { get; set; }

    }
}