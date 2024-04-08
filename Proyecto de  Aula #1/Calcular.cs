using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de__Aula__1
{
    public class Calcular
    {
        public static int valorKilovatio = 850;
        public static int valorM3agua = 4600;
        public static double CalcularValorPagarServicios()
        {
            Console.Write("Ingrese el numero de cedula del cliente: ");
            int cedulaCliente = int.Parse(Console.ReadLine());
            Cliente cliente = ListaClientes.Find(c => c.Cedula == cedulaCliente);

            double valorParcial = cliente.ConsumoEnergia * valorKilovatio;
            double valorIncentivo = (cliente.MetaAhorro - cliente.ConsumoEnergia) * valorKilovatio;
            double valorPagarEnergia = valorParcial - valorIncentivo;

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
            double valorServios = valorPagarEnergia + valorPagarAgua;

            Console.WriteLine("El valor a pagar Energia es: " + valorPagarEnergia);
            Console.WriteLine("El valor a pagar Agua es: " + valorPagarAgua);
            Console.WriteLine("El valor a pagar de los servicios es: " + valorServios);
        }

        public static double CalcularPromedioConsumoEnergia(List<Cliente> clientes)
        {
            double sumatoriaConsumoEnergia = 0;
            foreach (Cliente cliente in ListaClientes)
            {
                sumatoriaConsumoEnergia += cliente.ConsumoEnergia;
            }

            double promedioConsumoGeneral = sumatoriaConsumoEnergia / ListaClientes.Count;
            Console.WriteLine("El promedio de consumo de energia es: " + promedioConsumoGeneral);
        }

        public static double CalcularTotalDescuentos(List<Cliente> clientes)
        {
            double totalDescuentosIncentivos = 0;
            foreach (Cliente cliente in ListaClientes)
            {
                if (cliente.ConsumoEnergia < cliente.MetaAhorro)
                {
                    double valorParcial = cliente.ConsumoEnergia * valorKilovatio;
                    double valorIncentivo = (cliente.MetaAhorro - cliente.ConsumoEnergia) * valorKilovatio;
                    totalDescuentosIncentivos += valorIncentivo;
                }

            }
            Console.WriteLine("El total de descuento es: " + totalDescuentosIncentivos);
        }

        public static double CalcularExcesoAgua(List<Cliente> clientes)
        {
            double contConsumoagua = 0;
            foreach (Cliente cliente in ListaClientes)
            {
                contConsumoagua += cliente.ConsumoAgua;
            }
            double promedioConsumoagua = contConsumoagua / ListaClientes.Count;
            double aguaMayorpromedio = 0;

            foreach (Cliente cliente in ListaClientes)
            {
                if (cliente.ConsumoAgua > promedioConsumoagua)
                {

                    aguaMayorpromedio += cliente.ConsumoAgua - promedioConsumoagua;
                }
            }
            Console.WriteLine("El total de exceso de agua es: " + aguaMayorpromedio);

        }

        public static void ContabilizarClientesMayorPromedioAgua()
        {
            double contCLientesMayorPromedio = 0;
            foreach (Cliente cliente in ListaClientes)
            {
                if (cliente.ConsumoAgua > cliente.PromedioAgua)
                {
                    contCLientesMayorPromedio += 1;
                }
            }
            Console.WriteLine("Los clientes que tuvieron un consumo de agua mayor al promedio fueron: " + contCLientesMayorPromedio);
        }
    }
}
