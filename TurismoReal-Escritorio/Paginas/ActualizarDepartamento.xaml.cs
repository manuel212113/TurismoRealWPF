using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Edittar_Departamento.xaml
    /// </summary>
    public partial class ActualizarDepartamento : Window
    {
        public ActualizarDepartamento(string nombre, string direccion, string descripcion, string metroscuadrados, string habitaciones, string banos,
            string region, string comuna, string valorarriendo, string fecha, string habilitado, string imagen)
        {
            InitializeComponent();


        }

            public void AgregarDatosFormulario(string nombre, string direccion, string descripcion, string metroscuadrados, string habitaciones, string banos,
                string region, string comuna, string valorarriendo, string fecha, string habilitado, string imagen)
            {
                txtNombreActualizar.Text = nombre;
                txtDescripcionActualizar.Text = direccion;
                txtMetroscuadradosActualizar.Text = metroscuadrados;
                txtHabitacionesActualizar.Text = habitaciones;
                txtBanosActualizar.Text = banos;
                txtRegionActualizar.Text = region;
                txtcomunaActualizar.Text = comuna;
                txtValorarriendoActualizar.Text = valorarriendo;
                txtFechaActualizar.Text = fecha;
                txtHabilitadoActualizar.Text = habilitado;
                txtImagenActualizar.Text = imagen;
            }

            private void btnActualizar_Click(object sender, RoutedEventArgs e)
            {

            }
        
    }
}
