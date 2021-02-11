using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHouse.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Employee HR ID")]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee HR ID")]
        [RegularExpression("\\D", ErrorMessage = "Please write letters only.")]
        [Required]
        public string FullName { get; set; }
        public Nationality Nationality { get; set; }
        public int NationalityId { get; set; }
        public MaritualStatus MaritualStatus { get; set; }
        public int MaritualStatusId { get; set; }
    }
}