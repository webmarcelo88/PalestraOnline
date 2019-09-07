using FluentNHibernate.Mapping;
using Palestra.Model;

namespace Palestra.DAO
{
    public class UsuarioMap : ClassMap<UsuarioModel>
    {
        public UsuarioMap()
        {
            Id(x => x.ID);
            Map(x => x.Login);
            Map(x => x.Senha);
            Table("Usuario");
        }
    }
}
