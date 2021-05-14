using APIRESTFULL_paises.Context;
using APIRESTFULL_paises.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRESTFULL_paises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PaisController(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        
        // GET: api/<PaisController>
        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return context.Pais.ToList();
        }

        // GET api/<PaisController>/5
        [HttpGet("{id}")]
        public Pais Get(int id)
        {
            var pais = context.Pais.FirstOrDefault(p=>p.Id==id);
            return pais;
        }

        // POST api/<PaisController>
        [HttpPost]
        public ActionResult Post([FromBody] Pais pais)
        {
            try
            { 
                context.Pais.Add(pais);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<PaisController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pais pais)
        {
            if (pais.Id == id)
            {
                context.Entry(pais).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<PaisController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pais = context.Pais.FirstOrDefault(p => p.Id == id);
            if(pais != null)
            {
                context.Pais.Remove(pais);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
