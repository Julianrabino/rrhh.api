using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rrhh.Api.DTOs;
using Rrhh.AppService.Services;
using Rrhh.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Rrhh.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService service;
        private readonly EmployeeTypeService employeeTypeService;
        private readonly IdentificationTypeService identificationTypeService;
        private readonly IMapper mapper;

        public EmployeeController(
            EmployeeService service, 
            EmployeeTypeService productTypeService,
            IdentificationTypeService identificationTypeService,
            IMapper mapper)
        {
            this.service = service;
            this.employeeTypeService = productTypeService;
            this.identificationTypeService = identificationTypeService;
            this.mapper = mapper;
        }

        // GET /employee
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<EmployeeDTO>>(this.service.GetAll()).ToList();
        }

        // GET /employee/{id}
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> Get(int id)
        {
            return this.mapper.Map<EmployeeDTO>(this.service.Get(id));
        }

        // POST
        [HttpPost]
        public void Post([FromBody] EmployeeDTO value)
        {
            TryValidateModel(value);
            var employee = this.mapper.Map<Employee>(value);
            employee.EmployeeType = this.employeeTypeService.Get(value.EmployeeTypeId);
            employee.IdentificationType = this.identificationTypeService.Get(value.IdentificationTypeId.Value);
            this.service.Create(employee);
        }

        // PUT  /employee/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDTO value)
        {
            var employee = this.service.Get(id);
            TryValidateModel(value);
            this.mapper.Map<EmployeeDTO, Employee>(value, employee);
            employee.EmployeeType = this.employeeTypeService.Get(value.EmployeeTypeId);
            employee.IdentificationType = this.identificationTypeService.Get(value.IdentificationTypeId.Value);
            this.service.Update(employee);                   
        }

        // DELETE /employee/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = this.service.Get(id);
            this.service.Delete(product);
        }
    }
}
