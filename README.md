# Help Desk System


### compose dla sql server 
```
version: '3.8'

services:
  sqldata:
      image: mcr.microsoft.com/mssql/server:2022-latest
      environment:
        - MSSQL_SA_PASSWORD=Pass@word
        - ACCEPT_EULA=Y
      ports:
        - "1433:1433"

```
### Example ConnString

```
"ConnectionStrings": {
  "DefaultConnection": "Server = 127.0.0.1; Database = <baza>; user id = SA; password = Pass@word; Encrypt = false; TrustServerCertificate = true; Integrated Security = false;"
},

```


