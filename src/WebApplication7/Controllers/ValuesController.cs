using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Data;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // db ref
        private ApplicationDbContext _db;
        public ValuesController(ApplicationDbContext db)
        {
            this._db = db;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Donkey> Get()
        {
            Donkey[] seed = { 
                    new Donkey {
                        name = "Danny",
                        Id = 1,
                        color = "green"
                    },
                       new Donkey {
                        name = "Brock",
                        Id = 2,
                        color = "blue"
                    }
             };
            //return seed;
            return _db.Donkeys.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var donkey = _db.Donkeys.FirstOrDefault(m => m.Id == id);
            if (donkey == null)
            {
                return NotFound();
            }
            return Ok(donkey);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Donkey donkey)
        {
             if (!_db.Donkeys.Any())
             {
                 Donkey[] seed = {
                     new Donkey {
                         name = "Danny",
                         color = "green"
                     },
                        new Donkey {
                         name = "Brock",
                         color = "blue"
                     }

                 };
                for (var i = 0; i < seed.Length; i++)
                 {
                     _db.Donkeys.Add(seed[i]);
                 }
                 _db.SaveChanges();
              }
            //do stuff with donkey
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            //  if (donkey.Id == 0)
            // {
            // add movie
            //   Donkey dinkey = donkey;
            _db.Donkeys.Add(donkey);
         //       _db.SaveChanges();
         //   }
         //   else
         //   {
                // update movie
             //   var original = _db.Donkeys.FirstOrDefault(m => m.Id == donkey.Id);
           //     original.name = donkey.name;
           //     original.color = donkey.color;
                _db.SaveChanges();
          //  }
            return Ok(donkey);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Donkey donkey)
        {
            var _donkey = _db.Donkeys.FirstOrDefault(d => d.Id == id);
            if(_donkey == null)
            {
                return NotFound();
            }
            _donkey.color = donkey.color;
            _donkey.name = donkey.name;
            _db.Donkeys.Update(_donkey);
            _db.SaveChanges();
            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //delete a donkey
            var donkey = _db.Donkeys.FirstOrDefault(m => m.Id == id);
            if (donkey == null)
            {
                return NotFound();
            }
            _db.Donkeys.Remove(donkey);
            _db.SaveChanges();
            return Ok();

        }
    }
}
