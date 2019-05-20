using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary;
using System.Threading;
using ModelClassLibrary;
using DAOClassLibrary;

namespace WikiMaker_WebApp.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Editor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GravarDocumento(Documento doc)
        {
            try
            {
                if (String.IsNullOrEmpty(doc.Titulo))
                {
                    TempData["DocumentoVazio"] = "Atribua um título para o documento";
                }
                else if (String.IsNullOrEmpty(doc.CorpoDocumento))
                {
                    TempData["DocumentoVazio"] = "Atribua um conteúdo para o documento";
                }
                else
                {
                    TempData["Sucesso"] = "Documento salvo com sucesso!!!";

                    DateTime localDate = DateTime.Now;
                    Documento d = new Documento();
                    d.Titulo = doc.Titulo;
                    d.CorpoDocumento = doc.CorpoDocumento;
                    d.Datas.Add(new DataDocumento { GetDate = localDate });

                    DocumentPersist p = new DocumentPersist();
                    p.SalvarDocumento(d);

                    Thread.Sleep(5000);
                }

                return RedirectToAction("Editor", "Home");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Editor", "Home");
            }

        }

    }
}