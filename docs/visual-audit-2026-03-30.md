# Auditoría visual integral — 2026-03-30

## Contexto
- **Modo:** diagnóstico continuo (sin releases activas).
- **Objetivo:** revisar todas las pantallas navegables y detectar oportunidades de unificación visual para mantener estilo consistente en todas las opciones del menú.
- **Fuente de análisis:** inspección estructural de pantallas Razor (`@page`) y uso de componentes UI compartidos.

---

## Cobertura relevada

Se relevaron todas las rutas declaradas en `GestAI.Web/Pages/**/*.razor`, incluyendo:
- núcleo general (`/`, `/dashboard`, `/login`, `/plans`, `/audit-log`),
- gestión SaaS (`/account`, `/users`),
- plataforma (`/platform/tenants`),
- comercio (listados, detalle, configuración, reportes, caja, cuentas corrientes, importación).

---

## Hallazgos principales

## 1) Estandarización ya lograda (fortaleza actual)
- Los **listados maestros principales** de comercio ya están convergidos al patrón compartido:
  - `ListPageHeader`
  - `ListPageFilters`
  - `UnifiedGrid`
  - `ListPaginationBar`
- Pantallas en ese estándar: Clientes, Presupuestos, Proveedores, Sucursales, Depósitos, Categorías, Productos, Ventas y Compras.

**Conclusión:** base sólida para “look & feel” homogéneo en el core operativo.

## 2) Brecha visual entre listados “core” y pantallas satélite
Pantallas como `DeliveryNotes`, `DocumentHistory`, `Reports`, `SupplierAccounts`, `CustomerCurrentAccounts`, `SupplierCurrentAccounts`, `ProductHealth`, `PriceLists`, `Inventory`, `ProductImport` aún combinan patrones previos y nuevos.

**Impacto UX:**
- variación de densidad visual entre módulos,
- cambios de jerarquía de títulos/acciones al navegar menú,
- sensación de producto “mezclado” (moderno en algunas pantallas, legacy en otras).

## 3) Inconsistencia en cabeceras de cards
Hay alta repetición manual de bloques `ui-card-header` (eyebrow + título + subtítulo), con microvariaciones de espaciado y semántica.

**Riesgo:** mantener consistencia futura exige tocar múltiples archivos.

## 4) Inconsistencia en acciones por fila
Conviven:
- botones inline,
- combinaciones mixtas,
- menú contextual en algunas grillas.

**Impacto:** el usuario no siempre encuentra las acciones en el mismo lugar/patrón.

## 5) Estado operativo y feedback aún heterogéneo en módulos secundarios
Aunque existe `OperationalStateHint` y `EmptyState`, no todas las pantallas lo aplican con el mismo criterio (especialmente en detalles/reportes).

**Impacto:** variaciones en mensajes de carga/error/vacío y en “claridad de siguiente paso”.

---

## Backlog de unificación recomendado

## Fase A — Quick wins (bajo riesgo, alto impacto visual)
1. **`UiCardHeader` compartido**
   - encapsular eyebrow/título/subtítulo en componente único.
2. **`UiStatCard` compartido**
   - normalizar KPI (`label`, `value`, `foot`) para summary grids.
3. **`ListRowActions` compartido**
   - patrón único para acciones por fila (kebab/dropdown + fallback inline si aplica).

## Fase B — Consistencia transversal de pantallas
4. **Migrar listados satélite a `ListPageHeader` + `ListPageFilters` + `UnifiedGrid`**
   - prioridad: `DeliveryNotes`, `DocumentHistory`, `Reports`, `SupplierAccounts`.
5. **Unificar paginación en pantallas remanentes**
   - aplicar `ListPaginationBar` donde haya page/next-prev.

## Fase C — Estados y accesibilidad visual
6. **Wrapper `ViewStatePanel`**
   - estado unificado para `loading`, `empty`, `error`, `success`.
7. **Checklist visual a11y**
   - contraste, jerarquía de foco, targets táctiles y consistencia de labels.

---

