using Palestra.DAO;

namespace Palestra.Business
{
    public class Usuario 
    {
        /// <summary>
        /// Método responsável por buscar o usuário através de login e senha
        /// </summary>
        /// <param name="usuario">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>ID do usuário</returns>
        public long BuscarUsuario(string usuario, string senha)
        {
            return new UsuarioDAO().BuscarUsuario(usuario, senha);
        }

        /*
         * Os métodos abaixo não foram utilizados
         * Considerando que o usuario padrão (administrador) já venha carregado na base, e não tenha um cadastro de usuários
         * Mas caso tivesse o cadastro de usuários, poderiam ser utilizados para não armazenar a senha plana no banco de dados
         */ 

        public string Base64Encode(string senha)
        {
            var senhaBytes = System.Text.Encoding.UTF8.GetBytes(senha);
            return System.Convert.ToBase64String(senhaBytes);
        }

        public string Base64Decode(string senha)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(senha);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
