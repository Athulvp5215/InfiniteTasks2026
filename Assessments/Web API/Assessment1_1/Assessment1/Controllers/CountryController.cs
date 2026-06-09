using Assessment1.Models;   
using CountryAPI.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace CountryAPI.Controllers
{
    public class CountryController : ApiController
    {
        private AppDbContext db = new AppDbContext();

      
        public IHttpActionResult GetCountries()
        {
            return Ok(db.Countries.ToList());
        }

        
        public IHttpActionResult GetCountry(int id)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

       
        public IHttpActionResult PostCountry([FromBody] Country country)
        {
          
            if (country == null)
                return BadRequest("Country data is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Countries.Add(country);
            db.SaveChanges();

            return Ok(country);
        }

      
        public IHttpActionResult PutCountry(int id, [FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Country data is required");

            if (id != country.ID)
                return BadRequest("ID mismatch");

            db.Entry(country).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            db.Countries.Remove(country);
            db.SaveChanges();

            return Ok(country);
        }
    }
}
