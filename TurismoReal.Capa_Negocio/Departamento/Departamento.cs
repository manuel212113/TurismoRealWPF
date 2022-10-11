using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Capa_Negocio.Departamento
{
    public  class Departamento
    {



        public string iddepa { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
        public string metroscuadrados { get; set; }
        public string habitaciones { get; set; }
        public string banos { get; set; }
        public string region { get; set; }
        public string comuna { get; set; }
        public string valorarriendo { get; set; }
        public string fecha { get; set; }
        public string habilitado { get; set; }

        public Departamento()
        {
            this.Init();
        }

        public void Init()
        {
            iddepa = string.Empty;
            nombre = string.Empty;
            direccion = string.Empty;
            descripcion = string.Empty;
            metroscuadrados = string.Empty;
            habitaciones = string.Empty;
            banos = string.Empty;
            region = string.Empty;
            comuna = string.Empty;
            valorarriendo = string.Empty;
            fecha = string.Empty;
            habilitado = string.Empty;
        }

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

        public void CrearDepartamento()
        {

        }


        public ObservableCollection<Departamento> CargarDepartamentos(ObservableCollection<Departamento> listaDepa)
        {
            
            try
            {
                cone.Open();
                OracleCommand comando_listar_depa = new OracleCommand("FN_LISTAR_DEPA", cone);
                comando_listar_depa.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_listar_depa.Parameters.Add("LDP_CURSOR", OracleDbType.RefCursor);

                lista_salida.Direction = System.Data.ParameterDirection.ReturnValue;

                comando_listar_depa.ExecuteNonQuery();

                OracleDataReader lector = ((OracleRefCursor)lista_salida.Value).GetDataReader();

                while (lector.Read())
                {
                    Departamento DEPA = new Departamento();

                    DEPA.iddepa = lector.GetString(0);
                    DEPA.nombre = lector.GetString(1);
                    DEPA.direccion = lector.GetString(2);
                    DEPA.descripcion = lector.GetString(3);
                    DEPA.metroscuadrados = lector.GetString(4);
                    DEPA.habitaciones = lector.GetString(5);
                    DEPA.banos = lector.GetString(6);
                    DEPA.region = lector.GetString(7);
                    DEPA.comuna = lector.GetString(8);
                    DEPA.valorarriendo = lector.GetString(9);
                    DEPA.fecha = lector.GetString(10);
                    DEPA.habilitado = lector.GetString(11);

                    listaDepa.Add(DEPA);
                }
                try
                {
                    return listaDepa;
                }
                catch(Exception e)
                {
                    return listaDepa;
                    MessageBox.Show(e.Message); 
                }
               


            }
            catch (Exception e)
            {
                return listaDepa;

                Console.WriteLine(e.Message);
            }


        }
    }
}
