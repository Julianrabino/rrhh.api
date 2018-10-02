using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rrhh.Api.DTOs;
using Rrhh.AppService.Services;
using Rrhh.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Rrhh.Api.Controllers
{
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

        // GET /identificationtype
        [HttpGet]
        public ActionResult<IEnumerable<IdentificationTypeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<IdentificationTypeDTO>>(this.service.GetAll()).ToList();
        }

        // GET /identificationtype/{id}
        [HttpGet("{id}")]
        public ActionResult<IdentificationTypeDTO> Get(int id)
        {
            return this.mapper.Map<IdentificationTypeDTO>(this.service.Get(id));
        }

        // POST
        [HttpPost]
        public void Post([FromBody] IdentificationTypeDTO value)
        {
            TryValidateModel(value);
            this.service.Create(this.mapper.Map<IdentificationType>(value));
        }

        // PUT  /identificationtype/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IdentificationTypeDTO value)
        {
            var identificationType = this.service.Get(id);
            TryValidateModel(value);
            this.mapper.Map<IdentificationTypeDTO, IdentificationType>(value, identificationType);
            this.service.Update(identificationType);
        }

        // DELETE /identificationtype/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var identificationType = this.service.Get(id);
            this.service.Delete(identificationType);
        }
    }
}
