using System;
using System.Collections.Generic;

namespace EmployeeMgmtService.Models
{
    public partial class SalaryDetails
    {
        public int SalaryId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? Basic { get; set; }
        public decimal? Allowance { get; set; }

        public virtual EmployeeInfo Employee { get; set; }
    }
}
