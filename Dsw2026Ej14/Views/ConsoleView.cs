using Dsw2026Ej14.Domain.Entities;

namespace Dsw2026Ej14.Presentation.Views;

public class ConsoleView
{
    private Controlador _controlador;

    public ConsoleView()
    {
        _controlador = new Controlador(this);
    }

    

    public void ListarVehiculos(List<VehiculoViewModel> vehiculos)
    {
        LimpiarPantalla();
        string[] columnas = { "Patente", "Vehículo", "Tipo", "Cap. Carga", "Km/l", "Año", "L.Extra", "Kms a recorrer" };
        DibujarEncabezado(columnas);

        DibjuarDatos(columnas.Length, vehiculos);

        DibujarLinea();

        Console.Write("\n");
        Console.Write("\n");
        Console.WriteLine("Presione una tecla para calcular el total de consumos...");
        Console.ReadLine();
        Dictionary<string, double> vehiculosDict = [];
        foreach (VehiculoViewModel vehiculo in vehiculos)
        {
            vehiculosDict.Add(vehiculo.Patente, vehiculo.KmARecorrer);
        }
        _controlador.CalcularConsumos(vehiculosDict);
    }

    public void MostrarConsumos(double electricos, double combustible)
    {
        DibujarLinea();
        Console.WriteLine($"Total consumo Vehículos Eléctricos: {electricos:N2} kWh");
        Console.WriteLine($"Total consumo Vehículos Combustible: {combustible:N2} Litros");
        DibujarLinea();
        Console.Write("\n");
        Console.Write("\n");
        Console.WriteLine("Presione una tecla para salir...");
        Console.ReadLine();
    }

    public void AgregarVehiculo()
    {
        LimpiarPantalla();
        DibujarLinea();
        CentrarTexto("Agregar Nuevo Vehículo", out int _);
        DibujarLinea();
        Console.WriteLine();

        string patente = LeerTexto("Patente");
        string marca = LeerTexto("Marca");
        string modelo = LeerTexto("Modelo");
        int anio = LeerEntero("Año");
        double capacidadCarga = LeerDecimal("Capacidad de Carga (kg)");

        Sucursal? sucursal = SeleccionarSucursal();
        if (sucursal == null)
        {
            MostrarMensaje("Error: No se pudo seleccionar una sucursal.");
            return;
        }

        int tipoVehiculo = SeleccionarTipoVehiculo();

        if (tipoVehiculo == 1)
        {
            AgregarVehiculoElectrico(patente, marca, modelo, anio, capacidadCarga, sucursal);
        }
        else if (tipoVehiculo == 2)
        {
            AgregarVehiculoCombustible(patente, marca, modelo, anio, capacidadCarga, sucursal);
        }
    }

    private void AgregarVehiculoElectrico(string patente, string marca, string modelo, int anio, 
        double capacidadCarga, Sucursal sucursal)
    {
        Console.WriteLine();
        Console.WriteLine("=== Datos específicos para Vehículo Eléctrico ===");
        double kwhBase = LeerDecimal("kWh Base (por cada 100 km)");

        bool resultado = _controlador.AgregarVehiculoElectrico(patente, marca, modelo, anio, 
            capacidadCarga, sucursal, kwhBase);

        if (resultado)
        {
            MostrarMensaje("¡Vehículo eléctrico agregado exitosamente!");
        }
        else
        {
            MostrarMensaje("Error: No se pudo agregar el vehículo eléctrico.");
        }
    }

    private void AgregarVehiculoCombustible(string patente, string marca, string modelo, int anio, 
        double capacidadCarga, Sucursal sucursal)
    {
        Console.WriteLine();
        Console.WriteLine("=== Datos específicos para Vehículo de Combustible ===");
        double kmPorLitro = LeerDecimal("Kilómetros por Litro");
        double litrosExtra = LeerDecimal("Litros Extra");

        bool resultado = _controlador.AgregarVehiculoCombustible(patente, marca, modelo, anio, 
            capacidadCarga, sucursal, kmPorLitro, litrosExtra);

        if (resultado)
        {
            MostrarMensaje("¡Vehículo de combustible agregado exitosamente!");
        }
        else
        {
            MostrarMensaje("Error: No se pudo agregar el vehículo de combustible.");
        }
    }

    private Sucursal? SeleccionarSucursal()
    {
        Console.WriteLine();
        Console.WriteLine("=== Seleccione una Sucursal ===");

        List<Sucursal> sucursales = _controlador.ObtenerSucursales();

        for (int i = 0; i < sucursales.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sucursales[i].Codigo} - {sucursales[i].Ciudad} ({sucursales[i].Direccion})");
        }

        Console.Write("Seleccione el número de sucursal: ");
        if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= sucursales.Count)
        {
            return sucursales[seleccion - 1];
        }

        return null;
    }

    private int SeleccionarTipoVehiculo()
    {
        Console.WriteLine();
        Console.WriteLine("=== Seleccione el Tipo de Vehículo ===");
        Console.WriteLine("1. Vehículo Eléctrico");
        Console.WriteLine("2. Vehículo de Combustible");
        Console.Write("Seleccione el tipo: ");

        if (int.TryParse(Console.ReadLine(), out int tipo) && (tipo == 1 || tipo == 2))
        {
            return tipo;
        }

        return 0;
    }

    private string LeerTexto(string campo)
    {
        Console.Write($"{campo}: ");
        return Console.ReadLine() ?? string.Empty;
    }

    private int LeerEntero(string campo)
    {
        while (true)
        {
            Console.Write($"{campo}: ");
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                return valor;
            }
            Console.WriteLine("Error: Ingrese un número entero válido.");
        }
    }

    private double LeerDecimal(string campo)
    {
        while (true)
        {
            Console.Write($"{campo}: ");
            if (double.TryParse(Console.ReadLine(), out double valor))
            {
                return valor;
            }
            Console.WriteLine("Error: Ingrese un número válido.");
        }
    }

    private void MostrarMensaje(string mensaje)
    {
        Console.WriteLine();
        DibujarLinea();
        Console.WriteLine(mensaje);
        DibujarLinea();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadLine();
    }

    
    }

    #region Util
    private static void DibujarEncabezado()
    {
        LimpiarPantalla();
        DibujarLinea();
        CentrarTexto("Menú Principal - Empresa de Transporte", out int _);
        DibujarLinea();
    }

    private static void CentrarTexto(string? texto, out int usado, int? ancho = null, bool salto = true)
    {
        texto ??= string.Empty;
        ancho ??= Console.WindowWidth;
        int largo = texto.Length;
        if (largo > ancho)
        {
            largo = ancho.Value;
            texto = texto.Substring(0, ancho.Value);
        }
        int espacios = (ancho.Value - largo) / 2;
        espacios = espacios % 2 == 0 ? espacios : espacios + 1;
        string fin = salto ? "\n" : string.Empty;
        string final = new string(' ', espacios) + texto + fin;
        Console.Write(final);
        usado = final.Length;
    }
    private static void LimpiarPantalla()
    {
        Console.Clear();
    }
    private static void DibujarLinea()
    {
        var with = Console.WindowWidth;
        for (int i = 0; i < with; i++)
        {
            Console.Write("-");
        }
    }
    private static void DibujarEncabezado(params string[] columnas)
    {
        DibujarLinea();
        int ancho = Console.WindowWidth / columnas.Length;

        foreach (var columna in columnas)
        {
            Console.Write("|");
            CentrarTexto(columna, out int l, ancho - 1, false);
            Console.Write("".PadRight(ancho - 1 - l));
        }
        Console.Write("\n");
        DibujarLinea();
    }
    #endregion
}
