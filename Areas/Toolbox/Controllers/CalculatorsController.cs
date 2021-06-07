using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiscussionSheetApp.Areas.Toolbox.Data;
using DiscussionSheetApp.Areas.Toolbox.ViewModel;
using DiscussionSheetClassLibrary.ToolBoxClasses;
using DiscussionSheetClassLibrary.AbstractClasses;
using DiscussionSheetClassLibrary.CRECashFlow;
using DiscussionSheetClassLibrary.CashFlowAnalysisClasses;
using System.Data;


namespace DiscussionSheetApp.Areas.Toolbox.Controllers
{
    public class CalculatorsController : Controller
    {
        // GET: Toolbox/Amortization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrincipalAndInterest()
        {
            ViewBag.actionMethod = "PrincipalAndInterestAmortizationTable";
            ViewBag.pageHeading = "Principal and Interest Amortization Table";
            return View();
        }
        
        public PartialViewResult PrincipalAndInterestAmortizationTable()
        {
            ViewBag.pageHeading = "Principal and Interest Amortization Table";
            LoanPaymentInputs loanInputs = (LoanPaymentInputs)TempData.Peek("principalAndInterestInputValues");
            AmortizationTable amortizationTable = new AmortizationTable(loanInputs.LoanAmount, loanInputs.Amortization, loanInputs.InterestRate);
            LoanAmortizationSchedule loan = new LoanAmortizationSchedule
            {
                amortTable = amortizationTable.PrintLoanAmortizationPrincipalandInterest(),
                amortSummary = amortizationTable.FiveYearPrincipalAndInterest(),
                LoanAmount = loanInputs.LoanAmount,
                Amortization = loanInputs.Amortization,
                InterestRate = loanInputs.InterestRate,
                TotalInterest = amortizationTable.TotalInterest
            };

            return PartialView("_DisplayAmortizationSchedule", loan);
        }

        [HttpPost]
        public ActionResult PrincipalAndInterestAmortizationTable(LoanPaymentInputs paymentInputs)
        {
            ViewBag.pageHeading = "Principal and Interest Amortization Table";
            
            if (!ModelState.IsValid)
            {
                return PartialView("_LoanInputsForm", paymentInputs);
            }

            TempData["principalAndInterestInputValues"] = paymentInputs;
            TempData.Keep("principalAndInterestInputValues");

            return RedirectToAction("PrincipalAndInterestAmortizationTable", "Calculators", new { Area = "Toolbox" });
        }
        

        public ActionResult PrincipalPlusInterest()
        {
            ViewBag.actionMethod = "PrincipalPlusInterestAmortizationTable";
            ViewBag.pageHeading = "Principal plus Interest Amortization Table";
            return View();
        }
        public PartialViewResult PrincipalPlusInterestAmortizationTable()
        {
            ViewBag.pageHeading = "Principal plus Interest Amortization Table";

            LoanPaymentInputs paymentInputs = (LoanPaymentInputs)TempData.Peek("principalPlusInterestInputValues");
            AmortizationTable amortizationTable = new AmortizationTable(paymentInputs.LoanAmount, paymentInputs.Amortization, paymentInputs.InterestRate);
            LoanAmortizationSchedule loan = new LoanAmortizationSchedule
            {
                amortTable = amortizationTable.PrintLoanAmortizationPrincipalPlusInterest(),
                amortSummary = amortizationTable.FiveYearPrincipalAndInterest(),
                LoanAmount = paymentInputs.LoanAmount,
                Amortization = paymentInputs.Amortization,
                InterestRate = paymentInputs.InterestRate,
                TotalInterest = amortizationTable.TotalInterest
            };
            
            return PartialView("_DisplayAmortizationSchedule", loan);
        }

