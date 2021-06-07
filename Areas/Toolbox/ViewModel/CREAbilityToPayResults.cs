using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiscussionSheetApp.Areas.Toolbox.ViewModel
{
    public class CREAbilityToPayResults : Data.CREAbilityToPayInputs
    {
        public double NetOperatingIncome { get; set; }
        public double SecondYENetOperatingIncome { get; set; }

    }
}