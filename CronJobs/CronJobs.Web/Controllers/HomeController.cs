using Microsoft.AspNetCore.Mvc;

namespace CronJobs.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
