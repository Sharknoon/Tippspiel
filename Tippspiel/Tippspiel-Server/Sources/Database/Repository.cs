
using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using Tippspiel_Server.Sources.Database.Helper;

namespace Tippspiel_Server.Sources.Database
{
    public class Repository<T> where T : class
    {

        public List<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.CreateCriteria<T>().List<T>();
                return returnList as List<T>;
            }
        }

        public void Delete(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        public void Save(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Merge(entity);//TEMP
                    transaction.Commit();
                }
            }
        }

        public void Update(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Merge(entity);
                    transaction.Commit();
                }
            }
        }

        public List<T> GetByPropertyIgnoreCase(string property, object value)
        {
            return GetByProperty(property, value, true);
        }

        public List<T> GetByPropertyCaseSensitive(string property, object value)
        {
            return GetByProperty(property, value, false);
        }

        private List<T> GetByProperty(string property, object value, Boolean ignoreCase)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var restriction = ignoreCase ? Restrictions.Eq(property, value).IgnoreCase() : Restrictions.Eq(property, value);
                var returnList = session.CreateCriteria<T>().Add(restriction).List<T>();
                return returnList as List<T>;
            }
        }

        public T GetById(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var restriction = Restrictions.Eq("Id", id);
                var result = session.CreateCriteria<T>().Add(restriction).UniqueResult<T>();
                return result;
            }
        }
    }
}