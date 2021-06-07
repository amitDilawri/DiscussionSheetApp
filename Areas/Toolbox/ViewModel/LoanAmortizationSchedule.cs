using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiscussionSheetClassLibrary.ToolBoxClasses;

namespace DiscussionSheetApp.Areas.Toolbox.ViewModel
{
    public class LoanAmortizationSchedule : Data.LoanPaymentInputs
    {
        public double TotalInterest {get;set;}
        public Dictionary<int, AmortizationTable> amortTable { get; set; }
        public List<AmortizationTable> amortSummary { get; set; }
    }
}