using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id =1, Name = "Marlon", Department = "Development", Email = "marlon@te.co.zw"},
                new Employee() { Id =1, Name = "Ralph", Department = "Development", Email = "ralph@te.co.zw"},
                new Employee() { Id =1, Name = "Tonde", Department = "Development", Email = "tonde@te.co.zw"}
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
