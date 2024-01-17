using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.AppWPF.Area.Administration.Security.Interfaces;
using Presentation.AppWPF.Area.Administration.Security.Model;
using Application.MainModule.Administration.Authentication;
using Presentation.AppWPF.Common;

namespace Presentation.AppWPF.Area.Administration.Security.Presenter
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

        //recuperar todos los usuario....
        public void Login(string Name, string Password, bool persiste = false)
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
    }
}