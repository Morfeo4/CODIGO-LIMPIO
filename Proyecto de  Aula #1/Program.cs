using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proyecto_de__Aula__1
{
    class Cliente
    {
        public int cedula { get; set; }
        public int estrato { get; set; }
        public double metaAhorro { get; set; }
        public double consumoEnergia { get; set; }
        public double consumoAgua { get; set; }
        public double promedioAgua { get; set; }
        class ProgramaEPM
        {
            static List<Cliente> ListaClientes = new List<Cliente>();
            static double SumatoriaConsumoEnergia = 0;
            static void Main()
            {
                int opciones;
                do
                {
                    Console.WriteLine("Hola bienvenido ¿Que desea hacer?: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("1. Ingresar cliente: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("2. Calcular valor a pagar por los servicios: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("3. Calcular promedio de consumo actual de energia: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("4.Calcular el valor total que se le dio a los clientes por concepto de descuentos: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("5. Mostrar la cantidad total de mt3 de agua que se consumieron por encima del promedio: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("6. Mostrar los porcentajes de consumo excesivo de agua por estrato: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("7. Contabilizar los clientes que tuvieron un consumo de agua mayor al promedio. : ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("8. Salir");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    opciones = int.Parse(Console.ReadLine());
                    if (opciones == 1)
                    {
                        Cliente nuevoCliente = new Cliente();

                        Console.Write("Ingrese cedula del cliente: ");
                        nuevoCliente.cedula = int.Parse(Console.ReadLine());
                        Console.Write("Estrato del cliente: ");
                        nuevoCliente.estrato = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese meta de ahorro: ");
                        nuevoCliente.metaAhorro = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese consumo actual de energia: ");
                        nuevoCliente.consumoEnergia = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese promedio de consumo de agua: ");
                        nuevoCliente.promedioAgua = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese consumo actual de agua: ");
                        nuevoCliente.consumoAgua = double.Parse(Console.ReadLine());
                        SumatoriaConsumoEnergia += nuevoCliente.consumoEnergia;
                        ListaClientes.Add(nuevoCliente);
                    }
                    else if (opciones == 2)
                    {
                        Console.Write("Ingrese el numero de cedula del cliente: ");
                        int cedulaCliente = int.Parse(Console.ReadLine());
                        Cliente cliente = ListaClientes.Find(c => c.cedula == cedulaCliente);

                        double valorParcial = cliente.consumoEnergia * 850;
                        double valorIncentivo = (cliente.metaAhorro - cliente.consumoEnergia) * 850;
                        double valorPagar = valorParcial - valorIncentivo;

                        double excesoAgua = cliente.consumoAgua - cliente.promedioAgua;
                        double castigoExceso = excesoAgua * (2 * 4600);
                        double costoPromedio = cliente.promedioAgua * 4600;
                        double valorPagarAgua = costoPromedio + castigoExceso;
                        double valorServios = valorPagar + valorPagarAgua;

                        Console.WriteLine("El valor a pagar Energia es: " + valorPagar);
                        Console.WriteLine("El valor a pagar Agua es: " + valorPagarAgua);
                        Console.WriteLine("El valor a pagar de los servicios es: " + valorServios);
                    }
                    else if (opciones == 3)
                    {
                        double promedioConsumoGeneral = SumatoriaConsumoEnergia / ListaClientes.Count;
                        Console.WriteLine("El promedio de consumo de energia es: " + promedioConsumoGeneral);
                    }
                    else if (opciones == 4)
                    {
                        double totalDescuentosIncentivos = 0;
                        foreach (Cliente cliente in ListaClientes)
                        {
                            double valorParcial = cliente.consumoEnergia * 850;
                            double valorIncentivo = (cliente.metaAhorro - cliente.consumoEnergia) * 850;
                            totalDescuentosIncentivos += valorIncentivo;
                        }
                        Console.WriteLine("El total de descuento es: " + totalDescuentosIncentivos);
                    }
                    else if (opciones == 5)
                    {
                        double contConsumoagua = 0;
                        foreach(Cliente cliente in ListaClientes)
                        {
                            contConsumoagua += cliente.consumoAgua;
                        }
                        double promedioConsumoagua=contConsumoagua/ ListaClientes.Count;
                        double aguaMayorpromedio = 0;

                        foreach (Cliente cliente in ListaClientes)
                        {
                            if (cliente.consumoAgua > promedioConsumoagua)
                            {
                                
                                aguaMayorpromedio += cliente.consumoAgua - cliente.promedioAgua;
                            }
                        }
                        Console.WriteLine("El total de exceso de agua es: " + aguaMayorpromedio);
                    }
                    else if (opciones == 6)
                    {
                        List<double> consumoTotalEstrato = new List<double>();
                        List<double> excesoConsumoEstrato = new List<double>();

                        for (int i = 0; i<6; i++)
                        {
                            consumoTotalEstrato.Add(0);
                            excesoConsumoEstrato.Add(0);
                        }
                        foreach (Cliente cliente in ListaClientes)
                        {
                            consumoTotalEstrato[cliente.estrato - 1] += cliente.consumoAgua;
                            excesoConsumoEstrato[cliente.estrato - 1] += Math.Max(cliente.consumoAgua - cliente.promedioAgua, 0);
                        }
                        for (int i = 0; i < consumoTotalEstrato.Count; i++)
                        {
                            double porcentaje = 0;
                            if (consumoTotalEstrato[i] > 0)
                            {
                                porcentaje = (excesoConsumoEstrato[i] / consumoTotalEstrato[i]) * 100;
                            }
                            Console.WriteLine($"Estrato {i+1}: {porcentaje}%");
                        }
                    }
                    else if (opciones==7)
                    {
                        double contCLientesMayorPromedio = 0;
                      foreach(Cliente cliente in ListaClientes)
                        {
                            if (cliente.consumoAgua > cliente.promedioAgua)
                            {
                                contCLientesMayorPromedio += 1;
                            }
                        }
                      Console.WriteLine("Los clientes que tuvieron un consumo de agua mayor al promedio fueron: "+contCLientesMayorPromedio);
                    }
                    else if (opciones == 8)
                    {
                        return;
                    }
                    Console.WriteLine();
                } while (opciones != 8);
            }
    }   }
}
