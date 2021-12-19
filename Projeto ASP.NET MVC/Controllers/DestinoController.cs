using CRUDMVC.Models;
using CRUDMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace CRUDMVC.Controllers
{
    public class DestinoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var dbcontext = new Contexto();

            ViewData["destinos"] = dbcontext.Destinos.Where(p => p.Id > 0).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Destino destino)
        {
            var dbcontext = new Contexto();
            dbcontext.Add(destino);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deletar(Destino destino)
        {
            var dbcontext = new Contexto();

            var destinoDelete = dbcontext.Destinos.Find(destino.Id);
            dbcontext.Remove(destinoDelete);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Atualizar(Destino novosDadosDestino)
        {
            var dbcontext = new Contexto();

            var antigosDadosDestino = dbcontext.Destinos.Find(novosDadosDestino.Id);

            antigosDadosDestino.Titulo = novosDadosDestino.Titulo;
            antigosDadosDestino.Descricao = novosDadosDestino.Descricao;
            antigosDadosDestino.Preco = novosDadosDestino.Preco;
            antigosDadosDestino.Promo = novosDadosDestino.Promo;
            antigosDadosDestino.Tipo = novosDadosDestino.Tipo;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}