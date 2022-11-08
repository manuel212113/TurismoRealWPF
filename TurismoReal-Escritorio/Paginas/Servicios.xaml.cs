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
using TurismoReal.Capa_Negocio.Departamento;
using TurismoReal.Capa_Negocio.Servicios;
using System.Runtime.Intrinsics.Arm;

using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;

namespace TurismoReal_Escritorio.Paginas
{
 
    public partial class Servicios : Page
    {

        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        TurismoReal.Capa_Negocio.Servicios.Servicio_Extra srv = new TurismoReal.Capa_Negocio.Servicios.Servicio_Extra();


        public Servicios()
        {
            InitializeComponent();

            ObservableCollection<TurismoReal.Capa_Negocio.Servicios.Servicio_Extra> serv_lista = new ObservableCollection<TurismoReal.Capa_Negocio.Servicios.Servicio_Extra>();
            ObservableCollection<TurismoReal.Capa_Negocio.Servicios.Servicio_Extra> ser_lista2 = new ObservableCollection<TurismoReal.Capa_Negocio.Servicios.Servicio_Extra>();

            serv_lista = srv.CargarInventario(ser_lista2);
            Lista.ItemsSource = serv_lista;
            Servicio_srv.Text = "SERVICIO: " + serv_lista.Count.ToString();

        }
        private void btnAgregarServicio_click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarServicioextra.IsOpen = true;
        

        }


        //       OracleConnection cone = new OracleConnection("DATA SOURCE = xe ; PASSWORD = 123 ; USER ID = TURISMOREALWPF");

        private void btnGuardarServicio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NOMBRESRV = TxtNOMBRE_SRV.Text;
                string PRECIO = TxtPRECIO.Text;


                srv.AgregarServicioExtra(NOMBRESRV, PRECIO);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se agrego el Departamento a la base de datos");
                cone.Close();

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEliminarInventario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var departamentoSeleccionado = Lista.SelectedItem as Servicio_Extra;
                Servicio_Extra departamentoSeleccionado1 = departamentoSeleccionado;
                string departamento_seleccionado_id = departamentoSeleccionado1.IDSER;
                Int16 depart_id = Convert.ToInt16(departamentoSeleccionado.IDSER);

                MessageBoxResult dialogResult = MessageBox.Show("Estas seguro de eliminar a el departamento con  ID :" + departamento_seleccionado_id, "Eliminar Departamento:", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {

                    try
                    {
                      Servicio_Extra servicios = new Servicio_Extra();
                        servicios.EliminarServicioExtra(departamento_seleccionado_id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        cone.Close();


                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

       
}

