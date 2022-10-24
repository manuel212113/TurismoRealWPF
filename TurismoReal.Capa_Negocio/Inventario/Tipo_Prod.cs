using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media.TextFormatting;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;

namespace TurismoReal.Capa_Negocio.Inventario
{
    public class Tipo_Prod
    {
        public string ID_CAT { get; set; }
        public string NOMBRE_CATEGORIA { get; set; }


        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        public Tipo_Prod()
        {
            this.Init();
        }
        public void Init()
        {
            ID_CAT = string.Empty;
            NOMBRE_CATEGORIA = string.Empty;
        }

        public ObservableCollection<Tipo_Prod> CargarCategoria(ObservableCollection<Tipo_Prod> ListaCategoria)
        {

            try
            {
                cone.Open();
                OracleCommand comando_lista_Catego = new OracleCommand("FN_LISTAR_CAT", cone);
                comando_lista_Catego.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_lista_Catego.Parameters.Add("L_CURS", OracleDbType.RefCursor);

                lista_salida.Direction = System.Data.ParameterDirection.ReturnValue;

                comando_lista_Catego.ExecuteNonQuery();

                OracleDataReader lector = ((OracleRefCursor)lista_salida.Value).GetDataReader();

                while (lector.Read())
                {
                    Tipo_Prod Inven = new Tipo_Prod();

                    Inven.ID_CAT = lector.GetString(0);
                    Inven.NOMBRE_CATEGORIA = lector.GetString(1);



                    ListaCategoria.Add(Inven);
                }
                cone.Close();
                return ListaCategoria;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ListaCategoria;

            }

        }

    }
}
