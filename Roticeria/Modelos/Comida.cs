using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roticeria.Modelos
{
    public class Comida
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string ingredientes { get; set; }
        public int precio { get; set; }
        public int puntaje { get; set; }
       
        public string portada_url { get; set; }

        public override string ToString()
        {
            return nombre + " - " + ingredientes;
        }
    }
}

