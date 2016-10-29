using Couchbase.Core;
using Couchbase.Linq;
using Couchbase.Linq.Extensions;
using Couchbase.N1QL;
using ew.core;
using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.infrastructure.Repositories
{
    public class AccountRepository: GenericRepository<Account>
    {
        public AccountRepository(IBucket bucket, IBucketContext context): base(bucket, context)
        {
        }
        
    }
}
