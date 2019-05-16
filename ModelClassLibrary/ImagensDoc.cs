using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    /// <summary>
    /// Representa uma imagem com Nome e estensão, caminho da imagem a representação da imagem
    /// como um Array de bytes e a referencia para o documento ao qual a imagem pertence.
    /// </summary>
    public class ImagensDoc
    {
        public int Id { get; set; }
        public string NomeImagem { get; set; }
        public string CaminhoImagem { get; set; }
        public byte[] ArrayByte { get; set; }
        public virtual Documento Documento { get; set; }
    }
}
