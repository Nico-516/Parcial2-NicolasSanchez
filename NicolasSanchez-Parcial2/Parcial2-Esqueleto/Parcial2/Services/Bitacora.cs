using System;
using System.Collections.Generic;
using System.IO;

namespace Parcial2.Services
{
    // TODO 3 · Singleton
    // >>> PROBLEMA: abrí "Bitácora" en la app: aparece vacía, aunque el sistema registró cosas.
    //     Y en Datos/bitacora.log todas las líneas dicen #001.
    // Convertí esta clase en un Singleton de verdad (las tres reglas) sin cambiar
    // la forma en que la usan los demás: Bitacora.Instancia.Registrar("...").
    public class Bitacora
    {
        private static Bitacora _instancia;

        private readonly List<string> _entradas = new List<string>();
        private int _numero = 0;
        private readonly string _ruta = Path.Combine(AppContext.BaseDirectory, "Datos", "bitacora.log");

        private Bitacora() { }

        public static Bitacora Instancia
        {
            get
            {
                if (_instancia == null) 
                { _instancia = new Bitacora(); }
                return _instancia;
            }
        }

        public void Registrar(string mensaje)
        {
            _numero++;
            string linea = $"#{_numero:000}  [{DateTime.Now:dd/MM HH:mm:ss}]  {mensaje}";
            _entradas.Add(linea);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_ruta));
                File.AppendAllText(_ruta, linea + Environment.NewLine);
            }
            catch (IOException)
            {
                // Si el disco falla, la bitácora en memoria sigue funcionando: no frenamos la venta por un log.
            }
        }

        public List<string> ObtenerEntradas()
        {
            return new List<string>(_entradas);   // una copia: nadie de afuera puede borrar el historial
        }
    }
}
