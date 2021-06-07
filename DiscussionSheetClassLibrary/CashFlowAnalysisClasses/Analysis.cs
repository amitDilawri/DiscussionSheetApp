using System;
using System.Collections.Generic;
using System.Text;
using DiscussionSheetClassLibrary.CRECashFlow;


namespace DiscussionSheetClassLibrary.CashFlowAnalysisClasses
{
    public class Analysis : AbstractClasses.IncomeStatement
    {
        private DateTime FirstFiscalYear { get; set; }
        private DateTime SecondFiscalYear { get; set; }
        
        public Analysis(CREIncome income, CREExpenses expenses, CREProforma cREProforma, CREAbilityToPay abilityToPay)
        {
            this.FirstFiscalYear = FiscalYearEnds.FirstFiscalYearEndDate();
            this.SecondFiscalYear = FiscalYearEnds.SecondFiscalYearEndDate();
            
        }

    }
}
