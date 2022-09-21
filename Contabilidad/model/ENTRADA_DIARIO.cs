using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Contabilidad.model{
    public class ENTRADA_DIARIO{
        int idEntrada;
        string concepEnt;
        double valorEnt;
        DateTime fechaEnt;
        
        public ENTRADA_DIARIO() 
        { 
        }

        public int IdEntrada {
            get {
                return idEntrada;
            }
            set {
                idEntrada = value;
            }
    }
        public string ConcepEntrada {
            get {
                return concepEnt;
            }
            set {
                concepEnt = value;
            }
        }
        public double ValorEntrada {
            get {
                return valorEnt;
            }
            set {
                valorEnt = value;
            }
        }
        public DateTime Fecha {
            get {
                return fechaEnt;
            }
            set {
                fechaEnt = value;
            }
        }
        
    }
}
