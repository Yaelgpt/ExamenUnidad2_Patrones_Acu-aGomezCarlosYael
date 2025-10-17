using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class AdministrarNotificaciones
    {
        // Esta es la única instancia que existirá
        private static AdministrarNotificaciones _instancia;
        private static readonly object _lock = new object();

        private PoolMensajes _pool;
        private int _mensajesEnviados;

        private AdministrarNotificaciones()
        {
            _pool = new PoolMensajes();
            _mensajesEnviados = 0;
            Console.WriteLine("Se creó el Administrador de Notificaciones");
        }

        // Método público para obtener la instancia
        public static AdministrarNotificaciones ObtenerInstancia()
        {
            // Si no existe la instancia, la creamos
            lock (_lock)
            {
                if (_instancia == null)
                {
                    _instancia = new AdministrarNotificaciones();
                }
                return _instancia;
            }
        }

        // Método para enviar SMS
        public void EnviarSMS(string numero, string mensaje)
        {
            var sms = _pool.ObtenerMensaje("sms");
            sms.Configurar(numero, mensaje);
            sms.Enviar();
            _mensajesEnviados++;
            _pool.DevolverMensaje(sms);
        }

        // Método para enviar Email
        public void EnviarEmail(string email, string mensaje)
        {
            var emailObj = _pool.ObtenerMensaje("email");
            emailObj.Configurar(email, mensaje);
            emailObj.Enviar();
            _mensajesEnviados++;
            _pool.DevolverMensaje(emailObj);
        }

        // Método para enviar Push
        public void EnviarPush(string dispositivo, string mensaje)
        {
            var push = _pool.ObtenerMensaje("push");
            push.Configurar(dispositivo, mensaje);
            push.Enviar();
            _mensajesEnviados++;
            _pool.DevolverMensaje(push);
        }

        public void MostrarEstadisticas()
        {
            Console.WriteLine($"\n=== ESTADÍSTICAS ===");
            Console.WriteLine($"Total mensajes enviados: {_mensajesEnviados}");
            _pool.MostrarEstadisticas();
        }
    }
}
