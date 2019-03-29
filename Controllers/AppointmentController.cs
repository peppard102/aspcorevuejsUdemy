using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vue2Spa.Data;
using Vue2Spa.Models;
using System;

namespace Vue2Spa.Controllers
{

    [Route("api/[controller]")]
    public class AppointmentController : BaseController
    {
        private AppointmentManager manager;
        public AppointmentController(IConfiguration config) : base(config)
        {
            manager = new AppointmentManager(configuration);
        }
        // GET: api/Appointment
        [HttpGet]
        public List<Appointment> GetAllAppointments()
        {
            return manager.GetAll();
        }

        [HttpGet]
        [Route("lengthOptions")]
        public List<AppointmentLengthOptions> GetAllAppointmentLengthOptions()
        {
            return manager.GetAllAppointmentLengthOptions();
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public Appointment GetAppointment(int id)
        {
            return manager.GetById(id);
        }
        
        // GET: api/Appointment/5
        [HttpPost]
        [Route("timeOptions")]
        public List<TimeSpan> GetAppointmentTimeOptions([FromBody]AppointmentLengthParams apptLengthParams)
        {
            return manager.GetAppointmentTimeOptions(apptLengthParams);
        }

        // POST: api/Appointment
        [HttpPost]
        public Appointment PostAppointment([FromBody]Appointment value)
        {
            value.StartTime = value.StartTime.ToLocalTime();
            value.EndTime = value.EndTime.ToLocalTime();
            manager.AddAppointment(value);
            return value;
        }

        // PUT: api/Appointment
        [HttpPut]
        public Appointment PutAppointment([FromBody]Appointment value)
        {
            manager.UpdateAppointment(value);
            return value;
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public int DeleteAppointment(int id)
        {
            manager.DeleteAppointment(new Appointment { Id = id});
            return id;
        }

        // DELETE: api/Items/5
        //[HttpDelete]
        //public int DeleteItems([FromBody]List<Items> values)
        //{
        //    manager.DeleteItem(new Items { Id = id });
        //    return id;
        //}
    }
}
