﻿using System.Windows.Documents;
using TurismoReal.Capa_Negocio.Usuario;

namespace PruebasUnitariasTurismoReal
{
    public class PruebaUsuarios
    {

        [Fact]
        public void CrearDepartamento()
        {
            Usuario usr = new Usuario();

            string rut = "203107761";
            string nombre = "manu";
            string email = "manu@gamil.com";
            string genero = "masculino";
            string contrasena = "23445555";
            string apellido = "leon";
            string celular = "3223325";
            string tipo_user = "2";



            string resultado = usr.AgregarUsuario(rut, nombre, email, genero, contrasena, apellido, celular, tipo_user);

            Assert.Equal("Exito", resultado);
        }


        [Fact]
        public void EliminarUsuario()
        {
            Usuario usr = new Usuario();

            string rut = "203107761";

            string resultado = usr.EliminarUsuario(rut);

            Assert.Equal("Exito", resultado);

        }


    }
}
