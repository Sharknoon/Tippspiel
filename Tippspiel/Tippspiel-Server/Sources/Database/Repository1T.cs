using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Criterion;
using Tippspiel_Server.Sources.Database.Helper;

namespace Tippspiel_Server.Sources.Database
{
    public class Repository1T<T> where T : class
    {

        public List<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<T>().List<T>();
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

        public void Delete(List<T> entities)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    entities.ForEach(entity => session.Delete(entity));
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

        public void Save(List<T> entities)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    entities.ForEach(entity => session.Merge(entity));//TEMP
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
                    session.Merge(entity);//TEMP
                    transaction.Commit();
                }
            }
        }

        public void Update(List<T> entities)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    entities.ForEach(entity => session.Merge(entity));//TEMP
                    transaction.Commit();
                }
            }
        }

        public List<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<T>().Where(expression).List<T>();
                return returnList as List<T>;
            }
        }

        public T GetById(int Id)//Unsafe....
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<T>().Where(Restrictions.Eq("Id", Id)).List<T>();
                return returnList.FirstOrDefault();
            }
        }
    }
}