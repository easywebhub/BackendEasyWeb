
## Overview of BackendEasyWeb
#### 1. API Back-end: .Net MVC5 Web API,  using ```Couchbase``` NoSQL (and RMDB such as MSSQL or MySQL)
   + Save source on ```/CouchbaseAPIMVC/*```
   + Push to deploy: branch ```publicAPI``` is used to push and deploy to ```api.easywebhub.com``` 
 
#### 2. Web Admin:  Aurelia with Semantic UI (limit to use Bootstrap)
   + Save source on ```WebAdmin/*```
   + Use branch `/gh-pages` to host Aurelia website on GitHub pages.
   + CNAME:  easyadmincp.com
 
### List of API 
### Authentication (with sample  ```input & output json```)
  + Sign Up [[more]](https://gist.github.com/thanhtdvn/0deddb983c95e64b15d7ba63532ac99b)
  + Sign In [[more]](https://gist.github.com/thanhtdvn/b24379343a50fe29cc9190fd0825231b)
  + Update Account Info

###  Create new website
  + new website with owner is current user ```["creator", "dev"]```
  + add ```websiteId``` to list of websites
  
  [more](https://gist.github.com/thanhtdvn/b1cf56686335287e603f90e0915ac836)

### Allow users to access website
  + update website.json with input:  ```websiteId``` and  permisson ```accessLevel```
  + add ```websiteId``` to list of websites
  
  [[more]](https://gist.github.com/thanhtdvn/f4b1f9b2687fbe0716ac281d27c49172)

### Update website Info:
  + update Stagging or Deploy information
  + update website.json  only.
  
### Update more Info beside of WebsiteInfo
  + Info to process the Shopping Cart https://gist.github.com/thinnv/97ca63a2a7a40e7701aa84cc983445b8
  + Info of live domain
  
### Order
  + Insert Order [JSON](https://gist.github.com/thinnv/584eacc7db1e8956dd2021b6ed5996d7)
  + Update Order [JSON](https://gist.github.com/thinnv/df86acfcd7a19e13072b4de29181a242) // Có thêm OrderId
  + Get List Order [link]( http://api.easywebhub.com//api-order/GetListOrder?siteId=mtfashion)

### List of results (json) for easy debug or integrate with Aurelia Admin
  + List of accounts [[more]](https://gist.github.com/thanhtdvn/a451ec9898d221b739f37087a3a7af12)
  
  + List of created websites [[more]](https://gist.github.com/thanhtdvn/ad72e51475204f0265caef91d15c7cf6) 

### Core features
#### 1. User management  with Admin forms
  + Sign in/ Sign up 
    + API: add here  add here link to the Url (or screenshot) 
    + WebAdmin: add here link to the Url (or screenshot)
  + API User info (json format) with function permissions 
    + API: add here  add here link to the Url (or screenshot) 
    + WebAdmin: add here link to the Url (or screenshot)
  + List Users 
    + List groups that a user belongs
 
#### 2. Group management with Admin forms
   + A Group could have children groups
   + Create / Edit a group 
   + Set permissions for a group
   + Assign users into a group
   + List All Groups or children groups 

