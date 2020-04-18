using Dapper;
using System;

namespace Model
{
    public abstract class BaseModel
    {
        [Key]
        public long ID { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
