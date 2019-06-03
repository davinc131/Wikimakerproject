using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WikiMaker_WebApp.Models;
using ModelClassLibrary;
using Newtonsoft.Json;

namespace WikiMaker_WebApp.Controllers
{
    public class HomeController : Controller
    {

        private List<Documento> documentos = new List<Documento>();

        public IActionResult Index()
        {
            CarregarLista();

            List<JsTreeDocument> nodes = new List<JsTreeDocument>();

            for(int i = 0; i < documentos.Count; i++)
            {
                nodes.Add(new JsTreeDocument { id = documentos[i].Id.ToString(), parent = "#", text = documentos[i].Titulo });

                for(int j = 0; j < documentos[i].DocumentoFilho.Count; j++)
                {
                    nodes.Add(new JsTreeDocument { id = documentos[i].Id.ToString() + "-" + documentos[i].DocumentoFilho[j].Id.ToString(), parent = documentos[i].Id.ToString(), text = documentos[i].DocumentoFilho[j].Titulo });
                }
            }

            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }
        [HttpPost]
        public ActionResult Index(string selectedItens)
        {
            List<Documento> items = JsonConvert.DeserializeObject<List<Documento>>(selectedItens);
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Editor()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CarregarLista()
        {
            try
            {
                for(int i = 0; i < 5; i++)
                {
                    Documento d = new Documento();
                    d.Id = i;
                    d.Titulo = "Documento" + i;
                    d.CorpoDocumento = "Um texto qualquer";

                    documentos.Add(d);
                }

                for (int i = 0; i < documentos.Count; i++)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        Documento d = new Documento();
                        d.Id = j;
                        d.Titulo = "Documento Filho" + j;
                        d.CorpoDocumento = "Um texto qualquer";

                        documentos[i].DocumentoFilho.Add(d);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
