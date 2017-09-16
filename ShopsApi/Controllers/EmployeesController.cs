using CodeFirstEmployee.models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ShopsApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IRepository<Employee> repository;

        public EmployeesController(IRepository<Employee> _repository)
        {
            this.repository = _repository;
        }

        public IQueryable<Employee> GetEmployees()
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            var emps = repository.GetAllEntities();

            return emps;
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = repository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.UpdateEntity(employee);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.InsertEntity(employee);

            return CreatedAtRoute("ShopApi", new { id = employee.EmployeeId }, employee);
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.DeleteEntity(id);

            return Ok(id);
        }
    }
}
