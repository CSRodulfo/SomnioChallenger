using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.Authentication
{
    public interface ISecurityMembership
    {
        void InitializeDatabaseConnection(string connectionStringName, string userTableName, string userIdColumn, string userNameColumn, bool autoCreateTables);
        void InitializeDatabaseConnection(string connectionString, string providerName, string userTableName, string userIdColumn, string userNameColumn, bool autoCreateTables);

        bool ChangePassword(string userName, string currentPassword, string newPassword);
        bool ConfirmAccount(string accountConfirmationToken);
        string CreateUserAndAccount(string userName, string password, object propertyValues = null, bool requireConfirmationToken = false);
        bool Login(string userName, string password, bool persistCookie = false);
        void Logout();
        bool IsConfirmed(string userName);
        int GetUserId(string userName);
        string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow = 0x5a0);
        string CreateAccount(string userName, string password, bool requireConfirmationToken = false);
        bool ResetPassword(string passwordResetToken, string newPassword);

        int MinPasswordLength { get; }
    }
}
