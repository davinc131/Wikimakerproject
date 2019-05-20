using System;
using System.Collections.Generic;
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
        }
    }
}
