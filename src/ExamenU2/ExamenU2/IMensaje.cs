using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public interface IMensaje
    {
        string Tipo { get; }
        void Configurar(string destinatario, string contenido);
        void Enviar();
        void Limpiar();
    }
}
