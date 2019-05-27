using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ModelClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace DAOClassLibrary
{
    public class UserPersist
    {
        public void SalvarUsuario(Usuario Usuario)
        {
            using (WikiDbContext con = new WikiDbContext())
            {

                Usuario us = ConsultarPorNome(Usuario.NomeUsuario);

                if (us == null)
                {
                    con.GetUsuarios.Add(Usuario);
                    con.SaveChanges();
                }
                else
                {
                    us.Documentos = Usuario.Documentos;
                    con.GetUsuarios.Update(us);
                    con.SaveChanges();
                }
            }
        }

        public Usuario ConsultarPorId(int id)
        {
            using (WikiDbContext con = new WikiDbContext())
            {
                var Consulta = con.GetUsuarios.Include(d => d.Documentos).SingleOrDefault(d => d.Id == id);
                return Consulta;
            }
        }

        public Usuario ConsultarPorNome(string nome)
        {
            using (WikiDbContext con = new WikiDbContext())
            { 
                var Consulta = con.GetUsuarios.Include(d => d.Documentos).SingleOrDefault(d => d.NomeUsuario == nome);
                return Consulta;
            }
        }

        public List<Usuario> ListarPorParamentro(string c)
        {
            using (WikiDbContext context = new WikiDbContext())
            {
                var Consulta = context.GetUsuarios.Include(d => d.Documentos).Where(i => i.NomeUsuario.Contains(c)).ToList();

                return Consulta;
            }
        }

        public List<Usuario> ListarContatos()
        {
            using (var context = new WikiDbContext())
            {
                var Consulta = context.GetUsuarios.Include(d => d.Documentos).ToList();

                return Consulta;
            }
        }

        public void Modificar(Usuario doc)
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
