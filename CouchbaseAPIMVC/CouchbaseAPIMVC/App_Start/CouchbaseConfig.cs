using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase;
using Couchbase.Configuration.Client;
using CouchbaseAPIMVC.Helper;

namespace CouchbaseAPIMVC.App_Start
{
    public class CouchbaseConfig
    {
        public static void Initialize()
        {
            var config = new ClientConfiguration();
          //  config.BucketConfigs.Clear();

            config.Servers = new List<Uri>{ new Uri(CouchbaseConfigHelper.Instance.Server) };
          /*  var config = new ClientConfiguration
            {
                Servers = new List<Uri>
                {
                    //change this to your cluster to bootstrap
                    new Uri("http://45.117.80.57/:8091/"),

                 //   new Uri("http://localhost/:8091/")
                    }
            };*/

            /*config.BucketConfigs.Add(
                CouchbaseConfigHelper.Instance.Bucket,
                new BucketConfiguration
                {
                    BucketName = CouchbaseConfigHelper.Instance.Bucket,
                    Username = CouchbaseConfigHelper.Instance.User,
                    Password = CouchbaseConfigHelper.Instance.Password
                });

            config.BucketConfigs.Add(
                "default",
                new BucketConfiguration
                {
                    BucketName = "default",
                    Username = CouchbaseConfigHelper.Instance.User,
                    Password = CouchbaseConfigHelper.Instance.Password
                });
            */
           
            ClusterHelper.Initialize(config);
        }

        public static void Close()
        {
            ClusterHelper.Close();
        }
    }
}