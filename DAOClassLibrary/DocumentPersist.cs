using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ModelClassLibrary;

namespace DAOClassLibrary
{
    public class DocumentPersist
    {
        public void SalvarDocumento(Documento documento)
        {
            using (WikiDbContext con = new WikiDbContext())
            {
                if (documento.CorpoDocumento != null)
                {
                    int i = documento.Id;
                    documento = null;
                    documento = con.GetDocumentos.Find(i);

                    con.GetDocumentos.Add(documento);
                    con.SaveChanges();
                }
                else
                {
                    con.GetDocumentos.Add(documento);
                    con.SaveChanges();
                }
            }
        }

        public Documento ConsultarPorId(int id)
        {
            using (WikiDbContext con = new WikiDbContext())
            {
                //var Consulta = con.GetDocumentos.Include(d => d.Datas).Include(l => l.ListImagensDocs).Include(f => f.DocumentoFilho).Where(b => b.Url.Contains("dotnet")).ToList();
                var Consulta = con.GetDocumentos.Single(d => d.Id == id);
                return Consulta;
            }
        }

        public List<Documento> ListarPorParamentro(string c)
        {
            using (WikiDbContext context = new WikiDbContext())
            {
                var Consulta = context.GetDocumentos.Include(d => d.Datas).Include(l => l.ListImagensDocs).Include(f => f.DocumentoFilho).Where(i => i.Titulo.Contains(c)).ToList();

                return Consulta;
            }
        }

        public List<Documento> ListarContatos()
        {
            using (var context = new WikiDbContext())
            {
                var Consulta = context.GetDocumentos.Include(d => d.Datas).Include(l => l.ListImagensDocs).Include(f => f.DocumentoFilho).ToList();

                return Consulta;
            }
        }

        public void Modificar(Documento doc)
        {
            using (var context = new WikiDbContext())
            {
                
            }
        }

        public void Excluir(int id)
        {
            using (var context = new WikiDbContext())
            {
                
            }
        }
    }
}
