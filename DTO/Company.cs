using System.Collections.Generic;
using Dapper;

namespace Model
{
    [Table("tblCompany")]
    public class Company : BaseModel
    {
        public Company()
        {
            Employees = new List<Employee>();
        }

        public string Name { get; set; }

        [NotMapped]

        public List<Employee> Employees { get; set; }
    }
}
