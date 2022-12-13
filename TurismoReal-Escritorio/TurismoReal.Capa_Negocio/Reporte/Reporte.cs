using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;

namespace TurismoReal.Capa_Negocio.Reportes
{
    public class Reporte
    {

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");




        public bool GenerarReporte(string region, string fecha_tipo, ref string ganancias_f, ref string cantidad_reserva_f)
        {
            try
            {
                cone.Open();


                OracleCommand Comando = new OracleCommand("SP_REPORTE", cone);
                Comando.CommandType = System.Data.CommandType.StoredProcedure;
                Comando.Parameters.Add("V_REGION", region);
                Comando.Parameters.Add("TIPO_FECHA", fecha_tipo);

                Comando.Parameters.Add("GANANCIAS_V", OracleDbType.Varchar2, 100, null, ParameterDirection.Output);
                Comando.Parameters.Add("V_CANTIDAD_RESERVAS", OracleDbType.Varchar2, 100, null, ParameterDirection.Output);
                Comando.Parameters.Add("V_SALIDA", OracleDbType.Varchar2, 100, null, ParameterDirection.Output);
                Comando.ExecuteNonQuery();


                string cant_reserva = Comando.Parameters["V_CANTIDAD_RESERVAS"].Value.ToString();
                string ganancias = Comando.Parameters["GANANCIAS_V"].Value.ToString();
                string v_salida = Comando.Parameters["V_SALIDA"].Value.ToString();


                if (ganancias == "null" || ganancias == "" || cant_reserva == "null" || cant_reserva == "")
                {

                    cone.Close();
                    return false;

                }
                else
                {

                    ganancias_f = ganancias;

                    cantidad_reserva_f = cant_reserva;


                    cone.Close();
                    return true;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;

            }

        }
    }
}