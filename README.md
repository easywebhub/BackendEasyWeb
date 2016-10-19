
## Overview of BackendEasyWeb
#### 1. API Back-end: .Net MVC5 Web API,  using ```Couchbase``` NoSQL (and RMDB such as MSSQL or MySQL)
   + Save source on ```/CouchbaseAPIMVC/*```
   + Push to deploy: branch ```publicAPI``` is used to push and deploy to ```api.easywebhub.com``` 
 
#### 2. Web Admin:  Aurelia with Semantic UI (limit to use Bootstrap)
   + Save source on ```WebAdmin/*```
   + Use branch `/gh-pages` to host Aurelia website on GitHub pages.
   + CNAME:  admin.easywebhub.com
 
### List of API 
### Authentication (with sample  ```input & output json```)
  + Sign Up  
  + Sign In 
  + Update Account Info

###  Create new website
  + new website with owner is current user ```["creator", "dev"]```
  + add ```websiteId``` to list of websites

### Allow users to access website
  + update website.json with input:  ```websiteId``` and  permisson ```accessLevel```
  + add ```websiteId``` to list of websites

### Update website Info:
  + update Stagging or Deploy information
  + update website.json  only.
  
### Update more Info beside of WebsiteInfo
  + Info to process the Shopping Cart https://gist.github.com/thinnv/97ca63a2a7a40e7701aa84cc983445b8/revisions
  + Info of live domain
  
### Order
  + Insert Order [JSON](https://gist.github.com/thinnv/584eacc7db1e8956dd2021b6ed5996d7)
  + Update Order [JSON](https://gist.github.com/thinnv/df86acfcd7a19e13072b4de29181a242) // Có thêm OrderId
  + Get List Order [link]( http://api.easywebhub.com//api-order/GetListOrder?siteId=mtfashion)

### List of results (json) for easy debug or integrate with Aurelia Admin
  + List of accounts
  + List of created websites  [JSON](https://gist.github.com/thinnv/47d4d486aa642c976c2f3f28c9b9d649)

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

 
