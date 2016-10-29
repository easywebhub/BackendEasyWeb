using Couchbase.Core;
using Couchbase.Linq;
using Couchbase.Linq.Extensions;
using Couchbase.N1QL;
using ew.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.infrastructure.Repositories
{
    public class GenericRepository<T> where T : ewDocument
    {
        protected readonly IBucket _bucket;
        protected readonly IBucketContext _context;

        public GenericRepository(IBucket bucket, IBucketContext context)
        {
            _bucket = bucket;
            _context = context;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Query<T>()
               .ScanConsistency(ScanConsistency.RequestPlus)   // waiting for the indexing to complete before it returns a response
               ;
        }

        public T Get(string id)
        {
            return _bucket.Get<T>(key: id).Value;
            //return _bucket.Get<T>(string.Format("{0}::{1}", typeof(T).Name , key)).Value;
        }

        public void AddOrUpdate(T entity)
        {
            // if there is no ID, then assume this is a "new" person
            // and assign an ID
            if (string.IsNullOrEmpty(entity.Id))
                entity.Id = Guid.NewGuid().ToString(); // string.Format("{0}::{1}", entity.Type, Guid.NewGuid());

            _context.Save(entity);

            // alternate: with plain .NET SDK
            //            var doc = new Document<Person>
            //            {
            //                Id = "Person::" + person.Id,
            //                Content = person
            //            };
            //            _bucket.Upsert(doc);
        }

        public void Delete(string id)
        {
            // you could use _context.Remove(document); if you have the whole document
            //_bucket.Remove(string.Format("{0}::{1}", typeof(T).Name, id));
            _bucket.Remove(id);
        }

    }
}
