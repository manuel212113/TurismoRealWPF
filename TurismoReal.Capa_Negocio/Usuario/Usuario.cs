using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        public string _rut { get; set; }
        public string _nombre { get; set; }
        public string _email { get; set; }
        public string _genero { get; set; }
        public string _apellido { get; set; }
        public string _celular { get; set; }
        
        public string _desc_tipo_usuario { get; set; }



        OracleConnection cone = new OracleConnection(
            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        public Usuario()
        {
            this.Init();
        }

        public void Init()
        {
            _rut = string.Empty;
            _nombre = string.Empty;
            _apellido = string.Empty;
            _email = string.Empty;
            _genero = string.Empty;
            _celular = string.Empty;
            _desc_tipo_usuario = string.Empty;
        }



        public bool Login(TextBox txtUsuario, PasswordBox contraseña)
        {

          

            cone.Open();

            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE EMAIL = :Usuario AND TIPO_USUARIO_ID_TIPO_USUARIO=2 AND CONTRASENA = :Contra", cone);

            comando.Parameters.Add(":Usuario", txtUsuario.Text);
            comando.Parameters.Add(":Contra", contraseña.Password);

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

                    usuar._rut = lector.GetString(0);
                    usuar._nombre = lector.GetString(1);
                    usuar._apellido = lector.GetString(4);
                    usuar._email = lector.GetString(2);
                    usuar._genero = lector.GetString(3);
                    usuar._celular = lector.GetString(5);
                    usuar._desc_tipo_usuario=lector.GetString(7);


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