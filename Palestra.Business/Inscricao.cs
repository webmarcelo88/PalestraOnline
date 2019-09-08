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

            if (!CPFValido(modelo.CPF))
                throw new BusinessException("CPF inválido!");

            var dao = new InscricaoDAO();

            var modelInscricaoAtual = dao.ConsultarPeloCPF(modelo.CPF);
            if (modelInscricaoAtual != null)
                throw new BusinessException("Inscrição já realizada para este CPF!");

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

        /// <summary>
        /// Método responsável por validar o CPF
        /// </summary>
        /// <param name="cpf">CPF</param>
        /// <returns>Retorna true se o CPF é valido</returns>
        public static bool CPFValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
