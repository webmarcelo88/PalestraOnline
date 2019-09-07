using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Palestra.DAO
{
    public class ApoioDAO<T> : IDAO<T> where T: class
    {

        public long Incluir(T modelo)
        {
            long id = 0;

            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    id = (long)session.Save(modelo);
                    transacao.Commit();
                }
            }

            return id;
        }

        public void Alterar(T modelo, long id)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    session.Update(modelo, id);
                    transacao.Commit();
                }
            }
        }

        public List<T> Consultar()
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                return (from e in session.Query<T>() select e).ToList();
            }
        }

        public void Excluir(T modelo)
        {
            using (ISession session = FluentySessionFactory.AbrirSessao())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    session.Delete(modelo);
                    transacao.Commit();
                }
            }
        }        
    }
}
