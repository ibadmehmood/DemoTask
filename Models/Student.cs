using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        
        public string FullName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{4}-[0-9]{7}", ErrorMessage = "Mobile No must follow the XXXX-XXXXXXX format!")]

        public string Phone { get; set; }
        [Required]
       [RegularExpression("^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "CNIC No must follow the XXXXX-XXXXXXX-X format!")]

        public string FatherCnic { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        
        public string Class { get; set; }
    }
}