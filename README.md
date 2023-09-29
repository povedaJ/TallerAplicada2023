# Swagger en .NET usando C# y una API mínima

## Pasos

1. Tener las siguientes paqueterías en ambos proyectos (`API` y `DataAccess`)
- Microsoft EntityFrameworkCore SQL
- Microsoft EntityFrameworkCore Tools

2. Comprobar que existan una referencia del proyecto `API` hacia el proyecto `DataAccess`

3. Ejecutar el comando `Scaffold-DbContext "Server=163.178.173.130;Database=HotelParaiso;user id = basesdedatos; password = rpbases.2022; Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models` en la consola del Nuget, para mapear la base de datos.

4. Agregar la linea 

````csharp
builder.Services.AddDbContext<HotelParaisoContext>();
````

5. Seguridad

````json
"ConnectionStrings":{
	"DefaultConnection":"Server=163.178.173.130;Database=HotelParaiso;user id = basesdedatos; password = rpbases.2022; Encrypt=False"
}
````
````csharp
builder.Services.AddDbContext<HotelParaisoContext>(options => 
	options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
);
````

`Scaffold-DbContext Name=DefaultConnection Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force`