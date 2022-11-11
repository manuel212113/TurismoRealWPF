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
using TurismoReal.Capa_Negocio.Servicios;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Actualizar_Servicios_Extra.xaml
    /// </summary>
    public partial class ActualizarServicioExtra : Window
    {
       string IDSERVICIO;
        public ActualizarServicioExtra(string IDSER, string NOMBRESRV, string PRECIO)
        {
            InitializeComponent();

            AgregarDatosFormulario(IDSER, NOMBRESRV, PRECIO);

        }

        public void AgregarDatosFormulario(string IDSER , string NOMBRESRV, string PRECIO)
        {
            TxtNOMBRE_SRV.Text = NOMBRESRV;
            TxtPRECIO.Text = PRECIO;
            IDSERVICIO=IDSER;   
           
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

            string NOMBRESRV = TxtNOMBRE_SRV.Text;
            string PRECIO = TxtPRECIO.Text;



            string IDSER_FI = IDSERVICIO;

            Servicio_Extra servicio = new Servicio_Extra();
            servicio.ActualizarServicioExtra(IDSER_FI, NOMBRESRV, PRECIO);

        }
    }
}
