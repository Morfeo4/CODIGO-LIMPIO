using System;
using System.Collections.Generic;

namespace Proyecto_de__Aula__1
{
    public class GestionClientes
    {
        private List<Cliente> ListaClientes { get; set; }
        private int SumatoriaConsumoEnergia { get; set; }

        public GestionClientes()
        {
            ListaClientes = new List<Cliente>();
            SumatoriaConsumoEnergia = 0;
        }

        public void GestionarInformacionClientes()
        {
            int subOpcion;
            do
            {
                MostrarMenuGestionClientes();
                subOpcion = int.Parse(Console.ReadLine());
                ProcesarSubOpcionGestionClientes(subOpcion);
            } while (subOpcion != 5);
        }

        private void MostrarMenuGestionClientes()
        {
            Console.WriteLine("¿Qué desea hacer?");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1. Ingresar nuevo cliente");
            Console.WriteLine("2. Mostrar información de un cliente");
            Console.WriteLine("3. Editar información de un cliente");
            Console.WriteLine("4. Eliminar cliente");
            Console.WriteLine("5. Volver al menú principal");
            Console.WriteLine("------------------------------------");
        }

        private void ProcesarSubOpcionGestionClientes(int subOpcion)
        {
            switch (subOpcion)
            {
                case 1:
                    IngresarNuevoCliente();
                    break;
                case 2:
                    MostrarInformacionCliente();
                    break;
                case 3:
                    EditarInformacionCliente();
                    break;
                case 4:
                    EliminarCliente();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        private void IngresarNuevoCliente()
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

        private void MostrarInformacionCliente()
        {
            Console.WriteLine("Clientes disponibles: ");
            foreach (Cliente cliente in ListaClientes)
            {
                Console.WriteLine(cliente.Nombre);
            }

            Console.WriteLine("Ingrese el nombre del cliente que desea ver información");
            string nombreCliente = Console.ReadLine();

            Cliente clienteEditar = ListaClientes.Find(c => c.Nombre == nombreCliente);

            if (clienteEditar != null)
            {
                Console.WriteLine("Información actual");
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

        private void EditarInformacionCliente()
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
                Console.WriteLine("Información actual");
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

        private void EliminarCliente()
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
    }
}
