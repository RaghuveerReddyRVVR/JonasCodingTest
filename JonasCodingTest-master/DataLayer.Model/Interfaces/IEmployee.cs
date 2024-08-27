using DataAccessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByCodeAsync(string employeeCode);
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(string employeeCode);
}
