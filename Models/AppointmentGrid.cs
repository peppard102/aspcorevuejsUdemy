using Dapper.Contrib.Extensions;
using System;

namespace Vue2Spa.Models
{
    public class AppointmentGrid : Appointment
    {
        public string VetName { get; set; }

        public string PetName { get; set; }
    }
}
