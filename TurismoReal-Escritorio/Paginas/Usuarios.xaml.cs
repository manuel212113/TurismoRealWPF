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
using TurismoReal.Capa_Negocio.Cliente;
using System.Data;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Usuarios : Page
    {

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");

        Usuario usr = new Usuario();

        ObservableCollection<Usuario> usuarios_l = new ObservableCollection<Usuario>();
        public Usuarios()
        {
            InitializeComponent();


            usr.CargarUsuarios(usuarios_l, UsuarioDatagrid);
            TXTTotalusuarios.Text = "USUARIOS: "+ usuarios_l.Count.ToString();
            this.PreviewKeyDown += (ss, ee) =>
            {
                if (ee.Key == Key.Escape)
                {
                    VentanaAgregarusario.IsOpen = false;
                }
            };
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarusario.IsOpen = true;

        }


        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (TxtTipo.Text == "Administrador")
            {
                TxtTipo.Text = "2";

            }
         

            try
            {
                 


                if(usr.AgregarUsuario(TxtRUT.Text, TxtNombre.Text, TxtCorreo.Text, TxtGenero.Text, TxtContrasena.Text, TxtApellido.Text, TxtCelular.Text, TxtTipo.Text))
                {
                    VentanaAgregarusario.IsOpen = false;

                }
                else
                {

                    this.PreviewKeyDown += (ss, ee) =>
                    {
                        if (ee.Key == Key.Escape)
                        {
                            VentanaAgregarusario.IsOpen = false;

                        }
                    };

                }

            }
            catch
            {
                MessageBox.Show("No se agrego la persona a la base de datos");
                cone.Close();

            }

        }

        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var usuarioSeleccionado = UsuarioDatagrid.SelectedItem as Usuario;
                string rut_seleccionado = usuarioSeleccionado.RUT;
                string genero = usuarioSeleccionado.GENERO;
                string nombre_completo_seleccionado=usuarioSeleccionado.NOMBRE +" " +usuarioSeleccionado.APELLIDO;

                MessageBoxResult dialogResult = MessageBox.Show("Estas seguro de eliminar a :"+nombre_completo_seleccionado  , "Eliminar Usuario:"+rut_seleccionado, MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    try
                    {

                        Usuario usr = new Usuario();


                        if (genero == "Desconocido")
                        {
                            usr.EliminarUsuario_WEB(rut_seleccionado);
                        }else{
                            usr.EliminarUsuario(rut_seleccionado);

                        }

                        usuarios_l.Clear();
                        usr.CargarUsuarios(usuarios_l, UsuarioDatagrid);
                        UsuarioDatagrid.Items.Refresh();
                        TXTTotalusuarios.Text = "USUARIOS: " + usuarios_l.Count.ToString();


                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                else if (dialogResult == MessageBoxResult.No)
                {
                    //do something else
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

      
        

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            var usuarioSeleccionado = UsuarioDatagrid.SelectedItem as Usuario;
            string rut_seleccionado = usuarioSeleccionado.RUT;
            string  contrasena_seleccionada= usuarioSeleccionado.CONTRASENA;
            string email_seleccionado = usuarioSeleccionado.EMAIL;
            string celular_seleccionado = usuarioSeleccionado.CELULAR;
            string tipo_usuario_seleccionado = usuarioSeleccionado.TIPOUSUARIO;
            if (usuarioSeleccionado.GENERO == "Desconocido")
            {
                ActualizarUsuarioWEB pagina_actualizar_cliente_funcionario = new ActualizarUsuarioWEB(rut_seleccionado, email_seleccionado, contrasena_seleccionada, celular_seleccionado, tipo_usuario_seleccionado);

                pagina_actualizar_cliente_funcionario.Show();
            }
            else
            {
                ActualizarUsuario pagina_actualizar = new ActualizarUsuario(rut_seleccionado, email_seleccionado, contrasena_seleccionada, celular_seleccionado, tipo_usuario_seleccionado);

                pagina_actualizar.Show();
            }

           
        }
    }
}
