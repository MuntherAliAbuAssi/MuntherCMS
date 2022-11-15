﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuntherCMS.Data.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public bool IsDelete { get; set; } 


    }
}
