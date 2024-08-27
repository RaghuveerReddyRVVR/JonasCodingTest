using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new List<Employee>();

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await Task.FromResult(_employees);
    }

    public async Task<Employee> GetEmployeeByCodeAsync(string employeeCode)
    {
        return await Task.FromResult(_employees.FirstOrDefault(e => e.EmployeeCode == employeeCode));
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        employee.LastModified = DateTime.UtcNow;
        _employees.Add(employee);
        await Task.CompletedTask;
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var existingEmployee = _employees.FirstOrDefault(e => e.EmployeeCode == employee.EmployeeCode);
        if (existingEmployee != null)
        {
            existingEmployee.SiteId = employee.SiteId;
            existingEmployee.CompanyCode = employee.CompanyCode;
            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.Occupation = employee.Occupation;
            existingEmployee.EmployeeStatus = employee.EmployeeStatus;
            existingEmployee.EmailAddress = employee.EmailAddress;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.LastModified = DateTime.UtcNow;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteEmployeeAsync(string employeeCode)
    {
        var employee = _employees.FirstOrDefault(e => e.EmployeeCode == employeeCode);
        if (employee != null)
        {
            _employees.Remove(employee);
        }
        await Task.CompletedTask;
    }
}
