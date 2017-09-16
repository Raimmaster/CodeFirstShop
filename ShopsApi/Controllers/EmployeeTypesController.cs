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
    public class EmployeeTypesController : ApiController
    {
        private readonly IRepository<EmployeeType> repository;

        public EmployeeTypesController(IRepository<EmployeeType> _repository)
        {
            this.repository = _repository;
        }

        public IQueryable<EmployeeType> GetEmployeeTypes()
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            var emps = repository.GetAllEntities();

            return emps;
        }

        [ResponseType(typeof(EmployeeType))]
        public IHttpActionResult GetEmployeeType(int id)
        {
            var type = repository.GetById(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeType(EmployeeType employeeType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.UpdateEntity(employeeType);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(EmployeeType))]
        public IHttpActionResult PostEmployeeType(EmployeeType employeeType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.InsertEntity(employeeType);

            return CreatedAtRoute("ShopApi", new { id = employeeType.EmployeeTypeId }, employeeType);
        }

        [ResponseType(typeof(EmployeeType))]
        public IHttpActionResult DeleteEmployeeType(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            repository.DeleteEntity(id);

            return Ok(id);
        }
    }
}
