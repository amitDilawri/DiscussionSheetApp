using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.ToolBoxClasses
{
    public class RealEstateOperatingExpenses : AbstractClasses.IncomeStatement
    {
        
        public RealEstateOperatingExpenses()
        {
            this.Advertising = 0;
            this.Utilities = 0;
            this.RepairsAndMaintenance = 0;
            this.Commissions = 0;
            this.Insurance = 0;
            this.LegalAndProfessionalFees = 0;
            this.ManagementFees = 0;
            this.Taxes = 0;
            this.SalariesAndWages = 0;
            this.ReplacementReserves = 0;
            this.OtherOperatingExpenses = 0;
            this.ListOfOperatingExpenses = new double[11] { (double)this.Advertising, (double)this.Utilities, (double)this.RepairsAndMaintenance, (double)this.Commissions, (double)this.Insurance, (double)this.LegalAndProfessionalFees, (double)this.ManagementFees, (double)this.Taxes, (double)this.SalariesAndWages, (double)this.ReplacementReserves, (double)this.OtherOperatingExpenses };

        }

        public RealEstateOperatingExpenses(double advertising, 
            double utilities, 
            double repairsAndMaintenance, 
            double commissions, 
            double insurance, 
            double legalAndProfessionalFee, 
            double managementFee, 
            double taxes,
            double salariesAndWages,
            double replacementReserves,
            double otherOperatingExpenses)
        {
            this.Advertising = advertising;
            this.Utilities = utilities;
            this.RepairsAndMaintenance = repairsAndMaintenance;
            this.Commissions = commissions;
            this.Insurance = insurance;
            this.LegalAndProfessionalFees = legalAndProfessionalFee;
            this.ManagementFees = managementFee;
            this.Taxes = taxes;
            this.SalariesAndWages = salariesAndWages;
            this.ReplacementReserves = replacementReserves;
            this.OtherOperatingExpenses = otherOperatingExpenses;
            this.ListOfOperatingExpenses = new double[11] { (double)this.Advertising, (double)this.Utilities, (double)this.RepairsAndMaintenance, (double)this.Commissions, (double)this.Insurance, (double)this.LegalAndProfessionalFees, (double)this.ManagementFees, (double)this.Taxes, (double)this.SalariesAndWages, (double)this.ReplacementReserves, (double)this.OtherOperatingExpenses };
        }

        public override double TotalOperatingExpenses()
        {
            double sum = 0;
            for(int i = 0; i < this.ListOfOperatingExpenses.Length; i++)
            {
                sum += this.ListOfOperatingExpenses[i];
            }
            return sum;
        }

        
    }
}
