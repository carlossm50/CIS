///////////////////////////////////////////////////////////
//  TRANSACCION.cs
//  Implementation of the Class TRANSACCION
//  Generated by Enterprise Architect
//  Created on:      01-nov-2018 09:54:31 p.m.
//  Original author: User
///////////////////////////////////////////////////////////




using Contabilidad;
namespace Contabilidad {
	public class TRANSACCION {

        private int cnttrnid;
        private decimal cnttrnvalor;
        private string cnttrnconc;
        private int cnttiptrnid;

		public TRANSACCION(){

		}

		~TRANSACCION(){

		}

		public virtual void Dispose(){

		}

		public int Cnttrnid{
			get{
				return cnttrnid;
			}
			set{
				cnttrnid = value;
			}
		}

		public decimal Cnttrnvalor{
			get{
				return cnttrnvalor;
			}
			set{
				cnttrnvalor = value;
			}
		}

		public string Cnttrnconc{
			get{
				return cnttrnconc;
			}
			set{
				cnttrnconc = value;
			}
		}

		public int Cnttiptrnid{
			get{
				return cnttiptrnid;
			}
			set{
				cnttiptrnid = value;
			}
		}

	}//end TRANSACCION

}//end namespace Contabilidad