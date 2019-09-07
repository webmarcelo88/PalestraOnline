using NHibernate;
using Palestra.Model;
using System.Linq;

namespace Palestra.DAO
{
    public class InscricaoDAO : ApoioDAO<InscricaoModel>
    {
        public InscricaoModel ConsultarPeloNumeroInscricao(string numeroInscricao)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                var result = session.Query<InscricaoModel>()
                                .Where(p => p.NumeroInscricao == numeroInscricao);

                if (result != null)
                    return result.FirstOrDefault();

                return null;
            }
        }

        public InscricaoModel ConsultarPeloID(long id)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                var result = session.Query<InscricaoModel>()
                                .Where(p => p.ID == id);

                if (result != null)
                    return result.FirstOrDefault();

                return null;
            }
        }

        public void Aceitar(string numeroInscricao)
        {

        }

        public void NaoAceitar(string numeroInscricao)
        {

        }
    }
}
