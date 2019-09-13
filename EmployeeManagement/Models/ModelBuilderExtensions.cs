﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Department = Dept.IT,
                    Email = "john@te.co.za"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mary",
                    Department = Dept.HR,
                    Email = "mary@te.co.za"
                }
            );
        }
    }
}
