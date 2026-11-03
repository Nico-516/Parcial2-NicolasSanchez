# Programación II · IDRA · 2.º parcial

**Taller Mecánico Juan B. Justo — órdenes de trabajo**
WinForms · .NET 5 · MVC · JSON · Patrones de diseño

> Mismo esqueleto que el simulacro: mismas carpetas, mismos 8 TODOs, en el mismo orden. Cambia el negocio y cambian las reglas: **leelas bien**, no son las de La Banquina.

---

## Antes de arrancar (5 minutos)

1. Copiá la carpeta del esqueleto al **disco ThawSpace** y renombrá la carpeta raíz a `Apellido_Nombre` (solo la carpeta de afuera, **no** el proyecto).
2. Abrí `Parcial2.sln` con Visual Studio y ejecutá con **F5**. **El esqueleto compila y abre.** Lo que todavía no está hecho muestra un mensaje del tipo *"Falta el TODO 4…"*.
3. Para ver todos los `TODO` del código: **Ctrl+Shift+F**, buscá `TODO` en **Toda la solución**.

**Duración: 2 horas.** 100 puntos, todos prácticos · Bonus: hasta 10 puntos (tope 100).

## Reglas

- Individual. **Sin IA** y sin comunicarte con compañeros.
- Podés usar el material de la cursada (presentaciones, Faro Envíos, el simulacro, tus guías).
- Si algo no te sale, **no lo borres**: dejá un comentario con qué intentaste. Un intento bien explicado suma puntos parciales.
- Cada `TODO` se corrige por separado: si te trabás en uno, pasá al siguiente.

---

## El caso

El taller de la avenida Juan B. Justo anota las órdenes de trabajo en una libreta. Te piden terminar el sistema: cargar la orden con los trabajos del catálogo, calcular el ajuste según la forma de pago, seguir cada vehículo por el taller, avisarle al cliente por WhatsApp y emitir comprobantes.

Recorrido de una orden: `Ingresada → EnReparacion → Terminada → Retirada`. **Solo se cancela mientras está `Ingresada`**: una vez que el mecánico empezó, no.

```
Parcial2/
├── Program.cs              Composition Root: el ÚNICO lugar donde se arma el sistema
├── Models/                 OrdenTrabajo, ItemOrden, Servicio, EstadoOrden, IEntidad
├── Repository/             IRepository<T> + JsonRepository<T>   (persistencia)
├── Services/               Bitacora                              (Singleton)
├── Pagos/                  IPagoStrategy + estrategias + factory (Strategy + Factory)
├── Observer/               Interfaces y suscriptores              (Observer)
├── Comprobantes/           Generadores y formatos                 (Factory Method)
├── Controllers/            OrdenController, ComprobanteController
├── Views/                  Formularios (ya diseñados: no hace falta tocar el Diseñador)
└── Datos/                  servicios.json (catálogo) y ordenes.json (órdenes de ejemplo)
```

**Lo que ya funciona:** la estructura MVC, el diseño de los formularios, la lectura del JSON (solo en el caso feliz), el catálogo, la estrategia `PagoEfectivo`, el comprobante TXT y el algoritmo del comprobante (`GeneradorComprobante`).

**Regla de oro:** el formulario no calcula ni guarda; le pide al controller. El controller no muestra mensajes; lanza excepciones con un texto claro. La vista decide cómo mostrarlas.

---

## Consignas (100 puntos)

Hacelas en orden: cada una se apoya en la anterior.

### TODO 1 · Persistencia — 8 pts · `Repository/JsonRepository.cs`

- `LeerTodos()` hoy funciona solo si el archivo existe y está bien. Hacelo robusto: archivo inexistente o vacío → lista vacía; JSON dañado → `InvalidOperationException("El archivo … está dañado.")` (sin mostrar la excepción cruda).
- `Actualizar(item)`: reemplaza el elemento con el mismo `Id` y reescribe el archivo. Si no existe → `InvalidOperationException("No existe el registro #…")`.

### TODO 2 · Modelo y validaciones — 14 pts · `Models/OrdenTrabajo.cs`

