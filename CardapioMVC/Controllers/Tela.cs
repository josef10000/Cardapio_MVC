using Microsoft.AspNetCore.Mvc;

namespace CardapioMVC.Controllers
{
    public class Tela : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
