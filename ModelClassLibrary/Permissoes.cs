using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    /// <summary>
    /// Permissões de acesso ao documento.
    /// Proprietário cria novos documentos e edita diretamente o documento original
    /// Redator apenas edita documentos que são armazenados em DocTemporario
    /// </summary>
    public enum Permissoes
    {
        Proprietario,
        Redator
    }
}
