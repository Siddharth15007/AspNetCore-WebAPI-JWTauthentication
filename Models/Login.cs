using System;  
using System.ComponentModel.DataAnnotations;  
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;

namespace StudentWebApi.Models
{
    public class Login
    {
        [Required(ErrorMessage = " Please Fill the UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Fill the Password")]
        public string Password { get; set; }
    }
}