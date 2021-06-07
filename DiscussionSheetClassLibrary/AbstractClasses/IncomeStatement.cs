using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.AbstractClasses
{
    public abstract class IncomeStatement
    {
        // Declare variables for sales
        public double Revenue, Reimbursement, RentalIncome, OtherRevenue1, OtherRevenue2, OtherRevenue3, ReturnsAndAllowances, VacancyMinimum, NetEffectiveIncome; //Vacancy min. decrease reduce the real estate revenues

        public double[] ListOfRevenues = new double[20];

        //Declare variables for operating expenses
        public double Taxes, Interest, Depreciation,
            Amortization, Advertising, Utilities,
            RepairsAndMaintenance, Commissions, Insurance,
            RentsAndOperatingLeases, ManagementFees, LegalAndProfessionalFees,
            Travel, BadDebt, PensionPlans,
            SellingAndGeneralAdministrative, SalariesAndWages, ReplacementReserves, OtherOperatingExpenses;

        public double[] ListOfOperatingExpenses = new double[20];

        //Declare variables for other income and expenses
        public double? InterestIncome, GainOrLossOnSaleOfAssets, OtherIncome, OtherExpenses;

        public double[] ListOfOtherIncome = new double[20];

        //Declare net profit variable
        public double? NetIncome;

        

        public virtual double TotalRevenues()
        {
            double sum = 0;
            for(int i = 0; i < this.ListOfRevenues.Length; i++)
            {
                sum += this.ListOfRevenues[i];
            }
            return sum;
        }


        public virtual double TotalOperatingExpenses()
        {
            double sum = 0;
            for (int i = 0; i < this.ListOfOperatingExpenses.Length; i++)
            {
                sum += this.ListOfOperatingExpenses[i];
            }
            return sum;
        }
        
        public virtual double TotalOtherIncome()
        {
            double sum = 0;
            for(int i = 0; i < this.ListOfOtherIncome.Length; i++)
            {
                sum += this.ListOfOtherIncome[i];
            }
            return sum;
        }
    }
}
