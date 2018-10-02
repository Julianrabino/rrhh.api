using System.ComponentModel.DataAnnotations;

namespace Rrhh.Api.DTOs
{
    public class IdentificationTypeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Initials { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
