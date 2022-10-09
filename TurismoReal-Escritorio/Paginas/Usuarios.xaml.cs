using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.OracleClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurismoReal.Capa_Negocio.Usuario;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Usuarios : Page
    {

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

        public Usuarios()
        {
            InitializeComponent();

            Usuario usr = new Usuario();

            ObservableCollection<Usuario> usuarios_l = new ObservableCollection<Usuario>();
            usr.CargarUsuarios(usuarios_l, UsuarioDatagrid);
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarusario.IsOpen = true;

        }


        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cone.Open();
                OracleCommand ComandoAgregar = new OracleCommand("SP_CREAR_USUARIO", cone);
                ComandoAgregar.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoAgregar.Parameters.Add("rut", OracleType.VarChar).Value = TxtRUT.Text;
                ComandoAgregar.Parameters.Add("nombre", OracleType.VarChar).Value = TxtNombre.Text;
                ComandoAgregar.Parameters.Add("email", OracleType.VarChar).Value = TxtCorreo.Text;
                ComandoAgregar.Parameters.Add("genero", OracleType.VarChar).Value = TxtGenero.Text;
                ComandoAgregar.Parameters.Add("contrasena", OracleType.VarChar).Value = TxtContrasena.Text;
                ComandoAgregar.Parameters.Add("apellido", OracleType.VarChar).Value = TxtApellido.Text;
                ComandoAgregar.Parameters.Add("celular", OracleType.VarChar).Value = TxtCelular.Text;
                ComandoAgregar.Parameters.Add("TIPO_USUARIO_ID_TIPO_USUARIO", OracleType.VarChar).Value = TxtTipo.Text;
                ComandoAgregar.ExecuteNonQuery();
                MessageBox.Show("Persona agregada a la base de datos");
                cone.Close();
            }
            catch
            {
                MessageBox.Show("No se agrego la persona a la base de datos");
                cone.Close();

            }

        }

        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
