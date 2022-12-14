using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using RestSharp;
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
        public string CONTRASENA { get; set; }


        public string TIPOUSUARIO { get; set; }
        public string HABILITADO { get; set; }



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
            CONTRASENA = string.Empty;
            HABILITADO = string.Empty;

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

             
           string  contra_encriptada = EncriptarContraseña(contraseña.Password.ToString());
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE EMAIL = :Usuario AND TIPO_USUARIO_ID_TIPO_USUARIO=2 AND CONTRASENA = :Contra", cone);

            comando.Parameters.Add(":Usuario", txtUsuario.Text);
            comando.Parameters.Add(":Contra", contra_encriptada);


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }

        public bool AgregarUsuario(string rut, string nombre, string email, string genero, string contrasena, string apellido, string celular, string tipo_user)
        {
            try
            {

                if(rut.Length>1 && nombre.Length>1 && email.Length>1 && genero.Length>1 && contrasena.Length>1 && apellido.Length>1 && celular.Length>1  && tipo_user.Length>=1)
                {
                    int.Parse(tipo_user);
                    contrasena = EncriptarContraseña(contrasena);
                    cone.Open();
                    OracleCommand comando3 = new OracleCommand("SP_CREAR_USUARIO", cone);
                    comando3.CommandType = System.Data.CommandType.StoredProcedure;
                    comando3.Parameters.Add("rut", rut);
                    comando3.Parameters.Add("nombre", nombre);
                    comando3.Parameters.Add("email", email);
                    comando3.Parameters.Add("genero", genero);
                    comando3.Parameters.Add("contrasena", contrasena);
                    comando3.Parameters.Add("apellido", apellido);
                    comando3.Parameters.Add("celular", celular);
                    comando3.ExecuteNonQuery();
                    MessageBox.Show("Persona agregada a la base de datos");
                    cone.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("No puede haber campos vacios");

                    return false;
                }
               
            }
            catch (Exception e)
            {
                cone.Close();
                MessageBox.Show(e.Message);
                return false;

            }

        }


        public bool EliminarUsuario_WEB(string rut)
        {
            try
            {
                cone.Open();
                OracleCommand comandoEliminar = new OracleCommand("SP_Eliminar_usuario_WEB", cone);
                comandoEliminar.CommandType = System.Data.CommandType.StoredProcedure;
                comandoEliminar.Parameters.Add("RUT_ELIMINAR", rut);
                comandoEliminar.ExecuteNonQuery();
                MessageBox.Show("Usuario Eliminado de la base de datos");

                cone.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cone.Close();
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
                comandoEliminar.Parameters.Add("RUT_ELIMINAR" ,rut);
                comandoEliminar.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Usuario Eliminado de la base de datos");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
        }

        public ObservableCollection<Usuario> CargarFuncionarioCliente(ObservableCollection<Usuario> lista_usr)
        {

            try
            {
                cone.Open();
                OracleCommand comando_listar_usr = new OracleCommand("FN_LISTAR_USUARIOS_WEB", cone);
                comando_listar_usr.CommandType = System.Data.CommandType.StoredProcedure;


                OracleParameter lista_salida = comando_listar_usr.Parameters.Add("LD_CURSOR", OracleDbType.RefCursor);

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
                    usuar.GENERO = "Desconocido";
                    usuar.CELULAR = lector.GetString(5);
                    usuar.TIPOUSUARIO = lector.GetString(7);
                    usuar.CONTRASENA = "Encriptada";


                    lista_usr.Add(usuar);
                }
                cone.Close();
                return lista_usr;




            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        

    }

        public string ActualizarUsuario(string rut, string correo, string contrasena, string celular)
        {


            try
            {
                cone.Open();
                string contra_encriptada = EncriptarContraseña(contrasena);

                OracleCommand ComandoAgregar = new OracleCommand("SP_ACTUALIZAR_USUARIO", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("RUT_ACTUALIZAR", rut);
                ComandoAgregar.Parameters.Add("EMAIL_AC", correo);
                ComandoAgregar.Parameters.Add("CONTRASENA_AC", contra_encriptada);
                ComandoAgregar.Parameters.Add("CELULAR_AC", celular);
                ComandoAgregar.Parameters.Add("TIPO_USUARIO_AC", "2");
      

                ComandoAgregar.ExecuteNonQuery();
                MessageBox.Show("Usuario Actualizado Correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                cone.Close();
                return "Exito";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Actualizar el Usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                cone.Close();

                MessageBox.Show(ex.Message);
                return "Error";


            }
        
    }

        public void ActualizarUsuarioWeb(string rut , string correo , string celular, string tipo_usuario)
        {
            try
            {
                var client = new RestClient("http://127.0.0.1:8000/");
                // client.Authenticator = new HttpBasicAuthenticator(username, password);
                var request = new RestRequest("api/v1/Usuario/actualizar");
                request.AddParameter("RUT", rut);
                request.AddParameter("correo", correo);
                request.AddParameter("celular", celular);
                request.AddParameter("tipo_usuario", tipo_usuario);
                request.AddParameter("token", "18oL6ZCi8ur5rMgBM1W1yC7JN07");
                MessageBox.Show(client.ToString());


                var response = client.Post(request);
                var content = response.Content;
                if (content.Contains("Exito"))
                {
                    MessageBox.Show("Usuario Actualizado Correctamente");
                }
                else
                {
                    MessageBox.Show("No se puso Actualizar el Usuario");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo establecer conexion con la pagina web");

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
                    usuar.TIPOUSUARIO = lector.GetString(7);
                    usuar.CONTRASENA = lector.GetString(8);


                    lista_usr.Add(usuar);
                }



                cone.Close();
                lista_usr=CargarFuncionarioCliente(lista_usr);
                dataGrid.ItemsSource = lista_usr;
                dataGrid.Items.Refresh();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }



    }
}