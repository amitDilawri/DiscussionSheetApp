using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.ToolBoxClasses
{
    public class DebtServiceCoverageRatio 
    {
        private double NetIncome { get; set; }
        private double Interest { get; set; }
        private double Depreciation { get; set; }
        private double AmortizationExpense { get; set; }
        private double AnnualPrincipalPayment { get; set; }

        public DebtServiceCoverageRatio()
        {
            //
        }

        public DebtServiceCoverageRatio(double netIncome, double interest, double depreciation, double amortization, double principalPayment)
        {
            this.NetIncome = netIncome;
            this.Interest = interest;
            this.Depreciation = depreciation;
            this.AmortizationExpense = amortization;
            this.AnnualPrincipalPayment = principalPayment;
        }

        public double EBITDA()
        {
            double eBITDA = this.NetIncome + this.Interest + this.Depreciation + this.AmortizationExpense;
            return eBITDA;
        }

        public double AnnualDebtObligation()
        {
            double debtObligation = this.Interest + this.AnnualPrincipalPayment;
            return debtObligation;
        }

        public double DSCR()
        {
            double debtServiceRatio = EBITDA() / AnnualDebtObligation();
            return debtServiceRatio;
        }
        public double ExcessCashFlow()
        {
            double excess = EBITDA() - AnnualDebtObligation();
            return excess;
        }
    }
}
