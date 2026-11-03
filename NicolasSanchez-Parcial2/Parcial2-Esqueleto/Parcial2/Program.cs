using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Parcial2.Controllers;
using Parcial2.Models;
using Parcial2.Repository;
using Parcial2.Views;

namespace Parcial2
{
    internal static class Program
    {
        // Composition Root: el ÚNICO lugar donde se arma el sistema.
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-AR");

            string carpetaDatos = Path.Combine(AppContext.BaseDirectory, "Datos");
            Directory.CreateDirectory(carpetaDatos);

            // Los repositorios se crean UNA sola vez: inyección de dependencias directa, sin factory.
            IRepository<OrdenTrabajo> ordenes = new JsonRepository<OrdenTrabajo>(Path.Combine(carpetaDatos, "ordenes.json"));
            IRepository<Servicio> servicios = new JsonRepository<Servicio>(Path.Combine(carpetaDatos, "servicios.json"));

            var ordenController = new OrdenController(ordenes, servicios);
            var comprobanteController = new ComprobanteController(ordenes);

            var formPrincipal = new FormPrincipal(ordenController, comprobanteController);

            // TODO 7 · Observer: acá se decide QUIÉN escucha al ordenController.
            //   - HistorialObserver
            //   - AvisoClienteObserver (archivo Datos/avisos_clientes.txt)
            //   - el formPrincipal (ya implementa IOrdenObserver)

            Application.Run(formPrincipal);
        }
    }
}
