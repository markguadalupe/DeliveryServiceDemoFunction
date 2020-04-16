using Dapper;

namespace Model
{
    [Table("tblEmployee")]
    public class Employee : BaseModel
    {
        public long CompanyID { get; set; }
        public string Name { get; set; }

        [IgnoreSelect, IgnoreInsert, IgnoreUpdate]
        public Company Company { get; set; }

    }
}
