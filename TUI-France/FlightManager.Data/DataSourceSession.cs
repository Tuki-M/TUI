using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data
{
    /// <summary>
    /// Expose the CRUD operation of nhibernate session (created from Factory)
    /// </summary>
    public class DataSourceSession
    {
        private static ISessionFactory _source;
        private static DataSourceSession _instance = null;
        private ISession _session;
        public static DataSourceSession Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataSourceSession();

                return _instance;
            }
        }

        public DataSourceSession()
        {
            _source = new DataSourceFactory().CreateSessionFactory();
        }

        public T SaveOrUpdate<T>(T entity)
        {
            _session.SaveOrUpdate(entity);
            return entity;
        }

        public T Update<T>(T entity)
        {
            _session.Clear();
            _session.Update(entity);
            return entity;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _session.Query<T>().ToList();
        }

        public T Get<T>(object id)
        {
            return _session.Get<T>(id);
        }

        public void CloseSession()
        {
            try
            {
                _session.Transaction.Commit();
                _session. Close();
            }
            catch (Exception ex)
            {
                _session.Transaction.Rollback();
                _session.Close();
                throw ex;
            }
        }

        public void OpenSession()
        {
            _session = _source.OpenSession();
            _session.BeginTransaction();
        }

    }
}
