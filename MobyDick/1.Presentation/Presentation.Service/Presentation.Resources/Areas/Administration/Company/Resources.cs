using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace MBAdministration.Company {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Administración de compañía</summary>
        public static System.String MenuCompany {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuCompany", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[MenuCompany]";
                        }
               }
            }
            
        /// <summary>CUIT</summary>
        public static System.String CUIT {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CUIT", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[CUIT]";
                        }
               }
            }
            
        /// <summary>Company Name</summary>
        public static System.String CompanyName {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CompanyName", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[CompanyName]";
                        }
               }
            }
            
        /// <summary>Address</summary>
        public static System.String Address {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Address", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[Address]";
                        }
               }
            }
            
        /// <summary>Number</summary>
        public static System.String Number {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Number", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[Number]";
                        }
               }
            }
            
        /// <summary>State</summary>
        public static System.String State {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("State", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[State]";
                        }
               }
            }
            
        /// <summary>Country</summary>
        public static System.String Country {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Country", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[Country]";
                        }
               }
            }
            
        /// <summary>Company Administration</summary>
        public static System.String CompanyAdministration {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CompanyAdministration", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[CompanyAdministration]";
                        }
               }
            }
            
        /// <summary>Edit Company</summary>
        public static System.String EditCompany {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("EditCompany", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[EditCompany]";
                        }
               }
            }
            
        /// <summary>Couldnt update the company</summary>
        public static System.String updateCompanyMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("updateCompanyMessage", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[updateCompanyMessage]";
                        }
               }
            }
            
        /// <summary>The company was changed successfully</summary>
        public static System.String editCompanyMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("editCompanyMessage", CultureInfo.CurrentUICulture.Name,34);
                        }
                    catch (Exception)
                        {
                            return "[editCompanyMessage]";
                        }
               }
            }

        }        
}
