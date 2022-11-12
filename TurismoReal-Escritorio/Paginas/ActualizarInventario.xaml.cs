using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TurismoReal.Capa_Negocio.Inventario;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Actualizar_Inventario.xaml
    /// </summary>
    public partial class ActualizarInventario : Window
    {

        string categoria_producto_f_id;
        string id_producto_final;
       
        public ActualizarInventario(string id_producto, string nombre_producto, string cantidad_producto, string estado_producto, string descripcion_producto, string id_depa,string categoria_producto, string categoria_producto_id)
        {
            InitializeComponent();
             id_producto_final = id_producto;
            categoria_producto_f_id= categoria_producto_id;
            AgregarDatosFormulario(id_producto, nombre_producto, cantidad_producto, estado_producto, descripcion_producto,  id_depa,categoria_producto, categoria_producto_id);
        }


        public void AgregarDatosFormulario(string id_producto, string nombre_producto, string cantidad_producto, string estado_producto, string descripcion_producto, string id_depa,string categoria_producto, string categoria_producto_id)
        {
            TxtPRODCUTO.Text = nombre_producto;
            TxtCANTIDAD.Text = cantidad_producto;
            ComboBoxESTADO.Text = estado_producto;
            TxtDESCRIPCION.Text = descripcion_producto;
            ComboBoxCategoria.Text = categoria_producto;
            TxtDepaId.Text = id_depa;

            CargarComboBox();

           

        }

        public void CargarComboBox()
        {
            ObservableCollection<Tipo_Prod> ListaCategoria2 = new ObservableCollection<Tipo_Prod>();
            ObservableCollection<Tipo_Prod> ListaCategoria = new ObservableCollection<Tipo_Prod>();

            Tipo_Prod CAT = new Tipo_Prod();

            ListaCategoria2 = CAT.CargarCategoria(ListaCategoria);

            var diccionarioCategorias = new Dictionary<string, string>();

            foreach (var i in ListaCategoria2)
            {
                if (i.ID_CAT == categoria_producto_f_id)
                {
                    diccionarioCategorias.Add(i.ID_CAT, i.NOMBRE_CATEGORIA);

                }
                else
                {
                    diccionarioCategorias.Add(i.ID_CAT, i.NOMBRE_CATEGORIA);
                }
            }

            ComboBoxCategoria.ItemsSource = (diccionarioCategorias);
            ComboBoxCategoria.SelectedValuePath = "Key";
            ComboBoxCategoria.DisplayMemberPath = "Value";
            ComboBoxCategoria.SelectedIndex = 0;
        }
         
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            


            var tipo_producto_id = (ComboBoxCategoria.SelectedValue.ToString());



            Inventarios inventarios = new Inventarios();
            inventarios.ActualizarProducto(id_producto_final, TxtPRODCUTO.Text, TxtCANTIDAD.Text, ComboBoxESTADO.Text, TxtDESCRIPCION.Text, tipo_producto_id, tipo_producto_id, TxtDepaId.Text);





        }
    }
}
