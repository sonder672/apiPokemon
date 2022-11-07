# API Pokemon

Foobar is a Python library for dealing with word pluralization.

## Installation

Recuerde pegar en la carpeta pantera.controller el archivo appsettings.json

## Arquitectura

Se aplicó una arquitectura N capas, donde el controlador (pantera.controllers) envía la petición a la capa de servicio (pantera.services) y esta se encarga de orquestar entre la lógica de negocio (pantera.businessLogic) y el acceso a datos (pantera.dataAccess)

## Buenas prácticas

Se aplicó SOLID y se usaron códigos de estado HTTP (400, 422, 401, 200, 201, etc.).
