using FluentNHibernate.Mapping;
using Palestra.Model;

namespace Palestra.DAO
{
    public class InscricaoMap : ClassMap<InscricaoModel>
    {
        public InscricaoMap()
        {
            Id(x => x.ID).GeneratedBy.Increment();
            Map(x => x.Nome);
            Map(x => x.CPF);
            Map(x => x.DataNascimento);
            Map(x => x.ArquivoContrato).Length(int.MaxValue);
            Map(x => x.ArquivoContratoNome);
            Map(x => x.ArquivoCPF).Length(int.MaxValue);
            Map(x => x.ArquivoCPFNome);
            Map(x => x.ArquivoRG).Length(int.MaxValue);
            Map(x => x.ArquivoRGNome);
            Map(x => x.Motivo);
            Map(x => x.NumeroInscricao);
            Map(x => x.SituacaoInscricao);
            Table("Inscricao");
        }
    }
}
