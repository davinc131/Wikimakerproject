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
                    UserPersist persist = new UserPersist();

                    Usuario us = persist.ConsultarPorNome("davinc131");

                    if (us == null)
                    {
                        Usuario u = new Usuario { Nome = "Leonardo", Email = "davinc131@hotmail.com", NomeUsuario = "davinc131", Senha = "" };
                        persist.SalvarUsuario(u);
                        us = persist.ConsultarPorNome(us.NomeUsuario);
                    }

                    DateTime localDate = DateTime.Now;

                    doc.Datas.Add(new DataDocumento { GetDate = localDate });
                    doc.Temporario = false;
                    doc.Usuario = us;

                    DocumentPersist p = new DocumentPersist();
                    p.SalvarDocumento(doc);

                    Thread.Sleep(5000);
                    TempData["Sucesso"] = "Documento salvo com sucesso!!!";
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