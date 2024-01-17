using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Presentation.MVC.Common;
using Presentation.MVC.Models;
using Application.MainModule.Administration.Authentication;
using Application.MainModule.Administration.RolesManagement;
using System.Web;
using Application.MainModule.Administration.Culture.Interfaces;
using Application.MainModule.Administration.Culture.DTO;

namespace Presentation.MVC.Controllers
{
    public class AccountController : BaseController
    {
        public ISecurityMembership MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) { MembershipService = ManagerService.GetService<ISecurityMembership>("MVC"); }

            base.Initialize(requestContext);
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IServiceUsers userService = ManagerService.GetService<IServiceUsers>();

                if (userService.UserExists(model.UserName))
                {
                    if (MembershipService.Login(model.UserName, model.Password, model.RememberMe))
                    {
                        //Le cargo la cultura al usuario
                        IServiceUsers service = ManagerService.GetService<IServiceUsers>();
                        var UserId = service.GetUserIdByUserName(model.UserName);

                        if (UserId > 0)
                        {
                            IServiceCulture serviceCulture = ManagerService.GetService<IServiceCulture>();
                            var cultureId = service.GetCultureIdByUserId(UserId);
                            if (cultureId > 0)
                            {
                                //Recargo la cultura del usuario
                                HttpCookie cookie = Request.Cookies["_culture"];
                                if (cookie != null)
                                    cookie.Value = serviceCulture.GetDTOCultureById(cultureId).Code;   // update cookie value
                                else
                                {
                                    cookie = new HttpCookie("_culture");
                                    cookie.Value = serviceCulture.GetDTOCultureById(cultureId).Code;
                                    cookie.Expires = DateTime.Now.AddYears(1);
                                }
                                Response.Cookies.Add(cookie);
                            }
                        }

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "El usuario o contraseña proporcionados son incorrectos.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El usuario o contraseña proporcionados son incorrectos.");
                }


            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            MembershipService.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                // Attempt to register the user
                var requireEmailConfirmation = false;
                var token = MembershipService.CreateUserAndAccount(model.UserName, model.Password, new { FirstName = model.Nombre, LastName = model.Apellido }, requireConfirmationToken: requireEmailConfirmation);

                if (requireEmailConfirmation)
                {
                    // Send email to user with confirmation token
                    //string hostUrl = Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
                    //string confirmationUrl = hostUrl + VirtualPathUtility.ToAbsolute("~/Account/Confirm?confirmationCode=" + HttpUtility.UrlEncode(token));

                    //var fromAddress = "Your Email Address";
                    //var toAddress = model.Email;
                    //var subject = "Thanks for registering but first you need to confirm your registration...";
                    //var body = string.Format("Your confirmation code is: {0}. Visit <a href=\"{1}\">{1}</a> to activate your account.", token, confirmationUrl);

                    //// NOTE: This is just for sample purposes
                    //// It's generally a best practice to not send emails (or do anything on that could take a long time and potentially fail)
                    //// on the same thread as the main site
                    //// You should probably hand this off to a background MessageSender service by queueing the email, etc.
                    //MessengerService.Send(fromAddress, toAddress, subject, body, true);

                    //// Thank the user for registering and let them know an email is on its way
                    //return RedirectToAction("Thanks", "Account");
                }
                else
                {
                    // Navigate back to the homepage and exit
                    MembershipService.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        public ActionResult Confirm()
        {
            string confirmationToken = Request.QueryString["confirmationCode"];
            MembershipService.Logout();

            if (!string.IsNullOrEmpty(confirmationToken))
            {
                if (MembershipService.ConfirmAccount(confirmationToken))
                {
                    ViewBag.Message = "Registration Confirmed! Click on the login link at the top right of the page to continue.";
                }
                else
                {
                    ViewBag.Message = "Could not confirm your registration info";
                }
            }

            return View();
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        /// <summary>
        /// Setea la cultura atravez de una cookie, en caso de no existir la crea, para ser
        /// utilizada por todas las peticiones
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public ActionResult SetCulture(LocalCultureModel culture)
        {
            IServiceCulture serviceCulture = ManagerService.GetService<IServiceCulture>();
            DTOCulture selectedCulture = serviceCulture.GetDTOCultureById(culture.IdCulture);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = selectedCulture.Code;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = selectedCulture.Code;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            IServiceUsers service = ManagerService.GetService<IServiceUsers>();
            service.UpdateUserCulture(culture.UserId, culture.IdCulture);

            return RedirectToAction("Manage", new { Message = ManageMessageId.ChangeCultureSuccess });
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            var isValid = false;
            var resetToken = string.Empty;

            if (ModelState.IsValid)
            {
                if (MembershipService.GetUserId(model.UserName) > -1 && MembershipService.IsConfirmed(model.UserName))
                {
                    resetToken = MembershipService.GeneratePasswordResetToken(model.UserName);
                    isValid = true;
                }

                if (isValid)
                {
                    //string hostUrl = Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
                    //string resetUrl = hostUrl + VirtualPathUtility.ToAbsolute("~/Account/PasswordReset?resetToken=" + HttpUtility.UrlEncode(resetToken));

                    //var fromAddress = "Your Email Address";
                    //var toAddress = model.Email;
                    //var subject = "Password reset request";
                    //var body = string.Format("Use this password reset token to reset your password. <br/>The token is: {0}<br/>Visit <a href='{1}'>{1}</a> to reset your password.<br/>", resetToken, resetUrl);

                    //MessengerService.Send(fromAddress, toAddress, subject, body, true);
                }
                return RedirectToAction("ForgotPasswordMessage");
            }
            return View(model);
        }

        public ActionResult ForgotPasswordMessage()
        {
            return View();
        }

        public ActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordReset(PasswordResetModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ResetPassword(model.ResetToken, model.NewPassword))
                {
                    return RedirectToAction("PasswordResetSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The password reset token is invalid.");
                }
            }

            return View(model);
        }

        public ActionResult PasswordResetSuccess()
        {
            return View();
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            if (message != null)
                TempData["TempMessage"] =
                    message == ManageMessageId.ChangePasswordSuccess ? MBAdministration.Users.Resources.ChangePasswordSuccess
                    : message == ManageMessageId.SetPasswordSuccess ? MBAdministration.Users.Resources.SetPasswordSuccess
                    : message == ManageMessageId.RemoveLoginSuccess ? MBAdministration.Users.Resources.RemoveLoginSuccess
                    : message == ManageMessageId.ChangeCultureSuccess ? MBAdministration.Users.Resources.ChangeCultureSuccess
                    : "";

            //Carga la cultura
            IServiceUsers service = ManagerService.GetService<IServiceUsers>();
            var model = new MVC.Models.LocalCultureModel();
            model.UserId = service.GetUserIdByUserName(User.Identity.Name);
            model.IdCulture = service.GetCultureIdByUserId(model.UserId);
            model.Cultures = service.GetDTOCulture();

            ViewBag.ReturnUrl = Url.Action("Manage");
            return View(model);
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    if (changePasswordSucceeded)
                    {
                        IServiceUsers userService = ManagerService.GetService<IServiceUsers>();
                        userService.UpdatePasswordMobile(User.Identity.Name, model.ConfirmPassword);
                    }
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                else
                {
                    ModelState.AddModelError("", "La contraseña actual es incorrecta o la nueva contraseña es inválida.");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }


        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            ChangeCultureSuccess,
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
