﻿using System;
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
using TurismoReal.Capa_Negocio.Usuario;
using TurismoReal.Capa_Negocio.Cliente;
using TurismoReal.Capa_Negocio.Departamento;
using System.Runtime.Intrinsics.Arm;
using TurismoReal.Capa_Negocio.Inventario;

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>

    public partial class Inventario : Page
    {
        OracleConnection cone = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = C##TR; Password=123");
        Inventarios inv = new Inventarios();


        public Inventario()
        {
            InitializeComponent();


            ObservableCollection<Inventarios> Invent = new ObservableCollection<Inventarios>();
            ObservableCollection<Inventarios> Invent_lista = new ObservableCollection<Inventarios>();

            Invent_lista = inv.CargarInventario(Invent);
            Lista.ItemsSource = Invent_lista;
            Inventario_inve.Text = "INVENTARIO: " + Invent.Count.ToString();
        }

        private void btnFormularioInventario_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarServicio.IsOpen = true;

        }

        private void btnGuardarInventario_Click(object sender, RoutedEventArgs e)
        {

            VentanaAgregarServicio.IsOpen = false;
            try
            {
                string ID_INV = TxtID_INV.Text;
                string PRODUCTO = TxtPRODCUTO.Text;
                string CANTIDAD = TxtCANTIDAD.Text;
                string ESTADO = ComboBoxESTADO.Text;
                string DESCRIPCION = TxtDESCRIPCION.Text;
                string TIPO_PROD = TxtTIPO_PROD.Text;
                string TIPO_PROD_ID_T_PR = TxtTIPO_PROD_ID_T_PR.Text;
                string DEPARTAMENTO_ID_DEPA = TxtDEPARTAMENTO_ID_DEPA.Text;


                inv.guardar_inventario(ID_INV, PRODUCTO, CANTIDAD, ESTADO, DESCRIPCION, TIPO_PROD, TIPO_PROD_ID_T_PR, DEPARTAMENTO_ID_DEPA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se agrego a la base de datos");
                cone.Close();


                MessageBox.Show(ex.Message);
                cone.Close();
            }

        }


        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void BtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                var ProductoSeleccionado = Lista.SelectedItem as Inventarios;
                Inventarios ProductoSeleccionado1 = ProductoSeleccionado;
                string id_Producto_seleccionado = ProductoSeleccionado1.ID_INV;
                int producto_id = int.Parse(ProductoSeleccionado.ID_INV);


                MessageBoxResult dialogResult = MessageBox.Show("Estas seguro de eliminar a el Producto con  ID :" + id_Producto_seleccionado, "Eliminar Producto:", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {

                    try
                    {
                        cone.Open();
                        OracleCommand comandoEliminar = new OracleCommand("SP_Eliminar_Produ", cone);
                        comandoEliminar.CommandType = System.Data.CommandType.StoredProcedure;
                        comandoEliminar.Parameters.Add("ID_INV_ELIMINAR", (producto_id));
                        MessageBox.Show("Producto Eliminado de la base de datos");
                        comandoEliminar.ExecuteNonQuery();
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

    }
}





    
        


 

      


      
