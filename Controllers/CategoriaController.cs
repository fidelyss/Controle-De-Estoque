using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estoque.Models;

namespace Categoria.Controllers;
public class CategoriaController : Controller
{
    private readonly EstoqueWeb _context;
    public CategoriaController(EstoqueWeb context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Categorias.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
    }
    [HttpGet]
    public async Task<IActionResult> Cadastrar(int? id)
    {
        if (id.HasValue)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        return View(new CategoriaModel());
    }
    private bool CategoriaExiste(int id)
    {
        return _context.Categorias.Any(x => x.IdCategoria == id);
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(int? id, [FromForm] CategoriaModel categoria)
    {
        if (ModelState.IsValid)
        {
            if (id.HasValue)
            {
                if (CategoriaExiste(id.Value))
                {
                    _context.Categorias.Update(categoria);
                    TempData["mensagem"] = MensagemModel.Serializar("Categoria alterada com sucesso.");
                }
                else { return NotFound(); }
            }
            else
            {
                _context.Categorias.Add(categoria);
                TempData["mensagem"] = MensagemModel.Serializar("Categoria cadastrada com sucesso.");
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Excluir(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }
        else
        {
            var categoria = await _context.Categorias.FindAsync(id);
            return View(categoria);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Excluir(CategoriaModel dado)
    {
        _context.Categorias.Remove(dado);
        await _context.SaveChangesAsync();
        TempData["mensagem"] = MensagemModel.Serializar("Categoria Excluida com sucesso.");

        return RedirectToAction("Index");
    }
}