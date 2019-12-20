using System;  
using System.ComponentModel.DataAnnotations;  
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;

namespace StudentWebApi.Models
{
    public partial class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string Department { get; set; }
    }
}