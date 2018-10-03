using System.ComponentModel.DataAnnotations;

namespace Rrhh.Api.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public int? EmployeeTypeId { get; set; }

        public string EmployeeTypeDesc { get; set; }

        [Required]
        public int? IdentificationTypeId { get; set; }

        public string IdentificationTypeDesc { get; set; }

        [Required]
        public int? IdentificationNumber { get; set; }
    }
}
