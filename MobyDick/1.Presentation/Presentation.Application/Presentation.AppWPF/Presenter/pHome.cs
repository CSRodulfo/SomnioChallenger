using Presentation.AppWPF.Interface;

namespace Presentation.AppWPF.Presenter
{
    public class pHome
    {
        private IViewHome _view;

        public pHome(IViewHome view)
        {           
            _view = view;
        }       
    }
}
