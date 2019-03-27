using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vue2Spa.Data;
using Vue2Spa.Models;

namespace Vue2Spa.Controllers
{

    [Route("api/[controller]")]
    public class VetController : BaseController
    {
        private VetManager manager;
        public VetController(IConfiguration config) : base(config)
        {
            manager = new VetManager(configuration);
        }
        // GET: api/Vet
        [HttpGet]
        public List<Vet> GetAllVets()
        {
            return manager.GetAll();
        }

        // GET: api/Vet/5
        [HttpGet("{id}")]
        public Vet GetVet(int id)
        {
            return manager.GetById(id);
        }

        // POST: api/Vet
        [HttpPost]
        public Vet PostVet([FromBody]Vet value)
        {
            manager.AddVet(value);
            return value;
        }

        // PUT: api/Vet
        [HttpPut]
        public Vet PutVet([FromBody]Vet value)
        {
            manager.UpdateVet(value);
            return value;
        }

        // DELETE: api/Vet/5
        [HttpDelete("{id}")]
        public int DeleteVet(int id)
        {
            manager.DeleteVet(new Vet { Id = id});
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