| Método | Regla |
|---|---|
| `AgregarItem(servicio, cantidad)` | Si la orden **no** está `Ingresada` → `InvalidOperationException`. Servicio `null` → `ArgumentException`. Cantidad fuera de 1…`MaximoPorItem` (10) → `ArgumentException`. Si el trabajo **ya está** en la orden, se **suma** la cantidad a esa línea (la suma tampoco puede pasar de 10). Si no, se agrega un `ItemOrden` con el **nombre y el precio actuales** del servicio. |
| `CalcularSubtotal()` | Suma de los `Subtotal` de los ítems. |
| `AvanzarEstado()` | `Ingresada → EnReparacion → Terminada → Retirada`. Si está finalizada (Retirada o Cancelada) → `InvalidOperationException`. |
| `Cancelar()` | **Solo** si está `Ingresada`. Si no → `InvalidOperationException`. |

### TODO 3 · Singleton — 8 pts · `Services/Bitacora.cs`

Abrí **Bitácora** en la app: aparece vacía y en `bitacora.log` todas las líneas dicen `#001`. Convertí `Bitacora` en un Singleton de verdad. **Nadie más cambia:** todos siguen usando `Bitacora.Instancia.Registrar(...)`.

### TODO 4 · Strategy — 14 pts · carpeta `Pagos/`

Creá dos estrategias que implementen `IPagoStrategy` (usá `PagoEfectivo` de modelo). `CalcularAjuste` devuelve un número **negativo si es descuento y positivo si es recargo**.

| Clase | `Nombre` | `PermiteCuotas` | `RequiereCuit` | `CalcularAjuste(subtotal, cuotas)` |
|---|---|---|---|---|
| `PagoTarjeta` | `"Tarjeta de crédito"` | `true` | `false` | 1 cuota: sin recargo · 3 cuotas: +10 % · 6 cuotas: +20 %. Cualquier otra cantidad → `ArgumentException("Con tarjeta se paga en 1, 3 o 6 cuotas.")`. |
| `PagoCuentaCorriente` | `"Cuenta corriente"` | `false` | `true` | $ 3.000 fijos + 5 % del subtotal. Subtotal **mayor** a $ 600.000 → `InvalidOperationException("La cuenta corriente admite órdenes de hasta $ 600.000.")`. |

### TODO 5 · Factory — 8 pts · `Pagos/PagoFactory.cs`

`Crear(tipo)` recibe el texto que llega del ComboBox o del JSON y devuelve la estrategia correcta. Texto desconocido → `ArgumentException`. Debe ser el **único** lugar del sistema que hace `new` de las estrategias concretas.

### TODO 6 · Controller + vista — 18 pts · `Controllers/OrdenController.cs` y `Views/FormNuevaOrden.cs`

**`CotizarPago(tipo, subtotal, cuotas)`**: factory → estrategia → cálculo, redondeado a 0 decimales.

**`ConfirmarOrden(borrador, cliente, telefono, patente, cuit, cuotas, tipo)`**:
1. Cliente y teléfono obligatorios; la orden tiene que tener al menos un trabajo → `ArgumentException`.
2. **Patente:** se le sacan los espacios y se pasa a mayúsculas; tiene que quedar con 6 o 7 caracteres, solo letras y números (`AB123CD`, `KJH452`). Si no → `ArgumentException`.
3. Si la estrategia `RequiereCuit` y el CUIT está vacío → `ArgumentException`. **Preguntale a la estrategia: no compares el texto del tipo.**
4. Completá el borrador: datos sin espacios de más; `Cuit = ""` si la forma de pago no lo requiere; `Cuotas = 1` si no permite cuotas; `Ajuste` con la estrategia (redondeado) y `Total = subtotal + ajuste`; estado `Ingresada`, fecha actual.
5. Guardalo con el repositorio, **notificá el alta** (lo completás en el TODO 7) y devolvelo.

**En `FormNuevaOrden`:**
- `ActualizarControlesPago()`: al cambiar la forma de pago, `nudCuotas` se habilita solo si la estrategia `PermiteCuotas` (si no, vuelve a 1) y `txtCuit` solo si `RequiereCuit` (si no, se vacía). Usá `_controller.InfoPago(...)`: **no compares el texto del ComboBox**.
- `btnConfirmar_Click`: llamá a `ConfirmarOrden`. Si sale bien → `OrdenCreada`, `DialogResult.OK` y cerrar. Si lanza `ArgumentException` o `InvalidOperationException` → `MessageBox` con el mensaje y el formulario queda abierto.

### TODO 7 · Observer — 20 pts

