using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace Default {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Choose your language</summary>
        public static System.String ChooseYourLanguage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ChooseYourLanguage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[ChooseYourLanguage]";
                        }
               }
            }
            
        /// <summary>Must be less than 50 characters</summary>
        public static System.String FirstNameLong {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("FirstNameLong", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[FirstNameLong]";
                        }
               }
            }
            
        /// <summary>First name is required</summary>
        public static System.String FirstNameRequired {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("FirstNameRequired", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[FirstNameRequired]";
                        }
               }
            }
            
        /// <summary>The {0} field is required.</summary>
        public static System.String Required {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Required", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[Required]";
                        }
               }
            }
            
        /// <summary>The field {0} must have a maximum length of {1}</summary>
        public static System.String StringLengthErrorMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("StringLengthErrorMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[StringLengthErrorMessage]";
                        }
               }
            }
            
        /// <summary>The field {0} must have a minimum length of {2} and a maximum length of {1}</summary>
        public static System.String StringLengthMinimumErrorMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("StringLengthMinimumErrorMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[StringLengthMinimumErrorMessage]";
                        }
               }
            }
            
        /// <summary>The e-mail address is not valid.</summary>
        public static System.String EmailAddressErrorMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("EmailAddressErrorMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[EmailAddressErrorMessage]";
                        }
               }
            }
            
        /// <summary>The values do not match.</summary>
        public static System.String CompareErrorMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("CompareErrorMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[CompareErrorMessage]";
                        }
               }
            }
            
        /// <summary>Save</summary>
        public static System.String BtnSave {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnSave", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[BtnSave]";
                        }
               }
            }
            
        /// <summary>Return</summary>
        public static System.String BtnBack {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnBack", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[BtnBack]";
                        }
               }
            }
            
        /// <summary>Picture</summary>
        public static System.String Picture {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Picture", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[Picture]";
                        }
               }
            }
            
        /// <summary>Select Image</summary>
        public static System.String SelectImage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("SelectImage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[SelectImage]";
                        }
               }
            }
            
        /// <summary>New</summary>
        public static System.String BtnNew {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnNew", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[BtnNew]";
                        }
               }
            }
            
        /// <summary>Edit</summary>
        public static System.String BtnEdit {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnEdit", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[BtnEdit]";
                        }
               }
            }
            
        /// <summary>Export</summary>
        public static System.String BtnExport {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnExport", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[BtnExport]";
                        }
               }
            }
            
        /// <summary>Change Password</summary>
        public static System.String ChangePassword {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ChangePassword", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[ChangePassword]";
                        }
               }
            }
            
        /// <summary>Search</summary>
        public static System.String BtnSearch {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnSearch", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[BtnSearch]";
                        }
               }
            }
            
        /// <summary>Results</summary>
        public static System.String Results {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Results", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[Results]";
                        }
               }
            }
            
        /// <summary>There is not selected item</summary>
        public static System.String selectFieldMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("selectFieldMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[selectFieldMessage]";
                        }
               }
            }
            
        /// <summary>The search does not find any items</summary>
        public static System.String searchMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("searchMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[searchMessage]";
                        }
               }
            }
            
        /// <summary>User generated successfully</summary>
        public static System.String insertUserMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("insertUserMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[insertUserMessage]";
                        }
               }
            }
            
        /// <summary>No export results for selected filters</summary>
        public static System.String NonFilterMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("NonFilterMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[NonFilterMessage]";
                        }
               }
            }
            
        /// <summary>An error occurred in the export</summary>
        public static System.String ErrorFilterMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("ErrorFilterMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[ErrorFilterMessage]";
                        }
               }
            }
            
        /// <summary>Unexpected behavior has occurred.</summary>
        public static System.String errorMessage {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("errorMessage", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[errorMessage]";
                        }
               }
            }
            
        /// <summary>MobyDick</summary>
        public static System.String Home {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("Home", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[Home]";
                        }
               }
            }
            
        /// <summary>Select...</summary>
        public static System.String SelectItem {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("SelectItem", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[SelectItem]";
                        }
               }
            }
            
        /// <summary>Unassigned</summary>
        public static System.String SelectAssignItem {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("SelectAssignItem", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[SelectAssignItem]";
                        }
               }
            }
            
        /// <summary>Delete</summary>
        public static System.String BtnDel {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("BtnDel", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[BtnDel]";
                        }
               }
            }
            
        /// <summary>Visualize deleted items</summary>
        public static System.String VisualizeDeletedItems {
               get {
                    try {
                        return (System.String) resourceProvider.GetResource("VisualizeDeletedItems", CultureInfo.CurrentUICulture.Name,0);
                        }
                    catch (Exception)
                        {
                            return "[VisualizeDeletedItems]";
                        }
               }
            }

        }        
}
