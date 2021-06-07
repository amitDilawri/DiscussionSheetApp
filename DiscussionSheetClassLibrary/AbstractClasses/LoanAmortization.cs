using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.AbstractClasses
{
    public abstract class LoanAmortization
    {
        public double LoanAmount, InterestRate, AnnualDebtObligation;
        public int Amortization;

        
        public virtual double ConvertRateToDecimal()
        {
            double rate = this.InterestRate / 100;
            return rate;
        }

        public virtual double CalculateMonthlyInterestRate()
        {
            double monthlyInterestRate = ConvertRateToDecimal() / 12;
            return monthlyInterestRate;
        }

        public virtual double CalculateMonthlyPayment() //Principal and Interest Payment
        {
            double monthlyPayment;
            double monthlyInterest = CalculateMonthlyInterestRate();
            monthlyPayment = (this.LoanAmount * (monthlyInterest)) / (1 - Math.Pow((1 + (monthlyInterest)), -(this.Amortization)));

            return monthlyPayment;
        }

        public virtual double CalculateMonthlyPrincipalPlusInterestPayment()
        {
            double monthlyPplusIPayment;
            double monthlyPrincipal = this.LoanAmount / this.Amortization;
            double firstMonthInterest = this.LoanAmount * (1 + (ConvertRateToDecimal() * this.Amortization));
            monthlyPplusIPayment = monthlyPrincipal + firstMonthInterest;
            return monthlyPplusIPayment;
        }

        public virtual double AnnualDebtService()
        {
            double annualPrincipalandInterest = CalculateMonthlyPayment() * 12;
            return annualPrincipalandInterest;
        }
    }
}
