using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE MENSAJES ===\n");

            // Probamos que el Singleton funciona
            var admin1 = AdministrarNotificaciones.ObtenerInstancia();
            var admin2 = AdministrarNotificaciones.ObtenerInstancia();

            // Deberían ser la misma instancia
            Console.WriteLine($"¿Son la misma instancia?");
            Console.WriteLine(ReferenceEquals(admin1, admin2));

            // Enviamos algunos mensajes
            Console.WriteLine("\n--- ENVIANDO MENSAJES ---");

            admin1.EnviarSMS("+123456789", "Hola somos de telcel por favor envienos su numero de tarjeta, su fecha de vencimiento y su cvc");
            Console.WriteLine();
            admin1.EnviarEmail("usuario@email.com", "Hola le enviamos este correo porque se gano un IPHONE 17PRO no deje pasar esta oportunidad!!");
            Console.WriteLine();    
            admin1.EnviarPush("dispositivo IPHONE 17 PRO", "Compra un cargador nuevo ya!!");
            Console.WriteLine();

            admin2.EnviarEmail("1234565", "");
            // Mostramos estadísticas finales
            admin1.MostrarEstadisticas();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
