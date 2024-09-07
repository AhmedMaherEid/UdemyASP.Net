using e_CommerceOrdersApp.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace e_CommerceOrdersApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("<h1>Welcome to the Best e-Commerce site</h1>", "text/html");
        }

        [Route("order")]
        public IActionResult Order([FromForm] Order order)
        {
            if (order != null)
            {
                if (ModelState.IsValid)
                {
                    Response.StatusCode = 200;
                    int orerNumber = new Random().Next(1, 100000);
                    order.OrderNo = orerNumber;
                    return Json(new { orderNumber = order.OrderNo });
                }
                else return BadRequest(ModelState);
            }
            else
            {
                return Content("order data is not completed", "text/html");
            }
        }

    }
}
