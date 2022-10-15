﻿using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.ObjectModel;
using System.Data.OracleClient;
using System.Diagnostics;
using System.IO;
using System.Windows;
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


        public void AbrirVentanaArchivoImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                MessageBox.Show(filename);
                SubirImagen(filename);


            }

        }



        public void  SubirImagen( string pathfoto)
        {
            try
            {

                var client = new ImgurClient("a677cc15537cab0", "f6d689a421b3d132b522715e9e5eb1f3ff231b0c");
                var endpoint = new ImageEndpoint(client);
                IImage image;
                string path = pathfoto;
                try
                {

                    if (File.Exists(path))
                    {

                        using (var fs = new FileStream(path, FileMode.Open))
                        {
                            image = endpoint.UploadImageStreamAsync(fs).GetAwaiter().GetResult();
                        }
                        MessageBox.Show("image uploaded");
                        MessageBox.Show(image.Link);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Произошла ошибка при загрузке изображения");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred uploading an image to Imgur.");
                Debug.Write(ex.Message);
            }


        }
    }
}
