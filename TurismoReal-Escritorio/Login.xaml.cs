using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.OracleClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TurismoReal.Capa_Negocio.Usuario;

namespace TurismoReal_Escritorio
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Estas seguro que deseas cerrar la aplicación?", "Informacion", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) {
                Close();


            }

        }



        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaCargandoLogin.IsOpen = true;
            Usuario usr = new Usuario();

            if (usr.Login(TxtUsuario, TxtContraseña) &  String.IsNullOrEmpty(TxtUsuario.Text)==false & String.IsNullOrEmpty(TxtContraseña.Password)==false)
            {
                VentanaCargandoLogin.IsOpen = false;
                MainWindow ventanaPrincipal = new MainWindow();
                Close();
                ventanaPrincipal.Show();
            }
            
            else
            {
          
                if(String.IsNullOrEmpty(TxtUsuario.Text) || String.IsNullOrEmpty(TxtContraseña.Password))
                {
                    VentanaCargandoLogin.IsOpen = false;
                    MessageBox.Show("Tienes que llenar todos los campos de texto");

                }
                else
                {
                    VentanaCargandoLogin.IsOpen = false;
                    MessageBox.Show("Contraseña o Usuario Incorrecto");
                }
              


            }
        }


        private void MoverVentana(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }

        private void CambiarColorEnter(object sender, MouseEventArgs e)
        {
            IconoSalir.Foreground = new SolidColorBrush(Colors.Red); ;
        }

        private void CambiarColorSalir(object sender, MouseEventArgs e)
        {
            IconoSalir.Foreground = new SolidColorBrush(Colors.White); ;

        }
    }
}
