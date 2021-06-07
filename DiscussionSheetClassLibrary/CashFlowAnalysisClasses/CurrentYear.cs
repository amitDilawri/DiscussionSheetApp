using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.CashFlowAnalysisClasses
{
    public class CurrentYear
    {
        private int currentYear;

        public int CurrentFiscalYear()
        {
            this.currentYear = DateTime.Now.Year;
            return currentYear;
        }
    }
}