        [HttpPost]
        public ActionResult PrincipalPlusInterestAmortizationTable(LoanPaymentInputs paymentInputs)
        {
            ViewBag.pageHeading = "Principal plus Interest Amortization Table";

            if (!ModelState.IsValid)
            {
                return PartialView("_LoanInputsForm", paymentInputs);
            }

            TempData["principalPlusInterestInputValues"] = paymentInputs;
            TempData.Keep("principalPlusInterestInputValues");

            return RedirectToAction("PrincipalPlusInterestAmortizationTable", "Calculators", new { Area = "Toolbox" });

        }

        public ActionResult CompoundAnnualGrowthRate()
        {
            ViewBag.pageHeading = "Compound Annual Growth Rate";

            return View();
        }

        public PartialViewResult CompoundAnnualGrowthRateCalc()
        {
            ViewBag.pageHeading = "Compound Annual Growth Rate";

            CAGRCalculationInputs input = (CAGRCalculationInputs)TempData.Peek("CAGRInputValues");
            CompoundAnnualGrowthRate growthRate = new CompoundAnnualGrowthRate(input.EndingBalance, input.BeginningBalance, input.NumberOfYears);
            CAGRCalculationResults results = new CAGRCalculationResults
            {
                EndingBalance = input.EndingBalance,
                BeginningBalance = input.BeginningBalance,
                NumberOfYears = input.NumberOfYears,
                Result = growthRate.CalculateCAGR()
            };
            
            return PartialView("_DisplayCAGRResult", results);
        }

        

        [HttpPost]
        public ActionResult CompoundAnnualGrowthRateCalc(CAGRCalculationInputs inputs)
        {
            ViewBag.pageHeading = "Compound Annual Growth Rate";

            if (!ModelState.IsValid)
            {
                return PartialView("_CAGRInputsForm", inputs);
            }

            TempData["CAGRInputValues"] = inputs;
            TempData.Keep("CAGRInputValues");
            
            return RedirectToAction("CompoundAnnualGrowthRateCalc", "Calculators", new { Area = "Toolbox" });
        }

        public ActionResult CREDebtServiceCoverageRatio()
        {
            ViewBag.pageHeading = "Commercial Real Estate Ability To Pay";
            ViewBag.FirstFYE = String.Format("{0}{1:MM/dd/yyyy}", "Fiscal Year End ", FiscalYearEnds.FirstFiscalYearEndDate());
            ViewBag.SecondFYE = String.Format("{0}{1:MM/dd/yyyy}", "Fiscal Year End ", FiscalYearEnds.SecondFiscalYearEndDate());
            ViewBag.Proforma = String.Format("{0}{1:MM/dd/yyyy}", "Proforma ", FiscalYearEnds.SecondFiscalYearEndDate());

            return View();            
        }

