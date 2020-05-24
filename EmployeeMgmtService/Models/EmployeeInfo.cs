using System;
using System.Collections.Generic;

namespace EmployeeMgmtService.Models
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            AttendanceDetails = new HashSet<AttendanceDetails>();
            SalaryDetails = new HashSet<SalaryDetails>();
        }

        public int EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual DepartmentInfo Department { get; set; }
        public virtual ICollection<AttendanceDetails> AttendanceDetails { get; set; }
        public virtual ICollection<SalaryDetails> SalaryDetails { get; set; }
    }
}
