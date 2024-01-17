using System.Collections.Specialized;
using System.Configuration;
using System.Web.Security;
using Application.MainModule.Administration.Authentication;
using Presentation.MVC.Common;
using WebMatrix.WebData;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Presentation.MVC.App_Start.SimpleMembershipMvc3), "Start")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Presentation.MVC.App_Start.SimpleMembershipMvc3), "Initialize")]

namespace Presentation.MVC.App_Start
{
    public static class SimpleMembershipMvc3
    {
        public static readonly string EnableSimpleMembershipKey = "enableSimpleMembership";

        public static bool SimpleMembershipEnabled
        {
            get { return IsSimpleMembershipEnabled(); }
        }

        public static void Initialize()
        {
            ISecurityMembership webSecurityService = ManagerService.GetService<ISecurityMembership>("MVC");
          //  webSecurityService.InitializeDatabaseConnection("ConnStringForWebSecurity", "Users", "UserId", "UserName", autoCreateTables: false);
        }

        public static void Start()
        {
            if (SimpleMembershipEnabled)
            {
                MembershipProvider provider = Membership.Providers["AspNetSqlMembershipProvider"];
                if (provider != null)
                {
                    MembershipProvider currentDefault = provider;
                    SimpleMembershipProvider provider2 = CreateDefaultSimpleMembershipProvider("AspNetSqlMembershipProvider", currentDefault);
                    Membership.Providers.Remove("AspNetSqlMembershipProvider");
                    Membership.Providers.Add(provider2);
                }
                Roles.Enabled = true;
                RoleProvider provider3 = Roles.Providers["AspNetSqlRoleProvider"];
                if (provider3 != null)
                {
                    RoleProvider provider6 = provider3;
                    SimpleRoleProvider provider4 = CreateDefaultSimpleRoleProvider("AspNetSqlRoleProvider", provider6);
                    Roles.Providers.Remove("AspNetSqlRoleProvider");
                    Roles.Providers.Add(provider4);
                }
            }
        }

        #region : Private Methods :

        private static bool IsSimpleMembershipEnabled()
        {
            bool flag;
            string str = ConfigurationManager.AppSettings[EnableSimpleMembershipKey];
            if (!string.IsNullOrEmpty(str) && bool.TryParse(str, out flag))
            {
                return flag;
            }
            return true;
        }

        private static SimpleMembershipProvider CreateDefaultSimpleMembershipProvider(string name, MembershipProvider currentDefault)
        {
            MembershipProvider previousProvider = currentDefault;
            SimpleMembershipProvider provider = new SimpleMembershipProvider(previousProvider);
            NameValueCollection config = new NameValueCollection();
            provider.Initialize(name, config);
            return provider;
        }

        private static SimpleRoleProvider CreateDefaultSimpleRoleProvider(string name, RoleProvider currentDefault)
        {
            RoleProvider previousProvider = currentDefault;
            SimpleRoleProvider provider = new SimpleRoleProvider(previousProvider);
            NameValueCollection config = new NameValueCollection();
            provider.Initialize(name, config);
            return provider;
        }

        #endregion

    }
}
