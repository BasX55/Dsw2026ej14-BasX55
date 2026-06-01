using Dsw2026Ej14.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Data;

public class Persistencia
{
    private static readonly List<Sucursal> Sucursales = new List<Sucursal>();
    private static readonly List<Vehiculo> Vehiculos = new List<Vehiculo>();
    private static readonly List<Responsable> Responsables = new List<Responsable>();

    private static void InicializarResponsables()
    {
        Responsable r1 = new Responsable("Carlos Gómez", "25444111", "3815551111");
        Responsable r2 = new Responsable("Laura Pérez", "30111222", "3815552222");
        Responsables.Add(r1);
        Responsables.Add(r2);
    }

    private static void InicializarSucursales()
    {
        Sucursal s1 = new Sucursal("SUC01", "Av. Belgrano 1200", "Tucumán", Responsables[0]);
        Sucursal s2 = new Sucursal("SUC02", "San Martín 450", "Yerba Buena", Responsables[1]);

        Sucursales.Add(s1);
        Sucursales.Add(s2);
    }

    private static void InicializarVehiculos()
    {
        Sucursal s1 = Sucursales[0];
        Sucursal s2 = Sucursales[1];
        var id = new Guid("DD0A4A95-8ED7-4CFB-ACC7-C2BAC23AB54C");
        VehiculoElectrico v1 = new VehiculoElectrico("AE123FG", "Renault", "Kangoo E-Tech", 2020, 1000, s1, 16, id);
        id = new Guid("B3BBB9CA-072F-47A2-8CA1-A0105B155BF9");
        VehiculoElectrico v2 = new VehiculoElectrico("AF456HI", "Ford", "E-Transit", 2021, 1300, s2, 16, id);
        id = new Guid("E09F407F-22A3-42F8-A114-5079FD4F999D");
        VehiculoCombustible v3 = new VehiculoCombustible("AC789JK", "Iveco", "Daily", 2023, 1200, s1, 8, 1.5, id);
        VehiculoCombustible v4 = new VehiculoCombustible("AD321LM", "Mercedes", "Sprinter", 2020, 1200, s2, 7, 1);

        Vehiculos.Add(v1);
        Vehiculos.Add(v2);
        Vehiculos.Add(v3);
        Vehiculos.Add(v4);
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
