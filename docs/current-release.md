# Current Release Status

## Release actual
- **ID:** R1 — Hardening UX + Calidad Operativa
- **Estado:** En progreso
- **Fecha de actualización:** 2026-03-28

## Validación de pertenencia de tarea
- **Tarea aplicada:** Cierre de ítems de Técnica del backlog (submódulos de features y extracción de lógica repetida de Razor a servicios).
- **¿Pertenece a la release actual?** Sí, por reducción de deuda técnica y riesgo de regresiones futuras.

## Trabajo realizado en la release
- Implementadas validaciones visuales resumidas previo al guardado en formularios críticos.
- Implementada protección ante pérdida de cambios (dirty form guard + confirmación).
- Unificado manejo de estados de error de carga en vistas transaccionales.
- Extendidos los patrones UX a `Products` y `Categories` para completar el set crítico definido en backlog.
- Optimizados listados críticos para evitar subconsultas duplicadas por fila en tenant/products.
- Depurado `product-backlog.md` para remover del backlog activo los ítems ya implementados/cerrados.
- Cerrados ítems de pendiente prioritario: homogeneización de feedback en pantallas maestras y control de paginación máxima en backend.
- Cerrados ítems de Producto: política única de pricing, patrón de filtros/búsqueda consistente y telemetría funcional en maestros.
- Cerrados ítems de Técnica: extracción de `CommercePartyFeatures` y servicio UI reutilizable para reducir duplicación en páginas maestras.

## Pendiente para cerrar release
- Ejecutar y dejar en verde build + tests en pipeline CI.
- Completar checklist de regresión QA de comercio.
- Documentar evidencia final de aceptación funcional y UX.
- Medir p95 y payload por endpoint crítico para validar impacto real de performance.

## Próximo paso recomendado
- Consolidar QA de regresión en CI y cerrar R1 con checklist firmado.
