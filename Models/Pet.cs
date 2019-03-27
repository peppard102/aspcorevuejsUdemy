using Dapper.Contrib.Extensions;

namespace Vue2Spa.Models
{
    [Table("Pet")] // Tell Dapper which table to use
    public class Pet
    {
        [Key] // Tell Dapper that this is the primary key in the DB table
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
