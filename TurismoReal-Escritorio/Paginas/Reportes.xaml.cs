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
using TurismoReal.Capa_Negocio.Reportes;

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
          

     

            VentanaReporte.IsOpen = true;
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnGuardarReporte_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxRegion.Text.Length>1 && ComboBoxTiempo.Text.Length > 1)
            {
                Reporte rep = new Reporte();
                string cant_reserv="";
                string ganancias_f="";

                if(rep.GenerarReporte(ComboBoxRegion.Text, ComboBoxTiempo.Text, ref ganancias_f, ref cant_reserv))
                {

                    if(ganancias_f=="null" || ganancias_f == "")
                    {
                        MessageBox.Show("No existen Datos par generar el reporte");

                    }
                    else
                    {

                        Informe inf = new Informe(ganancias_f, cant_reserv);

                        inf.Show();
                    }

                }
                else
                {
                    MessageBox.Show("No existen Datos para generar el reporte");

                }
            }

            
        }
    }
}