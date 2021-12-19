using CRUDMVC.Models;
using CRUDMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUDMVC.Controllers
{
    public class PacoteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var dbcontext = new Contexto();
            ViewData["pacotes"] = dbcontext.Pacotes.Where(p => p.Id > 0).ToList();
            return View();
        }
       
        [HttpPost]
        public IActionResult Index(Pacote pacote)
        {
            var dbcontext = new Contexto();
            dbcontext.Add(pacote);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public IActionResult Deletar(Pacote pacote)
        {
            var dbcontext = new Contexto();
            var pacoteDelete = dbcontext.Pacotes.Find(pacote.Id);
            dbcontext.Remove(pacoteDelete);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

     
        [HttpPost]
        public IActionResult Atualizar(Pacote novosDadosPacote)
        {
            var dbcontext = new Contexto();
            var antigosDadosPacote = dbcontext.Pacotes.Find(novosDadosPacote.Id);
            antigosDadosPacote.Id_cliente = novosDadosPacote.Id_cliente;
            antigosDadosPacote.Id_destino = novosDadosPacote.Id_destino;
            antigosDadosPacote.DataCompra = novosDadosPacote.DataCompra;
            antigosDadosPacote.DataViagem = novosDadosPacote.DataViagem;
            antigosDadosPacote.Preco = novosDadosPacote.Preco;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
