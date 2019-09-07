using System.ComponentModel;

namespace Palestra.Model.Enum
{
    public enum TipoSituacaoInscricao
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Aceita")]
        Aceita,
        [Description("Não Aceita")]
        NaoAceita
    }
}