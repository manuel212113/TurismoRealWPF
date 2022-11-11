using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TurismoReal.Capa_Negocio.Usuario;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para ActualizarUsuarioWEB.xaml
    /// </summary>
    public partial class ActualizarUsuarioWEB : Window
    {
        public ActualizarUsuarioWEB(string rut_seleccionado,string email_seleccionado, string contrasena_seleccionada, string celular_seleccionado, string tipo_usuario_seleccionado)
        {
            InitializeComponent();
            AgregarDatosFormulario(rut_seleccionado, email_seleccionado, celular_seleccionado, tipo_usuario_seleccionado);
        }


        public void AgregarDatosFormulario(string rut, string correo, string celular, string tipo_usuario)
        {
            txtRutActualizar.Text = rut;
            txtACorreoActualizar.Text = correo;
            txtCelularActualizar.Text = celular;
            txtTipoUsuarioActualizar_.Text = tipo_usuario;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

            Usuario usr = new Usuario();
            if(txtRutActualizar.Text.Length>1 && txtACorreoActualizar.Text.Length>1 && txtCelularActualizar.Text.Length>1 && txtTipoUsuarioActualizar_.Text.Length>1)
            {
                usr.ActualizarUsuarioWeb(txtRutActualizar.Text, txtACorreoActualizar.Text, txtCelularActualizar.Text, txtTipoUsuarioActualizar_.Text);

            }
            else
            {
                MessageBox.Show("no puede haber campos vacios");
            }
        }
    }
}
