
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitOfWorkLayer.Repository;

namespace UnitOfWorkLayer
{
    public interface IUnitOfWork
    {
        IGenericRepository<FeedCollection> FeedCollectionRepository { get; }
        IGenericRepository<Feed> FeedsRepository { get; }
        void Save();
        void Dispose();
    }
}