
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_de__Aula__1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Proyecto_de__Aula__1_Test1
{

    [TestClass]
    public class ProgramaEPMTest
    {
        [TestMethod]
        public void CalcularValorPagarServiciosTest()
        {
            
            int consumoEnergia = 100;
            int metaAhorro = 50;
            int consumoAgua = 20;
            int promedioAgua = 15;
            double valorKilovatio = 0.1;
            double valorM3agua = 1.5;

            
            double valorParcial = consumoEnergia * valorKilovatio;
            double valorIncentivo = (metaAhorro - consumoEnergia) * valorKilovatio;
            double valorPagarEnergia = valorParcial - valorIncentivo;

            double valorPagarAgua;
            if (consumoAgua > promedioAgua)
            {
                double excesoAgua = consumoAgua - promedioAgua;
                double castigoExceso = excesoAgua * (2 * valorM3agua);
                double costoPromedio = promedioAgua * valorM3agua;
                valorPagarAgua = costoPromedio + castigoExceso;
            }
            else
            {
                valorPagarAgua = consumoAgua * valorM3agua;
            }

            double valorServicios = valorPagarEnergia + valorPagarAgua;

            Assert.AreEqual(15, valorPagarEnergia, 0.01);
            Assert.AreEqual(37.5, valorPagarAgua, 0.01);
            Assert.AreEqual(52.5, valorServicios, 0.01);
        }
    

  
    
        private List<Cliente> GenerarListaClientes()
        {
            
            List<Cliente> listaClientes = new List<Cliente>
            {
                new Cliente { ConsumoEnergia = 100, MetaAhorro = 50 },
                new Cliente { ConsumoEnergia = 60, MetaAhorro = 70 },
                new Cliente { ConsumoEnergia = 40, MetaAhorro = 30 }
            };
            return listaClientes;
        }

        [TestMethod]
        public void CalcularTotalDescuentosTest()
        {
            
            ConsoleWrapper.Start();
            ProgramaEPM.ListaClientes = GenerarListaClientes();
            double totalDescuentosEsperado = 0;
            foreach (Cliente cliente in ProgramaEPM.ListaClientes)
            {
                if (cliente.ConsumoEnergia < cliente.MetaAhorro)
                {
                    double valorParcial = cliente.ConsumoEnergia * ProgramaEPM.valorKilovatio;
                    double valorIncentivo = (cliente.MetaAhorro - cliente.ConsumoEnergia) * ProgramaEPM.valorKilovatio;
                    totalDescuentosEsperado += valorIncentivo;
                }
            }

           
            ProgramaEPM.CalcularTotalDescuentos();
            string consoleOutput = ConsoleWrapper.GetOutput();
            ConsoleWrapper.End();

           
            string mensajeEsperado = "El total de descuento es: " + totalDescuentosEsperado;
            Assert.IsTrue(consoleOutput.Contains(mensajeEsperado));
        }
    
       
    public static class ConsoleWrapper
    {
        private static StringWriter stringWriter;
        private static TextWriter originalOutput;

        public static void Start()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public static string GetOutput()
        {
            return stringWriter.ToString().Trim();
        }

        public static void End()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }


        [TestMethod]
        public void MostrarValorTotalPagarTest()
        {
         
            ConsoleWrapper.Start();
            List<Cliente> listaClientes = new List<Cliente>
                {
                    new Cliente { ConsumoEnergia = 100, MetaAhorro = 50, ConsumoAgua = 20, PromedioAgua = 15 },
                    new Cliente { ConsumoEnergia = 60, MetaAhorro = 70, ConsumoAgua = 25, PromedioAgua = 20 },
                    new Cliente { ConsumoEnergia = 40, MetaAhorro = 30, ConsumoAgua = 18, PromedioAgua = 16 }
                };

            
            ProgramaEPM.MostrarValorTotalPagar();
            string consoleOutput = ConsoleWrapper.GetOutput();
            ConsoleWrapper.End();

            
            Assert.IsTrue(consoleOutput.Contains("El valor total que los clientes le pagan a la empresa por concepto de energía y agua es:"));
        }
    

    
        [TestMethod]
        public void ContabilizarClientesMayorPromedioAguaTest()
        {
           
            List<Cliente> listaClientes = new List<Cliente>
            {
                new Cliente { ConsumoAgua = 30, PromedioAgua = 20 },
                new Cliente { ConsumoAgua = 25, PromedioAgua = 18 },
                new Cliente { ConsumoAgua = 15, PromedioAgua = 15 }
            };
            ProgramaEPM.ListaClientes = listaClientes;

            
            int contClientesMayorPromedio = 0;
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.ConsumoAgua > cliente.PromedioAgua)
                {
                    contClientesMayorPromedio++;
                }
            }

            Assert.AreEqual(2, contClientesMayorPromedio); 
        }
        [TestMethod]
        public void MostrarPorcentajesConsumoAguaPorEstratoTest()
        {
          
            List<Cliente> listaClientes = new List<Cliente>
            {
                new Cliente { Estrato = 1, ConsumoAgua = 20, PromedioAgua = 15 },
                new Cliente { Estrato = 2, ConsumoAgua = 30, PromedioAgua = 25 },
                new Cliente { Estrato = 3, ConsumoAgua = 25, PromedioAgua = 20 },
                new Cliente { Estrato = 4, ConsumoAgua = 35, PromedioAgua = 30 },
                new Cliente { Estrato = 5, ConsumoAgua = 40, PromedioAgua = 35 },
                new Cliente { Estrato = 6, ConsumoAgua = 45, PromedioAgua = 40 }
            };
            ProgramaEPM.ListaClientes = listaClientes;

            
            ConsoleWrapper.Start();
            ProgramaEPM.MostrarPorcentajesConsumoAguaPorEstrato();
            string consoleOutput = ConsoleWrapper.GetOutput();
            ConsoleWrapper.End();

            
            string[] lines = consoleOutput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(6, lines.Length); 
            foreach (var line in lines)
            {
                Assert.IsTrue(line.StartsWith("Estrato"));
                Assert.IsTrue(line.EndsWith("%")); 
            }
        }
        [TestMethod]
        public void MostrarEstratoMayorAhorroAguaTest()
        {
            
            List<Cliente> listaClientes = new List<Cliente>
            {
                new Cliente { ConsumoAgua = 30, PromedioAgua = 25, Estrato = 1 },
                new Cliente { ConsumoAgua = 20, PromedioAgua = 18, Estrato = 2 },
                new Cliente { ConsumoAgua = 40, PromedioAgua = 35, Estrato = 3 },
                new Cliente { ConsumoAgua = 15, PromedioAgua = 10, Estrato = 4 },
                new Cliente { ConsumoAgua = 25, PromedioAgua = 20, Estrato = 5 },
                new Cliente { ConsumoAgua = 22, PromedioAgua = 18, Estrato = 6 }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                ProgramaEPM.ListaClientes = listaClientes;
                ProgramaEPM.MostrarEstratoMayorAhorroAgua();

                
                string expected = "El estrato con mayor ahorro de agua es: 1";
                Assert.AreEqual(expected, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void MostrarEstratoMayorMenorConsumoEnergiaTest()
        {
           
            List<Cliente> listaClientes = new List<Cliente>
            {
                new Cliente { ConsumoEnergia = 150, Estrato = 1 },
                new Cliente { ConsumoEnergia = 120, Estrato = 2 },
                new Cliente { ConsumoEnergia = 200, Estrato = 3 },
                new Cliente { ConsumoEnergia = 90, Estrato = 4 },
                new Cliente { ConsumoEnergia = 180, Estrato = 5 },
                new Cliente { ConsumoEnergia = 100, Estrato = 6 }
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw); 


                ProgramaEPM.ListaClientes = listaClientes;
                ProgramaEPM.MostrarEstratoMayorMenorConsumoEnergia();

                
                string expected = "El estrato con mayor consumo de energía es: 3\r\n" +
                                  "El estrato con menor consumo de energía es: 4";
                Assert.AreEqual(expected, sw.ToString().Trim());
            }
        }
        [TestMethod]
        public void CalcularPromedioConsumoEnergiaTest()
        {
            
            List<Cliente> listaClientes = new List<Cliente>
    {
        new Cliente { ConsumoEnergia = 100 },
        new Cliente { ConsumoEnergia = 150 },
        new Cliente { ConsumoEnergia = 50 }
    };

            
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ProgramaEPM.ListaClientes = listaClientes;
                ProgramaEPM.CalcularPromedioConsumoEnergia();
                string expected = "El promedio de consumo de energia es: 100";
                Assert.AreEqual(expected, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void MayorConsumoDeAguaPorPeriodoDeConsumoTest()
        {
            
            List<Cliente> listaClientes = new List<Cliente>
                        {
                            new Cliente { Cedula = 123456789, Nombre = "Juan", Apellido = "Perez", PeriodoDeConsumo = 1, ConsumoAgua = 50 },
                            new Cliente { Cedula = 987654321, Nombre = "Maria", Apellido = "Gomez", PeriodoDeConsumo = 1, ConsumoAgua = 70 },
                            new Cliente { Cedula = 456789123, Nombre = "Pedro", Apellido = "Martinez", PeriodoDeConsumo = 2, ConsumoAgua = 60 }
                        };
            ProgramaEPM.ListaClientes = listaClientes;

           
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            StringReader stringReader = new StringReader("1");
            Console.SetIn(stringReader);

           
            ProgramaEPM.MayorConsumoDeAguaPorPeriodoDeConsumo();

           
            string consoleOutput = stringWriter.ToString();

            Assert.IsTrue(consoleOutput.Contains("Cliente con mayor consumo de agua en el periodo 1:"));
            Assert.IsTrue(consoleOutput.Contains("Cédula: 987654321"));
            Assert.IsTrue(consoleOutput.Contains("Nombre: Maria"));
            Assert.IsTrue(consoleOutput.Contains("Apellido: Gomez"));
        }

    }
}


