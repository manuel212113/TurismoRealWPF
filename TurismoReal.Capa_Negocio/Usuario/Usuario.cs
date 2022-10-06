using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;

namespace TurismoReal.Capa_Negocio.Usuario
{
    public class Usuario
    {
        public string _rut { get; set; }
        public string _nombre { get; set; }
        public string _email { get; set; }
        public string _genero { get; set; }
        public string _contrasena { get; set; }
        public string _apellido { get; set; }
        public string _celular { get; set; }
        public int _tipo_usuario_id_tipo_usuario { get; set; }
        
        public string _desc_tipo_usuario { get; set; }



        OracleConnection cone = new OracleConnection("DATA SOURCE = xe ; PASSWORD = 123 ; USER ID = C##TR");

        public Usuario()
        {
            this.Init();
        }

        public void Init()
        {
            _rut = string.Empty;
            _nombre = string.Empty;
            _email = string.Empty;
            _genero = string.Empty;
            _contrasena = string.Empty;
            _apellido = string.Empty;
            _celular = string.Empty;
            _tipo_usuario_id_tipo_usuario =0;
            _desc_tipo_usuario = string.Empty;
        }



        public bool Login(TextBox txtUsuario, PasswordBox contraseña)
        {

          

            cone.Open();

            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO WHERE EMAIL = :Usuario AND TIPO_USUARIO_ID_TIPO_USUARIO=2 AND CONTRASENA = :Contra", cone);

            comando.Parameters.AddWithValue(":Usuario", txtUsuario.Text);
            comando.Parameters.AddWithValue(":Contra", contraseña.Password);

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

    }
}