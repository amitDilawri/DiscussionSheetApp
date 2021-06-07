using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DiscussionSheetApp.Areas.Toolbox.Data
{
    public class CREAbilityToPayInputs
    {
        //Variable naming - If current year end is 12/31/2021 then first year would be 12/31/2019 and the second year end would be 12/31/2020.
        
        [Display(Name = "Rental Income ")]
        public string FirstYearRents { get; set; }
        public string SecondYearRents { get; set; }
        public string ProformaYearRents { get; set; }

        [Display(Name = "Reimbursement ")]
        public string FirstYearReimbursement { get; set; }
        public string SecondYearReimbursement { get; set; }
        public string ProformaYearReimbursement { get; set; }

        [Display(Name = "Other Income ")]
        public string FirstYearOtherIncome { get; set; }
        public string SecondYearOtherIncome { get; set; }
        public string ProformaYearOtherIncome { get; set; }

        [Display(Name = "(Vacancy Min. 5% proforma) ")]
        public string ProformaVacancy { get; set; }

        [Display(Name = "Net Effective Revenue ")]
        public string FirstYearNetEffectiveRevenue { get; set; }
        public string SecondYearNetEffectiveRevenue { get; set; }
        public string ProformaNetEffectiveRevenue { get; set; }

        [Display(Name = "Advertising ")]
        public string FirstYearAdvertising { get; set; }
        public string SecondYearAdvertising { get; set; }
        public string ProformaAdvertising { get; set; }

        [Display(Name = "Repairs and Maintenance (5% proforma) ")]
        public string FirstYearRepairsAndMaintenance { get; set; }
        public string SecondYearRepairsAndMaintenance { get; set; }
        public string ProformaRepairsAndMaintenance { get; set; }

        [Display(Name = "Commission ")]
        public string FirstYearCommission { get; set; }
        public string SecondYearCommission { get; set; }
        public string ProformaCommission { get; set; }

        [Display(Name = "Insurance ")]
        public string FirstYearInsurance { get; set; }
        public string SecondYearInsurance { get; set; }
        public string ProformaInsurance { get; set; }

        [Display(Name = "Legal and Professional Fees ")]
        public string FirstYearLegalAndProfessionalFees { get; set; }
        public string SecondYearLegalAndProfessionalFees { get; set; }
        public string ProformaLegalAndProfessionalFees { get; set; }

        [Display(Name = "Management Fees (5% proforma) ")]
        public string FirstYearManagementFee { get; set; }
        public string SecondYearManagementFee { get; set; }
        public string ProformaManagementFee { get; set; }

        [Display(Name = "Taxes ")]
        public string FirstYearTaxes { get; set; }
        public string SecondYearTaxes { get; set; }
        public string ProformaTaxes { get; set; }

        [Display(Name = "Utilities ")]
        public string FirstYearUtilities { get; set; }
        public string SecondYearUtilities { get; set; }
        public string ProformaUtilities { get; set; }

        [Display(Name = "Salaries and Wages ")]
        public string FirstYearSalariesAndWages { get; set; }
        public string SecondYearSalariesAndWages { get; set; }
        public string ProformaSalariesAndWages { get; set; }

        [Display(Name = "Replacement Reserves ")]
        public string FirstYearReplacementReserves { get; set; }
        public string SecondYearReplacementReserves { get; set; }
        public string ProformaReplacementReserves { get; set; }

        [Display(Name = "Other Operating Expenses ")]
        public string FirstYearOtherOperatingExpenses { get; set; }
        public string SecondYearOtherOperatingExpenses { get; set; }
        public string ProformaOtherOperatingExpenses { get; set; }

        [Display(Name = "Net Operating Income ")]
        public string FirstYearNetOperatingIncome { get; set; }
        public string SecondYearNetOperatingIncome { get; set; }
        public string ProformaNetOperatingIncome { get; set; }

        [Display(Name = "Total Operating Expenses ")]
        public string FirstYearTotalOperatingExpenses { get; set; }
        public string SecondYearTotalOperatingExpenses { get; set; }
        public string ProformaTotalOperatingExpenses { get; set; }

        [Display(Name = "Historical Annual Debt Service ")]
        public string FirstYearHistoricalAnnualDebtService { get; set; }
        public string SecondYearHistoricalAnnualDebtService { get; set; }
        public string ProformaHistoricalDebtAnnualDebtService { get; set; }
        
        [Display(Name = "Debt Service Coverage Ratio ")]
        public string FirstYearDSCR { get; set; }
        public string SecondYearDSCR { get; set; }
        public string ProformaDSCR { get; set; }

        [Display(Name = "Cash Flow After Debt Service ")]
        public string FirstYearExcessCashFlow { get; set; }
        public string SecondYearExcessCashFlow { get; set; }
        public string ProformaExcessCashFlow { get; set; }


    }
}