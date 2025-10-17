using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class PoolMensajes
    {
        // Listas para guardar los mensajes disponibles
        private List<IMensaje> smsDisponibles = new List<IMensaje>();
        private List<IMensaje> emailsDisponibles = new List<IMensaje>();
        private List<IMensaje> pushsDisponibles = new List<IMensaje>();

        public PoolMensajes()
        {
            // Aqui podemos aumentar la cantidad inicial si se desea
            for (int i = 0; i < 9; i++)
            {
                smsDisponibles.Add(new SMS());
                emailsDisponibles.Add(new Email());
                pushsDisponibles.Add(new PushNotification());
            }
        }

        // Pedir un mensaje del pool
        public IMensaje ObtenerMensaje(string tipo)
        {
            List<IMensaje> pool = null;

            // Elegir el pool correcto según el tipo
            switch (tipo.ToLower())
            {
                case "sms":
                    pool = smsDisponibles;
                    break;
                case "email":
                    pool = emailsDisponibles;
                    break;
                case "push":
                    pool = pushsDisponibles;
                    break;
            }

            // Si hay mensajes disponibles, tomar uno
            if (pool.Count > 0)
            {
                var mensaje = pool[0];
                pool.RemoveAt(0);
                Console.WriteLine($"Tomando {tipo} del pool");
                return mensaje;
            }
            else
            {
                // Si no hay, crear uno nuevo
                Console.WriteLine($"Creando nuevo {tipo} (pool vacío)");
                switch (tipo.ToLower())
                {
                    case "sms": return new SMS();
                    case "email": return new Email();
                    case "push": return new PushNotification();
                    default: return null;
                }
            }
        }

        // Devolver un mensaje al pool
        public void DevolverMensaje(IMensaje mensaje)
        {
            // Limpiar el mensaje para reusarlo
            mensaje.Limpiar();

            // Devolverlo al pool correcto
            switch (mensaje.Tipo.ToLower())
            {
                case "sms":
                    smsDisponibles.Add(mensaje);
                    break;
                case "email":
                    emailsDisponibles.Add(mensaje);
                    break;
                case "push":
                    pushsDisponibles.Add(mensaje);
                    break;
            }
            Console.WriteLine($"Devolviendo {mensaje.Tipo} al pool");
        }

        // Mostrar cuantos mensajes hay disponibles
        public void MostrarEstadisticas()
        {
            Console.WriteLine($"\nSMS disponibles: {smsDisponibles.Count}");
            Console.WriteLine($"Emails disponibles: {emailsDisponibles.Count}");
            Console.WriteLine($"Push disponibles: {pushsDisponibles.Count}");
        }
    }
}
