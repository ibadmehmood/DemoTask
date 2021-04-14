using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        [Required]
        public string Degree { get; set; }

        [Required]


        [RegularExpression("^[0-9]*$", ErrorMessage = "Total Marks Must be Numbers")]

        public int TotalMarks { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Obtain Marks Must be Numbers")]
        public int ObtainMarks { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Percentage Marks Must be Numbers")]
        public int Percentage { get; set; }
        [Required]

        [StringLength(2,ErrorMessage ="Grade must not be more than two characters. i-e A")]
        public string Grade { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}