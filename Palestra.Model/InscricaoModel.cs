using System;

namespace Palestra.Model
{
    public class InscricaoModel
    {
        public virtual long ID { get; set; } = long.MinValue;
        public virtual string Nome { get; set; } = string.Empty;
        public virtual string CPF { get; set; } = string.Empty;
        public virtual DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public virtual byte[] ArquivoRG { get; set; }
        public virtual string ArquivoRGNome { get; set; } = string.Empty;
        public virtual byte[] ArquivoCPF { get; set; }
        public virtual string ArquivoCPFNome { get; set; } = string.Empty;
        public virtual byte[] ArquivoContrato { get; set; }
        public virtual string ArquivoContratoNome { get; set; } = string.Empty;
        public virtual string NumeroInscricao { get; set; } = string.Empty;
        public virtual int SituacaoInscricao { get; set; } = 0;
        public virtual string Motivo { get; set; } = string.Empty;
    }
}
