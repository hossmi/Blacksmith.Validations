using System.Collections.Generic;

namespace Blacksmith.Validations.Tests.SampleDomain.Services
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> getVehiclesContainingPlate(string plate);
    }
}