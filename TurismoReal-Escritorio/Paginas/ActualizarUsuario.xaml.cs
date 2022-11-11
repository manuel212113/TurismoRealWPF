using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using TurismoReal.Capa_Negocio.Departamento;
using TurismoReal.Capa_Negocio.Usuario;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para ActualizarUsuario.xaml
    /// </summary>
    public partial class ActualizarUsuario : Window
    {
        public ActualizarUsuario(string rut, string correo , string contrasena, string celular, string tipo_usuario )
        {
            InitializeComponent();
            AgregarDatosFormulario(rut, correo, contrasena, celular, tipo_usuario);

        }

        public void AgregarDatosFormulario(string rut, string correo, string contrasena, string celular, string tipo_usuario)
        {
            txtRutActualizar.Text = rut;
            txtACorreoActualizar.Text = correo;
            txtContrasenaActualizar.Password = contrasena;
            txtCelularActualizar.Text = celular;
         
            txtTipoUsuarioActualizar_.Text = "Administrador";
            

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

            Usuario usuario = new Usuario();
            usuario.ActualizarUsuario(txtRutActualizar.Text, txtACorreoActualizar.Text, txtContrasenaActualizar.Password, txtCelularActualizar.Text);
        }
    }
}
