using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OracleClient;
using System.Diagnostics.Metrics;
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
using TurismoReal.Capa_Negocio.Usuario;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>

    public partial class Inicio : Page
    {


        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        Departamento dep = new Departamento();

   

        public Inicio()

        {
            InitializeComponent();


            ObservableCollection<Departamento> depa_l = new ObservableCollection<Departamento>();
            ObservableCollection<Departamento> depa_lista = new ObservableCollection<Departamento>();

            depa_lista = dep.CargarDepartamentos(depa_l);
            DataGridDepa.ItemsSource = depa_lista;
            Departamento_depa.Text = "DEPARTAMENTO: " + depa_l.Count.ToString();
        }




        private void btnAgregarDepa_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarusuario.IsOpen = true;

        }
        private void btnGuardarDepa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string iddepa = TxtIddepa.Text;
                string nombre = TxtNombre.Text;
                string direccion = TxtDireccion.Text;
                string descripcion = TxtDescripcion.Text;
                string metroscuadrados = TxtMetrosCua.Text;
                string habitaciones = TxtHabitaciones.Text;
                string banos = TxtBanos.Text;
                string region = TxtRegion.Text;
                string comuna = TxtComuna.Text;
                string valorarriendo = TxtValorArriendo.Text;
                string fecha = TxtFecha.Text;
                string habilitado = TxtHabilitado.Text;

                dep.AgregarDepartamento(iddepa, nombre, direccion, descripcion, metroscuadrados, habitaciones, banos, region, comuna, valorarriendo, fecha, habilitado);
                }
                catch
                {
                      MessageBox.Show("No se agrego el Departamento a la base de datos");
                      cone.Close();
            }

        }


     

        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnEliminarDepartamento_Click(object sender, RoutedEventArgs e)
        {
            dep.AbrirVentanaArchivoImagen();
            try
            {
                var departamentoSeleccionado = DataGridDepa.SelectedItem as Departamento;
                Departamento departamentoSeleccionado1 = departamentoSeleccionado;
                string departamento_seleccionado_id = departamentoSeleccionado1.iddepa;
                Int16 depart_id= Convert.ToInt16(departamentoSeleccionado.iddepa);

                MessageBoxResult dialogResult = MessageBox.Show("Estas seguro de eliminar a el departamento con  ID :" + departamento_seleccionado_id, "Eliminar Departamento:" , MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    Departamento depa = new Departamento();

                    try
                    {
                        cone.Open();
                        OracleCommand comandoEliminarDepa = new OracleCommand("SP_ELIMINAR_DEPA", cone);
                        comandoEliminarDepa.CommandType = System.Data.CommandType.StoredProcedure;
                        comandoEliminarDepa.Parameters.Add("ID_DEPA_ELIMINAR", int.Parse(departamento_seleccionado_id));
                        MessageBox.Show("Departamento Eliminado de la base de datos");
                        comandoEliminarDepa.ExecuteNonQuery();
                        cone.Close();

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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

                /*Poner metodo de actualizar*/


          
        }
    }
}