## Priorización sugerida (producto)
- **P1 (inmediato):** `UiCardHeader`, `ListRowActions`, migración de listados satélite críticos.
- **P2:** `UiStatCard` + unificación final de paginación en módulos no core.
- **P3:** `ViewStatePanel` y estandarización completa de estados en todos los detalles.

---

## Resultado esperado tras ejecutar el backlog
- navegación por menú con **patrón visual estable** en todas las pantallas,
- menor costo de mantenimiento y menor riesgo de regresión visual,
- percepción de producto más maduro y consistente.

---

## Segunda pasada de consistencia (menú completo) — 2026-03-30

### Estado por ítem de menú

| Ítem menú | Ruta | Estado de armonía | Observación |
|---|---|---|---|
| Dashboard | `/dashboard` | Alta | cabecera migrada a `ListPageHeader`; mantiene estructura de tablero con lenguaje visual convergente. |
| Tenants | `/platform/tenants` | Alta | cabecera, filtros, grilla y paginación migrados a componentes compartidos del patrón de listados. |
| Clientes | `/customers` | Alta | ya está en patrón unificado (header+filters+grid+paginación). |
| Presupuestos | `/quotes` | Alta | en patrón unificado, incluyendo acciones contextuales. |
| Ventas | `/sales` | Alta | en patrón unificado para listado principal. |
| Facturación | `/invoices` | Alta | header/filters/grid unificados (sin paginación explícita por split actual). |
| Remitos | `/delivery-notes` | Alta | migrada a `ListPageHeader` + `UnifiedGrid`; patrón visual alineado al core. |
| Reportes | `/reports` | Alta | migrada a `ListPageHeader` + `ListPageFilters` + `UnifiedGrid` en tablas principales. |
| Compras | `/purchases` | Alta | patrón unificado completo en listado. |
| Caja | `/cash` | Alta | cabecera alineada con `ListPageHeader` y grilla de movimientos en `UnifiedGrid`. |
| Ctas. clientes | `/customer-current-accounts` | Alta | migrada a `ListPageHeader` + `ListPageFilters` + `UnifiedGrid` en grillas principales. |
| Ctas. proveedores | `/supplier-current-accounts` | Alta | migrada a `ListPageHeader` + `ListPageFilters` + `UnifiedGrid` en grillas principales. |
| Inventario | `/inventory` | Alta | migrada a `ListPageHeader` + `ListPageFilters` + `UnifiedGrid` en stock/movimientos. |
| Categorías | `/categories` | Alta | patrón unificado completo. |
| Productos | `/products` | Alta | patrón unificado completo. |
| Listas de precios | `/price-lists` | Alta | cabecera y grillas migradas a componentes compartidos; mayor paridad con menú core. |
| Importación | `/products/import` | Alta | cabecera alineada con `ListPageHeader` y tabla de preview migrada a `UnifiedGrid`. |
| Sucursales | `/branches` | Alta | patrón unificado completo. |
| Depósitos | `/warehouses` | Alta | patrón unificado completo. |
| Proveedores | `/suppliers` | Alta | patrón unificado completo. |
| Fiscal / ARCA | `/fiscal-configuration` | Alta | cabecera migrada a `ListPageHeader` y mayor coherencia visual con menú core. |
| Auditoría | `/audit-log` | Alta | migrada a `ListPageHeader` + `ListPageFilters` + `UnifiedGrid`. |
| Historial | `/document-history` | Alta | migrada a `ListPageHeader` + `ListPageFilters` + `UnifiedGrid`. |

### Conclusión de la segunda pasada
- **Armonía alta** en listados core de operación comercial (clientes, presupuestos, ventas, compras, productos, maestros).
- **Sin brechas de armonía media** en el menú principal: dashboard y listados administrativos/comerciales convergen en cabecera y estilo base.
- **No se detectan quiebres críticos de UI**, pero sí una brecha de estandarización en módulos no-core del menú.

### Próximo batch recomendado (para 100% consistencia de menú)
1. Introducir `UiCardHeader` reusable para eliminar variaciones de eyebrow/título/subtítulo en todas las cards.
2. Consolidar variantes de chips KPI para tablero/listados en un token visual compartido.
3. Revisar acciones unitarias (cuando hay una sola acción) para definir si conviene mantener botón directo o también menú contextual.
