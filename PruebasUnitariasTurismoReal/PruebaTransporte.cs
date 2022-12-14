using System.Windows.Documents;
using TurismoReal.Capa_Negocio.Transporte;
using TurismoReal.Capa_Negocio.Usuario;

namespace PruebasUnitariasTurismoReal
{
    public class PruebaTransporte
    {

        [Fact]
        public void CrearTrasporte()
        {
            TurismoReal.Capa_Negocio.Transporte.Planificar_transporte trn = new TurismoReal.Capa_Negocio.Transporte.Planificar_transporte();

            string CONDUCTOR = "ronaldo";
            string AUTO = "nissan";
            string PATENTE = "777";
           

            string resultado = trn.AgregarTransporte(CONDUCTOR, AUTO, PATENTE,"82");

            Assert.Equal("Exito", resultado);
        }

        
        [Fact]
        public void EliminarTransporte()
        {
            TurismoReal.Capa_Negocio.Transporte.Planificar_transporte trn = new TurismoReal.Capa_Negocio.Transporte.Planificar_transporte();

            string ID_PLANIFICACION = "82";

            bool resultado = trn.EliminarTransporte(ID_PLANIFICACION);
            Assert.Equal(true, resultado);

        }
        
    }
}
