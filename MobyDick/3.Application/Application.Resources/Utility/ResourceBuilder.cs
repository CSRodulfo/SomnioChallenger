using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Application.MainModule.Administration;
using Application.MainModule.Administration.RolesManagement;

namespace Resources.Utility
{
    public class ResourceBuilder
    {
        /// <summary>
        /// Generates a class with properties for each resource key
        /// </summary>
        /// <param name="provider">Resource provider instance</param>
        /// <param name="namespaceName">Name of namespace containing the resource class</param>
        /// <param name="className">Name of the class</param>
        /// <param name="filePath">Where to generate the source file</param>
        /// <param name="summaryCulture">If not null, adds a &lt;summary&gt; tag to each property using the specified culture.</param>
        /// <returns>Generated class file full path</returns>
        public Boolean Create(BaseResourceProvider provider, string className = "Resources", string summaryCulture = null)
        {
            // Retrieve all resources           
            MethodInfo method = provider.GetType().GetMethod("ReadResources", BindingFlags.Instance | BindingFlags.NonPublic);

            IList<DTOResource> resources = method.Invoke(provider, null) as List<DTOResource>;

            if (resources == null || resources.Count == 0)
                throw new Exception(string.Format("No resources were found in {0}", provider.GetType().Name));

            string filePath = GetSolutionPath(Directory.GetCurrentDirectory()) + @"\1.Presentation\Presentation.Service\Presentation.Resources\";

            //Generate a different file for each menu
            foreach (DTOMenu menu in resources.Select(r => r.Menu).Distinct())
            {

                // Get a unique list of resource names (keys)
                var keys = resources
                                   .Where(r => r.Menu == null || menu == null ? r.Menu == menu : r.Menu.IDMenu == menu.IDMenu)
                                   .Select(r => r.Name).Distinct();

                string namespaceName;
                if (menu != null)
                {
                    namespaceName = string.Format("MB{0}.{1}", menu.Area, menu.Controller);
                }
                else
                    namespaceName = "Default";

                #region Templates
                const string header =
    @"using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace {0} {{
        public class {1} {{
            private static IResourceProvider resourceProvider = new {2}();

    {3}
        }}        
}}"; // {0}: namespace {1}:class name   {2}:provider class name   {3}: body  

                const string property =
    @"
        {1}
        public static {2} {0} {{
               get {{
                    try {{
                        return ({2}) resourceProvider.GetResource(""{0}"", CultureInfo.CurrentUICulture.Name,{3});
                        }}
                    catch (Exception)
                        {{
                            return ""[{0}]"";
                        }}
               }}
            }}"; // {0}: key
                #endregion


                // store keys in a string builder
                var sbKeys = new StringBuilder();

                foreach (string key in keys)
                {
                    var resource = resources.Where(r => (summaryCulture == null ? true : r.Culture.ToLowerInvariant() == summaryCulture.ToLowerInvariant()) && r.Name == key).FirstOrDefault();
                    if (resource == null)
                    {
                        throw new Exception(string.Format("Could not find resource {0}", key));
                    }

                    sbKeys.Append(new String(' ', 12)); // indentation
                    if (menu != null)
                        sbKeys.AppendFormat(property, key,
                        summaryCulture == null ? string.Empty : string.Format("/// <summary>{0}</summary>", resource.Value),
                        typeof(string), menu.IDMenu);
                    else
                        sbKeys.AppendFormat(property, key,
                        summaryCulture == null ? string.Empty : string.Format("/// <summary>{0}</summary>", resource.Value),
                        typeof(string), 0);

                    sbKeys.AppendLine();
                }

                //If there's no menu, generate it in account
                string fullpath;
                if (menu != null)
                    if (menu.Area == null)
                        fullpath = Path.Combine(Path.GetDirectoryName(filePath), "Areas", menu.Controller);
                    else
                        fullpath = Path.Combine(Path.GetDirectoryName(filePath), "Areas", menu.Area, menu.Controller);
                else
                    fullpath = Path.Combine(Path.GetDirectoryName(filePath), "Areas", "Default");

                if (!Directory.Exists(fullpath))
                    Directory.CreateDirectory(fullpath);

                //If File exists, it's on SC, so it's readonly
                if (File.Exists(Path.Combine(fullpath, "Resources.cs")))
                {
                    File.SetAttributes(Path.Combine(fullpath, "Resources.cs"), FileAttributes.Normal);
                }

                try
                {
                    // write to file
                    using (var writer = File.CreateText(Path.Combine(fullpath, "Resources.cs")))
                    {
                        // write header along with keys
                        if (menu != null)
                            writer.WriteLine(header, namespaceName, className, provider.GetType().Name, sbKeys.ToString());
                        else
                            writer.WriteLine(header, namespaceName, className, provider.GetType().Name, sbKeys.ToString());

                        writer.Flush();
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the parent solution directory
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        private string GetSolutionPath(String Path)
        {
            String[] ChildDirectories = Directory.GetDirectories(Path);

            for (int i = 0; i < ChildDirectories.Count(); i++)
            {
                if (ChildDirectories[i].Contains("1.Presentation"))
                    return Path;
            }

            return GetSolutionPath(Directory.GetParent(Path).FullName);
        }
    }
}