using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace MBAdministration.Menues {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Menu Administration</summary>
        public static System.String MenuAdministration {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuAdministration", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[MenuAdministration]";
                        }
               }
            }
            
        /// <summary>Description</summary>
        public static System.String Description {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Description", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[Description]";
                        }
               }
            }
            
        /// <summary>Assigned Roles</summary>
        public static System.String AssignedRoles {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("AssignedRoles", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[AssignedRoles]";
                        }
               }
            }
            
        /// <summary>Do you wish to delete the selected items?</summary>
        public static System.String DeleteMenu {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("DeleteMenu", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[DeleteMenu]";
                        }
               }
            }
            
        /// <summary>The changes will be lost.</summary>
        public static System.String LeaveMenu {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("LeaveMenu", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[LeaveMenu]";
                        }
               }
            }
            
        /// <summary>First you must select a menu entry.</summary>
        public static System.String SelectMenu {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("SelectMenu", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[SelectMenu]";
                        }
               }
            }
            
        /// <summary>Add menu</summary>
        public static System.String AddMenu {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("AddMenu", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[AddMenu]";
                        }
               }
            }
            
        /// <summary>Edit menu</summary>
        public static System.String EditMenu {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("EditMenu", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[EditMenu]";
                        }
               }
            }
            
        /// <summary>Name</summary>
        public static System.String MenuName {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuName", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[MenuName]";
                        }
               }
            }
            
        /// <summary>Parent Menu</summary>
        public static System.String MenuParentName {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuParentName", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[MenuParentName]";
                        }
               }
            }
            
        /// <summary>Description</summary>
        public static System.String MenuDescription {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuDescription", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[MenuDescription]";
                        }
               }
            }
            
        /// <summary>Area</summary>
        public static System.String MenuArea {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuArea", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[MenuArea]";
                        }
               }
            }
            
        /// <summary>Controller</summary>
        public static System.String MenuController {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuController", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[MenuController]";
                        }
               }
            }
            
        /// <summary>Action</summary>
        public static System.String MenuAction {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("MenuAction", CultureInfo.CurrentUICulture.Name,23);
                        }
                    catch (Exception)
                        {
                            return "[MenuAction]";
                        }
               }
            }

        }        
}
