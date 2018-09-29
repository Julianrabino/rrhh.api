using Rrhh.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rrhh.Model.Entities
{
    [Table("employee")]
    public class Employee: IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //[ForeignKey("EmployeeTypeId")]
        public virtual EmployeeType EmployeeType { get; set; }
    }
}
