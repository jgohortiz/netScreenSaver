# netScreenSaver (ProtectorPantalla)

Protector de pantalla para Windows desarrollado en C# con Windows Forms sobre .NET 9. Muestra un logo corporativo que se desplaza por la pantalla, la fecha y la hora actuales, y un fondo en escala de grises que cambia de tono de forma gradual.

## Características

- Logo personalizable que rebota por los bordes de la pantalla con velocidad variable.
- Reloj (HH:mm:ss) y fecha (yyyy-MM-dd) actualizados cada segundo.
- Fondo en escala de grises que transita entre negro y blanco, con periodos en negro.
- Color del texto ajustado automáticamente según la luminancia del fondo para mantener la legibilidad.
- Soporte para múltiples monitores: se abre una ventana en cada pantalla conectada.
- Compatible con los modos estándar de protector de pantalla de Windows: pantalla completa, vista previa y configuración.
- Se cierra al pulsar una tecla, hacer clic o mover el ratón.

## Requisitos

- Windows 10 u 11 (x64).
- SDK de .NET 9 para compilar.
- Visual Studio 2022 (opcional) para abrir la solución `ProtectorPantalla.sln`.

## Estructura del proyecto

| Archivo | Descripción |
|---|---|
| `Program.cs` | Punto de entrada. Interpreta los argumentos de línea de comandos (`/s`, `/p`, `/c`) y lanza el modo correspondiente. |
| `ScreenSaverForm.cs` | Lógica del protector: temporizadores, movimiento del logo, reloj, cambio de color de fondo y detección de actividad del usuario. |
| `ScreenSaverForm.Designer.cs` | Definición de los controles visuales del protector. |
| `SettingsForm.cs` | Ventana de configuración (información del producto y autor). |
| `SettingsForm.Designer.cs` | Definición de los controles de la ventana de configuración. |
| `ProtectorPantalla.csproj` | Proyecto .NET 9 (`net9.0-windows`, WinForms, `WinExe`). |
| `leame.txt` | Notas rápidas de compilación. |

## Recursos gráficos

El protector carga las imágenes desde rutas fijas en el equipo:

| Recurso | Ruta |
|---|---|
| Logo en movimiento | `C:\OEMInfo\netScreenSaverLogo.png` |
| Banner central (actualmente oculto) | `C:\OEMInfo\netScreenSaverBanner.png` |

Antes de instalar el protector, cree la carpeta `C:\OEMInfo` y copie allí los archivos PNG. Si no existen, el protector se ejecuta sin mostrar las imágenes.

## Compilación

Compilación de depuración:

```
dotnet build
```

Publicación como ejecutable único y autocontenido:

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

El resultado queda en:

```
bin\Release\net9.0-windows\win-x64\publish
```

## Instalación

1. Copie `ProtectorPantalla.exe` desde la carpeta de publicación y cambie su extensión a `.scr` (por ejemplo, `netScreenSaver.scr`).
2. Copie el archivo `.scr` a `C:\Windows\System32` o, como alternativa, haga clic derecho sobre él y seleccione "Instalar".
3. Abra "Configuración del protector de pantalla" en Windows y seleccione netScreenSaver.
4. Verifique que las imágenes estén en `C:\OEMInfo`.

## Modos de ejecución

Windows invoca el protector con los siguientes argumentos:

| Argumento | Modo | Comportamiento |
|---|---|---|
| `/s` | Pantalla completa | Muestra el protector en todos los monitores. |
| `/p <hwnd>` | Vista previa | Dibuja el protector dentro de la ventana de vista previa del panel de configuración. |
| `/c` | Configuración | Abre la ventana de información. |
| (sin argumentos) | Configuración | Igual que `/c`. |

También se aceptan argumentos con dos puntos, por ejemplo `/p:1234567`.

Para probarlo manualmente desde la consola:

```
ProtectorPantalla.exe /s
```

## Funcionamiento interno

- `clockTimer` (1000 ms): actualiza la fecha y la hora, ajusta el color del texto y avanza un paso del ciclo de color del fondo (0 a 255). Tras 510 segundos, el fondo se mantiene en negro durante unos 120 segundos y luego el ciclo se reinicia.
- `cuadroTimer` (1 ms): desplaza el logo con una velocidad aleatoria de 1 a 3 píxeles por paso, invirtiendo la dirección al llegar a los bordes.
- La salida se produce con cualquier tecla, un clic o un movimiento del ratón superior a 5 píxeles. En modo vista previa estos eventos se ignoran.

## Personalización

Los principales parámetros se encuentran en `ScreenSaverForm.cs`:

| Variable | Valor por defecto | Uso |
|---|---|---|
| `intColorInit` | 255 | Valor máximo de brillo del fondo. |
| `intTimeStep` | 510 | Segundos antes de iniciar el periodo en negro. |
| `intTimeStepMax` | 630 | Segundo en el que termina el periodo en negro y se reinicia el ciclo. |

El texto del pie de pantalla (`lblPropietario`) y el mensaje de salida (`lblSalir`) se modifican en `ScreenSaverForm.Designer.cs`.

## Licencia

© 2025 404q9l, FoxShell. Todos los derechos reservados.
