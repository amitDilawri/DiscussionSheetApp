 using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;


namespace DiscussionSheetClassLibrary.ToolBoxClasses
{
    public class AmortizationTable : AbstractClasses.LoanAmortization
    {

        public double MonthlyPayment { get; set; }
        public double BeginningBalance { get; set; }
        public double MonthlyInterest { get; set; }
        public double MonthlyPrincipal { get; set; }
        public double EndingBalance { get; set; }
        public double TotalInterest { get; set; }
        public double YearOneAnnualPrincipal { get; set; }
        public double YearOneAnnualInterest { get; set; }
        public double YearOneAnnualDebtService { get; set; }
        public double YearTwoAnnualPrincipal { get; set; }
        public double YearTwoAnnualInterest { get; set; }
        public double YearTwoAnnualDebtService { get; set; }
        public double YearThreeAnnualPrincipal { get; set; }
        public double YearThreeAnnualInterest { get; set; }
        public double YearThreeAnnualDebtService { get; set; }
        public double YearFourAnnualPrincipal { get; set; }
        public double YearFourAnnualInterest { get; set; }
        public double YearFourAnnualDebtService { get; set; }
        public double YearFiveAnnualPrincipal { get; set; }
        public double YearFiveAnnualInterest { get; set; }
        public double YearFiveAnnualDebtService { get; set; }

        //Years in months
        const int YearOne = 12;
        const int YearTwo = 24;
        const int YearThree = 36;
        const int YearFour = 48;
        const int YearFive = 60;

        public AmortizationTable()
        {
            //
        }

        public AmortizationTable(double loanAmount, int amortizationInMonths, double interestRate)
        {
            this.LoanAmount = loanAmount;
            this.Amortization = amortizationInMonths;
            this.InterestRate = interestRate;
        }

        public double PplusIPrincipalPayment()
        {
            double principalPayment = (double)this.LoanAmount / this.Amortization;
            return principalPayment;
        }

        public double TotalInterestPaid()
        {
            return this.TotalInterest;
        }

        public List<AmortizationTable> FiveYearPrincipalAndInterest()
        {
            List<AmortizationTable> list = new List<AmortizationTable>()
            {
                new AmortizationTable
                {
                    YearOneAnnualPrincipal = YearOneAnnualPrincipal,
                    YearOneAnnualInterest = YearOneAnnualInterest,
                    YearOneAnnualDebtService = YearOneAnnualDebtService,
                    YearTwoAnnualPrincipal = YearTwoAnnualPrincipal,
                    YearTwoAnnualInterest = YearTwoAnnualInterest,
                    YearTwoAnnualDebtService = YearTwoAnnualDebtService,
                    YearThreeAnnualPrincipal = YearThreeAnnualPrincipal,
                    YearThreeAnnualInterest = YearThreeAnnualInterest,
                    YearThreeAnnualDebtService = YearThreeAnnualDebtService,
                    YearFourAnnualPrincipal = YearFourAnnualPrincipal,
                    YearFourAnnualInterest = YearFourAnnualInterest,
                    YearFourAnnualDebtService = YearFourAnnualDebtService,
                    YearFiveAnnualPrincipal = YearFiveAnnualPrincipal,
                    YearFiveAnnualInterest = YearFiveAnnualInterest,
                    YearFiveAnnualDebtService = YearFiveAnnualDebtService
                    
                    
                }
            };

            return list;
        }

        public Dictionary<int, AmortizationTable> PrintLoanAmortizationPrincipalandInterest()
        {
            Dictionary<int, AmortizationTable> dict = new Dictionary<int, AmortizationTable>();
            this.BeginningBalance = (double)this.LoanAmount;
            this.MonthlyPayment = CalculateMonthlyPayment();
            double monthlyInterestRate = CalculateMonthlyInterestRate();
            this.MonthlyInterest = monthlyInterestRate * this.BeginningBalance;
            this.MonthlyPrincipal = this.MonthlyPayment - this.MonthlyInterest;
            this.EndingBalance = this.BeginningBalance - this.MonthlyPrincipal;
            

            double interestCounter = this.MonthlyInterest;
            double principalCounter = this.MonthlyPrincipal;

            this.TotalInterest = interestCounter;

            for(int i = 1; i <= this.Amortization; i++)
            {
                dict.Add(i, new AmortizationTable { BeginningBalance = BeginningBalance, MonthlyPayment = MonthlyPayment, MonthlyInterest = MonthlyInterest, MonthlyPrincipal = MonthlyPrincipal, EndingBalance = EndingBalance });
                if (i == YearOne)
                {
                    this.YearOneAnnualInterest = interestCounter;
                    this.YearOneAnnualPrincipal = principalCounter;
                    this.YearOneAnnualDebtService = this.YearOneAnnualPrincipal + this.YearOneAnnualInterest;
                }
                else if(i == YearTwo)
                {
                    this.YearTwoAnnualInterest = interestCounter - this.YearOneAnnualInterest;
                    this.YearTwoAnnualPrincipal = principalCounter - this.YearOneAnnualPrincipal;
                    this.YearTwoAnnualDebtService = this.YearTwoAnnualPrincipal + this.YearTwoAnnualInterest;
                }
                else if(i == YearThree)
                {
                    this.YearThreeAnnualInterest = interestCounter - (this.YearTwoAnnualInterest + this.YearOneAnnualInterest);
                    this.YearThreeAnnualPrincipal = principalCounter - (this.YearTwoAnnualPrincipal + this.YearOneAnnualPrincipal);
                    this.YearThreeAnnualDebtService = this.YearThreeAnnualPrincipal + this.YearThreeAnnualInterest;
                }
                else if(i == YearFour)
                {
                    this.YearFourAnnualInterest = interestCounter - (this.YearThreeAnnualInterest + this.YearTwoAnnualInterest + this.YearOneAnnualInterest);
                    this.YearFourAnnualPrincipal = principalCounter - (this.YearThreeAnnualPrincipal + this.YearTwoAnnualPrincipal + this.YearOneAnnualPrincipal);
                    this.YearFourAnnualDebtService = this.YearFourAnnualInterest + this.YearFourAnnualPrincipal;
                }
                else if(i == YearFive)
                {
                    this.YearFiveAnnualInterest = interestCounter - (this.YearFourAnnualInterest + this.YearThreeAnnualInterest + this.YearTwoAnnualInterest + this.YearOneAnnualInterest);
                    this.YearFiveAnnualPrincipal = principalCounter - (this.YearFourAnnualPrincipal + this.YearThreeAnnualPrincipal + this.YearTwoAnnualPrincipal + this.YearOneAnnualPrincipal);
                    this.YearFiveAnnualDebtService = this.YearFiveAnnualInterest + this.YearFiveAnnualPrincipal;
                }
                this.BeginningBalance = this.EndingBalance;
                this.MonthlyInterest = monthlyInterestRate * this.BeginningBalance;
                this.MonthlyPrincipal = this.MonthlyPayment - this.MonthlyInterest;
                this.EndingBalance = this.BeginningBalance - this.MonthlyPrincipal;
                
                interestCounter = interestCounter + this.MonthlyInterest;
                principalCounter = principalCounter + this.MonthlyPrincipal;

                this.TotalInterest = interestCounter;
                
            }
            return dict;
        }

