using System.Collections.Generic;

namespace Palestra.DAO
{
    public interface IDAO<T>
    {
        long Incluir(T modelo);
        void Alterar(T modelo, long id);
        void Excluir(T modelo);
        List<T> Consultar();
    }
}
