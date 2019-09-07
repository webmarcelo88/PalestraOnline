using NHibernate;
using Palestra.Model;
using System.Linq;

namespace Palestra.DAO
{
    public class UsuarioDAO : ApoioDAO<UsuarioModel>
    {
        public long BuscarUsuario(string usuario, string senha)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                var result = session.Query<UsuarioModel>()
                                .Where(p => p.Login == usuario && p.Senha == senha)
                                .Select(p => p.ID);

                return result.FirstOrDefault();
            }
        }
    }
}
