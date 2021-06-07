using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.CashFlowAnalysisClasses
{
    public static class FiscalYearEnds 
    {
        
        

        public static DateTime FirstFiscalYearEndDate()
        {
            int currentYear = DateTime.Now.Year;

            //Returns First Fiscal Year End 
            DateTime firstFYE = new DateTime(currentYear - 2, 12, 31);
            return firstFYE;
        }

        public static DateTime SecondFiscalYearEndDate()
        {
            int currentYear = DateTime.Now.Year;

            //Returns Second Fiscal Year End
            DateTime secondFYE = new DateTime(currentYear - 1, 12, 31);
            return secondFYE;
        }
    }
}
