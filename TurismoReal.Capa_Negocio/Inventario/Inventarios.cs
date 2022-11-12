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
    public class Inventarios
    {
        public string ID_INV { get; set; }
        public string PRODUCTO { get; set; }
        public string CANTIDAD { get; set; }
        public string ESTADO { get; set; }
        public string DESCRIPCION { get; set; }
        public string TIPO_PROD { get; set; }
        public string TIPO_PROD_ID_T_PR { get; set; }
        public string DEPARTAMENTO_ID_DEPA { get; set; }


        public Inventarios()
        {
            this.Init();
        }

        public void Init()
        {
            ID_INV = string.Empty;
            PRODUCTO = string.Empty;
            CANTIDAD = string.Empty;
            ESTADO = string.Empty;
            DESCRIPCION = string.Empty;
            TIPO_PROD = string.Empty;
            TIPO_PROD_ID_T_PR = string.Empty;
            DEPARTAMENTO_ID_DEPA = string.Empty;

        }

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");



        public bool ActualizarProducto(string id_producto,string PRODUCTO, string CANTIDAD, string ESTADO, string DESCRIPCION, string TIPO_PROD, string TIPO_PROD_ID_T_PR, string DEPARTAMENTO_ID_DEPA)
        {
            try
            {
                cone.Open();
                OracleCommand ComandoAgregar = new OracleCommand("SP_ACTUA_INVEN", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("ID_INV_ACTU",id_producto);
                ComandoAgregar.Parameters.Add("PRODUCTO_ACTU", PRODUCTO);
                ComandoAgregar.Parameters.Add("CANTIDAD_ACTU", CANTIDAD);
                ComandoAgregar.Parameters.Add("ESTADO_ACTU", ESTADO);
                ComandoAgregar.Parameters.Add("DESCRIPCION_ACTU", DESCRIPCION);
                ComandoAgregar.Parameters.Add("TIPO_PROD_ACTU", TIPO_PROD);
                ComandoAgregar.Parameters.Add("TIPO_PROD_ID_T_PR_ACTU", TIPO_PROD_ID_T_PR);
                ComandoAgregar.Parameters.Add("DEPARTAMENTO_ID_DEPA_ACTU", DEPARTAMENTO_ID_DEPA);

                ComandoAgregar.ExecuteNonQuery();
                MessageBox.Show("Se actualizo el producto", "Exito", MessageBoxButton.OK);
                cone.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Actualizar el producto", "Error", MessageBoxButton.OK);
                cone.Close();

                MessageBox.Show(ex.Message);
                return false;

            }
        }

        public string guardar_inventario( string PRODUCTO, string CANTIDAD, string ESTADO, string DESCRIPCION, string TIPO_PROD, string TIPO_PROD_ID_T_PR, string DEPARTAMENTO_ID_DEPA)
        {
           
            try
            {
                cone.Open();
                OracleCommand ComandoAgregar = new OracleCommand("SP_Crear_Inven", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("PRODUCTO", PRODUCTO);
                ComandoAgregar.Parameters.Add("CANTIDAD", CANTIDAD);
                ComandoAgregar.Parameters.Add("ESTADO", ESTADO);
                ComandoAgregar.Parameters.Add("DESCRIPCION", DESCRIPCION);
                ComandoAgregar.Parameters.Add("TIPO_PROD", TIPO_PROD);
                ComandoAgregar.Parameters.Add("TIPO_PROD_ID_T_PR", TIPO_PROD_ID_T_PR);
                ComandoAgregar.Parameters.Add("DEPARTAMENTO_ID_DEPA", DEPARTAMENTO_ID_DEPA);

                ComandoAgregar.ExecuteNonQuery();
                MessageBox.Show("Se agrego a la base de datos", "Exito", MessageBoxButton.OK);
                cone.Close();
                return "Exito";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se agrego a la base de datos", "Error", MessageBoxButton.OK);
                cone.Close();

                MessageBox.Show(ex.Message);
                return "Error";

            }

        }
        public bool EliminarProducto(string ID_INV)
        {
            try
            {
                cone.Open();
                OracleCommand comandoEliminar = new OracleCommand("SP_Eliminar_Produ", cone);
                comandoEliminar.CommandType = System.Data.CommandType.StoredProcedure;
                comandoEliminar.Parameters.Add("ID_INV_ELIMINAR", ID_INV);
                comandoEliminar.ExecuteNonQuery();

                MessageBox.Show("Eliminado de la base de datos");
                cone.Close();
                return true;
            }
            catch (Exception ex)
            {
                cone.Close();
                MessageBox.Show(ex.Message);
                return false;

            }
        }




        public ObservableCollection<Inventarios> CargarInventario(ObservableCollection<Inventarios> lista_Inven)
        {

            try
            {
                cone.Open();
                OracleCommand comando_lista_Inven = new OracleCommand("FN_LISTAR_INVEN", cone);
                comando_lista_Inven.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_lista_Inven.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);

                lista_salida.Direction = System.Data.ParameterDirection.ReturnValue;

                comando_lista_Inven.ExecuteNonQuery();

                OracleDataReader lector = ((OracleRefCursor)lista_salida.Value).GetDataReader();

                while (lector.Read())
                {
                    Inventarios Inven = new Inventarios();

                    Inven.ID_INV = lector.GetString(0);
                    Inven.PRODUCTO = lector.GetString(1);
                    Inven.CANTIDAD = lector.GetString(2);
                    Inven.ESTADO = lector.GetString(3);
                    Inven.DESCRIPCION = lector.GetString(4);
                    Inven.TIPO_PROD = lector.GetString(5);
                    Inven.TIPO_PROD_ID_T_PR = lector.GetString(6);
                    Inven.DEPARTAMENTO_ID_DEPA = lector.GetString(7);


                    lista_Inven.Add(Inven);
                }
                cone.Close();
                return lista_Inven;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return lista_Inven;

            }

        }



    }
}