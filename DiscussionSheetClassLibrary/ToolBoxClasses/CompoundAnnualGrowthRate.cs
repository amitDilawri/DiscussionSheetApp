using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.ToolBoxClasses
{
    public class CompoundAnnualGrowthRate
    {
        private double EndingBalance { get; set; }
        private double BeginningBalance { get; set; }
        private int NumberOfCompoundingPeriods { get; set; }

        public CompoundAnnualGrowthRate()
        {
            //
        }

        public CompoundAnnualGrowthRate(double endingBalance, double beginningBalance, int numberOfCompoundingPeriod)
        {
            this.EndingBalance = endingBalance;
            this.BeginningBalance = beginningBalance;
            this.NumberOfCompoundingPeriods = numberOfCompoundingPeriod;
        }

        public double CalculateCAGR()
        {
            double mathPowBase = this.EndingBalance / this.BeginningBalance;
            decimal mathPowPower = (decimal)1 / (decimal)this.NumberOfCompoundingPeriods; 
            double CAGR = ((Math.Pow(mathPowBase, (double)mathPowPower)) - 1);
            return CAGR;
        }
    }
}
