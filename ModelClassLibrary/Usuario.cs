using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    /// <summary>
    /// Armazena dados de cadastro de usuário, como dados de 
    /// contato básico e informações de login e lista de documentos
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public virtual List<Documento> Documentos { get; set; }
    }
}
