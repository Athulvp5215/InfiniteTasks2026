using System.Linq;
using System.Web.Http;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    public class OrdersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        [Route("api/orders/employee5")]
        public IHttpActionResult GetOrdersByEmployee()
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == 5)
                           .ToList();

            return Ok(orders);
        }
    }
}
