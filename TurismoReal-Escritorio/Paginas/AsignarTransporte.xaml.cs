using MaterialDesignThemes.Wpf;
using Oracle.ManagedDataAccess.Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurismoReal.Capa_Negocio.Departamento;
using TurismoReal.Capa_Negocio.Transporte;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Actualizar_Transporte.xaml
    /// </summary>
    public partial class AsignarTransporte : Window
    {
        public AsignarTransporte()
        {
            InitializeComponent();
        }



        public void AgregarDatosFormulario(string CONDUCTOR, string AUTO, string PATENTE)
        {
          

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

            string CONDUCTOR = TxtCONDUCTOR.Text;
            string AUTO = TxtAUTO.Text;
            string PATENTE = TxtPATENTE.Text;

            Planificar_transporte transporte = new Planificar_transporte();
            transporte.AgregarTransporte(CONDUCTOR, AUTO, PATENTE);

        }

    }
}
