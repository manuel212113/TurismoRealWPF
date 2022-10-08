﻿using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OracleClient;
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

namespace TurismoReal.Capa_Negocio.Usuario
{
    public class Usuario
    {
        public string RUT { get; set; }
        public string NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public string GENERO { get; set; }
        public string APELLIDO { get; set; }
        public string CELULAR { get; set; }

        public string TIPOUSUARIO { get; set; }



        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        public Usuario()
        {
            this.Init();
        }

        public void Init()
        {
            RUT = string.Empty;
            NOMBRE = string.Empty;
            APELLIDO = string.Empty;
            EMAIL = string.Empty;
            GENERO = string.Empty;
            CELULAR = string.Empty;
            TIPOUSUARIO = string.Empty;
        }



        public static string EncriptarContraseña(string contraseña)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(contraseña));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();


        }



        public bool Login(TextBox txtUsuario, PasswordBox contraseña)
        {



            cone.Open();


            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE EMAIL = :Usuario AND TIPO_USUARIO_ID_TIPO_USUARIO=2 AND CONTRASENA = :Contra", cone);

            comando.Parameters.Add(":Usuario", txtUsuario.Text);
            comando.Parameters.Add(":Contra", contraseña.Password );


            try
            {

                OracleDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    cone.Close();
                    return true;
                }
                else
                {
                    cone.Close();
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
          

        }

        public bool AgregarUsuario(TextBox rut, TextBox nombre, TextBox email,TextBox genero, TextBox contrasena,TextBox apellido, TextBox celular , TextBox tipo_user )
        {
            try
            {
                cone.Open();
                OracleCommand comando3 = new OracleCommand("SP_CREAR_USUARIO", cone);
                comando3.CommandType = System.Data.CommandType.StoredProcedure;
                comando3.Parameters.Add("RUT", OracleType.VarChar).Value = rut.Text;
                comando3.Parameters.Add("NOMBRE", OracleType.VarChar).Value = nombre.Text;
                comando3.Parameters.Add("EMAIL", OracleType.VarChar).Value = email.Text;
                comando3.Parameters.Add("GENERO", OracleType.VarChar).Value = genero.Text;
                comando3.Parameters.Add("CONTRASENA", OracleType.VarChar).Value = contrasena.Text;
                comando3.Parameters.Add("APELLIDO", OracleType.VarChar).Value = apellido.Text;
                comando3.Parameters.Add("CELULAR", OracleType.VarChar).Value = celular.Text;
                comando3.Parameters.Add("TIPO_USUARIO_ID_TIPO_USUARIO", OracleType.Int32).Value = Int32.Parse(tipo_user.Text);
                comando3.ExecuteNonQuery();
                MessageBox.Show("Persona agregada a la base de datos");
                cone.Close();
                return true;
            }
            catch
            {
                cone.Close();
                MessageBox.Show("No se agrego la persona a la base de datos");
                return false;

            }

        }



        public bool EliminarUsuario(string rut)
        {
            try
            {
                cone.Open();
                OracleCommand comandoEliminar = new OracleCommand("SP_ELIMINAR_USUARIO", cone);
                comandoEliminar.CommandType = System.Data.CommandType.StoredProcedure;
                comandoEliminar.Parameters.Add("RUT_ELIMINAR", OracleType.VarChar).Value = rut;
                MessageBox.Show("Persona agregada a la base de datos");
                cone.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
        }
        public void CargarUsuarios(ObservableCollection<Usuario> lista_usr, DataGrid dataGrid)
        {

            try
            {
                cone.Open();
                OracleCommand comando_listar_usr = new OracleCommand("FN_LISTAR_USUARIOS_NO_BLOQUEADOS", cone);
                comando_listar_usr.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_listar_usr.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);

                lista_salida.Direction = System.Data.ParameterDirection.ReturnValue;
                
                comando_listar_usr.ExecuteNonQuery();

                OracleDataReader lector = ((OracleRefCursor)lista_salida.Value).GetDataReader();

                while (lector.Read())
                {
                    Usuario usuar = new Usuario();

                    usuar.RUT = lector.GetString(0);
                    usuar.NOMBRE = lector.GetString(1);
                    usuar.APELLIDO = lector.GetString(4);
                    usuar.EMAIL = lector.GetString(2);
                    usuar.GENERO = lector.GetString(3);
                    usuar.CELULAR = lector.GetString(5);
                    usuar.TIPOUSUARIO=lector.GetString(7);


                    lista_usr.Add(usuar);
                }
                dataGrid.ItemsSource=lista_usr;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

      

    }
}