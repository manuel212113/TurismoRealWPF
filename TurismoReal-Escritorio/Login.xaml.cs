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
using System.Windows.Threading;

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
            if(TxtUsuario.Text.Length>0 && TxtContraseña.Password.ToString().Length>0)
            {
                VentanaCargandoLogin.IsOpen = true;

                /* Timer de 2 segundo de espera version de prueba*/
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    VentanaCargandoLogin.IsOpen = false;
                    MainWindow ventanaPrincipal = new MainWindow();
                    this.Close();
                    ventanaPrincipal.Show();
                };
                

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
