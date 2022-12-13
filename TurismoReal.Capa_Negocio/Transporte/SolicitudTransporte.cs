using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TurismoReal.Capa_Negocio.Transporte
{
    public class SolicitudTransporte
    {
        public string ID_SOLICITUD { get; set; }
        public string FECHA_SOLICITUD { get; set; }
        public string HORA_SOLICITUD { get; set; }
        public string ORIGEN { get; set; }
        public string DESTINO { get; set; }
        public string ESTADO { get; set; }

        public string ID_RESERVA { get; set; }


        public SolicitudTransporte()
        {
            this.Init();
        }

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");


        public void Init()
        {
            ID_SOLICITUD = string.Empty;
            FECHA_SOLICITUD = string.Empty;
            HORA_SOLICITUD = string.Empty;
            ORIGEN = string.Empty;  
            DESTINO= string.Empty;
            ESTADO= string.Empty;
            ID_RESERVA=string.Empty;
        }


       



    }
}
