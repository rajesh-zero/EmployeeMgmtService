using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }



        [Required]
        [StringLength(30)]
        [RegularExpression(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")]
        public string UserName { get; set; }


        [Required]
        [StringLength(30)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
        public string Password { get; set; }


        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string Email { get; set; }


        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual DepartmentInfo Department { get; set; }
        public virtual ICollection<AttendanceDetails> AttendanceDetails { get; set; }
        public virtual ICollection<SalaryDetails> SalaryDetails { get; set; }
    }
}
