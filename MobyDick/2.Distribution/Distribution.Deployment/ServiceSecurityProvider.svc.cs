using Application.MainModule.Administration.Authentication;
using Distribution.MainModule.Administration.Security;
using Infrastructure.Cross.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Distribution.Deployment
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceSecurity" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceSecurity.svc o ServiceSecurity.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceSecurityProvider : IServiceMembershipProvider
    {
        public void DoWork()
        {
        }

        public bool Login(string Name, string Password, bool persiste = false)
        {
            ISecurityMembership servicio = FactoryIoC.Container.Resolve<ISecurityMembership>("FORM");

            if (!WebMatrix.WebData.WebSecurity.Initialized)
            {
                servicio.InitializeDatabaseConnection("ConnStringForWebSecurity", "Users", "UserId", "UserName", autoCreateTables: false);
            }
            
            return servicio.Login(Name, Password, persiste);
        }
    }
}
