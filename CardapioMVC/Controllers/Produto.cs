using CardapioMVC.Data;
using CardapioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardapioMVC.Controllers
{

    public class Produto : Controller
    {

        readonly private ApplicationDBContenx _db;



        public Produto(ApplicationDBContenx db)
        {
            _db = db;
        }




        public IActionResult Index()
        {

            IEnumerable<ProdutoModel> produtos = _db.Produtos;

            return View(produtos);
        }
    }
}
