using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentation.AppTelerik.Area.Administration.Security.Interfaces
{
   public interface IViewLogin
    {
       void MenssageSucceful();

       void ErrorMessage();

       void ErrorMessageException(string message);
    }
}
