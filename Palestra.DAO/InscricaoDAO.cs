using NHibernate;
using Palestra.Model;
using System.Linq;

namespace Palestra.DAO
{
    public class InscricaoDAO : ApoioDAO<InscricaoModel>
    {
        /// <summary>
        /// Método que busca a inscrição pelo número
        /// </summary>
        /// <param name="numeroInscricao">Número da inscrição</param>
        /// <returns>Entidade com os dados da inscrição</returns>
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

        /// <summary>
        /// Método que busca a inscrição pelo ID
        /// </summary>
        /// <param name="id">ID da inscrição</param>
        /// <returns>Entidade com os dados da inscrição</returns>
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

        /// <summary>
        /// Método que busca a inscrição pelo CPF
        /// </summary>
        /// <param name="cpf">CPF da inscrição</param>
        /// <returns>Entidade com os dados da inscrição</returns>
        public InscricaoModel ConsultarPeloCPF(string cpf)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                var result = session.Query<InscricaoModel>()
                                .Where(p => p.CPF == cpf);

                if (result != null)
                    return result.FirstOrDefault();

                return null;
            }
        }
    }
}
