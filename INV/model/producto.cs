using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INV.model
{
        
    class producto
    {
        private int id_producto;
        private string nom_producto;
        private double costo_producto;
        private double precio_producto;
        private int existencia_producto;
        private int id_entidad;
        public producto()
        {

		}

        public int Id_producto
        {
            get
            {
                return id_producto;
            }
            set
            {
                id_producto = value;
            }
        }
        public string Nom_producto
        {
            get
            {
                return nom_producto;
            }
            set
            {
                nom_producto = value;
            }
        }
        public double Costo_producto
        {
            get
            {
                return costo_producto;
            }
            set
            {
                costo_producto = value;
            }
        }
        public double Precio_producto
        {
            get
            {
                return precio_producto;
            }
            set
            {
                precio_producto = value;
            }
        }
        public int Existencia_producto
        {
            get
            {
                return existencia_producto;
            }
            set
            {
                existencia_producto = value;
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
