using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeByID(int ID);
        Task<Employee> InsertEmployee(Employee objEmployee);
        Task<Employee> UpdateEmployee(Employee objEmployee);
        bool DeleteEmployee(int ID);
    }
}
