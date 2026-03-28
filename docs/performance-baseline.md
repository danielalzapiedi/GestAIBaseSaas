# Performance Baseline (Commerce)

Fecha: 2026-03-28

## Objetivo
Definir métricas mínimas de seguimiento para endpoints críticos de Commerce y prevenir degradaciones tempranas.

## Endpoints críticos priorizados
- `GET /api/commerce/products`
- `GET /api/commerce/categories`
- `GET /api/commerce/sales`
- `GET /api/commerce/quotes`
- `GET /api/commerce/purchases`
- `GET /api/commerce/tenants` (scope SuperAdmin)

## SLO inicial (objetivo)
- p95 <= 350 ms para listados paginados sin filtros complejos.
- p95 <= 500 ms para listados con filtros combinados (búsqueda + estado + entidad relacionada).
- Error rate <= 1% por endpoint (5xx).

## Presupuesto de payload
- Respuesta de listado paginado (`pageSize=20`): <= 200 KB.
- Respuesta de detalle individual: <= 80 KB.

## Estrategia de validación
1. Ejecutar smoke de consultas con páginas 1, 2 y 3.
2. Comparar tiempos con y sin filtros.
3. Registrar evidencia por endpoint (p50, p95, tamaño de payload).
4. Repetir después de cada cambio de proyecciones o joins.

## Cambios aplicados en esta iteración
- Consolidación de datos de owner (nombre/email) en consultas de tenant para evitar subqueries repetidas por fila.
- Join con conteo agregado de variantes activas en listado de productos para reducir costo de proyección por registro.
