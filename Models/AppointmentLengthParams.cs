using Dapper.Contrib.Extensions;
using System;

namespace Vue2Spa.Models
{
    public class AppointmentLengthParams
    {
        public int VetId { get; set; }
        public DateTime Date { get; set; }
        public int lengthOfAppt { get; set; }
    }
}
