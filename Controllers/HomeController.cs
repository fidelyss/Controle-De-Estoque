using Microsoft.AspNetCore.Mvc;
using Estoque.Models;

namespace ControleDeEstoque.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            TempData.Remove("mensagem");
            return View();
        }
    }
}