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

        /// <summary>
        /// Permite recuperar todas las instancias
        /// </summary>
        /// <returns>Una colección de instancias</returns>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeTypeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<EmployeeTypeDTO>>(this.service.GetAll()).ToList();
        }

        /// <summary>
        /// Permite recuperar una instancia mediante un identificador
        /// </summary>
        /// <param name="id">Identificador de la instancia a recuperar</param>
        /// <returns>Una instancia</returns>
        [HttpGet("{id}")]
        public ActionResult<EmployeeTypeDTO> Get(int id)
        {
            return this.mapper.Map<EmployeeTypeDTO>(this.service.Get(id));
        }

        /// <summary>
        /// Permite crear una nueva instancia
        /// </summary>
        /// <param name="value">Una instancia</param>
        [HttpPost]
        public void Post([FromBody] EmployeeTypeDTO value)
        {
            TryValidateModel(value);
            this.service.Create(this.mapper.Map<EmployeeType>(value));
        }

        /// <summary>
        /// Permite editar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a editar</param>
        /// <param name="value">Una instancia con los nuevos datos</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeTypeDTO value)
        {
            var employeeType = this.service.Get(id);
            TryValidateModel(value);
            this.mapper.Map<EmployeeTypeDTO, EmployeeType>(value, employeeType);
            this.service.Update(employeeType);
        }

        /// <summary>
        /// Permite borrar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a borrar</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeType = this.service.Get(id);
            this.service.Delete(employeeType);
        }
    }
}
