using Application.MainModule.Administration.Culture.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Presentation.MVC.Common.Extensions;
using Presentation.Resources;

namespace Presentation.MVC.Models
{
    public class Users
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [MobyDickRequired]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [MobyDickRequired]
        [DataType(DataType.Password)]
        [MobyDickDisplayName("OldPassword", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string OldPassword { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(100, 6)]
        [DataType(DataType.Password)]
        [MobyDickDisplayName("NewPassword", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [MobyDickDisplayName("ConfirmPassword", ResourceType = typeof(MBAdministration.Users.Resources))]
        [MobyDickCompare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }

    public class LocalCultureModel
    {
        public int UserId { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("Language", ResourceType = typeof(MBAdministration.Users.Resources))]
        public int IdCulture { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("Language", ResourceType = typeof(MBAdministration.Users.Resources))]
        public List<DTOCulture> Cultures { get; set; }
    }

    public class LoginModel
    {
        [MobyDickRequired]
        [Display(Name = "Nombre de usuario:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña válida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña:")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("UserName", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string UserName { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(128, 6)]
        [DataType(DataType.Password)]
        [MobyDickDisplayName("Password", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [MobyDickStringLength(128, 6)]
        [MobyDickDisplayName("Password", ResourceType = typeof(MBAdministration.Users.Resources))]
        [MobyDickCompare("Password")]
        public string ConfirmPassword { get; set; }

        [MobyDickStringLength(50)]
        [MobyDickDisplayName("FirstName", ResourceType = typeof(MBAdministration.Users.Resources))]
        [MobyDickRequired]
        public string Nombre { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("LastName", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string Apellido { get; set; }

        [MobyDickRequired]
        [MobyDickEmailAddress]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("Email", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string Email { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("Language", ResourceType = typeof(MBAdministration.Users.Resources))]
        public int IdCulture { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("Language", ResourceType = typeof(MBAdministration.Users.Resources))]
        public List<System.Web.Mvc.SelectListItem> Cultures { get; set; }
    }

    public class EditModel
    {
        public int UserId { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("UserName", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string UserName { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("FirstName", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string FirstName { get; set; }

        [MobyDickRequired]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("LastName", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string LastName { get; set; }

        [MobyDickRequired]
        [MobyDickEmailAddress]
        [MobyDickStringLength(50)]
        [MobyDickDisplayName("Email", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string Email { get; set; }

        [MobyDickDisplayName("Language", ResourceType = typeof(MBAdministration.Users.Resources))]
        public int IdCulture { get; set; }

        [MobyDickRequired]
        [MobyDickDisplayName("Language", ResourceType = typeof(MBAdministration.Users.Resources))]
        public List<DTOCulture> Cultures { get; set; }

        //public DTOFile File { get; set; }

        public int FileId { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    public class ForgotPasswordModel
    {
        [MobyDickRequired]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [MobyDickRequired]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email address")]
        public string Email { get; set; }
    }

    public class PasswordResetModel
    {
        [MobyDickRequired]
        [Display(Name = "Reset Token")]
        public string ResetToken { get; set; }

        [MobyDickRequired]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordModel
    {
        [MobyDickRequired]
        [Display(Name = "Reset Token")]
        public string ResetToken { get; set; }

        [MobyDickRequired]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "OldPasswrod")]
        [Compare("OldPassword", ErrorMessage = "VER")]
        public string OldPassword { get; set; }
    }

    public class UsersList
    {
        [MobyDickDisplayName("UserName", ResourceType = typeof(MBAdministration.Users.Resources))]
        public string UserName { get; set; }
    }


}
