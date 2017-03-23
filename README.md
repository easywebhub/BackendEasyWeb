
## Overview
>Triển khai ở api.easywebhub.com

> Là hệ thống quản trị account và websites của EasyWeb. Gồm các phần như sau

- Công nghệ sử dụng
   - Framework Asp.Net MVC5 Web API,  
   - Database: using ```Couchbase``` NoSQL, không sử dụng MSSQL
   - SwaggerUI cho Restful API document

- Source Code
   + repo: `https://github.com/easywebhub/BackendEasyWeb`,  branch `master`
   + Couchbase Info:`http://104.168.94.152:8091`, db name `ewhcb` 

- Development: đang áp dụng push to deploy
   + push-to-deploy server: `107.175.56.236`, port `4567`
   + từ repo: `https://github.com/easywebhub/deployments`, branch `api.easywebhub.com` 
   + deployed: server: `107.175.56.236` US 4G RAM, IIS Services name `api.easywebhub.com`
       
## Hệ thống sử dụng

### 1. easyadmincp.com
> chi tiết https://github.com/easywebhub/easyadmincp

> Tóm lượt

- Công nghệ sử dụng
  - SPA : Aurelia, SemanticUI
  - sử dụng API từ `api.easywebhub.com` bên trên

- Source Code:
  - Repo `https://github.com/easywebhub/easyadmincp`, branch `master`

- Deployment: đang áp dụng push to deploy
 - push-to-deploy server: `107.175.56.236`, port `4567`
 - từ repo: `https://github.com/easywebhub/deployments`, branch `cap_nhat`
 - deployed server: sử dụng github, repo `https://github.com/xxx`, branch `gh-pages

### 2. EasyBuider
> Là phần mềm chạy trên Win, Linux và MacOS
> Chi tiết https://github.com/easywebhub/easyapp

- Công nghệ sử dụng
  - Electron, NodeJS, RiotJS, Git
  - Metalsmith, HanderbarJS

- Source code
  - Repo: `https://github.com/easywebhub/easyapp` , branch `master`

- Build

### 3. Identity Server
- Công nghệ sử dụng
  - Identity Server 4, MSSQL Server 2012, .net Core

- Danh sách tính năng
  - tổng hợp ơ task #
  
- Source Code:
  - Repo `https://github.com/easywebhub/NetCoreIdentityServer`, branch `master`
  

- Deployment: chưa áp dụng push to deploy
 - ~~push-to-deploy server: `107.175.56.236`, port `4567`~~
 - MSSQL server,  đổi sang  Azure server name: `ewh-server-01.database.windows.net`, dbname `ewh-admincp-dev` 
 - từ repo: `https://github.com/easywebhub/deployments`, branch `id.easywebhub.com`
 - deployed server: ~~server việt nam bị xóa~~ => chuyển sang `107.175.56.236` , IIS services `cap-nhat`
 


 

   

### Config to Run:
1. Set project ```ew.api``` as startup project

2. Change config in web.config file

```<add key="couchbaseServer1" value="xxxxx" />``` point to couchbase server

3. Ctrl + F5 to build and run web api

### Tính năng
- List API https://github.com/easywebhub/BackendEasyWeb/blob/master/ListRestfulAPI.md
