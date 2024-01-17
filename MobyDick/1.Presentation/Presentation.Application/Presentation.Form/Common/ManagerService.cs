using System;
using System.Collections.Generic;
using Infrastructure.Cross.IoC;

namespace Presentation.DesktopForm.Common
{
    public static class ManagerService
    {
        public static TEntidad GetService<TEntidad>() where TEntidad :class
        {
            return (TEntidad)FactoryIoC.Container.Resolve<TEntidad>();
        }

        public static TEntidad GetService<TEntidad>(string parameter) where TEntidad : class
        {
            return (TEntidad)FactoryIoC.Container.Resolve<TEntidad>(parameter);
        }


    }
}
