using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET: api/Employees
        public IEnumerable<Employee> Get()
        {
            return new Employee[] {
                new Employee{FullName = "Edgar Cruzado",Notes="My Notes",Department = "Marketing"},
                new Employee{FullName = "Daniel Cruzado",Notes="My Notes",Department = "Marketing"},
                new Employee{FullName = "Luis Cruzado",Notes="My Notes",Department = "Marketing"}
            };
        }
    }

    public class Employee
    {
        public string FullName { get; set; }
        public string Notes { get; set; }
        public string Department { get; set; }
    }
}
