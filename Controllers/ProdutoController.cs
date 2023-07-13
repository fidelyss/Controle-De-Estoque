using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Produto.Controllers;
public class ProdutoController : Controller
{
    private readonly EstoqueWeb _context;
    public ProdutoController(EstoqueWeb context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Produtos.OrderBy(x => x.Nome).Include(x => x.Categoria).AsNoTracking().ToListAsync());
    }
    [HttpGet]
    public async Task<IActionResult> Cadastrar(int? id)
    {
        var categoria = _context.Categorias.OrderBy(x => x.Nome).AsNoTracking().ToList();
        var selectItems = new SelectList(categoria, nameof(CategoriaModel.IdCategoria), nameof(CategoriaModel.Nome));
        ViewBag.Categoria = selectItems;
        if (id.HasValue)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        return View(new ProdutoModel());
    }
    private bool ProdutoExiste(int id)
    {
        return _context.Produtos.Any(x => x.IdProduto == id);
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(int? id, [FromForm] ProdutoModel produto)
    {

        if (ModelState.IsValid)
        {
            if (id.HasValue)
            {
                if (ProdutoExiste(id.Value))
                {
                    _context.Produtos.Update(produto);
                    TempData["mensagem"] = MensagemModel.Serializar("Produto alterado com sucesso.");
                }
                else { return NotFound(); }
            }
            else
            {
                _context.Produtos.Add(produto);
                TempData["mensagem"] = MensagemModel.Serializar("Produto cadastrado com sucesso.");
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
            var produto = await _context.Produtos.FindAsync(id);
            return View(produto);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Excluir(ProdutoModel dado)
    {
        _context.Produtos.Remove(dado);
        await _context.SaveChangesAsync();
        TempData["mensagem"] = MensagemModel.Serializar("Produto Excluido com sucesso.");

        return RedirectToAction("Index");
    }
}