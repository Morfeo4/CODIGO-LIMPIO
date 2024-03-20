using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proyecto_de__Aula__1
{
   
    
      
        public static class ProgramaEPM
        {
            static List<Cliente> ListaClientes = new List<Cliente>();
            static double SumatoriaConsumoEnergia = 0;
            static void Main()
            {
                int valorKilovatio = 850;
                int valorM3agua = 4600;
                int opciones;
                do
                {
                    Console.WriteLine("Hola bienvenido ¿Que desea hacer?: ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("1. Ingresar o editar la informacion del cliente: ");
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
                    Console.WriteLine("8. Mostrar los datos del cliente que tuvo mayor iferencia del consumo de energía con respecto a la meta de ahorro : ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("9. Mostrar el estrato en el cual los clientes ahorraron la mayor cantidad de agua : ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("10. Mostrar el estrato con el mayor y menor consumo de energía : ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("11. Mostrar el valor total que los clientes le pagan a la empresa por concepto de energía y agua. : ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("12. Salir");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    opciones = int.Parse(Console.ReadLine());
                if (opciones == 1)
                {
                    int subOpcion;
                    do
                    {
                        Console.WriteLine("¿Que desea hacer?");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("1. Ingresar nuevo cliente");
                        Console.WriteLine("2. Mostrar informacion de un cliente");
                        Console.WriteLine("3. Editar informacion de un cliente");
                        Console.WriteLine("4. Eliminar cliente");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.WriteLine("------------------------------------");
                        Console.Write("Seleccione una opción: ");
                        subOpcion = int.Parse(Console.ReadLine());

                        if (subOpcion == 1)
                        {
                            Cliente nuevoCliente = new Cliente();

                            Console.Write("Ingrese nombre del cliente: ");
                            nuevoCliente.Nombre = Console.ReadLine();
                            Console.Write("Ingrese apellido del cliente: ");
                            nuevoCliente.Apellido = Console.ReadLine();
                            Console.Write("Ingrese cedula del cliente: ");
                            nuevoCliente.Cedula = int.Parse(Console.ReadLine());
                            Console.Write("Estrato del cliente: ");
                            nuevoCliente.Estrato = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese meta de ahorro: ");
                            nuevoCliente.MetaAhorro = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese consumo actual de energia: ");
                            nuevoCliente.ConsumoEnergia = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese promedio de consumo de agua: ");
                            nuevoCliente.PromedioAgua = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese consumo actual de agua: ");
                            nuevoCliente.ConsumoAgua = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese periodo de consumo del cliente: ");
                            nuevoCliente.PeriodoDeConsumo = int.Parse(Console.ReadLine());

                            SumatoriaConsumoEnergia += nuevoCliente.ConsumoEnergia;
                            ListaClientes.Add(nuevoCliente);
                        }

                        else if (subOpcion == 2)
                        {
                            Console.WriteLine("Clientes disponibles: ");
                            foreach (Cliente cliente in ListaClientes)
                            {
                                Console.WriteLine(cliente.Nombre);

                            }

                            Console.WriteLine("Ingrese el nombre del cliente que desea ver informacion");
                            string nombreCliente = Console.ReadLine();

                            Cliente clienteEditar = ListaClientes.Find(c => c.Nombre == nombreCliente);

                            if (clienteEditar != null)
                            {
                                Console.WriteLine("Informacion actual");
                                Console.WriteLine($"Nombre: {clienteEditar.Nombre}");
                                Console.WriteLine($"Apellido: {clienteEditar.Apellido}");
                                Console.WriteLine($"Cedula: {clienteEditar.Cedula}");
                                Console.WriteLine($"Estrato: {clienteEditar.Estrato}");
                                Console.WriteLine($"MetaAhorro: {clienteEditar.MetaAhorro}");
                                Console.WriteLine($"ConsumoEnergia: {clienteEditar.ConsumoEnergia}");
                                Console.WriteLine($"PromedioAgua: {clienteEditar.PromedioAgua}");
                                Console.WriteLine($"ConsumoAgua: {clienteEditar.ConsumoAgua}");
                                Console.WriteLine($"PeriodoDeConsumo: {clienteEditar.PeriodoDeConsumo}");

                            }
                            else
                            {
                                Console.WriteLine("El cliente ingresado no existe");
                            }
                        }
                        else if (subOpcion == 3)
                        {
                            Console.WriteLine("Clientes disponibles: ");
                            foreach (Cliente cliente in ListaClientes)
                            {
                                Console.WriteLine(cliente.Nombre);

                            }

                            Console.WriteLine("Ingrese el nombre del cliente que desea editar");
                            string nombreCliente = Console.ReadLine();

                            Cliente clienteEditar = ListaClientes.Find(c => c.Nombre == nombreCliente);

                            if (clienteEditar != null)
                            {
                                Console.WriteLine("Informacion actual");
                                Console.WriteLine($"Nombre: {clienteEditar.Nombre}");
                                Console.WriteLine($"Apellido: {clienteEditar.Apellido}");
                                Console.WriteLine($"Cedula: {clienteEditar.Cedula}");
                                Console.WriteLine($"Estrato: {clienteEditar.Estrato}");
                                Console.WriteLine($"MetaAhorro: {clienteEditar.MetaAhorro}");
                                Console.WriteLine($"ConsumoEnergia: {clienteEditar.ConsumoEnergia}");
                                Console.WriteLine($"PromedioAgua: {clienteEditar.PromedioAgua}");
                                Console.WriteLine($"ConsumoAgua: {clienteEditar.ConsumoAgua}");
                                Console.WriteLine($"PeriodoDeConsumo: {clienteEditar.PeriodoDeConsumo}");

                                Console.WriteLine("Ingrese los nuevos datos");

                                Console.WriteLine("Seleccione el número del campo que desea editar:");
                                Console.WriteLine("1. Nombre");
                                Console.WriteLine("2. Apellido");
                                Console.WriteLine("3. Cedula");
                                Console.WriteLine("4. Estrato");
                                Console.WriteLine("5. MetaAhorro");
                                Console.WriteLine("6. ConsumoEnergia");
                                Console.WriteLine("7. PromedioAgua");
                                Console.WriteLine("8. ConsumoAgua");
                                Console.WriteLine("9. PeriodoDeConsumo");

                                int opcion = int.Parse(Console.ReadLine());

                                if (opcion == 1)
                                {
                                    Console.Write("Ingrese el nuevo nombre: ");
                                    clienteEditar.Nombre = Console.ReadLine();
                                }
                                else if (opcion == 2)
                                {
                                    Console.Write("Ingrese el nuevo apellido: ");
                                    clienteEditar.Apellido = Console.ReadLine();
                                }
                                else if (opcion == 3)
                                {
                                    Console.Write("Ingrese la nueva cédula: ");
                                    clienteEditar.Cedula = int.Parse(Console.ReadLine());
                                }
                                else if (opcion == 4)
                                {
                                    Console.Write("Ingrese el nuevo estrato: ");
                                    clienteEditar.Estrato = int.Parse(Console.ReadLine());
                                }
                                else if (opcion == 5)
                                {
                                    Console.Write("Ingrese la nueva meta de ahorro: ");
                                    clienteEditar.MetaAhorro = int.Parse(Console.ReadLine());
                                }
                                else if (opcion == 6)
                                {
                                    Console.Write("Ingrese lel nuevo consumo de energia: ");
                                    clienteEditar.ConsumoEnergia = int.Parse(Console.ReadLine());
                                }
                                else if (opcion == 7)
                                {
                                    Console.Write("Ingrese el nuevo promedio de agua: ");
                                    clienteEditar.PromedioAgua = int.Parse(Console.ReadLine());
                                }
                                else if (opcion == 8)
                                {
                                    Console.Write("Ingrese el nuevo consumo de agua: ");
                                    clienteEditar.ConsumoAgua = int.Parse(Console.ReadLine());
                                }
                                else if (opcion == 9)
                                {
                                    Console.Write("Ingrese el nuevo periodo de consumo: ");
                                    clienteEditar.PeriodoDeConsumo = int.Parse(Console.ReadLine());
                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida");
                                }

                                Console.WriteLine("¡El dato ha sido actualizado correctamente!");

                            }
                            else
                            {
                                Console.WriteLine("El cliente ingresado no existe");
                            }
                        }

                        else if (subOpcion == 4)
                        {
                            Console.WriteLine("Clientes disponibles: ");
                            foreach (Cliente cliente in ListaClientes)
                            {
                                Console.WriteLine(cliente.Nombre);

                            }

                            Console.WriteLine("Ingrese el nombre del cliente que desea editar");
                            string nombreCliente = Console.ReadLine();

                            Cliente clienteEliminar = ListaClientes.Find(c => c.Nombre == nombreCliente);

                            if (clienteEliminar != null)
                            {
                                ListaClientes.Remove(clienteEliminar);
                                Console.WriteLine("El cliente ha sido eliminado correctamente. ");
                            }
                            else
                            {
                                Console.WriteLine("El cliente ingresado no existe");
                            }
                        }


                    } while (subOpcion != 5);


                }
                else if (opciones == 2)
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
                        if (cliente.ConsumoEnergia < cliente.MetaAhorro)
                        {
                            double valorParcial = cliente.ConsumoEnergia * valorKilovatio;
                            double valorIncentivo = (cliente.MetaAhorro - cliente.ConsumoEnergia) * valorKilovatio;
                            totalDescuentosIncentivos += valorIncentivo;
                        }

                    }
                    Console.WriteLine("El total de descuento es: " + totalDescuentosIncentivos);
                }
                else if (opciones == 5)
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
                else if (opciones == 6)
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
                else if (opciones == 7)
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
                else if (opciones == 8)
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


                else if (opciones == 9)
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
                else if (opciones == 10)
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
                else if (opciones == 11)
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

                else if (opciones == 12)
                {
                    return;
                }
                    Console.WriteLine();
                } while (opciones != 12);
            }
    }   }

