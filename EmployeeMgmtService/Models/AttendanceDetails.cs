using System;
using System.Collections.Generic;

namespace EmployeeMgmtService.Models
{
    public partial class AttendanceDetails
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OnDate { get; set; }
        public bool? PresentAbsent { get; set; }

        public virtual EmployeeInfo Employee { get; set; }
    }
}
