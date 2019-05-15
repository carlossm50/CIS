using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INV.model
{
    public class invhistoricom
    {
        private int id_historico;
        private double valor_productos;
        private double valor_cxp;
        private double valor_cxc;
        private double valor_efectivo;
        private double valor_gasto;
        private double valor_invInicial;
        private DateTime fecha_inventario;
        private int id_entidad;

        public int Id_historico
        {
            get
            {
                return id_historico;
            }
            set
            {
                id_historico = value;
            }
        }
        public double Valor_productos
        {
            get
            {
                return valor_productos;
            }
            set
            {
                valor_productos = value;
            }
        }
        public double Valor_cxp
        {
            get
            {
                return valor_cxp;
            }
            set
            {
                valor_cxp = value;
            }
        }
        public double Valor_cxc
        {
            get
            {
                return valor_cxc;
            }
            set
            {
                valor_cxc = value;
            }
        }
        public double Valor_efectivo
        {
            get
            {
                return valor_efectivo;
            }
            set
            {
                valor_efectivo = value;
            }
        }
        public double Valor_gasto
        {
            get
            {
                return valor_gasto;
            }
            set
            {
                valor_gasto = value;
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
        public DateTime Fecha_inventario
        {
            get
            {
                return fecha_inventario;
            }
            set
            {
                fecha_inventario = value;
            }
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
    }
}
