using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Vue2Spa.Models;

namespace Vue2Spa.Data
{
    public class VetManager
    {
        private readonly IConfiguration configuration;
        public VetManager(IConfiguration config)
        {
            configuration = config;
        }

        public Vet GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.Get<Vet>(id);
            }
        }
        public List<Vet> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.GetAll<Vet>().ToList();
            }
        }

        public long AddVet(Vet vet)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
              return  connection.Insert(vet);
            }
        }
        public void UpdateVet(Vet vet)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Update(vet);
            }
        }
        public void DeleteVet(Vet vet)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Delete(vet);
            }
        }

    }
}
