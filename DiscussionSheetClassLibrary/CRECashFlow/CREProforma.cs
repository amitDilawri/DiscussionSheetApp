using System;
using System.Collections.Generic;
using System.Text;
using DiscussionSheetClassLibrary.AbstractClasses;

namespace DiscussionSheetClassLibrary.CRECashFlow
{
    public class CREProforma : AbstractClasses.IncomeStatement
    {
        private double AnnualDebtObligation { get; set; }
        private double ProposedLoanAmount { get; set; }
        private double ProposedInterestRate { get; set; }
        private int ProposedAmortization { get; set; }
        public CREProforma(CREIncome income, CREExpenses expenses, string historicalDebtObligation)
        {
            double _historicalDebtObligation;
            

            _historicalDebtObligation = String.IsNullOrEmpty(historicalDebtObligation) ? 0 : double.Parse(historicalDebtObligation.Replace("$ ", string.Empty));


            this.RentalIncome = income.RentalIncome;
            this.Reimbursement = income.Reimbursement;
            this.OtherRevenue1 = income.OtherRevenue1;
            this.VacancyMinimum = this.RentalIncome * 0.05;
            this.NetEffectiveIncome = income.TotalRevenues() - this.VacancyMinimum;
            this.Advertising = expenses.Advertising + (expenses.Advertising * 0.03);
            this.RepairsAndMaintenance = this.RentalIncome * 0.05;
            this.Commissions = expenses.Commissions + (expenses.Commissions * 0.03);
            this.Insurance = expenses.Insurance + (expenses.Insurance * 0.03);
            this.LegalAndProfessionalFees = expenses.LegalAndProfessionalFees + (expenses.LegalAndProfessionalFees * 0.03);
            this.ManagementFees = this.RentalIncome * 0.05;
            this.Taxes = expenses.Taxes + (expenses.Taxes * 0.03);
            this.Utilities = expenses.Utilities + (expenses.Utilities * 0.03);
            this.SalariesAndWages = expenses.SalariesAndWages + (expenses.SalariesAndWages * 0.03);
            this.ReplacementReserves = expenses.ReplacementReserves + (expenses.ReplacementReserves * 0.03);
            this.OtherOperatingExpenses = expenses.OtherOperatingExpenses + (expenses.OtherOperatingExpenses * 0.03);
            this.AnnualDebtObligation = _historicalDebtObligation;

            
        }

        

        public double ProformaTotalOperatingExpenses()
        {
            double totalOperatingExpenses = this.Advertising + this.RepairsAndMaintenance + this.Commissions + this.Insurance + this.LegalAndProfessionalFees + this.ManagementFees +
                this.Taxes + this.Utilities + this.SalariesAndWages + this.ReplacementReserves + this.OtherOperatingExpenses;
            return totalOperatingExpenses;
        }

        public double ProformaNetOperatingIncome()
        {
            double netOperatingIncome = this.NetEffectiveIncome - ProformaTotalOperatingExpenses();
            return netOperatingIncome;
        }

        public double ProformaDebtServiceCoverageRatio()
        {
            double dSCR = ProformaNetOperatingIncome() / this.AnnualDebtObligation;
            return Math.Round(dSCR, 2);
        }
        public double ProformaCashFlowAfterDebtService()
        {
            double excessCashFlow = ProformaNetOperatingIncome() - this.AnnualDebtObligation;
            return excessCashFlow;
        }

    }
}
