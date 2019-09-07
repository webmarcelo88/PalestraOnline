using Palestra.DAO;
using Palestra.Model;
using Palestra.Model.Enum;
using System.Collections.Generic;

namespace Palestra.Business
{
    public class Inscricao
    {

        /// <summary>
        /// Método responsável por efetuar a inscrição do solicitante
        /// </summary>
        /// <param name="modelo">Entidade com os dados da inscrição</param>
        /// <returns>ID da inscrição gerada</returns>
        public long EnviarInscricao(InscricaoModel modelo)
        {
            modelo.SituacaoInscricao = (int)TipoSituacaoInscricao.Pendente; // status inicial

            var dao = new InscricaoDAO();
            long idInscricao = dao.Incluir(modelo);

            // Atualiza o numero de inscricao com o ID
            modelo.NumeroInscricao = idInscricao.ToString();
            dao.Alterar(modelo, idInscricao);

            return idInscricao; // Utilizado o ID como numero de inscrição
        }

        /// <summary>
        /// Método responsável por consultar a inscrição pelo número
        /// </summary>
        /// <param name="numeroInscricao">Número da inscrição</param>
        /// <returns>Entidade com os dados da inscrição</returns>
        public InscricaoModel ConsultarInscricao(string numeroInscricao)
        {
            var dao = new InscricaoDAO();
            return dao.ConsultarPeloNumeroInscricao(numeroInscricao);
        }

        /// <summary>
        /// Método responsável por buscar todas as inscrições
        /// </summary>
        /// <returns>Lista de inscrições</returns>
        public List<InscricaoModel> BuscarInscricoes()
        {
            var dao = new InscricaoDAO();
            return dao.Consultar();
        }

        /// <summary>
        /// Método responsável por buscar a inscrição pelo ID
        /// </summary>
        /// <param name="id">ID da inscrição</param>
        /// <returns>Entidade com os dados da inscrição</returns>
        public InscricaoModel BuscarInscricaoPeloID(long id)
        {
            var dao = new InscricaoDAO();
            return dao.ConsultarPeloID(id);
        }

        /// <summary>
        /// Método responsável por atualizar a inscrição
        /// </summary>
        /// <param name="id">ID da inscrição a ser atualizada</param>
        /// <param name="modelo">Entidade com os dados da inscrição</param>
        public void AtualizarInscricao(long id, InscricaoModel modelo)
        {
            var dao = new InscricaoDAO();
            dao.Alterar(modelo, id);
        }
    }
}
