using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Application.MainModule.Administration.Authentication;
using Application.MainModule.Services;

namespace Distribution.MainModule.Administration.Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceMembershipProvider : IServiceMembershipProvider
    {
        public ISecurityMembership MembershipService { get; set; }

        public ServiceMembershipProvider(ISecurityMembership service)
        {
            MembershipService = service;
        }

        public bool Login(string Name, string Password, bool persiste = false)
        {
            try
            {
                return MembershipService.Login(Name, Password, persiste);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
