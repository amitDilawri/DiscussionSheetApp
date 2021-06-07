using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DiscussionSheetApp.Areas.Toolbox.Data
{
    public class CAGRCalculationInputs
    {
        [Display(Name = "Ending Balance: ")]
        [Required(ErrorMessage = "Field is required")]
        [Range(1000, 1000000000, ErrorMessage = "Ending balance must be between 1,000 and 1,000,000,000")]
        public double EndingBalance { get; set; }
        [Display(Name = "Beginning Balance: ")]
        [Required(ErrorMessage = "Field is required")]
        [Range(1000, 1000000000, ErrorMessage = "Beginning balance must be between 1,000 and 1,000,000,000")]
        public double BeginningBalance { get; set; }
        [Display(Name = "Number of Years: ")]
        [Required(ErrorMessage = "Field is required")]
        [Range(1, 30, ErrorMessage = "Number of years must be min. 1 and max. 30")]
        public int NumberOfYears { get; set; }

        
        

    }
}