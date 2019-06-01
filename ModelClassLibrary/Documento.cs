using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary
{
    /// <summary>
    /// Representa um documento de texto formatado com titulo, texto e imagens.
    /// Dentro de um documento existem uma lista de datas, lista de imagens
    /// e uma lista de documentos filhos.
    /// </summary>
    public class Documento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column(Order = 1, TypeName = "serial")]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string CorpoDocumento { get; set; }
        public bool Temporario { get; set; }
        public List<DataDocumento> Datas{ get; set; }
        public virtual List<ImagensDoc> ListImagensDocs { get; set; }
        public virtual List<Documento> DocumentoFilho { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Documento()
        {
            Titulo = "";
            CorpoDocumento = "";
            Datas = new List<DataDocumento>();
            ListImagensDocs = new List<ImagensDoc>();
            DocumentoFilho = new List<Documento>();
            Usuario = new Usuario();
            Temporario = false;
        }

        public override string ToString()
        {
            return Titulo;
        }
    }
}
