using Couchbase.AspNet.Identity;
using ew.core.Authorization;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.services
{
    public class RoleService
    {
        private readonly ThrowableBucket _dbBucket;

        public RoleService(ThrowableBucket bucket)
        {
            _dbBucket = bucket;
        }

       
    }
}
