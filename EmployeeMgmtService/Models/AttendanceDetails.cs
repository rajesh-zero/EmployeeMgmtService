using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmtService.Models
{
    public partial class AttendanceDetails
    {
        public int AttendanceId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime OnDate { get; set; }

        public bool? PresentAbsent { get; set; }

        public virtual EmployeeInfo Employee { get; set; }
    }
}
