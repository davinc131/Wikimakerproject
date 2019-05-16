using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    /// <summary>
    /// Define o estado de aprovação de um documento temporário.
    /// Sob_Avaliação: Documento ativo disponível para edição pelo proprietário e redator.
    /// Aprovado: Irá substituir o documento Original e em seguida será removido do sistema.
    /// Rejeitado: Será excluído do sistema.
    /// </summary>
    public enum EstagioAprovacao
    {
        Aprovado,
        Rejeitado,
        Sob_Avaliação
    }
}
