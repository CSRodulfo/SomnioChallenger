using Application.MainModule.Administration.RolesManagement.DTO;
using Application.MainModule.Administration.RolesManagement.Interfaces;
using Domain.Administration;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.MainModule.Administration.RolesManagement
{
    public class ServiceMenues : IServiceMenues
    {
        private readonly IRepositoryMenu _repositoryMenu;
        private readonly IRolesValidation _rValidation;

        public ServiceMenues(IRepositoryMenu rMenues, IRolesValidation rValidation)
        {
            _rValidation = rValidation;
            _repositoryMenu = rMenues;
        }

        public void Insert(DTOMenuesForInsert dto)
        {
            Menu menu = AdapterMenuesForInsert.ToEntityMenuesForInsert(dto);

            menu.Orden = _repositoryMenu.GetMaxOrder() + 1;

            if (menu.Description == null)
                menu.Description = string.Empty;

            _repositoryMenu.Insert(menu);

            Save();
        }

        public void Edit(DTOMenuesForTreeEdit dto)
        {
            UpdateFromTree(AdapterMenuesForTreeEdit.ToEntityMenuesForTreeEdit(dto));
            Save();
        }

        private Menu UpdateFromTree(Menu entityDTO)
        {
            Menu entityDB = _repositoryMenu.GetByID(entityDTO.IDMenu);

            entityDB.SubMenues.Clear();

            foreach (Menu m in entityDTO.SubMenues)
                entityDB.SubMenues.Add(UpdateFromTree(m));

            entityDB.Name = entityDTO.Name;
            entityDB.Orden = entityDTO.Orden;
            entityDB.Roles = _rValidation.GetRolesForParentMenu(entityDB);

            _repositoryMenu.Update(entityDB);

            return entityDB;
        }

        public List<DTOMenu> GetAll()
        {
            return AdapterMenu.ToDTOs(_repositoryMenu.GetAll());
        }

        public List<DTOMenuForList> GetAllMenuDTOForList()
        {
            return AdapterMenuForList.ToDTOsMenuForList(_repositoryMenu.GetParentMenuItems());
        }

        public DTOMenuesForEdit GetDTOMenuesForEditById(int id)
        {
            return AdapterMenuesForEdit.ToDTOMenuesForEdit(_repositoryMenu.GetByID(id));
        }

        public void AdvEdit(DTOMenuesForEdit dto)
        {
            Menu entityDTO = AdapterMenuesForEdit.ToEntityMenuesForEdit(dto);

            Menu entityDB = _repositoryMenu.GetByID(dto.IDMenu);
            entityDB.Action = entityDTO.Action;
            entityDB.Area = entityDTO.Area;
            entityDB.Controller = entityDTO.Controller;
            entityDB.Description = entityDTO.Description != null ? entityDTO.Description : string.Empty;
            entityDB.Name = entityDTO.Name;
            entityDB.IDParent = entityDTO.IDParent;

            _repositoryMenu.Update(entityDB);
            Save();
        }

        public void Delete(int id)
        {
            Menu menu = _repositoryMenu.GetByID(id);
            if (menu.SubMenues.Count > 0 || menu.Roles.Count > 0)
                throw new Exception("No se puede eliminar el menú ya que contiene elementos asociados. Quite los submenús y roles asignados y vuelva a intentarlo.");

            _repositoryMenu.Delete(id);

            Save();
        }

        /// <summary>
        /// Valida si el controlador al que se quiere acceder necesita autorización
        /// </summary>
        /// <param name="controller">Nombre del controlador</param>
        /// <param name="area">Nombre del area donde está el controlador</param>
        /// <returns></returns>
        public bool RequiresAuthorization(string controller, string area)
        {
            return _repositoryMenu.RequiresAuthorization(controller, area);
        }

        private void Save()
        {
            _repositoryMenu.UnitOfWork.SaveChanges();
        }
    }
}
