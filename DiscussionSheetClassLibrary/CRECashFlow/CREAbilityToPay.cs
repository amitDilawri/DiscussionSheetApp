using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.CRECashFlow
{
    public class CREAbilityToPay : AbstractClasses.LoanAmortization
    {
        private double RentalIncome;
        private double PropertyExpenses;
        public CREAbilityToPay(double revenues, double operatingExpenses, string historicalDebtObligation)
        {
            double _historicalDebtObligation;

            _historicalDebtObligation = String.IsNullOrEmpty(historicalDebtObligation) ? 0 : double.Parse(historicalDebtObligation.Replace("$ ", string.Empty));
                       
            this.RentalIncome = revenues;
            this.PropertyExpenses = operatingExpenses;
            this.AnnualDebtObligation = _historicalDebtObligation;

        }

        public double NetOperatingIncome()
        {           
            double netOperatingIncome = this.RentalIncome - this.PropertyExpenses;
            return netOperatingIncome;
        }

        public double DebtServiceCoverageRatio()
        {
            double dSCR = NetOperatingIncome() / this.AnnualDebtObligation;            
            return Math.Round(dSCR, 2);
        }
        public double CashFlowAfterDebtService()
        {
            double excessCashFlow = NetOperatingIncome() - this.AnnualDebtObligation;
            return excessCashFlow;
        }
    }
}
