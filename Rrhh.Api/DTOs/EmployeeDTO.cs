namespace Rrhh.Api.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int EmployeeTypeId { get; set; }

        public string EmployeeTypeDesc { get; set; }
    }
}
