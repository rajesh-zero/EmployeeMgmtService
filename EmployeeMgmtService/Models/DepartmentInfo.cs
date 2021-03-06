﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmtService.Models
{
    public partial class DepartmentInfo
    {
        public DepartmentInfo()
        {
            EmployeeInfo = new HashSet<EmployeeInfo>();
        }

        public int DepartmentId { get; set; }
        
        [Required]
        public string DepartmentName { get; set; }

        public virtual ICollection<EmployeeInfo> EmployeeInfo { get; set; }
    }
}
