using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoReal.Capa_Negocio.Departamento;
using TurismoReal.Capa_Negocio.Inventario;
using TurismoReal.Capa_Negocio.Servicios;

namespace PruebasUnitariasTurismoReal
{
    public class PruebaServicios
    {

        [Fact]
        public void CrearServicio()
        {
            Servicios inv = new Servicios();

            string NOMBRESRV = "HBO";
            string PRECIO = "10000";
           

            string resultado = inv.AgregarServicioExtra(NOMBRESRV, PRECIO);

            Assert.Equal("Exito", resultado);
        }

        [Fact]
        public void EliminarServicios()
        {
            Servicios inv = new Servicios();

            string IDSER = "5";

            bool resultado = inv.EliminarServicioExtra(IDSER);

            Assert.Equal(true, resultado);

        }

    }
}
