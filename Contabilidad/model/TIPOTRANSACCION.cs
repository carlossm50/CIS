///////////////////////////////////////////////////////////
//  TIPOTRANSACCION.cs
//  Implementation of the Class TIPOTRANSACCION
//  Generated by Enterprise Architect
//  Created on:      01-nov-2018 09:54:31 p.m.
//  Original author: User
///////////////////////////////////////////////////////////




namespace Contabilidad {
	public class TIPOTRANSACCION {

        private int cnttiptrnid;
        private string cnttiptrnnombre;

		public TIPOTRANSACCION(){

		}

		~TIPOTRANSACCION(){

		}

		public virtual void Dispose(){

		}

		public int Cnttiptrnid{
			get{
				return cnttiptrnid;
			}
			set{
				cnttiptrnid = value;
			}
		}

		public string Cnttiptrnnombre{
			get{
				return cnttiptrnnombre;
			}
			set{
				cnttiptrnnombre = value;
			}
		}

	}//end TIPOTRANSACCION

}//end namespace Contabilidad