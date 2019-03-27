using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vue2Spa.Data;
using Vue2Spa.Models;

namespace Vue2Spa.Controllers
{

    [Route("api/[controller]")]
    public class PetController : BaseController
    {
        private PetManager manager;
        public PetController(IConfiguration config) : base(config)
        {
            manager = new PetManager(configuration);
        }
        // GET: api/Pet
        [HttpGet]
        public List<Pet> GetAllPets()
        {
            return manager.GetAll();
        }

        // GET: api/Pet/5
        [HttpGet("{id}")]
        public Pet GetPet(int id)
        {
            return manager.GetById(id);
        }

        // POST: api/Pet
        [HttpPost]
        public Pet PostPet([FromBody]Pet value)
        {
            manager.AddPet(value);
            return value;
        }

        // PUT: api/Pet
        [HttpPut]
        public Pet PutPet([FromBody]Pet value)
        {
            manager.UpdatePet(value);
            return value;
        }

        // DELETE: api/Pet/5
        [HttpDelete("{id}")]
        public int DeletePet(int id)
        {
            manager.DeletePet(new Pet { Id = id});
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
