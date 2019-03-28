using Dapper.Contrib.Extensions;

namespace Vue2Spa.Models
{
    [Table("Appointment")] // Tell Dapper which table to use
    public class Appointment
    {
        [Key] // Tell Dapper that this is the primary key in the DB table
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
