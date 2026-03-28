# Product Backlog

## 🔥 Pendiente prioritario
- Sin ítems críticos pendientes.

## 🧠 Producto
- Formalizar la política única de pricing para venta rápida y venta completa (precio catálogo vs override permitido).
- Estandarizar comportamiento de filtros y búsqueda en todos los listados para reducir fricción operativa.
- Incorporar observabilidad funcional (eventos de error por formulario, abandono y tiempos de finalización por flujo).

## 🧱 Técnica
- Refactorizar `CommerceFeatures` en submódulos por bounded context para bajar complejidad y facilitar mantenimiento.
- Reducir lógica de negocio incrustada en páginas Razor moviendo reglas y orquestación a servicios/view-models testeables.

## 🚀 Performance
- Medir y publicar resultados reales de p95/payload por endpoint crítico para validar baseline en entorno integrado.

## ✅ Cerrado
- Estandarizar manejo de errores en formularios críticos (ventas, productos, categorías, compras).
- Endurecer CORS por entorno y dominio explícito en API.
- Reducir acoplamiento crítico con separación de responsabilidades en controller/handlers.
- Extender `ApiClientException` con errores por campo.
- Definir checklist QA de regresión de comercio.
- Estandarizar validaciones visuales + dirty guard + estados de interfaz en pantallas transaccionales.
- Optimizar consultas con subqueries repetidas en listados críticos.
- Definir baseline inicial de performance (objetivos p95/payload y estrategia de medición).
- Homogeneizar mensajes de error/éxito en pantallas maestras pendientes (`branches`, `warehouses`, `customers`, `suppliers`) con `FormFeedback`.
- Ajustar límite máximo de paginación en backend para endpoints de alto tráfico (cap global de `PageSize` a 50).