        public PartialViewResult CREDebtServiceCoverageRatioCalc()
        {
            ViewBag.pageHeading = "Commercial Real Estate Ability To Pay";
            ViewBag.FirstFYE = String.Format("{0}{1:MM/dd/yyyy}", "Fiscal Year End ", FiscalYearEnds.FirstFiscalYearEndDate());
            ViewBag.SecondFYE = String.Format("{0}{1:MM/dd/yyyy}", "Fiscal Year End ", FiscalYearEnds.SecondFiscalYearEndDate());
            ViewBag.Proforma = String.Format("{0}{1:MM/dd/yyyy}", "Proforma ", FiscalYearEnds.SecondFiscalYearEndDate());

            CREAbilityToPayInputs input = (CREAbilityToPayInputs)TempData.Peek("CREAbilityToPayInputValues");

            CREIncome cREIncomeFirstYE = new CREIncome(input.FirstYearRents, input.FirstYearReimbursement, input.FirstYearOtherIncome);            
            double firstYETotalRevenues = cREIncomeFirstYE.TotalRevenues();

            CREIncome cREIncomeSecondYE = new CREIncome(input.SecondYearRents, input.SecondYearReimbursement, input.SecondYearOtherIncome);
            double secondYETotalRevenues = cREIncomeSecondYE.TotalRevenues();        

            CREExpenses cREExpensesFirstYE = new CREExpenses(input.FirstYearAdvertising, input.FirstYearRepairsAndMaintenance, input.FirstYearCommission, input.FirstYearInsurance, input.FirstYearLegalAndProfessionalFees, input.FirstYearManagementFee, input.FirstYearTaxes, input.FirstYearUtilities, input.FirstYearSalariesAndWages, input.FirstYearReplacementReserves, input.FirstYearOtherOperatingExpenses);
            double firstYETotalOperatingExpenses = cREExpensesFirstYE.TotalOperatingExpenses();

            CREExpenses cREExpensesSecondYE = new CREExpenses(input.SecondYearAdvertising, input.SecondYearRepairsAndMaintenance, input.SecondYearCommission, input.SecondYearInsurance, input.SecondYearLegalAndProfessionalFees, input.SecondYearManagementFee, input.SecondYearTaxes, input.SecondYearUtilities, input.SecondYearSalariesAndWages, input.SecondYearReplacementReserves, input.SecondYearOtherOperatingExpenses);
            double secondYETotalOperatingExpenses = cREExpensesSecondYE.TotalOperatingExpenses();

            CREProforma cREProforma = new CREProforma(cREIncomeSecondYE, cREExpensesSecondYE, input.SecondYearHistoricalAnnualDebtService);
            double proformaTotalRevenues = cREIncomeSecondYE.TotalRevenues();
            double proformaTotalExpenses = cREProforma.ProformaTotalOperatingExpenses();
            string proformaHistoricalDebtService = input.SecondYearHistoricalAnnualDebtService;

            CREAbilityToPay cREAbilityToPayFirstYE = new CREAbilityToPay(firstYETotalRevenues, firstYETotalOperatingExpenses, input.FirstYearHistoricalAnnualDebtService);
            CREAbilityToPay cREAbilityToPaySecondYE = new CREAbilityToPay(secondYETotalRevenues, secondYETotalOperatingExpenses, input.SecondYearHistoricalAnnualDebtService);

            double firstYENetOperatingIncome = cREAbilityToPayFirstYE.NetOperatingIncome();
            double firstYEDebtCoverage = cREAbilityToPayFirstYE.DebtServiceCoverageRatio();
            double firstYEExcessCashFlow = cREAbilityToPayFirstYE.CashFlowAfterDebtService();

            double secondYENetOperatingIncome = cREAbilityToPaySecondYE.NetOperatingIncome();
            double secondYEDebtCoverage = cREAbilityToPaySecondYE.DebtServiceCoverageRatio();
            double secondYEExcessCashFlow = cREAbilityToPaySecondYE.CashFlowAfterDebtService();

            double proformaNetOperatingIncome = cREProforma.ProformaNetOperatingIncome();
            double proformaDebtCoverage = cREProforma.ProformaDebtServiceCoverageRatio();
            double proformaExcessCashFlow = cREProforma.ProformaCashFlowAfterDebtService();
            

            CREAbilityToPayInputs results = new CREAbilityToPayInputs
            {               
                FirstYearRents = String.Format("{0}", input.FirstYearRents),
                SecondYearRents = String.Format("{0}", input.SecondYearRents),
                ProformaYearRents = String.Format("{0}{1:N}", "$ ", cREProforma.RentalIncome),
                FirstYearReimbursement = String.Format("{0}", input.FirstYearReimbursement),
                SecondYearReimbursement = String.Format("{0}", input.SecondYearReimbursement),
                ProformaYearReimbursement = String.Format("{0}{1:N}", "$ ", cREProforma.Reimbursement),
                FirstYearOtherIncome = String.Format("{0}", input.FirstYearOtherIncome),
                SecondYearOtherIncome = String.Format("{0}", input.SecondYearOtherIncome),
                ProformaYearOtherIncome = String.Format("{0}{1:N}", "$ ", cREProforma.OtherRevenue1),
                ProformaVacancy = String.Format("{0}{1:N}", "$ ", cREProforma.VacancyMinimum),
                FirstYearNetEffectiveRevenue = String.Format("{0}{1:N}", "$ ", firstYETotalRevenues),
                SecondYearNetEffectiveRevenue = String.Format("{0}{1:N}", "$ ", secondYETotalRevenues),
                ProformaNetEffectiveRevenue = String.Format("{0}{1:N}", "$ ", cREProforma.NetEffectiveIncome),
                FirstYearAdvertising = String.Format("{0}", input.FirstYearAdvertising),
                SecondYearAdvertising = String.Format("{0}", input.SecondYearAdvertising),
                ProformaAdvertising = String.Format("{0}{1:N}", "$ ", cREProforma.Advertising),
                FirstYearRepairsAndMaintenance = String.Format("{0}", input.FirstYearRepairsAndMaintenance),
                SecondYearRepairsAndMaintenance = String.Format("{0}", input.SecondYearRepairsAndMaintenance),
                ProformaRepairsAndMaintenance = String.Format("{0}{1:N}","$ ", cREProforma.RepairsAndMaintenance),
                FirstYearCommission = String.Format("{0}", input.SecondYearCommission),
                SecondYearCommission = String.Format("{0}", input.SecondYearCommission),
                ProformaCommission = String.Format("{0}{1:N}", "$ ", cREProforma.Commissions),
                FirstYearInsurance = String.Format("{0}", input.FirstYearInsurance),
                SecondYearInsurance = String.Format("{0}", input.SecondYearInsurance),
                ProformaInsurance = String.Format("{0}{1:N}", "$ ", cREProforma.Insurance),
                FirstYearLegalAndProfessionalFees = String.Format("{0}", input.FirstYearLegalAndProfessionalFees),
                SecondYearLegalAndProfessionalFees = String.Format("{0}", input.SecondYearLegalAndProfessionalFees),
                ProformaLegalAndProfessionalFees = String.Format("{0}{1:N}", "$ ", cREProforma.LegalAndProfessionalFees),
                FirstYearManagementFee = String.Format("{0}", input.FirstYearManagementFee),
                SecondYearManagementFee = String.Format("{0}", input.SecondYearManagementFee),
                ProformaManagementFee = String.Format("{0}{1:N}", "$ ", cREProforma.ManagementFees),
                FirstYearTaxes = String.Format("{0}", input.FirstYearTaxes),
                SecondYearTaxes = String.Format("{0}", input.SecondYearTaxes),
                ProformaTaxes = String.Format("{0}{1:N}", "$ ", cREProforma.Taxes),
                FirstYearUtilities = String.Format("{0}", input.FirstYearUtilities),
                SecondYearUtilities = String.Format("{0}", input.SecondYearUtilities),
                ProformaUtilities = String.Format("{0}{1:N}", "$ ", cREProforma.Utilities),
                FirstYearSalariesAndWages = String.Format("{0}", input.FirstYearSalariesAndWages),
                SecondYearSalariesAndWages = String.Format("{0}", input.SecondYearSalariesAndWages),
                ProformaSalariesAndWages = String.Format("{0}{1:N}", "$ ", cREProforma.SalariesAndWages),
                FirstYearReplacementReserves = String.Format("{0}", input.FirstYearReplacementReserves),
                SecondYearReplacementReserves = String.Format("{0}", input.SecondYearReplacementReserves),
                ProformaReplacementReserves = String.Format("{0}{1:N}", "$ ", cREProforma.ReplacementReserves),
                FirstYearOtherOperatingExpenses = String.Format("{0}", input.FirstYearOtherOperatingExpenses),
                SecondYearOtherOperatingExpenses = String.Format("{0}", input.SecondYearOtherOperatingExpenses),
                ProformaOtherOperatingExpenses = String.Format("{0}{1:N}", "$ ", cREProforma.OtherOperatingExpenses),
                FirstYearTotalOperatingExpenses = String.Format("{0}{1:N}", "$ ", firstYETotalOperatingExpenses),
                SecondYearTotalOperatingExpenses = String.Format("{0}{1:N}", "$ ", secondYETotalOperatingExpenses),
                ProformaTotalOperatingExpenses = String.Format("{0}{1:N}","$ ", proformaTotalExpenses),
                FirstYearNetOperatingIncome = String.Format("{0}{1:N}", "$ ", firstYENetOperatingIncome),
                SecondYearNetOperatingIncome = String.Format("{0}{1:N}", "$ ", secondYENetOperatingIncome),
                ProformaNetOperatingIncome = String.Format("{0}{1:N}", "$ ", proformaNetOperatingIncome),
                FirstYearHistoricalAnnualDebtService = String.Format("{0}", input.FirstYearHistoricalAnnualDebtService),
                SecondYearHistoricalAnnualDebtService =  String.Format("{0}", input.SecondYearHistoricalAnnualDebtService),
                ProformaHistoricalDebtAnnualDebtService = String.Format("{0}", proformaHistoricalDebtService),
                FirstYearDSCR = String.Format("{0}{1}", firstYEDebtCoverage, "x"),
                SecondYearDSCR = String.Format("{0}{1}", secondYEDebtCoverage, "x"),
                ProformaDSCR = String.Format("{0}{1}", proformaDebtCoverage, "x"),
                FirstYearExcessCashFlow = String.Format("{0}{1:N}", "$ ", firstYEExcessCashFlow),
                SecondYearExcessCashFlow = String.Format("{0}{1:N}", "$ ", secondYEExcessCashFlow),
                ProformaExcessCashFlow = String.Format("{0}{1:N}", "$ ", proformaExcessCashFlow)
            };
            return PartialView("_CREAbilityToPayInputForm", results);           
        }

