using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Vue2Spa.Models;

namespace Vue2Spa.Data
{
    public class PetManager
    {
        private readonly IConfiguration configuration;
        public PetManager(IConfiguration config)
        {
            configuration = config;
        }

        public Pet GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.Get<Pet>(id);
            }
        }
        public List<Pet> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return connection.GetAll<Pet>().ToList();
            }
        }

        public long AddPet(Pet Pet)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
              return  connection.Insert(Pet);
            }
        }
        public void UpdatePet(Pet Pet)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Update(Pet);
            }
        }
        public void DeletePet(Pet Pet)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Delete(Pet);
            }
        }

    }
}
