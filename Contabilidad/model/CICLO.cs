using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad.model
{
    public class CICLO
    {
        string aniociclo;
        string estado;
        public CICLO()
        {

        }
        public string Anio {
            get {
                return aniociclo;
            }
            set {
                aniociclo = value;
            }
    }
        public string Estado {
            get {
                return estado;
            }
            set {
                estado = value;
            }
        }
    }
}
