using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data.Core;
using Domain.Administration;
using Domain.Entities;

namespace Infrastructure.Data.Administration
{
    public partial class RepositoryMenu : Repository<Menu>, IRepositoryMenu
    {
        public List<Menu> GetParentMenuItems()
        {
            ICollection<Menu> ret = (from mi in _unitOfWork.CreateSet<Menu>()
                                     where mi.ParentMenu == null
                                     select mi).OrderBy(m => m.Orden).ToList();

            ret = RecursiveOrder(ret);

            return ret.ToList();
        }

        private ICollection<Menu> RecursiveOrder(ICollection<Menu> menues)
        {
            foreach (Menu menu in menues)
            {
                if (menu.SubMenues != null && menu.SubMenues.Count > 0)
                {
                    menu.SubMenues = RecursiveOrder(menu.SubMenues);
                }
            }
            menues = menues.OrderBy(m => m.Orden).ToList();

            return menues;
        }

        public Menu GetMenuForTitle(string controller, string action)
        {
            //Obtiene el menú que se encuentre mas por debajo en el arbol de dependencias que apunte a una acción determinada.
            Menu ret = (from mi in _unitOfWork.CreateSet<Menu>()
                        where mi.Controller == controller && mi.Action == action
                        orderby mi.SubMenues.Count()
                        select mi).FirstOrDefault();

            return ret;
        }

        public int GetMaxOrder()
        {
            return _unitOfWork.CreateSet<Menu>().Max(m => (int?)m.Orden) ?? 0;
        }

        /// <summary>
        /// Valida si el controlador al que se quiere acceder necesita autorización
        /// </summary>
        /// <param name="controller">Nombre del controlador</param>
        /// <param name="area">Nombre del area donde está el controlador</param>
        /// <returns></returns>
        public bool RequiresAuthorization(string controller, string area)
        {
            IQueryable<Menu> qMenu = _unitOfWork.CreateSet<Menu>().Where(m => m.Controller == controller);
            if (!String.IsNullOrEmpty(area))
                qMenu = qMenu.Where(m => m.Area == area);
            return false;
        }
    }
}