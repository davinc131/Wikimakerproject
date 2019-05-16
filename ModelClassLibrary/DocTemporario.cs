using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    /// <summary>
    /// É um documento temporário, gerado por um usuária com permissões de redator.
    /// A partir do momento em que um documento temporário é criado, tanto o redator quanto
    /// o proprietário, irão fazer edições apenas no temporário exeto que o proprietário desaprove ou aprove
    /// o documento.
    /// O IdDocOrigem é a referência para o documento ao qual ele se originou e em caso de aprovação, este parâmetro
    /// será usado para fazer a substituição do documento original.
    /// </summary>
    public class DocTemporario:Documento
    {
        public EstagioAprovacao Aprovado { get; set; }
        public int IdDocOrigem { get; set; }
    }
}
