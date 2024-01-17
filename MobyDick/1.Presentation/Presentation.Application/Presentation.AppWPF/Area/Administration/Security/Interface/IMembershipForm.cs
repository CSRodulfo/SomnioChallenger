using System;

namespace Presentation.AppWPF.Area.Administration.Security.Interfaces
{
    public interface IMembershipForm
    {
        /// <summary>
        /// Retorna si es satisfatorio el logueo del usuario o no.
        /// </summary>
        /// <param name="Name">Nombre del usuario</param>
        /// <param name="Password">Password del usuaio</param>
        /// <param name="persiste"></param>
        /// <returns>Verdadero si el usuario se ha logueado caso contrario falso.</returns>
        bool Login(string Name, string Password, bool persiste = false);
    }
}
