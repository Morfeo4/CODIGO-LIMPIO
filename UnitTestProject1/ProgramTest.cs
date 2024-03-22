using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_de__Aula__1;

[TestClass]
public class PruebasUnitarias
{
    [TestMethod]
    public void TestCalcularValorPagarServicios()
    {
        // Configuración de la entrada simulada
        int consumoEnergia = 100;
        int consumoAgua = 50;

        // Configuración del cliente de ejemplo
        Cliente clienteEjemplo = new Cliente
        {
            Cedula = 123456789,
            ConsumoEnergia = consumoEnergia,
            ConsumoAgua = consumoAgua,
            PromedioAgua = 40,
            MetaAhorro = 80
        };

        // Capturamos la salida del método
        using (System.IO.StringWriter sw = new System.IO.StringWriter())
        {
            Console.SetOut(sw);

            // Ejecutamos el método con la entrada simulada
            Proyecto_de__Aula__1.ProgramaEPM.CalcularValorPagarServicios();

            // Capturamos la salida del método
            string resultado = sw.ToString();

            // Verificamos si la salida contiene la información esperada
            Assert.IsTrue(resultado.Contains("El valor a pagar Energia es: 4300"));
            Assert.IsTrue(resultado.Contains("El valor a pagar Agua es: 1000"));
            Assert.IsTrue(resultado.Contains("El valor a pagar de los servicios es: 5300"));
        }
    }
}