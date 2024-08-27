using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using DataAccessLayer.Model.Models;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;


       


        //private readonly ILogger _logger;
         var _logger = new LoggerFactory().AddSerilog().CreateLogger("Global");
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            

        }

        // GET api/employee
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployeesAsync();
                return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all employees.");
                throw;
            }
        }

        // GET api/employee/5
        public async Task<IHttpActionResult> Get(string employeeCode)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeByCodeAsync(employeeCode);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<EmployeeDto>(employee));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching employee with code {employeeCode}.");
                return InternalServerError(ex);
            }
        }

        // POST api/employee
        public async Task<IHttpActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data is null.");
            }

            try
            {
                var employee = _mapper.Map<Employee>(employeeDto);
                await _employeeRepository.AddEmployeeAsync(employee);
                return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeCode }, employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new employee.");
                return InternalServerError(ex);
            }
        }

        // PUT api/employee/5
        public async Task<IHttpActionResult> Put(string employeeCode, [FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null || employeeCode != employeeDto.EmployeeCode)
            {
                return BadRequest("Invalid employee data.");
            }

            try
            {
                var existingEmployee = await _employeeRepository.GetEmployeeByCodeAsync(employeeCode);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                var updatedEmployee = _mapper.Map(employeeDto, existingEmployee);
                await _employeeRepository.UpdateEmployeeAsync(updatedEmployee);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating employee with code {employeeCode}.");
                return InternalServerError(ex);
            }
        }

        // DELETE api/employee/5
        public async Task<IHttpActionResult> Delete(string employeeCode)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeByCodeAsync(employeeCode);
                if (employee == null)
                {
                    return NotFound();
                }

                await _employeeRepository.DeleteEmployeeAsync(employeeCode);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting employee with code {employeeCode}.");
                return InternalServerError(ex);
            }
        }
    }
}
