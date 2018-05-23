
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using UnitOfWorkLayer.Repository;
using System.Data.Entity;

namespace UnitOfWorkLayer
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        private IGenericRepository<FeedCollection> feedCollectionsRepository;
        private IGenericRepository<Feed> feedRepository;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
            feedCollectionsRepository = new GenericRepository<FeedCollection>(context);
            feedRepository = new GenericRepository<Feed>(context);
        }
     

        public IGenericRepository<FeedCollection> FeedCollectionRepository
        {
            get
            {

                if (this.feedCollectionsRepository == null)
                {
                    this.feedCollectionsRepository = new GenericRepository<FeedCollection>(context);
                }
                var a = feedRepository.Get();
                return feedCollectionsRepository;
            }
        }
        public IGenericRepository<Feed> FeedsRepository
        {
            get
            {

                if (this.feedRepository == null)
                {
                    this.feedRepository = new GenericRepository<Feed>(context);
                }
                return feedRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
