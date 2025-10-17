using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class Email : IMensaje
    {
        public string Tipo => "Email";
        private string _destinatario;
        private string _contenido;

        public void Configurar(string destinatario, string contenido)
        {
            _destinatario = destinatario;
            _contenido = contenido;
        }

        public void Enviar()
        {
            Console.WriteLine($"Enviando Email a {_destinatario}: {_contenido}");
        }

        public void Limpiar()
        {
            _destinatario = "";
            _contenido = "";
        }
    }
}
