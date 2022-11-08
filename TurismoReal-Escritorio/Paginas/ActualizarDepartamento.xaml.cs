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
using TurismoReal.Capa_Negocio.Departamento;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Edittar_Departamento.xaml
    /// </summary>
    public partial class ActualizarDepartamento : Window
    {
        public ActualizarDepartamento(string iddepa, string nombre, string direccion, string descripcion, string metroscuadrados, string habitaciones, string banos,
            string region, string comuna, string valorarriendo, string habilitado, string imagen)
        {
            InitializeComponent();

            AgregarDatosFormulario(iddepa, nombre, direccion, descripcion, metroscuadrados, habitaciones, banos, region, comuna, valorarriendo, habilitado, imagen);


        }

        public void AgregarDatosFormulario(string iddepa, string nombre, string direccion, string descripcion, string metroscuadrados, string habitaciones, string banos,
                string region, string comuna, string valorarriendo, string habilitado, string imagen)
            {
                iddepa_fina.Text = iddepa;
                txtNombreActualizar.Text = nombre;
                txtDescripcionActualizar.Text = descripcion;
                txtDireccionActualizar.Text = direccion;
                txtMetroscuadradosActualizar.Text = metroscuadrados;
                txtHabitacionesActualizar.Text = habitaciones;
                txtBanosActualizar.Text = banos;
                txtRegionActualizar.Text = region;
                txtcomunaActualizar.Text = comuna;
                txtValorarriendoActualizar.Text = valorarriendo;
                txtHabilitadoActualizar.Text = habilitado;
                txtImagenActualizar.Text = imagen;
            }

            private void btnActualizar_Click(object sender, RoutedEventArgs e)
            {

            string nombre = txtNombreActualizar.Text;
            string direccion = txtDireccionActualizar.Text;
            string descripcion = txtDescripcionActualizar.Text;
            string metroscuadrados = txtMetroscuadradosActualizar.Text;
            string habitaciones = txtHabitacionesActualizar.Text;
            string banos = txtBanosActualizar.Text;
            string region = txtRegionActualizar.Text;
            string comuna = txtcomunaActualizar.Text;
            string valorarriendo = txtValorarriendoActualizar.Text;
            string habilitado = txtHabilitadoActualizar.Text;
            string imagen = txtImagenActualizar.Text;


            string iddepa_final = iddepa_fina.Text;

            Departamento departamento = new Departamento();
            departamento.ActualizarDepartamento(iddepa_final, nombre, direccion, descripcion, metroscuadrados, habitaciones,
                banos, region, comuna, valorarriendo, habilitado, imagen);

        }
        
    }
}
