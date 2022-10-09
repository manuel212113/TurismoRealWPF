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

namespace TurismoReal_Escritorio.Paginas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Usuarios : Page
    {


        Usuario usr = new Usuario();

        public Usuarios()
        {
            InitializeComponent();


            ObservableCollection<Usuario> usuarios_l = new ObservableCollection<Usuario>();
            usr.CargarUsuarios(usuarios_l, UsuarioDatagrid);
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            VentanaAgregarusario.IsOpen = true;

        }


        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string rut = TxtRUT.Text;
                string nombre = TxtNombre.Text;
                string apellido = TxtApellido.Text;
                string contrasena = TxtContrasena.Text;
                string email = TxtCorreo.Text;
                string tipo = TxtTipo.Text;
                string genero = TxtGenero.Text;
                string celular = TxtCelular.Text;


                usr.AgregarUsuario(rut, nombre, email, genero, contrasena, apellido, celular, tipo);
            }
               
          
            
            catch
            {
                MessageBox.Show("No se agrego la persona a la base de datos");

            }

        }

        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
