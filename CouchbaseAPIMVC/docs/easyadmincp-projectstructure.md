### Project structure

```yaml
    ├── library         # Định nghĩa các library trong ứng dụng
    │   ├── ew.core            # Đính nghĩa các poco class, repository cho các đối tượng trong hệ thống
    │   ├── ew.config          # Định nghĩa config dùng chung cho các project 
    │   ├── ew.common          # Định nghĩa các đối tượng, helper, services dùng chung trong solution
    │   ├── ew.infrastructure  # Hiện thực các interface định nghĩa ở core
    │   └── ew.application     # Chứa các thực thể, services ở mức ứng dụng
    ├── middleware      # Định nghĩa third-party sử dụng trong project
    │   ├── ew.cloudflare-wrapper    # API wrapper cho dịch vụ Cloudflare
    │   ├── ew.gogs-wrapper          # API wrapper cho gogs
    │   ├── ew.git-hook-listener     # API wrapper cho git hook listener
    │   └── ew.github-wrapper        # API wrapper cho github
    ├── presentation    # Chứa web application như web, webapi
    │   ├── ew.web        # Website (chưa sủ dụng cho mục đích gì)
    │   └── ew.webapi     # Web API của easyadmincp
    
```

#### ew.core

```yaml
├── library         # Định nghĩa các library trong ứng dụng
│   ├── ew.core            # Định nghĩa các poco class, repository cho các đối tượng trong hệ thống
│   │   ├── Users          # module Tài khoản  
│   │   ├── Authorization  # module Quyền
│   │   ├── Website        
│   │   ├── Enums          # Định nghĩa các enum sủ dụng chung trong hệ thống: cấp bậc, trạng thái,...
│   │   │   ├── AccessLevels  
│   │   │   ├── AccountStatus 
│   │   ├── Repositories   
│   │   │   ├── IGenericRepository            # Base Repository, chứa các methods cơ bản: Create, Edit, Delete, Find,...
│   │   │   ├── IAccountRepository            # Repository cho tài khoản
│   │   │   ├── IWebsiteRepository            
│   │   ├── Dtos            # Định nghĩa các Data Object Tranfers sử dụng giữa các service class trong hệ thống
│   │   │   ├── AccountDtos     
│   │   │   ├── WebsiteDtos     

```

#### ew.config

```yaml
├── library         # Định nghĩa các library trong ứng dụng
│   ├── ew.config  
│   │   ├── CloudflareInfo.cs   # chứa config cho cloudflare
│   │   ├── DemoServer.cs       # chứa config cho EW Demo Server
│   │   ├── ProductionServer.cs # chứa config cho EW Production Server
│   │   ├── SourceServer.cs     # chứa config cho EW Sourcecode Server
```

#### ew.common
Tầng service dùng chung cho toàn hộ solution

```yaml
├── library         # Định nghĩa các library trong ứng dụng
│   ├── ew.common  
│   │   ├── Entities   # chứa các đối tượng sử dụng chung trong solution
│   │   │   ├── IEwhEntityBase.cs     
│   │   │   ├── EwhEntityBase.cs     # base class của 1 đối tượng (thực thể hóa) trong hệ thống
│   │   ├── Helper     # chứa các service dùng chung như: service làm việc với Json, service xử lý chuổi
│   │   │   ├── JsonHelper.cs     
│   │   │   ├── StringUltis.cs     
│   │   ├── Log # chứa config cho EW Production Server
```

#### ew.infrastructure

```yaml
├── library         # Định nghĩa các library trong ứng dụng
│   ├── ew.infrastructure  
│   │   ├── Repositories   # chứa các hiện thực của các repository interface trong ew.core
│   │   │   ├── GenericRepository.cs     
│   │   │   ├── AccountRepository.cs     
│   │   │   ├── WebsiteRepository.cs     
```

#### ew.application
Tầng services ở mức ứng dụng cho solution

```yaml
├── library         # Định nghĩa các library trong ứng dụng
│   ├── ew.application  
│   │   ├── Entities   # chứa các đối tượng (báo gồm thuộc tính và các phương thức của đổi tượng) được thực thể hóa trong ứng dụng
│   │   │   ├── EwhAccount.cs     # đối tượng Tài Khoản
│   │   │   ├── EwhWebsite.cs     # đổi tượng Website
│   │   │   ├── Dtos   # chứa các Data Object Transfers sử dụng trong các Entities
│   │   ├── Helpers    # chứa các helper sử dụng trong project
│   │   ├── Services  
│   │   ├── AccountManager.cs   # định nghĩa đối tượng Manager của đối tượng Tài Khoản
│   │   ├── WebsiteManager.cs   # định nghĩa đối tượng Manager của đối tượng Website
```

#### ew.cloudflare-wrapper
Tầng Service cho dịch vụ cloudflare

```yaml
├── middleware         # Định nghĩa third-party sử dụng trong project
│   ├── ew.cloudflare-wrapper  
│   │   ├── Models   # chứa các models sủ dụng/trả về bởi CloudflareManager
│   │   │   ├── CloudFlareApiResult.cs 
│   │   │   ├── CreateDnsRecordDto.cs  
│   │   │   ├── DNSRecord.cs  
│   │   ├── CloudflareManager.cs   # định nghĩa đối tượng Manager của đối tượng cloudflare service
```

#### ew.gogs-wrapper
Tầng Service cho gogs server, chứa source code trên source-server gogs

```yaml
├── middleware         # Định nghĩa third-party sử dụng trong project
│   ├── ew.gogs-wrapper  
│   │   ├── Models   # chứa các models sủ dụng/trả về bởi EwhSource
│   │   │   ├── Repository.cs 
│   │   │   ├── WebHook.cs  
│   │   ├── EwhSource.cs   # định nghĩa đối tượng Source, cung cấp các thông tin, phương thức cho 1 thực thể Source ở gogs-source trên easyweb
```

#### ew.git-hook-listener
Tầng Service xử lý lắng nghe, quản lý webhook cho repository, sync source từ gogs-server tới các DemoServer và ProductionServer của website

```yaml
├── middleware         # Định nghĩa third-party sử dụng trong project
│   ├── ew.git-hook-listener  
│   │   ├── Models   # chứa các models sủ dụng/trả về bởi EwhGitHookListener
│   │   │   ├── Repository.cs 
│   │   ├── EwhGitHookListener.cs   # quản lý web-hook của 1 website trên github
```

#### ew.github-wrapper
Tầng Service cho github

```yaml
├── middleware         # Định nghĩa third-party sử dụng trong project
│   ├── ew.github-wrapper  
│   │   ├── Models   # chứa các models sủ dụng/trả về bởi EwhGitHookListener
│   │   ├── GitHubManager.cs   # quản lý web-hook của 1 website trên github
```

#### ew.webapi
Tầng presentation, cung cấp API
    
