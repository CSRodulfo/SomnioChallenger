# SomnioChallenger

La arquitectura que utilice es la que mencione en la entrevista que diseñe hace 10 años, seguí las líneas de la misma basada en DDD (Martin Fowler), pero adaptado y tomando algunas "salvedades" 

Agregue una conexión a MySql que no la tenía y monte todo sobre el repository (generico) y especificationRespository La arquitectura estaba diseñada para andar sobre SQL Server, por ende el Menú, Roles, Permisos y comportamientos están sobre dicha base de datos (un tema a considerar si es que desean correr el código)

Agregue una conexión a MySql que no la tenía y monte todo sobre el repository y especificationRespository 

La arquitectura estaba diseñada para andar sobre SQL Server, por ende el Menú, Roles, Permisos y comportamientos están sobre dicha base de datos (un tema a considerar si es que desean correr el código)

La lógica de filtrados está sobre el servicio, del lado del backend por que asumo una tabla que puedo tener muchos registros
