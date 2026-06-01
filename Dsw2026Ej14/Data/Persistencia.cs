using Dsw2026Ej14.Data.Dtos;
using Dsw2026Ej14.Domain;
using System.Text.Json;

namespace Dsw2026Ej14.Data;

public class Persistencia
{
    private static readonly List<Sucursal> Sucursales = new List<Sucursal>();
    private static readonly List<Vehiculo> Vehiculos = new List<Vehiculo>();
    private static readonly List<Responsable> Responsables = new List<Responsable>();

    private static void InicializarResponsables()
    {
        var responsablesData = CargarDatosDeArchivo<ResponsableDto>("responsables");

        if (responsablesData != null)
        {
            foreach (var data in responsablesData)
            {
                Responsable r = new Responsable(data.Nombre, data.Documento, data.Telefono, data.Id);
                Responsables.Add(r);
            }
        }
    }

    private static void InicializarSucursales()
    {
        var sucursalesData = CargarDatosDeArchivo<SucursalDto>("sucursales");

        if (sucursalesData != null)
        {
            foreach (var data in sucursalesData)
            {
                var responsable = Responsables.Find(r => r.Id == data.ResponsableId);
                if (responsable != null)
                {
                    Sucursal s = new Sucursal(data.Codigo, data.Direccion, data.Ciudad, responsable, data.Id);
                    Sucursales.Add(s);
                }
            }
        }
    }

    private static void InicializarVehiculos()
    {
        var vehiculosData = CargarDatosDeArchivo<VehiculoDto>("vehiculos");

        if (vehiculosData != null)
        {
            foreach (var data in vehiculosData)
            {
                var sucursal = Sucursales.Find(s => s.Id == data.SucursalId);
                if (sucursal != null)
                {
                    Vehiculo vehiculo;
                    if (data.Tipo == "Electrico")
                    {
                        vehiculo = new VehiculoElectrico(data.Patente, data.Marca, data.Modelo, 
                            data.Anio, data.CapacidadCarga, sucursal, data.KwhBase, data.Id);
                    }
                    else
                    {
                        vehiculo = new VehiculoCombustible(data.Patente, data.Marca, data.Modelo, 
                            data.Anio, data.CapacidadCarga, sucursal, data.KilometrosPorLitro, data.LitrosExtra, data.Id);
                    }
                    Vehiculos.Add(vehiculo);
                }
            }
        }
    }

    private static List<T>? CargarDatosDeArchivo<T>(string file)
    {
        string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Sources", $"{file}.json");
        string jsonContent = File.ReadAllText(jsonPath);
        return JsonSerializer.Deserialize<List<T>>(jsonContent);
    }

    public static List<Vehiculo> GetVehiculos()
    {
        return Vehiculos;
    }

    public static Vehiculo? GetVehiculo(string patente)
    {
        return Vehiculos.Find(v => v.Patente == patente);
    }

    public static List<Sucursal> GetSucursales()
    {
        return Sucursales;
    }

    public static bool AgregarVehiculo(Vehiculo vehiculo)
    {
        try
        {
            Vehiculos.Add(vehiculo);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static void InicializarDatos()
    {
        InicializarResponsables();
        InicializarSucursales();
        InicializarVehiculos();
    }
}
