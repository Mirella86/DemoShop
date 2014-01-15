using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets current instance of the NhUnitOfWork.
        /// It gets the right instance that is related to current thread.
        /// </summary>
        public static UnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }
        [ThreadStatic]
        private static UnitOfWork _current;

        /// <summary>
        /// Gets Nhibernate session object to perform queries.
        /// </summary>
        public DbContext Context { get; private set; }

        /// <summary>
        /// Reference to the session factory.
        /// </summary>
    //    private readonly IContextFactory _sessionFactory;

        /// <summary>
        /// Reference to the currently running transcation.
        /// </summary>
   //     private ITransaction _transaction;

        /// <summary>
        /// Creates a new instance of NhUnitOfWork.
        /// </summary>
        /// <param name="sessionFactory"></param>
    //    public UnitOfWork(ISessionFactory sessionFactory)
    //    {
   //         _sessionFactory = sessionFactory;
    //    }

        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        //public void BeginTransaction()
        //{
        //    Session = _sessionFactory.OpenSession();
        //    _transaction = Session.BeginTransaction();
        //}

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        //public void Commit()
        //{
        //    try
        //    {
        //        _transaction.Commit();
        //    }
        //    finally
        //    {
        //        Session.Close();
        //    }
        //}

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        //public void Rollback()
        //{
        //    try
        //    {
        //        _transaction.Rollback();
        //    }
        //    finally
        //    {
        //        Session.Close();
        //    }
        //}

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }

  
}
