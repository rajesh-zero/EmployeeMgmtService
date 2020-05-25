using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmtService.Models
{
    public partial class SalaryDetails
    {
        public int SalaryId { get; set; }

        [Required]
        public int? EmployeeId { get; set; }

        [Required]
        public decimal? Basic { get; set; }

        [Required]
        public decimal? Allowance { get; set; }

        public virtual EmployeeInfo Employee { get; set; }
    }
}
