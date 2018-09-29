using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rrhh.Api.DTOs;
using Rrhh.AppService.Services;
using Rrhh.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Rrhh.Api.Controllers
{
    [Route("api/employeetype")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly EmployeeTypeService service;
        private readonly IMapper mapper;
        
        public EmployeeTypeController(EmployeeTypeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET /employeetype
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeTypeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<EmployeeTypeDTO>>(this.service.GetAll()).ToList();
        }

        // GET /employeetype/{id}
        [HttpGet("{id}")]
        public ActionResult<EmployeeTypeDTO> Get(int id)
        {
            return this.mapper.Map<EmployeeTypeDTO>(this.service.Get(id));
        }

        // POST
        [HttpPost]
        public void Post([FromBody] EmployeeTypeDTO value)
        {
            this.service.Create(this.mapper.Map<EmployeeType>(value));
        }

        // PUT  /employeetype/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeTypeDTO value)
        {
            var employeeType = this.service.Get(id);
            this.mapper.Map<EmployeeTypeDTO, EmployeeType>(value, employeeType);
            this.service.Update(employeeType);
        }

        // DELETE /employeetype/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeType = this.service.Get(id);
            this.service.Delete(employeeType);
        }
    }
}