        public Dictionary<int, AmortizationTable> PrintLoanAmortizationPrincipalPlusInterest()
        {
            Dictionary<int, AmortizationTable> dict = new Dictionary<int, AmortizationTable>();

            this.BeginningBalance = this.LoanAmount;
            this.MonthlyPrincipal = this.BeginningBalance / this.Amortization;
            this.MonthlyInterest = (this.BeginningBalance * ConvertRateToDecimal() / 12);
            this.MonthlyPayment = this.MonthlyPrincipal + this.MonthlyInterest;
            this.EndingBalance = this.BeginningBalance - this.MonthlyPrincipal;

            double interestCounter = this.MonthlyInterest;
            double principalCounter = this.MonthlyPrincipal;

            this.TotalInterest = interestCounter;

            for(int i = 1; i <= this.Amortization; i++)
            {
                dict.Add(i, new AmortizationTable { BeginningBalance = BeginningBalance, MonthlyPayment = MonthlyPayment, MonthlyInterest = MonthlyInterest, MonthlyPrincipal = MonthlyPrincipal, EndingBalance = EndingBalance });
                if(i == YearOne)
                {
                    this.YearOneAnnualInterest = interestCounter;
                    this.YearOneAnnualPrincipal = principalCounter;
                    this.YearOneAnnualDebtService = this.YearOneAnnualPrincipal + this.YearOneAnnualInterest;
                }
                else if(i == YearTwo)
                {
                    this.YearTwoAnnualInterest = interestCounter - this.YearOneAnnualInterest;
                    this.YearTwoAnnualPrincipal = principalCounter - this.YearOneAnnualPrincipal;
                    this.YearTwoAnnualDebtService = this.YearTwoAnnualPrincipal + this.YearTwoAnnualInterest;
                }
                else if(i == YearThree)
                {
                    this.YearThreeAnnualInterest = interestCounter - (this.YearTwoAnnualInterest + this.YearOneAnnualInterest);
                    this.YearThreeAnnualPrincipal = principalCounter - (this.YearTwoAnnualPrincipal + this.YearOneAnnualPrincipal);
                    this.YearThreeAnnualDebtService = this.YearThreeAnnualPrincipal + this.YearThreeAnnualInterest;
                }
                else if(i == YearFour)
                {
                    this.YearFourAnnualInterest = interestCounter - (this.YearThreeAnnualInterest + this.YearTwoAnnualInterest + this.YearOneAnnualInterest);
                    this.YearFourAnnualPrincipal = principalCounter - (this.YearThreeAnnualPrincipal + this.YearTwoAnnualPrincipal + this.YearOneAnnualPrincipal);
                    this.YearFourAnnualDebtService = this.YearFourAnnualPrincipal + this.YearFourAnnualInterest;
                }
                else if(i == YearFive)
                {
                    this.YearFiveAnnualInterest = interestCounter - (this.YearFourAnnualInterest + this.YearThreeAnnualInterest + this.YearTwoAnnualInterest + this.YearOneAnnualInterest);
                    this.YearFiveAnnualPrincipal = principalCounter - (this.YearFourAnnualPrincipal + this.YearThreeAnnualPrincipal + this.YearTwoAnnualPrincipal + this.YearOneAnnualPrincipal);
                    this.YearFiveAnnualDebtService = this.YearFiveAnnualPrincipal + this.YearFiveAnnualInterest;
                }

                this.BeginningBalance = this.EndingBalance;
                this.MonthlyInterest = (this.BeginningBalance * ConvertRateToDecimal() / 12);
                this.MonthlyPayment = this.MonthlyPrincipal + this.MonthlyInterest;
                this.EndingBalance = this.BeginningBalance - this.MonthlyPrincipal;

                interestCounter = interestCounter + this.MonthlyInterest;
                principalCounter = principalCounter + this.MonthlyPrincipal;

                this.TotalInterest = interestCounter;
            }
            
            return dict;
        }


    }
}
