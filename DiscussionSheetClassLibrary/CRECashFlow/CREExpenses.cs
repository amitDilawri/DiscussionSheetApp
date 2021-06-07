using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.CRECashFlow
{
    public class CREExpenses : AbstractClasses.IncomeStatement
    {
        public CREExpenses()
        {
             //
        }

        public CREExpenses(string advertising, string repairsAndMaintenance, string commissions, string insurance, 
            string legalAndProfessionalFees, string managementFees, string taxes, 
            string utilities, string salaries, string replacementReserves, string otherOperatingExpenses)
        {
            double _advertising, _repairsAndMaintenance, _commissions, _insurance, _legalAndProfessionalFees, 
                _managementFees, _taxes, _utilities, _salaries, _replacementReserves, _otherOperatingExpenses;

            _advertising = String.IsNullOrEmpty(advertising) ? 0 : double.Parse(advertising.Replace("$ ", string.Empty));
            _repairsAndMaintenance = String.IsNullOrEmpty(repairsAndMaintenance) ? 0 : double.Parse(repairsAndMaintenance.Replace("$ ", string.Empty));
            _commissions = String.IsNullOrEmpty(commissions) ? 0 : double.Parse(commissions.Replace("$ ", string.Empty));
            _insurance = String.IsNullOrEmpty(insurance) ? 0 : double.Parse(insurance.Replace("$ ", string.Empty));
            _legalAndProfessionalFees = String.IsNullOrEmpty(legalAndProfessionalFees) ? 0 : double.Parse(legalAndProfessionalFees.Replace("$ ", string.Empty));
            _managementFees = String.IsNullOrEmpty(managementFees) ? 0 : double.Parse(managementFees.Replace("$ ", string.Empty));
            _taxes = String.IsNullOrEmpty(taxes) ? 0 : double.Parse(taxes.Replace("$ ", string.Empty));
            _utilities = String.IsNullOrEmpty(utilities) ? 0 : double.Parse(utilities.Replace("$ ", string.Empty));
            _salaries = String.IsNullOrEmpty(salaries) ? 0 : double.Parse(salaries.Replace("$ ", string.Empty));
            _replacementReserves = String.IsNullOrEmpty(replacementReserves) ? 0 : double.Parse(replacementReserves.Replace("$ ", string.Empty));
            _otherOperatingExpenses = String.IsNullOrEmpty(otherOperatingExpenses) ? 0 : double.Parse(otherOperatingExpenses.Replace("$ ", string.Empty));

            this.Advertising = _advertising;
            this.RepairsAndMaintenance = _repairsAndMaintenance;
            this.Commissions = _commissions;
            this.Insurance = _insurance;
            this.LegalAndProfessionalFees = _legalAndProfessionalFees;
            this.ManagementFees = _managementFees;
            this.Taxes = _taxes;
            this.Utilities = _utilities;
            this.SalariesAndWages = _salaries;
            this.ReplacementReserves = _replacementReserves;
            this.OtherOperatingExpenses = _otherOperatingExpenses;
            this.ListOfOperatingExpenses = new double[11] { this.Advertising, this.RepairsAndMaintenance, 
                this.Commissions, this.Insurance, this.LegalAndProfessionalFees, 
                this.ManagementFees, this.Taxes, this.Utilities, this.SalariesAndWages, 
                this.ReplacementReserves, this.OtherOperatingExpenses };
        }
    }
}

