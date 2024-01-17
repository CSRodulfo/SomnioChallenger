using System.Collections.Generic;
using Application.MainModule.Services;
using Domain.Entities;
using Infrastructure.Cross.IoC;

namespace Presentation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //IServiceTest service = FactoryIoC.Container.Resolve<IServiceTest>();
            //List<Domain.Entities.TestData> result = service.GetAll();
            //foreach (Domain.Entities.TestData td in result)
            //    System.Console.WriteLine(td.description);
            //System.Console.ReadKey();
            //IServiceVehicle service = FactoryIoC.Container.Resolve<IServiceVehicle>();
            //List<Vehicle> result = service.GetAll();
            System.Console.ReadKey();            
        }
    }
}
