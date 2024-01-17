using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace MBAdministration.Users {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>E-mail</summary>
        public static System.String Email {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Email", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[Email]";
                        }
               }
            }
            
        /// <summary>First name</summary>
        public static System.String FirstName {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("FirstName", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[FirstName]";
                        }
               }
            }
            
        /// <summary>Last Name</summary>
        public static System.String LastName {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("LastName", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[LastName]";
                        }
               }
            }
            
        /// <summary>Administration Users</summary>
        public static System.String UserAdministration {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("UserAdministration", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[UserAdministration]";
                        }
               }
            }
            
        /// <summary>New User</summary>
        public static System.String NewUser {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("NewUser", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[NewUser]";
                        }
               }
            }
            
        /// <summary>User</summary>
        public static System.String UserName {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("UserName", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[UserName]";
                        }
               }
            }
            
        /// <summary>Password</summary>
        public static System.String Password {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Password", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[Password]";
                        }
               }
            }
            
        /// <summary>Password Confirm</summary>
        public static System.String PasswordConfirm {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("PasswordConfirm", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[PasswordConfirm]";
                        }
               }
            }
            
        /// <summary>Language</summary>
        public static System.String Languege {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Languege", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[Languege]";
                        }
               }
            }
            
        /// <summary>The password and the password confirm not match.</summary>
        public static System.String PasswordError {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("PasswordError", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[PasswordError]";
                        }
               }
            }
            
        /// <summary>List Users</summary>
        public static System.String UserList {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("UserList", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[UserList]";
                        }
               }
            }
            
        /// <summary>User Edit</summary>
        public static System.String UserEdit {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("UserEdit", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[UserEdit]";
                        }
               }
            }
            
        /// <summary>Assign Roles</summary>
        public static System.String AssignRoles {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("AssignRoles", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[AssignRoles]";
                        }
               }
            }
            
        /// <summary>Assign Roles for User {0}</summary>
        public static System.String AssignRolesForUser {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("AssignRolesForUser", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[AssignRolesForUser]";
                        }
               }
            }
            
        /// <summary>Assign Rol</summary>
        public static System.String BtnAssign {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnAssign", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[BtnAssign]";
                        }
               }
            }
            
        /// <summary>Reset Password</summary>
        public static System.String BtnReset {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnReset", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[BtnReset]";
                        }
               }
            }
            
        /// <summary>Language</summary>
        public static System.String Language {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Language", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[Language]";
                        }
               }
            }
            
        /// <summary>Change Language</summary>
        public static System.String ChangeLanguage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ChangeLanguage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[ChangeLanguage]";
                        }
               }
            }
            
        /// <summary>Configuration</summary>
        public static System.String ManageTitle {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ManageTitle", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[ManageTitle]";
                        }
               }
            }
            
        /// <summary>You are logged as </summary>
        public static System.String SessionMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("SessionMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[SessionMessage]";
                        }
               }
            }
            
        /// <summary>Current Password</summary>
        public static System.String OldPassword {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("OldPassword", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[OldPassword]";
                        }
               }
            }
            
        /// <summary>New Password</summary>
        public static System.String NewPassword {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("NewPassword", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[NewPassword]";
                        }
               }
            }
            
        /// <summary>Confirm Password</summary>
        public static System.String ConfirmPassword {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ConfirmPassword", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[ConfirmPassword]";
                        }
               }
            }
            
        /// <summary>The user name is already in use</summary>
        public static System.String repeatUserMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("repeatUserMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[repeatUserMessage]";
                        }
               }
            }
            
        /// <summary>Could not register the user</summary>
        public static System.String errorUserMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("errorUserMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[errorUserMessage]";
                        }
               }
            }
            
        /// <summary>There was an error where changing password</summary>
        public static System.String errorPasswordMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("errorPasswordMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[errorPasswordMessage]";
                        }
               }
            }
            
        /// <summary>The password has been changed successfully</summary>
        public static System.String PasswordMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("PasswordMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[PasswordMessage]";
                        }
               }
            }
            
        /// <summary>The user was removed successfully</summary>
        public static System.String DeleteUserMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("DeleteUserMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[DeleteUserMessage]";
                        }
               }
            }
            
        /// <summary>Could not modify the user</summary>
        public static System.String errorEditUserMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("errorEditUserMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[errorEditUserMessage]";
                        }
               }
            }
            
        /// <summary>The user was changed successfully</summary>
        public static System.String EditUserMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("EditUserMessage", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[EditUserMessage]";
                        }
               }
            }
            
        /// <summary>First and LastName</summary>
        public static System.String FirstAndLastName {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("FirstAndLastName", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[FirstAndLastName]";
                        }
               }
            }
            
        /// <summary>The password has been changed.</summary>
        public static System.String ChangePasswordSuccess {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ChangePasswordSuccess", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[ChangePasswordSuccess]";
                        }
               }
            }
            
        /// <summary>The password has been saved.</summary>
        public static System.String SetPasswordSuccess {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("SetPasswordSuccess", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[SetPasswordSuccess]";
                        }
               }
            }
            
        /// <summary>The external login was removed.</summary>
        public static System.String RemoveLoginSuccess {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("RemoveLoginSuccess", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[RemoveLoginSuccess]";
                        }
               }
            }
            
        /// <summary>The culture was modified.</summary>
        public static System.String ChangeCultureSuccess {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ChangeCultureSuccess", CultureInfo.CurrentUICulture.Name,22);
                        }
                    catch (Exception)
                        {
                            return "[ChangeCultureSuccess]";
                        }
               }
            }

        }        
}
