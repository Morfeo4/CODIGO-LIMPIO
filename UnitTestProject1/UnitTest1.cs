using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Proyecto_de__Aula__1_Test1
{
    [TestClass]
    public class ProgramaEPM_Test
    {
        [TestMethod]
        public void TestTotalServicios()
        {
            int valorPagarEneriga = 75000;
            int valorPagarAgua = 70000;

            var valorServicios = Proyecto_de__Aula__1.ProgramaEPM.TotalServicios(valorPagarEneriga, valorPagarAgua);

            var valorEsperado = 145000;

            Assert.AreEqual(valorEsperado, valorServicios);


        }
    }   
}
