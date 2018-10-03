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
        /// Permite recuperar todas entidades
        /// </summary>
        /// <returns>Una colección de entidades</returns>
        [HttpGet]
        public ActionResult<IEnumerable<IdentificationTypeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<IdentificationTypeDTO>>(this.service.GetAll()).ToList();
        }

        /// <summary>
        /// Permite recuperar una entidad mediante un identificador
        /// </summary>
        /// <param name="id">Identificador de la entidad a recuperar</param>
        /// <returns>Una entidad</returns>
        [HttpGet("{id}")]
        public ActionResult<IdentificationTypeDTO> Get(int id)
        {
            return this.mapper.Map<IdentificationTypeDTO>(this.service.Get(id));
        }

        /// <summary>
        /// Permite crear una nueva entidad
        /// </summary>
        /// <param name="value">Una entidad</param>
        [HttpPost]
        public void Post([FromBody] IdentificationTypeDTO value)
        {
            TryValidateModel(value);
            this.service.Create(this.mapper.Map<IdentificationType>(value));
        }

        /// <summary>
        /// Permite editar una entidad
        /// </summary>
        /// <param name="id">Identificador de la entidad a editar</param>
        /// <param name="value">Una entidad con los nuevos datos</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IdentificationTypeDTO value)
        {
            var identificationType = this.service.Get(id);
            TryValidateModel(value);
            this.mapper.Map<IdentificationTypeDTO, IdentificationType>(value, identificationType);
            this.service.Update(identificationType);
        }

        /// <summary>
        /// Permite borrar una entidad
        /// </summary>
        /// <param name="id">Identificador de la entidad a borrar</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var identificationType = this.service.Get(id);
            this.service.Delete(identificationType);
        }
    }
}
