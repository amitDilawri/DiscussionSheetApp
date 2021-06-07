using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiscussionSheetApp.Areas.Toolbox.Data;
using DiscussionSheetClassLibrary.ToolBoxClasses;


namespace DiscussionSheetApp.Areas.Toolbox.ViewModel
{
    public class DebtCoverageRatioCalc : Data.DSCRInputs
    {
        public double DebtServiceCoverageRatio { get; set; }
        public double ExcessCashFlowAfterDebtService { get; set; }
        public double TotalEBITDA { get; set; }
        public double AnnualDebtService { get; set; }
        //public List<DebtCoverageRatioCalc> DSCRResults { get; set; }
        //public List<DebtServiceCoverageRatio> debtServiceCoverage { get; set; }
    }
}