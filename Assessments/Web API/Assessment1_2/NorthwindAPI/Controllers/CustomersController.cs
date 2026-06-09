using System.Linq;
using System.Web.Http;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    public class CustomersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        [Route("api/customers/bycountry")]
        public IHttpActionResult GetCustomers(string country)
        {
            var result = db.GetCustomersByCountry(country).ToList();
            return Ok(result);
        }
    }
}