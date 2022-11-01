
using TurismoReal.Capa_Negocio.Departamento;
using TurismoReal.Capa_Negocio.Inventario;

namespace PruebasUnitariasTurismoReal
{
    public class PruebasInventario
    {
        [Fact]
        public void CrearInventario()
        {
            Inventarios inv = new Inventarios();

            string PRODUCTO = "jabon";
            string CANTIDAD = "20";
            string ESTADO = "BUENO";
            string DESCRIPCION = "DNJSDN";
            string TIPO_PROD = "1";
            string TIPO_PROD_ID_T_PR = "2";
            string DEPARTAMENTO_ID_DEPA = "11";

            string resultado = inv.guardar_inventario( PRODUCTO, CANTIDAD, ESTADO, DESCRIPCION, TIPO_PROD, TIPO_PROD_ID_T_PR, DEPARTAMENTO_ID_DEPA);

            Assert.Equal("Exito", resultado);
        }


        [Fact]
        public void EliminarInventario()
        {
            Inventarios inv = new Inventarios();

            string ID_INV = "10";

            bool resultado = inv.EliminarProducto(ID_INV);

            Assert.Equal(true, resultado);

        }

    }
}
