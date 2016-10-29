using ew.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Linq;

namespace ew.infrastructure.Repositories
{
    public class WebsiteRepository : GenericRepository<Website>
    {
        public WebsiteRepository(IBucket bucket, IBucketContext context) : base(bucket, context)
        {
        }
    }
}
