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
using TurismoReal.Capa_Negocio.Servicios;
using System.Runtime.Intrinsics.Arm;


using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;
using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;

namespace TurismoReal_Escritorio.Paginas
{
    public partial class Transporte : Window
    {


        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        TurismoReal.Capa_Negocio.Transporte.Planificar_transporte trn = new TurismoReal.Capa_Negocio.Transporte.Planificar_transporte();
        public Transporte()
        {
            InitializeComponent();
            ObservableCollection<TurismoReal.Capa_Negocio.Transporte.Planificar_transporte> Lista1 = new ObservableCollection<TurismoReal.Capa_Negocio.Transporte.Planificar_transporte>();
            ObservableCollection<TurismoReal.Capa_Negocio.Transporte.Planificar_transporte> Lista2 = new ObservableCollection<TurismoReal.Capa_Negocio.Transporte.Planificar_transporte>();

            Lista1 = trn.CargarTransporte(Lista2);
            Lista.ItemsSource = Lista1;
            Transporte_trn.Text = "TRASNPORTE: " + Lista1.Count.ToString();

        }

        private void btnAgregarTransporte_click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarTransporte.IsOpen = true;


        }

        private void btnGuardarTransporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string CONDUCTOR = TxtCONDUCTOR.Text;
                string AUTO = TxtAUTO.Text;
                string PATENTE = TxtPATENTE.Text;


                trn.AgregarTransporte(CONDUCTOR, AUTO, PATENTE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se agrego el transporte");
                cone.Close();

                MessageBox.Show(ex.Message);
            }

        }

        /*
        private void BtnEliminarTransporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var TransporteSeleccionado = Lista.SelectedItem as Servicio_Extra;
                Servicio_Extra TransporteSeleccionado1 = TransporteSeleccionado;
                string TransporteSeleccionado_ID = TransporteSeleccionado1.PATENTE;
                Int16 PATENTE_ID = Convert.ToInt16(TransporteSeleccionado1.PATENTE);

                MessageBoxResult dialogResult = MessageBox.Show("Estas seguro de eliminar a el departamento con  ID :" + TransporteSeleccionado_ID, "Eliminar TRANSPORTE:", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {

                    try
                    {
                        Servicio_Extra servicios = new Servicio_Extra();
                        servicios.EliminarTransporte(TransporteSeleccionado_ID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        cone.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        */
    }
}



        
     





 