        [HttpPost]
        public ActionResult CREDebtServiceCoverageRatioCalc(CREAbilityToPayInputs inputs)
        {
            ViewBag.pageHeading = "Real Estate Ability To Pay";
            if (!ModelState.IsValid)
            {                
                return PartialView("_CREAbilityToPayInputsForm", inputs);
            }
            
            TempData["CREAbilityToPayInputValues"] = inputs;
            TempData.Keep("CREAbilityToPayInputValues");
            return RedirectToAction("CREDebtServiceCoverageRatioCalc", "Calculators", new { Area = "Toolbox" });
        }

        //Need to fix the Debt Coverage Ratio
        public ActionResult DebtServiceCoverageRatio()
        {

            return View();
        }

        public PartialViewResult DebtServiceCoverageCalc()
        {

            DSCRInputs dSCRInputs = (DSCRInputs)TempData.Peek("DSCRInputValues");
            
            DebtServiceCoverageRatio DSCR = new DebtServiceCoverageRatio(dSCRInputs.PreTaxNetIncome, dSCRInputs.InterestExpense, dSCRInputs.DepreciationExpense, dSCRInputs.AmortizationExpense, dSCRInputs.AnnualPrincipalPayment);
            DebtCoverageRatioCalc calc = new DebtCoverageRatioCalc
            {
                TotalEBITDA = DSCR.EBITDA(),
                AnnualDebtService = DSCR.AnnualDebtObligation(),
                DebtServiceCoverageRatio = DSCR.DSCR(),
                ExcessCashFlowAfterDebtService = DSCR.ExcessCashFlow(),
                PreTaxNetIncome = dSCRInputs.PreTaxNetIncome,
                DepreciationExpense = dSCRInputs.DepreciationExpense,
                AmortizationExpense = dSCRInputs.AmortizationExpense,
                InterestExpense = dSCRInputs.InterestExpense,
                AnnualPrincipalPayment = dSCRInputs.AnnualPrincipalPayment

            };

            return PartialView("_DisplayDSCRResult", calc);
        }

        [HttpPost]
        public ActionResult DebtServiceCoverageCalc(DSCRInputs dSCRInputValues)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("_DSCRInputsForm", dSCRInputValues);
            }
            
            TempData["DSCRInputValues"] = dSCRInputValues;
            TempData.Keep("DSCRInputValues");

            return RedirectToAction("DebtServiceCoverageCalc", "Calculators", new { Area = "Toolbox" });
        }

    

    }
}