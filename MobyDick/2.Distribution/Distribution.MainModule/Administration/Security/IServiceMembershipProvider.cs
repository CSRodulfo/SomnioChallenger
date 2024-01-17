using Application.MainModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Distribution.MainModule.Administration.Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceMembershipProvider
    {
        [OperationContract]
        bool Login(string Name, string Password, bool persiste = false);

    }
}
