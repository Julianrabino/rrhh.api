using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rrhh.Api.DTOs;
using Rrhh.AppService.Services;
using Rrhh.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Rrhh.Api.Controllers
{
    [Produces("application/json")]
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

        /// <summary>
        /// Permite recuperar todas entidades
        /// </summary>
        /// <returns>Una colección de entidades</returns>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<EmployeeDTO>>(this.service.GetAll()).ToList();
        }

        /// <summary>
        /// Permite recuperar una entidad mediante un identificador
        /// </summary>
        /// <param name="id">Identificador de la entidad a recuperar</param>
        /// <returns>Una entidad</returns>
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> Get(int id)
        {
            return this.mapper.Map<EmployeeDTO>(this.service.Get(id));
        }

        /// <summary>
        /// Permite crear una nueva entidad
        /// </summary>
        /// <param name="value">Una entidad</param>
        [HttpPost]
        public void Post([FromBody] EmployeeDTO value)
        {
            TryValidateModel(value);
            var employee = this.mapper.Map<Employee>(value);
            employee.EmployeeType = this.employeeTypeService.Get(value.EmployeeTypeId.Value);
            employee.IdentificationType = this.identificationTypeService.Get(value.IdentificationTypeId.Value);
            this.service.Create(employee);
        }

        /// <summary>
        /// Permite editar una entidad
        /// </summary>
        /// <param name="id">Identificador de la entidad a editar</param>
        /// <param name="value">Una entidad con los nuevos datos</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDTO value)
        {
            var employee = this.service.Get(id);
            TryValidateModel(value);
            this.mapper.Map<EmployeeDTO, Employee>(value, employee);
            employee.EmployeeType = this.employeeTypeService.Get(value.EmployeeTypeId.Value);
            employee.IdentificationType = this.identificationTypeService.Get(value.IdentificationTypeId.Value);
            this.service.Update(employee);                   
        }

        /// <summary>
        /// Permite borrar una entidad
        /// </summary>
        /// <param name="id">Identificador de la entidad a borrar</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = this.service.Get(id);
            this.service.Delete(product);
        }

        /// <summary>
        /// Permite saber si existe un empleado mediante tipo y número de identificación
        /// </summary>
        /// <param name="identificationTypeId">Identificador del tipo de identificación</param>
        /// <param name="identificationNumber">Número de identificación</param>
        /// <returns></returns>
        [HttpGet("existe/{identificationTypeId}/{identificationNumber}")]
        public ActionResult<bool> Existe(int identificationTypeId, int identificationNumber)
        {
            return this.service.Existe(identificationTypeId, identificationNumber);
        }
    }
}
