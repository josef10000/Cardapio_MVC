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

        public IActionResult Cadastrar()
        {



            return View();
        }

       
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProdutoModel produto = _db.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProdutoModel produto = _db.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            // Aqui você pode adicionar a lógica para excluir o produto do banco de dados
            // Exemplo:
            _db.Produtos.Remove(produto);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Cadastrar(ProdutoModel produto)
        {

            if (ModelState.IsValid)
            {

                _db.Produtos.Add(produto);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            if (ModelState.IsValid) 
            {
                  _db.Produtos.Update(produto);
                  _db.SaveChanges();    
                   return RedirectToAction("Index");
            
            
            
            }


            return View(produto);

        }






    }
}
