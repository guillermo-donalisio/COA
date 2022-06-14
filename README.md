# Exámen COA

### Project Versions:
- Visual Studio Code: 1.66.2
- Net 6.0

**Packages NuGet installed:**
### To Database Connections & Mapper
- Microsoft.EntityFrameworkCore (6.0.4)
- Microsoft.EntityFrameworkCore.Design (6.0.4)
- Microsoft.EntityFrameworkCore.SqlServer (6.0.4)
- Microsoft.EntityFrameworkCore.Tools (6.0.4)
- AutoMapper.Extensions.Microsoft.DependencyInjection (11.0.0)

### To execute Live Server
- Microsoft.AspNetCore.Cors (2.2.0)

### To consume web api
- Swashbuckle.AspNetCore (6.2.3)

## Configurations

- Inside *appsetings.json* place your connection string or use User Secrets to manage your keys:
````
{
  "ConnectionStrings": {
    "CoaConnection": "Connection string via User Secrets"
  }
}
````
## Test your endpoints using Swagger at local host or with live server

````
Swagger
https://localhost:7039/swagger/index.html

Live Server
http://127.0.0.1:5500/Front-end/index.html
````