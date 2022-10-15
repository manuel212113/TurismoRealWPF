using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OracleClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;

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

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

       

        public void AgregarDepartamento(string iddepa, string nombre, string direccion, string descripcion, string metroscuadrados, string habitaciones, string banos, string region, string comuna, string valorarriendo, string fecha, string habilitado)
        {
            try
            {
                cone.Open();
                OracleCommand ComandoAgregar = new OracleCommand("SP_Crear_Departamento", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("id_depa", iddepa);
                ComandoAgregar.Parameters.Add("nombre", nombre);
                ComandoAgregar.Parameters.Add("direccion", direccion);
                ComandoAgregar.Parameters.Add("descripcion", descripcion);
                ComandoAgregar.Parameters.Add("metros_cuadrados", metroscuadrados);
                ComandoAgregar.Parameters.Add("habitaciones", habitaciones);
                ComandoAgregar.Parameters.Add("banos", banos);
                ComandoAgregar.Parameters.Add("region", region);
                ComandoAgregar.Parameters.Add("comuna", comuna);
                ComandoAgregar.Parameters.Add("valor_arriendo", valorarriendo);
                ComandoAgregar.Parameters.Add("fecha", fecha);
                ComandoAgregar.Parameters.Add("habilitado", habilitado);

                ComandoAgregar.ExecuteNonQuery();
                MessageBox.Show("Departamento agregado a la base de datos");
                cone.Close();
            }
            catch
            {
                MessageBox.Show("No se agrego el Departamento a la base de datos");
                cone.Close();

            }

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


        public void  EliminarDepartamento(string ID_DEPA)
        {
            try
            {
                cone.Open();
                OracleCommand comandoEliminarDepa = new OracleCommand("SP_Eliminar_Depa", cone);
                comandoEliminarDepa.CommandType = System.Data.CommandType.StoredProcedure;
                comandoEliminarDepa.Parameters.Add("ID_DEPA", OracleType.VarChar).Value = ID_DEPA;
                MessageBox.Show("Departamento Eliminado de la base de datos");
                comandoEliminarDepa.ExecuteNonQuery();
                cone.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                

            }
        }
    }
}
