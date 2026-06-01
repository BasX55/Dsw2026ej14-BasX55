using Dsw2026Ej14.Data;
using Dsw2026Ej14.Domain;

namespace Dsw2026Ej14.Views;

public class Controlador
{
    private readonly ConsoleView _vista;

    public Controlador(ConsoleView vista)
    {
        _vista = vista;
    }

    public void ListarVehiculos()
    {
        List<VehiculoViewModel> vehiculos = [];
        foreach (Vehiculo vehiculo in Persistencia.GetVehiculos())
        {
            vehiculos.Add(new VehiculoViewModel(vehiculo));
        }
        _vista.ListarVehiculos(vehiculos);
    }

    public void CalcularConsumos(Dictionary<string, double> vehiculos)
    {
        double consumoElectricos = 0;
        double consumoCombustible = 0;
        foreach (KeyValuePair<string, double> entry in vehiculos)
        {
            double consumo = 0;
            Vehiculo? vehiculo = Persistencia.GetVehiculo(entry.Key);
            if (vehiculo != null)
            {
                consumo = vehiculo.CalcularConsumo(entry.Value);
                consumoElectricos += vehiculo.EsDe(VehiculoTipo.Electrico) ? consumo : 0;
                consumoCombustible += vehiculo.EsDe(VehiculoTipo.Combustible) ? consumo : 0;
            }
        }
        _vista.MostrarConsumos(consumoElectricos, consumoCombustible);
    }
}
