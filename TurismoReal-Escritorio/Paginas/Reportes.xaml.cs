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

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Reportes : Page
    {
        public Reportes()
        {
            InitializeComponent();
        }
        private void Titulo_click(object sender, RoutedEventArgs e)
        {
            
        }



        //       OracleConnection cone = new OracleConnection("DATA SOURCE = xe ; PASSWORD = 123 ; USER ID = TURISMOREALWPF");


        private void btnGenerarReportes_click(object sender, RoutedEventArgs e)
        {
            /*
             * 
             * Informe inf = new Informe();

     inf.Show();

     */

            VentanaReporte.IsOpen = true;
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}