using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;

using System.Threading.Tasks;
using System.Drawing;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Security.Policy;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Collections.ObjectModel;
using TurismoReal.Capa_Negocio.Servicios;

namespace TurismoReal.Capa_Negocio.Servicios
{
    public class Servicio_Extra
    {
        public string IDSER { get; set; }
        public string NOMBRESRV { get; set; }
        public string PRECIO { get; set; }


        public Servicio_Extra()
        {
            this.Init();
        }

        public void Init()
        {
            NOMBRESRV = string.Empty;
            PRECIO = string.Empty;
        }

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

        public string AgregarServicioExtra( string NOMBRESRV, string PRECIO)
        {

            try
            {
                cone.Open();
                OracleCommand ComandoAgregar = new OracleCommand("SP_CREAR_SERVICIO", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("NOMBRESRV", NOMBRESRV);
                ComandoAgregar.Parameters.Add("PRECIO", PRECIO);


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


        public bool EliminarServicioExtra(string IDSER)
        {
            try
            {
                cone.Open();
                OracleCommand comandoEliminar = new OracleCommand("SP_ELIMINAR_SERVICIO", cone);
                comandoEliminar.CommandType = System.Data.CommandType.StoredProcedure;
                comandoEliminar.Parameters.Add("IDSER", IDSER);
                comandoEliminar.ExecuteNonQuery();
                cone.Close();
               

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


        public ObservableCollection<Servicio_Extra> CargarInventario(ObservableCollection<Servicio_Extra> lista_Inven)
        {

            try
            {
                cone.Open();
                OracleCommand comando_lista_Inven = new OracleCommand("FN_LISTAR_SERV_EXT", cone);
                comando_lista_Inven.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_lista_Inven.Parameters.Add("L_CURSOEX", OracleDbType.RefCursor);

                lista_salida.Direction = System.Data.ParameterDirection.ReturnValue;

                comando_lista_Inven.ExecuteNonQuery();

                OracleDataReader lector = ((OracleRefCursor)lista_salida.Value).GetDataReader();

                while (lector.Read())
                {
                    Servicio_Extra Inven = new Servicio_Extra();

                    Inven.IDSER = lector.GetString(0);
                    Inven.NOMBRESRV = lector.GetString(1);
                    Inven.PRECIO = lector.GetString(2);
                 
                    

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

        public string ActualizarServicioExtra(string IDSER, string NOMBRESRV, string PRECIO)
        {

            try
            {
                cone.Open();
                OracleCommand ComandoAgregar = new OracleCommand("SP_ACTUA_SEREX", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("ID_SRV_ACTU", IDSER);
                ComandoAgregar.Parameters.Add("NOMBRESRV", NOMBRESRV);
                ComandoAgregar.Parameters.Add("PRECIO", PRECIO);

                ComandoAgregar.ExecuteNonQuery();
                MessageBox.Show("Servicio extra actualizado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                cone.Close();
                return "Exito";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se actualizo el servicio extra", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                cone.Close();

                MessageBox.Show(ex.Message);
                return "Error";


            }
        }



    }

}
