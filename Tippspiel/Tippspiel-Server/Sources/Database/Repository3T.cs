
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Criterion;
using Tippspiel_Server.Sources.Database.Helper;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database
{
    public class Repository3T<T, U, V> where T : class where U : class where V : class
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

        public List<T> GetByExpressionOnAReference(Expression<Func<U, bool>> expression, Expression<Func<T, U>> join)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<T>().JoinQueryOver(join).Where(expression).List<T>();
                return returnList as List<T>;
            }
        }

        public List<T> GetByExpressionOnAReference(Expression<Func<V, bool>> expression, Expression<Func<T, V>> join)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<T>().JoinQueryOver(join).Where(expression).List<T>();
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