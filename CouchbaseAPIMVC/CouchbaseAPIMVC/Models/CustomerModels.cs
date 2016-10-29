using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Couchbase;
using Couchbase.Core;
using Couchbase.Linq;

namespace CouchbaseAPIMVC.Models
{
    public class ApplicationCustomer : Customer
    {
        private static IBucket _bucket;
    
        public static async Task<bool> InsertWithPersistTo(Object value)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
         //   _bucket = ClusterHelper.
            var result = await _bucket.UpsertAsync(Guid.NewGuid().ToString(), value, ReplicateTo.Two);
            if (result.Success)
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> InsertWithPersistTo(IObject value)
        {

            _bucket = ClusterHelper.GetBucket("beer-sample");
            var result = await _bucket.UpsertAsync(value.Id, value, ReplicateTo.Two);
            if (result.Success)
            {
                return true;
            }
            return false;
        }


        public static Customer GetDocument(string id)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
            var result = _bucket.GetDocument<Customer>(id);
            return result.Content;
        }

        public static async Task<bool> DeleteDocument(Customer document)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
            var result = _bucket.Remove(document.Id);
            if (result.Success)
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> DeleteDocument(string id)
        {
            _bucket = ClusterHelper.GetBucket("beer-sample");
            var result = _bucket.Remove(id);
            if (result.Success)
            {
                return true;
            }
            return false;
        }
        public static List<CustomerModel> GetDocumentAllDataCustomerConfig()
        {

           
            var db = new BucketContext(ClusterHelper.GetBucket("beer-sample"));

            var query = from b in db.Query<CustomerModel>()
                 where b.Type == "CustomerModel"
                 select b;
       
            var rs = query.ToList();

             return rs;
            //return query.FirstOrDefault();
        }
    }

}