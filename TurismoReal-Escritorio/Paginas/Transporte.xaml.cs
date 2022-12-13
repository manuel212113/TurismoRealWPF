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
using TurismoReal.Capa_Negocio.Transporte;

namespace TurismoReal_Escritorio.Paginas
{
    public partial class Transporte : Page
    {


        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        TurismoReal.Capa_Negocio.Transporte.Planificar_transporte trn = new TurismoReal.Capa_Negocio.Transporte.Planificar_transporte();
        public Transporte()
        {
            InitializeComponent();
            ObservableCollection<TurismoReal.Capa_Negocio.Transporte.SolicitudTransporte> Lista1 = new ObservableCollection<TurismoReal.Capa_Negocio.Transporte.SolicitudTransporte>();
            ObservableCollection<TurismoReal.Capa_Negocio.Transporte.SolicitudTransporte> Lista2 = new ObservableCollection<TurismoReal.Capa_Negocio.Transporte.SolicitudTransporte>();

            Lista1 = trn.CargarTransporte(Lista2);
            Lista.ItemsSource = Lista1;
            Transporte_trn.Text = "TRANSPORTE: " + Lista1.Count.ToString();

        }

        private void btnAgregarTransporte_click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarTransporte.IsOpen = true;


        }

        private void btnGuardarTransporte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAsignarAuto_Click(object sender, RoutedEventArgs e)
        {
            var transporteSeleccionado = Lista.SelectedItem as SolicitudTransporte;
            string Estado_Transporte = transporteSeleccionado.ESTADO;
            string id_reserva_seleccionado = transporteSeleccionado.ID_SOLICITUD;

            if(Estado_Transporte=="Pendiente Vehiculo")
            {

                AsignarTransporte pagin_asignarTransp = new AsignarTransporte( id_reserva_seleccionado);


                pagin_asignarTransp.Show();

            }
            else
            {
                MessageBox.Show("Ya se asigno un vehiculo y conductor al Transporte");
            }
        }

        
        private void BtnEliminarTransporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var TransporteSeleccionado = Lista.SelectedItem as Planificar_transporte;
                Planificar_transporte TransporteSeleccionado1 = TransporteSeleccionado;
                string TransporteSeleccionado_ID = TransporteSeleccionado1.ID_PLANIFICACION;
                Int16 PATENTE_ID = Convert.ToInt16(TransporteSeleccionado1.ID_PLANIFICACION);

                MessageBoxResult dialogResult = MessageBox.Show("Estas seguro de eliminar EL  ID :" + TransporteSeleccionado_ID, "Eliminar TRANSPORTE:", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {

                    try
                    {
                        Planificar_transporte trasnporte = new Planificar_transporte();
                        trasnporte.EliminarTransporte(TransporteSeleccionado_ID);
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

    }
}



        
     





 