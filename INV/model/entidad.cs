using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INV.model
{
    class entidad
    {
        private int id_entidad;

        private string nom_entidad;
        private string ref_entidad;
        private double valor_invInicial;
        public entidad()
        {
		}

        public int Id_entidad
        {
            get
            {
                return id_entidad;
            }
            set
            {
                id_entidad = value;
            }
        }

        public string Nom_entidad
        {
            get
            {
                return nom_entidad;
            }
            set
            {
                nom_entidad = value;
            }
        }
        public string Ref_entidad
        {
            get
            {
                return ref_entidad;
            }
            set
            {
                ref_entidad = value;
            }
        }

        public double Valor_invInicial
        {
            get
            {
                return valor_invInicial;
            }
            set
            {
                valor_invInicial = value;
            }
        }
    }
}
