using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace BankApp.Controllers
{
    [Controller]
    public class BankController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            this.Response.StatusCode = 200;
            return Content("<h1>Welcome to the Best Bank</h1>", "text/html");
        }


        [Route("account-details")]
        public IActionResult Detailes()
        {
            this.Response.StatusCode = 200;
            return Json(new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 });
        }

        [Route("account-statement")]
        public IActionResult AcountStatment()
        {
            this.Response.StatusCode = 200;
            return Content("[Dummy PDF File]");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int? accountNumber)
        {
            if (accountNumber == null)
            {
                Response.StatusCode = 400;
                return Content("Account Number should be supplied");
            }
            else if(accountNumber == 1001)
            {
                this.Response.StatusCode = 200;
                return Content("5000");
            }
            else
            {
                this.Response.StatusCode = 404;
                return Content("Account Number should be 1001");
            }
        }
    }
}
