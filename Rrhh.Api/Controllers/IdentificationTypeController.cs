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
    [Route("api/identificationtype")]
    [ApiController]
    public class IdentificationTypeController : ControllerBase
    {
        private readonly IdentificationTypeService service;
        private readonly IMapper mapper;
        
        public IdentificationTypeController(IdentificationTypeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Permite recuperar todas las instancias
        /// </summary>
        /// <returns>Una colección de instancias</returns>
        [HttpGet]
        public ActionResult<IEnumerable<IdentificationTypeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<IdentificationTypeDTO>>(this.service.GetAll()).ToList();
        }

        /// <summary>
        /// Permite recuperar una instancia mediante un identificador
        /// </summary>
        /// <param name="id">Identificador de la instancia a recuperar</param>
        /// <returns>Una instancia</returns>
        [HttpGet("{id}")]
        public ActionResult<IdentificationTypeDTO> Get(int id)
        {
            return this.mapper.Map<IdentificationTypeDTO>(this.service.Get(id));
        }

        /// <summary>
        /// Permite crear una nueva instancia
        /// </summary>
        /// <param name="value">Una instancia</param>
        [HttpPost]
        public void Post([FromBody] IdentificationTypeDTO value)
        {
            TryValidateModel(value);
            this.service.Create(this.mapper.Map<IdentificationType>(value));
        }

        /// <summary>
        /// Permite editar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a editar</param>
        /// <param name="value">Una instancia con los nuevos datos</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IdentificationTypeDTO value)
        {
            var identificationType = this.service.Get(id);
            TryValidateModel(value);
            this.mapper.Map<IdentificationTypeDTO, IdentificationType>(value, identificationType);
            this.service.Update(identificationType);
        }

        /// <summary>
        /// Permite borrar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a borrar</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var identificationType = this.service.Get(id);
            this.service.Delete(identificationType);
        }
    }
}
