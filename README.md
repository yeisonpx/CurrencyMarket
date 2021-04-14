# CurrencyMarket 

##Instalacion 

### Opcion 1: Docker Compose

Desde la carpeta root del proyecto puede ejecutar los comandos:
```
docker-compose build
docker-compose up
```
Lo cual permitiria desplegar los contenedores de web-api en net core y base de datos en SQL Server.

Url de servicios desplegados:
- WebAPI: http://localhost:5001
- SQL Server: localhost:5002

### Opcion 2: Ejecutar proyecto con visual studio(recomendado 2019+)

- El proyecto solo requiere tener instalado .Net Core 3.1
- Entity Framework Core
- Seleccionar como proyecto principal Web Api
- Actualmente el proyecto contiene los migrations de entity framework y no se requiere ejecutar manualmente.

### Notas proyecto Front-End en Vue:
- Desde la ruta: */CurrencyMarket.Front-End/market-currency/* se debe correr en una PC con NodeJs los comandos:
```
npm install
npm run serve
```
