using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Vue2Spa.Models;
using System;

namespace Vue2Spa.Data
{
    public class AppointmentManager
    {
        private readonly IConfiguration configuration;
        public AppointmentManager(IConfiguration config)
        {
            configuration = config;
        }

        public Appointment GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.Get<Appointment>(id);
            }
        }
        public List<Appointment> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.GetAll<Appointment>().ToList();
            }
        }

        public List<AppointmentLengthOptions> GetAllAppointmentLengthOptions()
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.GetAll<AppointmentLengthOptions>().ToList();
            }
        }

        public long AddAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
              return  connection.Insert(appointment);
            }
        }
        public void UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Update(appointment);
            }
        }
        public void DeleteAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Delete(appointment);
            }
        }

    }
}
