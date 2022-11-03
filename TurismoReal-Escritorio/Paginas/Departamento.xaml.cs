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


        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
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



        }

          
        private void Boton_Guardar_depa_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarusuario.IsOpen = false;
            try
            {
                string nombre = TxtNombre.Text;
                string direccion = TxtDireccion.Text;
                string descripcion = TxtDescripcion.Text;
                string metroscuadrados = TxtMetrosCua.Text;
                string habitaciones = TxtHabitaciones.Text;
                string banos = TxtBanos.Text;
                string region = TxtRegion.Text;
                string comuna = TxtComuna.Text;
                string valorarriendo = TxtValorArriendo.Text;
                string fecha = DateTime.UtcNow.ToString("MM-dd-yyyy");
                string habilitado = ComboBoxHabilitado.Text;
                string imagen=txtImagen.Text;
                

                dep.AgregarDepartamento(nombre, direccion, descripcion, metroscuadrados, habitaciones, banos, region, comuna, valorarriendo, fecha, habilitado,imagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se agrego el Departamento a la base de datos");
                cone.Close();


                MessageBox.Show(ex.Message);
            }

        }

        private void TxtHabitaciones_PreviewTextInput(object sender, TextCompositionEventArgs e )
        {
            var textBox = sender as TextBox;
            // Use SelectionStart property to find the caret position.
            // Insert the previewed text into the existing text in the textbox.
            var fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            int val;
            // If parsing is successful, set Handled to false
            e.Handled = !int.TryParse(fullText, out val);
        }

        private void btnAgregarImagen_Click(object sender, RoutedEventArgs e)
        {
            string ruta_imagen=dep.AbrirVentanaArchivoImagen();
            if (ruta_imagen != null)
            {
                dep.SubirImagen(ruta_imagen, txtImagen);

            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

            var departamentoSelecciona = DataGridDepa.SelectedItem as Departamento;
            string id_seleccionado = departamentoSelecciona.iddepa;
            string nombre_seleccionada = departamentoSelecciona.nombre;
            string direccion_seleccionado = departamentoSelecciona.direccion;
            string descripcion_seleccionado = departamentoSelecciona.descripcion;
            string metros_cuadrados_seleccionado = departamentoSelecciona.metroscuadrados;
            string habitaciones_seleccionado = departamentoSelecciona.habitaciones;
            string banos_seleccionado = departamentoSelecciona.banos;
            string region_seleccionado = departamentoSelecciona.region;
            string comuna_seleccionado = departamentoSelecciona.comuna;
            string valorarriendo_seleccionado = departamentoSelecciona.valorarriendo;
            string fecha_seleccionado = departamentoSelecciona.fecha;
            string habilitado_seleccionado = departamentoSelecciona.habilitado;
            string imagen_seleccionado = departamentoSelecciona.imagen;





            ActualizarDepartamento pagina_actualizar = new ActualizarDepartamento(id_seleccionado, nombre_seleccionada, direccion_seleccionado, descripcion_seleccionado,
             metros_cuadrados_seleccionado, habitaciones_seleccionado, banos_seleccionado, region_seleccionado, comuna_seleccionado, valorarriendo_seleccionado,
            fecha_seleccionado, habilitado_seleccionado, imagen_seleccionado);

            pagina_actualizar.Show();
        }
    }
}
