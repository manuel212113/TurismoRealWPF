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
using System.Windows.Shapes;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para InfoDepartamento.xaml
    /// </summary>
    public partial class InfoDepartamento : Window
    {
        public InfoDepartamento(string iddepa, string nombre, string direccion, string descripcion, string metroscuadrados, string habitaciones, string banos,
            string region, string comuna, string valorarriendo, string habilitado, string imagen)
        {
            InitializeComponent();
            CargarDatos(iddepa, nombre, direccion, descripcion, metroscuadrados, habitaciones, banos, region, comuna, valorarriendo, habilitado, imagen);
        }

        private void CargarDatos(string iddepa, string nombre, string direccion, string descripcion, string metroscuadrados, string habitaciones, string banos,
            string region, string comuna, string valorarriendo, string habilitado, string imagen)
        {



            var image = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagen, UriKind.Absolute);
            bitmap.EndInit();

            image.Source = bitmap;
            ImagenEncabezado.Source = image.Source;

            TituloDepa.Text = nombre;
            DescripcionTxt.Text= descripcion + " " + direccion + "  Metros Cuadrados" + metroscuadrados + "  Habitaciones" + habitaciones + "  Baños" + banos;

            if(habilitado=="SI" || habilitado == "si")
            {
                btnHabilitado.Background = Brushes.Green;
                btnHabilitado.BorderBrush = Brushes.Green;
                iconoHabilitado.Kind = MaterialDesignThemes.Wpf.PackIconKind.Done;
            }
            else
            {
                btnHabilitado.Background = Brushes.Red;
                btnHabilitado.BorderBrush = Brushes.Red;
                iconoHabilitado.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;


            }


        }
    }
}
