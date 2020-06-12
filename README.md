### 1. Clonar repositorio
``` 
git clone https://github.com/ceruizdev/netcoreapi-library.git
```

### 2. Cambiar cadenas de conexión 
 - appsettings.json
 - Models/LibraryDBContext.cs (temporal para futuros commits)
 
### 3. Realizar migraciones - nuget
```
   add-migration initial
```

```
   update-database
```
### 5. Ejecutar 
 ``` 
    dotnet run
 ```
