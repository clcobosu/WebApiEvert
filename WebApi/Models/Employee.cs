using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }

        public int EstadoCivil { get; set; }
        public DateTime DateOfBird { get; set; }
        public bool Brothers { get; set; }
        public string PhotoFileName { get; set; }
    }
}
