using NHibernate;
using Palestra.Model;
using System.Linq;

namespace Palestra.DAO
{
    public class UsuarioDAO : ApoioDAO<UsuarioModel>
    {
        /// <summary>
        /// Método que busca o usuário pelo login e senha
        /// </summary>
        /// <param name="usuario">Login do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>ID do usuario</returns>
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
