using System;
using System.Collections.Generic;
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
            if (tipo_usuario.StartsWith('1'))
            {
                txtTipoUsuarioActualizar_.Text = "Cliente";
            }
            else if (tipo_usuario.StartsWith('2'))
             {
                txtTipoUsuarioActualizar_.Text = "Administrador";
            }
            else if (tipo_usuario.StartsWith('3'))
            {
                txtTipoUsuarioActualizar_.Text = "Funcionario";
            }

        }
    }
}
