using Rrhh.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rrhh.Model.Entities
{
    [Table("employeetype")]
    public class EmployeeType: IEntity
    {
        public int Id { get; set; }

        public string Initials { get; set; }

        public string Description { get; set; }
    }
}
