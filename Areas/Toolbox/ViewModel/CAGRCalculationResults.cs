using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiscussionSheetClassLibrary.ToolBoxClasses;
using DiscussionSheetApp.Areas.Toolbox.Data;

namespace DiscussionSheetApp.Areas.Toolbox.ViewModel
{
    public class CAGRCalculationResults : Data.CAGRCalculationInputs
    {
        public double Result { get; set; }
        public List<CAGRCalculationResults> CAGRSummary { get; set; }
    }
}