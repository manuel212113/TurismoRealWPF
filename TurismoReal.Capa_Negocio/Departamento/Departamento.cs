using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TurismoReal.Capa_Negocio.Departamento
{
    public  class Departamento
    {



        public int iddepa;
        public string nombre;
        public string direccion;
        public string descripcion;
        public int metroscuadrados;
        public int habitaciones;
        public int banos;
        public string region;
        public string comuna;
        public string valorarriendo;
        public string fecha;
        public string habilitado;

        public Departamento()
        {
            this.Init();
        }

        public void Init()
        {
            iddepa = 0;
            nombre = string.Empty;
            direccion = string.Empty;
            descripcion = string.Empty;
            metroscuadrados = 0;
            habitaciones = 0;
            banos = 0;
            region = string.Empty;
            comuna = string.Empty;
            valorarriendo = string.Empty;
            fecha = string.Empty;
            habilitado = string.Empty;
        }

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

        public void CrearDepartamento()
        {

        }


        public void LISTAR_DEPARTAMENTOS(ObservableCollection<Departamento> lista_usr, DataGrid dataGrid)
        {
            
            try
            {
                cone.Open();
                OracleCommand comando_listar_usr = new OracleCommand("FN_LISTAR_DEPA", cone);
                comando_listar_usr.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_listar_usr.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);

                lista_salida.Direction = System.Data.ParameterDirection.ReturnValue;

                comando_listar_usr.ExecuteNonQuery();

                OracleDataReader lector = ((OracleRefCursor)lista_salida.Value).GetDataReader();

                while (lector.Read())
                {
                    Departamento usuar = new Departamento();

                    usuar.iddepa = lector.GetInt32(0);
                    usuar.nombre = lector.GetString(1);
                    usuar.direccion = lector.GetString(2);
                    usuar.descripcion = lector.GetString(3);
                    usuar.metroscuadrados = lector.GetInt32(4);
                    usuar.habitaciones = lector.GetInt32(5);
                    usuar.banos = lector.GetInt32(6);
                    usuar.region = lector.GetString(7);
                    usuar.comuna = lector.GetString(8);
                    usuar.valorarriendo = lector.GetString(9);
                    usuar.fecha = lector.GetString(10);
                    usuar.habilitado = lector.GetString(11);

                    lista_usr.Add(usuar);
                }
                dataGrid.ItemsSource = lista_usr;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
