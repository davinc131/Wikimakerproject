using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class DataDocumento
    {
        public int Id { get; set; }
        public DateTime GetDate { get; set; }
        public virtual Documento Documento { get; set; }
    }
}
