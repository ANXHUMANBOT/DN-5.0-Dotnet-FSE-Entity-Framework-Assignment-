using System.Linq;
using FirstWebAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using FirstWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace FirstWebAPI.Controllers
{
[ApiController]
[Route("api/[controller]")]
[Authorize]
//[CustomAuthFilter]
//[TypeFilter(typeof(CustomExceptionFilter))]
public class EmployeeController : ControllerBase
    {
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department
                    {
                        Id = 101,
                        Name = "IT"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = ".NET" }
                    },
                    DateOfBirth = new DateTime(1998, 5, 20)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Alice",
                    Salary = 60000,
                    Permanent = false,
                    Department = new Department
                    {
                        Id = 102,
                        Name = "HR"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Communication" }
                    },
                    DateOfBirth = new DateTime(1999, 10, 15)
                }
            };
        }

       [HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public ActionResult<List<Employee>> Get()
{
    throw new Exception("Demo Exception");
}

[HttpPut("{id}")]
public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
{
    if (id <= 0)
    {
        return BadRequest("Invalid employee id");
    }

    var employees = GetStandardEmployeeList();

    var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

    if (existingEmployee == null)
    {
        return BadRequest("Invalid employee id");
    }

    existingEmployee.Name = employee.Name;
    existingEmployee.Salary = employee.Salary;
    existingEmployee.Permanent = employee.Permanent;
    existingEmployee.Department = employee.Department;
    existingEmployee.Skills = employee.Skills;
    existingEmployee.DateOfBirth = employee.DateOfBirth;

    return Ok(existingEmployee);
}

        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            return Ok(employee);
        }
    }
}