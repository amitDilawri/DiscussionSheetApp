using System;
using System.Collections.Generic;
using System.Text;

namespace DiscussionSheetClassLibrary.CRECashFlow
{
    public class CREIncome : AbstractClasses.IncomeStatement
    {
        public CREIncome()
        {
            //
        }
        
       public CREIncome(string rentalIncome, string reimbursement, string otherRevenues)
        {
            double _rentalIncome, _reimbursement, _otherRevenue;
           
            _rentalIncome = String.IsNullOrEmpty(rentalIncome) ? 0 : double.Parse(rentalIncome.Replace("$ ", string.Empty));
            _reimbursement = String.IsNullOrEmpty(reimbursement) ? 0 : double.Parse(reimbursement.Replace("$ ", string.Empty));
            _otherRevenue = String.IsNullOrEmpty(otherRevenues) ? 0 : double.Parse(otherRevenues.Replace("$ ", string.Empty));

            this.RentalIncome = _rentalIncome;
            this.Reimbursement = _reimbursement;
            this.OtherRevenue1 = _otherRevenue;
            this.ListOfRevenues = new double[3] { this.RentalIncome, this.Reimbursement, this.OtherRevenue1 };
        }

       

    }
}
