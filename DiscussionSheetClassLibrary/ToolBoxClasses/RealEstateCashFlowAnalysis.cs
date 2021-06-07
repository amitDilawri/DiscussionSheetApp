using System;
using System.Collections.Generic;
using System.Text;
using DiscussionSheetClassLibrary.ToolBoxClasses;



namespace DiscussionSheetClassLibrary.ToolBoxClasses
{
    public class RealEstateCashFlowAnalysis
    {
        private double RentsReceived { get; set; }
        private double OtherIncome { get; set; }

        public RealEstateCashFlowAnalysis(double rentsReceived, double otherIncome)
        {
            this.RentsReceived = rentsReceived;
            this.OtherIncome = otherIncome;

        }

        public double NOI()
        {
            RealEstateOperatingExpenses expenses = new RealEstateOperatingExpenses();
            double netOperatingIncome = (this.RentsReceived + this.OtherIncome) - expenses.TotalOperatingExpenses();
            return netOperatingIncome;
        }
    }
}
