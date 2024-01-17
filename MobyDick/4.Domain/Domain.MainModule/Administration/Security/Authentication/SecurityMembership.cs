using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Cross.Security.Autetification;
using Application.MainModule.Security;
using Application.MainModule.Administration.Authentication;

namespace Domain.MainModule.Administration.Security.Authentication
{
    public class SecurityMembership : ISecurityMembership
    {
        public static IMembershipService service;

        public SecurityMembership(IMembershipService service)
        {
            SecurityMembership.service = service;
        }

        public void InitializeDatabaseConnection(string connectionStringName, string userTableName, string userIdColumn, string userNameColumn, bool autoCreateTables)
        {
            service.InitializeDatabaseConnection(connectionStringName, userTableName, userIdColumn, userNameColumn, autoCreateTables);
        }

        public void InitializeDatabaseConnection(string connectionString, string providerName, string userTableName, string userIdColumn, string userNameColumn, bool autoCreateTables)
        {
            service.InitializeDatabaseConnection(connectionString, providerName, userTableName, userIdColumn, userNameColumn, autoCreateTables);
        }

        public bool ChangePassword(string userName, string currentPassword, string newPassword)
        {
            return service.ChangePassword(userName, currentPassword, newPassword);
        }
        public bool ConfirmAccount(string accountConfirmationToken)
        {
            return service.ConfirmAccount(accountConfirmationToken);
        }

        public string CreateUserAndAccount(string userName, string password, object propertyValues = null, bool requireConfirmationToken = false)
        {
            return service.CreateUserAndAccount(userName, password,propertyValues, requireConfirmationToken);
        }

        public bool Login(string userName, string password, bool persistCookie = false)
        {
            // Validacion de IP y Franja Horaria
            return service.Login(userName, password, persistCookie);
        }

        public void Logout()
        {
            service.Logout();
        }

        public bool IsConfirmed(string userName)
        {
            return service.IsConfirmed(userName);
        }

        public int GetUserId(string userName)
        {
            return service.GetUserId(userName);
        }

        public string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow = 0x5a0)
        {
            return service.GeneratePasswordResetToken(userName, tokenExpirationInMinutesFromNow);
        }

        public string CreateAccount(string userName, string password, bool requireConfirmationToken = false)
        {
            return service.CreateAccount(userName, password, requireConfirmationToken);
        }

        public bool ResetPassword(string passwordResetToken, string newPassword)
        {
            return service.ResetPassword(passwordResetToken, newPassword);
        }

        public int MinPasswordLength
        {
            get { return service.MinPasswordLength; }
        }
    }
}
