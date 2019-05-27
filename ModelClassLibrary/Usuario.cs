using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary
{
    /// <summary>
    /// Armazena dados de cadastro de usuário, como dados de 
    /// contato básico e informações de login e lista de documentos
    /// </summary>
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column(Order = 1, TypeName = "serial")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public virtual List<Documento> Documentos { get; set; }

        public Usuario()
        {
            Documentos = new List<Documento>();
        }
    }
}
