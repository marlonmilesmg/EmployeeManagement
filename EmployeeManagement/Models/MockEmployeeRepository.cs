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
                new Employee() { Id =1, Name = "Marlon", Department = Dept.Development, Email = "marlon@te.co.zw"},
                new Employee() { Id =2, Name = "Ralph", Department = Dept.Deployment, Email = "ralph@te.co.zw"},
                new Employee() { Id =3, Name = "Tonde", Department = Dept.Infrastructure, Email = "tonde@te.co.zw"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
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
