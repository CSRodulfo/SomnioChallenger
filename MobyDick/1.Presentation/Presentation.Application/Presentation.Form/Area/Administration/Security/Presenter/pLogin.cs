using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.DesktopForm.Area.Administration.Security.Interfaces;
using Presentation.DesktopForm.Area.Administration.Security.Model;
using Application.MainModule.Administration.Authentication;
using Presentation.DesktopForm.Common;

namespace Presentation.DesktopForm.Area.Administration.Security.Presenter
{
    public class pLogin
    {
        private IViewLogin _view;
        private IMembershipForm _model;

        //instaciar dentro de vista (webform)
        public pLogin(IViewLogin vista, IMembershipForm model)
        {
            _view = vista;
            _model = model;
        }

        /// <summary>
        /// Logue al usuario
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <param name="persiste"></param>
        public void Login(string Name, string Password, bool persiste = false)
        {
            try
            {
                if (_model.Login(Name, Password, persiste))
                {
                    _view.MenssageSucceful();
                }
                else
                {
                    _view.ErrorMessage();
                }
            }
            catch (Exception ex)
            {

                _view.ErrorMessageException(ex.InnerException.ToString());
            }
        }
    }
}