1. **`OrdenController` como notificador:** lista de `IOrdenObserver`, `Suscribir` (sin duplicados), `Desuscribir` y `Notificar`. Notificar tiene que funcionar aunque un suscriptor se dé de baja **mientras** se le avisa.
2. **`HistorialObserver`**: registra `evento.Descripcion()` en la `Bitacora`.
3. **`AvisoClienteObserver`** (recibe por constructor la ruta del archivo): agrega una línea en `avisos_clientes.txt` con el formato
   `[dd/MM HH:mm] WhatsApp a {Cliente} ({Telefono}): {texto}`
   — en el **alta**: `Hola {Cliente}, ingresó tu vehículo {Patente} (orden #{Id}). Presupuesto: {Total:C0}.`
   — cuando la orden pasa a **Terminada**: `Tu vehículo {Patente} está listo para retirar. Total: {Total:C0}.`
   — en la **cancelación**: `La orden #{Id} de tu vehículo {Patente} fue cancelada.`
   — en cualquier otro caso no escribe nada.
4. **`Program.cs`**: suscribí los dos observadores y el `FormPrincipal`.
5. **`FormTaller`**: que se suscriba al abrirse y se **desuscriba al cerrarse**. Probá abrir **dos** pantallas del taller, cerrar una y seguir avanzando órdenes: no tiene que romperse nada.

### TODO 8 · Factory Method — 10 pts · carpeta `Comprobantes/`

Agregá el **"Presupuesto HTML"** (extensión `html`) **sin tocar** `GeneradorComprobante`:
- `FormatoHtml : IFormatoComprobante` — una página `<html>` con un `<h1>` que diga el nombre del taller y el número de orden, un párrafo con cliente, patente y forma de pago, y una `<table>` con una fila por trabajo (descripción, cantidad, subtotal) y las filas de Subtotal, Descuento o Recargo, y Total. Los textos que vienen de los datos pasan por `System.Net.WebUtility.HtmlEncode`.
- `GeneradorComprobanteHtml : GeneradorComprobante` — su método fábrica devuelve un `FormatoHtml`.
- Una línea en `ComprobanteController.GeneradoresDisponibles()`.

---

## Bonus (hasta 10 pts, tope 100)

- **B1 · Billetera virtual (5 pts):** nueva forma de pago `"Billetera virtual"`: 5 % de descuento, sin cuotas, sin CUIT. Sin modificar ninguna estrategia existente ni el controller.
- **B2 · Presupuesto alto (5 pts):** un observador nuevo que, cuando entra una orden con total de **$ 300.000 o más**, registra en la bitácora `ATENCIÓN jefe de taller: presupuesto alto en orden #{Id} ({Total:C0})`. Una clase nueva + una línea en `Program.cs`.

---

## Para probar

| Caso | Resultado esperado |
|---|---|
| 2 pastillas de freno + 1 cambio de aceite, tarjeta en 6 cuotas | Subtotal $ 149.000 · Recargo $ 29.800 · Total $ 178.800 |
| La misma orden en efectivo | Descuento −$ 14.900 · Total $ 134.100 |
| 1 correa de distribución, cuenta corriente | Recargo $ 12.000 · Total $ 192.000 |
| Tarjeta en 4 cuotas | El formulario muestra "Con tarjeta se paga en 1, 3 o 6 cuotas." |
| 4 amortiguadores + 1 cambio de aceite, cuenta corriente | Muestra el tope de $ 600.000 |
| Patente `ab 123 cd` | Se guarda como `AB123CD` |
| Cancelar una orden EnReparacion | Mensaje: solo se cancela una orden Ingresada |
| Facturado con las órdenes de ejemplo | $ 952.800 (no cuenta la cancelada) |
| Vaciar `bin\…\Datos\ordenes.json` y abrir la app | La grilla aparece vacía, sin error |
| Escribirle texto cualquiera a ese archivo | Mensaje "El archivo ordenes.json está dañado." (después borralo y volvé a compilar: se restaura) |

---

## Entrega

1. Respondé las tres preguntas de `CIERRE.md`.
2. Cerrá Visual Studio. Borrá las carpetas `bin` y `obj`.
3. Comprimí la carpeta `Apellido_Nombre` en un **ZIP** con el mismo nombre y entregalo por el medio que indique el docente.

**El código tiene que compilar.** Si algo no compila, comentalo y explicá qué querías hacer.
