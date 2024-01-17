using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace MBAdministration.Roles {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Roles Administration</summary>
        public static System.String RolAdministration {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("RolAdministration", CultureInfo.CurrentUICulture.Name,9);
                        }
                    catch (Exception)
                        {
                            return "[RolAdministration]";
                        }
               }
            }
            
        /// <summary>Search</summary>
        public static System.String RolSearch {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("RolSearch", CultureInfo.CurrentUICulture.Name,9);
                        }
                    catch (Exception)
                        {
                            return "[RolSearch]";
                        }
               }
            }
            
        /// <summary>Assign Menues</summary>
        public static System.String RolAssignMenu {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("RolAssignMenu", CultureInfo.CurrentUICulture.Name,9);
                        }
                    catch (Exception)
                        {
                            return "[RolAssignMenu]";
                        }
               }
            }
            
        /// <summary>Description</summary>
        public static System.String RolDescription {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("RolDescription", CultureInfo.CurrentUICulture.Name,9);
                        }
                    catch (Exception)
                        {
                            return "[RolDescription]";
                        }
               }
            }
            
        /// <summary>Must insert role name</summary>
        public static System.String warningRoleMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("warningRoleMessage", CultureInfo.CurrentUICulture.Name,9);
                        }
                    catch (Exception)
                        {
                            return "[warningRoleMessage]";
                        }
               }
            }
            
        /// <summary>Menues for the role</summary>
        public static System.String RolMenuAdministration {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("RolMenuAdministration", CultureInfo.CurrentUICulture.Name,9);
                        }
                    catch (Exception)
                        {
                            return "[RolMenuAdministration]";
                        }
               }
            }

        }        
}
