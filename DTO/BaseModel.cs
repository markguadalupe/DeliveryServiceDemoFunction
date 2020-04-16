using Dapper;

namespace Model
{
    public abstract class BaseModel
    {
        [Key]
        public long ID { get; set; }
    }
}
