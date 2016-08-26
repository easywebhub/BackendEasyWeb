using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CouchbaseAPIMVC.Helper
{
    public class CouchbaseConfigHelper
    {
        public CouchbaseConfigHelper()
        {
        }

        private static CouchbaseConfigHelper instance = null;
        public static CouchbaseConfigHelper Instance
        {
            get { return instance ?? (instance = new CouchbaseConfigHelper()); }
        }

        public string Bucket
        {
            get
            {
                return ConfigurationManager.AppSettings["couchbaseBucketName"];
            }
        }

        public string Server
        {
            get
            {
                return ConfigurationManager.AppSettings["couchbaseServer2"];
            }
        }

        public string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["couchbasePassword"];
            }
        }

        public string User
        {
            get
            {
                return ConfigurationManager.AppSettings["couchbaseUser"];
            }
        }

        public string JWTTokenSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["JWTTokenSecret"];
            }
        }
    }
}