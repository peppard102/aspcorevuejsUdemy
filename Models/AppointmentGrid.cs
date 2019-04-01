using Dapper.Contrib.Extensions;
using System;

namespace Vue2Spa.Models
{
    public class AppointmentGrid : Appointment
    {
        public string VetFirstName { get; set; }

        public string VetLastName { get; set; }

        public string PetName { get; set; }
    }
}
