using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Cross.Security.Autetification.IAutetification
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}