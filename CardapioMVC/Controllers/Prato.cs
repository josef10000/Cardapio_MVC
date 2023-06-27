using CardapioMVC.Data;
using CardapioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioMVC.Controllers
{
    public class Prato : Controller
    {
        private readonly ApplicationDBContenx _db;

        public Prato(ApplicationDBContenx context)
        {
            _db = context;
        }

        // GET: Prato
        public async Task<IActionResult> Index()
        {
            var pratos = await _db.Pratos.ToListAsync();
            return View(pratos);
        }

        // GET: Prato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prato = await _db.Pratos.FirstOrDefaultAsync(p => p.Id == id);

            if (prato == null)
            {
                return NotFound();
            }

            return View(prato);
        }

        // GET: Prato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prato_Model prato)
        {
            if (ModelState.IsValid)
            {
                _db.Pratos.Add(prato);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(prato);
        }
    }
}
