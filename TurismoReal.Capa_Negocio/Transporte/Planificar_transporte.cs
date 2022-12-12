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

namespace TurismoReal.Capa_Negocio.Transporte
{
    public class Planificar_transporte
    {
        public string ID_PLANIFICACION { get; set; }
        public string CONDUCTOR { get; set; }
        public string AUTO { get; set; }    
        public string PATENTE { get; set; } 
        public string ID_SOLICITUD { get; set; }
    


        public Planificar_transporte()
        {
            this.Init();
        }

        public void Init()
        {
            CONDUCTOR = string.Empty;
            AUTO = string.Empty;
            PATENTE = string.Empty;

        }

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

        public string AgregarTransporte(string CONDUCTOR, string AUTO, string PATENTE)
        {

            try
            {
                cone.Open();
                OracleCommand ComandoAgregar = new OracleCommand("SP_CREAR_TRANSPORTE", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("CONDUCTOR", CONDUCTOR);
                ComandoAgregar.Parameters.Add("AUTO", AUTO);
                ComandoAgregar.Parameters.Add("PATENTE", PATENTE);


                ComandoAgregar.ExecuteNonQuery();
                MessageBox.Show("Se agrego el servicio de transporte", "Exito", MessageBoxButton.OK);
                cone.Close();
                return "Exito";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se agrego el servicio de transporte", "Error", MessageBoxButton.OK);
                cone.Close();

                MessageBox.Show(ex.Message);
                return "Error";

            }

        }

        public ObservableCollection<SolicitudTransporte> CargarTransporte(ObservableCollection<SolicitudTransporte> lista_Transporte)
        {

            try
            {
                cone.Open();
                OracleCommand comando_lista_Transporte = new OracleCommand("FN_LISTAR_SOLI_TRANSPORTE", cone);
                comando_lista_Transporte.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_lista_Transporte.Parameters.Add("SYS_REFCURSOR", OracleDbType.RefCursor);

                lista_salida.Direction = System.Data.ParameterDirection.ReturnValue;

                comando_lista_Transporte.ExecuteNonQuery();

                OracleDataReader lector = ((OracleRefCursor)lista_salida.Value).GetDataReader();

                while (lector.Read())
                {
                    SolicitudTransporte Trans = new SolicitudTransporte();

                    Trans.ID_SOLICITUD = lector.GetString(0);
                    Trans.FECHA_SOLICITUD = lector.GetString(1);
                    Trans.HORA_SOLICITUD = lector.GetString(2);
                    Trans.ORIGEN = lector.GetString(3);
                    Trans.DESTINO = lector.GetString(4);
                    Trans.ESTADO = lector.GetString(5);
                    Trans.ID_RESERVA = lector.GetString(6);






                    lista_Transporte.Add(Trans);
                }
                cone.Close();
                return lista_Transporte;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return lista_Transporte;

            }

        }

        
        public bool EliminarTransporte(string IDSER)
        {
            try
            {
                cone.Open();
                OracleCommand comandoEliminar = new OracleCommand("SP_ELIMINAR_TRANSP", cone);
                comandoEliminar.CommandType = System.Data.CommandType.StoredProcedure;
                comandoEliminar.Parameters.Add("ID_PLANIFICACION", ID_PLANIFICACION);
                comandoEliminar.ExecuteNonQuery();
                cone.Close();


                MessageBox.Show("Transporte eliminado");
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
        
    }

}
