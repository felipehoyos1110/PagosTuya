# PAGOSTUYA - Registro de pagos

### Ejecución API REST

Para ingresar un pago se debe consumir el servicio `POST /api/pago`
enviando el siguiente JSON: 
```
{
    "TipoIdentificacion": "CC",
    "Identificacion": "123",
    "Nombres": "Felipe Hoyos",
    "Email": "felipehoyos1110@gmail.com",
    "Total": 450000,
    "Detalles": [
        {"ProductoId": 1,
        "Cantidad": 2,
        "ValorUnidad": 50000,
        "ValorTotal": 100000},
        {"ProductoId": 2,
        "Cantidad": 1,
        "ValorUnidad": 350000,
        "ValorTotal": 350000}
    ]
}
```
## Construido con


* [C#] - Lenguaje de programación
* [MySql] - Motor de base de datos MySql
* [.NET Core] - Framework de desarollo
* [EF Core] - Framework ORM (Object Relational Mapping)
* [EF Core tools] - Herramientas del EF Core, utilizado principalmente para administrar migraciones a BD.
* [MySql Data EF Core] - Conector a base de datos MySql con EF Core
