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

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

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

    }

}
