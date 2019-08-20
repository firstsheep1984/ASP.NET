using System.Collections.Generic;

namespace AdmissionsOnlineSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Program> Programs { get; set; }
    }
}