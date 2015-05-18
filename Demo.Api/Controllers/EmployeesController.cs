using Demo.Entity;
using Demo.IRepository;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Demo.Api.Controllers
{
    [EnableCors("*","*","*")]
    public class EmployeesController : ApiController
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IEmployeeRepository repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Employees
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.GetAll());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError();
            }

        }

        // GET: api/Employees
        public IHttpActionResult Get(int id)
        {
            try
            {
                var employee = repository.GetById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                else 
                {
                    return Ok(employee);
                }
                
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError();
            }

        }

        // POST: api/Employees
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            try
            {
                if (employee == null) 
                {
                    return BadRequest();
                }

                repository.Add(employee);
                if (employee.EmployeeId != 0) 
                {
                    return Created(Request.RequestUri + "/" + employee.EmployeeId.ToString(), employee);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError();
            }
        }

        // PUT: api/Employees/5
        public IHttpActionResult Put(int id, [FromBody]Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                repository.Update(employee);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError();
            }
        }

        // DELETE: api/Employees/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                repository.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return InternalServerError();
            }
        }
    }
}
