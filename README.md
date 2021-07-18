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
