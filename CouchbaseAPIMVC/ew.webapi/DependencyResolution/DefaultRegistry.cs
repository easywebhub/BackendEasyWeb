// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ew.webapi.DependencyResolution {
    using application;
    using application.Services;
    using Couchbase;
    using Couchbase.Core;
    using Couchbase.Linq;
    using core.Repositories;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap.Web;
    using System.Configuration;
    using infrastructure.Repositories;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            For<IBucket>().Singleton().Use<IBucket>("Get a Couchbase Bucket",
                x => ClusterHelper.GetBucket(ConfigurationManager.AppSettings["couchbaseBucketName"]));
            For<IBucketContext>().HttpContextScoped().Use<IBucketContext>("Get a Couchbase Bucket Context",
                x => new BucketContext(x.GetInstance<IBucket>()));

            //repositories
            For(typeof(IGenericRepository<>)).Use(typeof(GenericRepository<>));
            For<IAccountRepository>().Use<AccountRepository>();
            For<IWebsiteRepository>().Use<WebsiteRepository>();

            //services 
            For<IWebsiteManager>().Use<WebsiteManager>();
            For<IAccountManager>().Use<AccountManager>();

            For<IEwhMapper>().Use<EwhMapper>();
            For<IAuthService>().Use<AuthService>();
            For<IAccountService>().Use<AccountService>();
            For<IWebsiteService>().Use<WebsiteService>();
            
        }

        #endregion
    }
}