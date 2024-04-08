using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de__Aula__1
{
    internal class EstadisticasCliente
    {
        private static List<Cliente> ListaClientes { get; set; }
        private static double valorKilovatio;
        private static double valorM3agua;

        public static void Inicializar(List<Cliente> clientes, double kilovatio, double m3agua)
        {
            ListaClientes = clientes;
            valorKilovatio = kilovatio;
            valorM3agua = m3agua;
        }

        public static void MostrarPorcentajesConsumoAguaPorEstrato()
        {
            List<double> consumoTotalEstrato = new List<double>();
            List<double> excesoConsumoEstrato = new List<double>();

            for (int i = 0; i < 6; i++)
            {
                consumoTotalEstrato.Add(0);
                excesoConsumoEstrato.Add(0);
            }
            foreach (Cliente cliente in ListaClientes)
            {
                consumoTotalEstrato[cliente.Estrato - 1] += cliente.ConsumoAgua;
                excesoConsumoEstrato[cliente.Estrato - 1] += Math.Max(cliente.ConsumoAgua - cliente.PromedioAgua, 0);
            }
            for (int i = 0; i < consumoTotalEstrato.Count; i++)
            {
                double porcentaje = 0;
                if (consumoTotalEstrato[i] > 0)
                {
                    porcentaje = (excesoConsumoEstrato[i] / consumoTotalEstrato[i]) * 100;
                }
                Console.WriteLine($"Estrato {i + 1}: {porcentaje}%");
            }
        }

        public static void MostrarClienteMayorDiferencia()
        {
            Cliente clienteMayorDiferencia = null;
            double mayorDifencia = 0;

            foreach (Cliente cliente in ListaClientes)
            {
                double diferencia = cliente.ConsumoEnergia - cliente.MetaAhorro;

                if (diferencia > mayorDifencia)
                {
                    clienteMayorDiferencia = cliente;
                    mayorDifencia = diferencia;
                }
            }
            if (clienteMayorDiferencia != null)
            {
                Console.WriteLine("Informacion del cliente con mayor desface");
                Console.WriteLine($"Nombre: {clienteMayorDiferencia.Nombre}");
                Console.WriteLine($"Apellido: {clienteMayorDiferencia.Apellido}");
                Console.WriteLine($"Cedula: {clienteMayorDiferencia.Cedula}");
                Console.WriteLine($"Estrato: {clienteMayorDiferencia.Estrato}");
                Console.WriteLine($"MetaAhorro: {clienteMayorDiferencia.MetaAhorro}");
                Console.WriteLine($"ConsumoEnergia: {clienteMayorDiferencia.ConsumoEnergia}");
                Console.WriteLine($"PromedioAgua: {clienteMayorDiferencia.PromedioAgua}");
                Console.WriteLine($"ConsumoAgua: {clienteMayorDiferencia.ConsumoAgua}");
                Console.WriteLine($"PeriodoDeConsumo: {clienteMayorDiferencia.PeriodoDeConsumo}");
            }
            else
            {
                Console.WriteLine("No se encontro ningun cliente.");
            }
        }

        public static void MostrarEstratoMayorAhorroAgua()
        {
            int[] ahorroPorEstrato = new int[6];

            foreach (Cliente cliente in ListaClientes)
            {
                int ahorro = cliente.PromedioAgua - cliente.ConsumoAgua;
                if (ahorro > 0 && cliente.Estrato >= 1 && cliente.Estrato <= 6)
                {
                    ahorroPorEstrato[cliente.Estrato - 1] += ahorro;
                }
            }
            int estratoMayorAhorro = Array.IndexOf(ahorroPorEstrato, ahorroPorEstrato.Max()) + 1;

            if (estratoMayorAhorro != -1)
            {
                Console.WriteLine($"El estrato con mayor ahorro de agua es: {estratoMayorAhorro}");
            }
            else
            {
                Console.WriteLine("No se encontró ningún estrato con ahorro de agua.");
            }
        }

        public static void MostrarEstratoMayorMenorConsumoEnergia()
        {
            double[] consumoEnergiaPorEstrato = new double[6];
            for (int i = 0; i < consumoEnergiaPorEstrato.Length; i++)
            {
                consumoEnergiaPorEstrato[i] = 0;
            }


            foreach (Cliente cliente in ListaClientes)
            {

                int indiceEstrato = cliente.Estrato - 1;


                consumoEnergiaPorEstrato[indiceEstrato] += cliente.ConsumoEnergia;
            }


            int estratoMayorConsumo = Array.IndexOf(consumoEnergiaPorEstrato, consumoEnergiaPorEstrato.Max()) + 1;
            int estratoMenorConsumo = Array.IndexOf(consumoEnergiaPorEstrato, consumoEnergiaPorEstrato.Min()) + 1;

            Console.WriteLine($"El estrato con mayor consumo de energía es: {estratoMayorConsumo}");
            Console.WriteLine($"El estrato con menor consumo de energía es: {estratoMenorConsumo}");
        }

        public static void MostrarValorTotalPagar()
        {
            double totalValorEnergia = 0;
            double totalValorAgua = 0;

            foreach (Cliente cliente in ListaClientes)
            {
                double valorParcialEnergia = cliente.ConsumoEnergia * valorKilovatio;
                double valorIncentivoEnergia = (cliente.MetaAhorro - cliente.ConsumoEnergia) * valorKilovatio;
                double valorPagarEnergia = valorParcialEnergia - valorIncentivoEnergia;

                double valorPagarAgua;
                if (cliente.ConsumoAgua > cliente.PromedioAgua)
                {
                    double excesoAgua = cliente.ConsumoAgua - cliente.PromedioAgua;
                    double castigoExceso = excesoAgua * (2 * valorM3agua);
                    double costoPromedio = cliente.PromedioAgua * valorM3agua;
                    valorPagarAgua = costoPromedio + castigoExceso;
                }
                else
                {
                    valorPagarAgua = cliente.ConsumoAgua * valorM3agua;
                }

                totalValorEnergia += valorPagarEnergia;
                totalValorAgua += valorPagarAgua;
            }

            double totalValorServicios = totalValorEnergia + totalValorAgua;
            Console.WriteLine("El valor total que los clientes le pagan a la empresa por concepto de energía y agua es: " + totalValorServicios);
        }

        public static void MayorConsumoDeAguaPorPeriodoDeConsumo()
        {
            double mayorConsumoPeriodo = 0;
            Cliente clienteMayorConsumoPeriodo = null;

            Console.WriteLine("Ingrese el periodo en el cual desea ver el mayor consumo de agua");
            int periodoCliente = int.Parse(Console.ReadLine());



            foreach (Cliente cliente in ListaClientes)
            {
                if (cliente.PeriodoDeConsumo == periodoCliente && cliente.ConsumoAgua > mayorConsumoPeriodo)
                {
                    mayorConsumoPeriodo = cliente.ConsumoAgua;
                    clienteMayorConsumoPeriodo = cliente;
                }
            }

            if (clienteMayorConsumoPeriodo != null)
            {
                Console.WriteLine("Cliente con mayor consumo de agua en el periodo " + periodoCliente + ":");
                Console.WriteLine($"Cédula: {clienteMayorConsumoPeriodo.Cedula}");
                Console.WriteLine($"Nombre: {clienteMayorConsumoPeriodo.Nombre}");
                Console.WriteLine($"Apellido: {clienteMayorConsumoPeriodo.Apellido}");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún cliente con consumo de agua en el periodo {periodoCliente}.");
            }

            Console.ReadLine();
        }



    }
}
