using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClassLibrary
{
    public class DataDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        ////[Column(Order = 1, TypeName = "serial")
        public int Id { get; set; }
        public DateTime GetDate { get; set; }
        public virtual Documento Documento { get; set; }
    }
}
