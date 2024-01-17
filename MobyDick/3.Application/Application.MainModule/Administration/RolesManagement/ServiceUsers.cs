using Application.MainModule.Administration.Culture.DTO;
using Application.MainModule.Administration.Culture;
using Application.MainModule.Administration.FileManagement.DTO;
using Application.MainModule.Administration.FileManagement.DTOAdapters;
using Application.MainModule.Administration.RolesManagement.DTO;
using Application.MainModule.Administration.RolesManagement.DTOAdapters;
using Application.MainModule.Services;
using Domain.Administration;
using Domain.Entities;
using Domain.Resources.Libraries.PagedData;
using Infrastructure.Cross.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repository;

namespace Application.MainModule.Administration.RolesManagement
{
    public class ServiceUsers : IServiceUsers
    {
        private readonly IRepositoryRoles _repositoryRoles;
        private readonly IRepositoryUsers _repositoryUsers;
        private readonly IRepositoryMembership _repositoryMembership;
        private readonly IRepositoryFile _repositoryFile;
        private readonly IRepositoryCulture _repositoryCulture;

        public ServiceUsers(IRepositoryRoles rRoles, IRepositoryUsers rUsers, IRepositoryMembership rMembership, IRepositoryFile rFile, IRepositoryCulture rCulture)
        {
            _repositoryRoles = rRoles;
            _repositoryUsers = rUsers;
            _repositoryMembership = rMembership;
            _repositoryFile = rFile;
            _repositoryCulture = rCulture;
        }


        public PagedDataResult<DTOUser> GetUsers(PagedDataParameters pagedParameters, string userNameFilter)
        {
            PagedDataResult<Users> pagedData = _repositoryUsers.GetUsersByPage(pagedParameters, userNameFilter);

            return new PagedDataResult<DTOUser>(AdapterUser.ToDTOs(pagedData.Results), pagedData.TotalCount);
        }

        private void insert(DTOUser user)
        {
            Users _user = AdapterUser.ToEntity(user);
            _repositoryUsers.Insert(_user);
        }

        public void Edit(DTOUser user)
        {
            Update(user);
            Save();
        }

        private void Update(DTOUser user) {
            Users _user = AdapterUser.ToEntity(user);
            _repositoryUsers.Update(_user);
        }

        public void Delete(int id)
        {
            Users user = _repositoryUsers.GetByID(id);

            if (user.Roles.Count > 0)
            {
                throw new Exception("No se puede eliminar el usuario ya que tiene elementos asociados. Quite los roles asignados y vuelva a intentarlo");
            }

            if (user.deleted == false)
            {
                user.deleted = true;
            }

            _repositoryUsers.Update(user);

           // _repositoryUsers.Delete(id);
            Save();
        }

        public void UpdatePhoto(string userName, DTOFile file)
        {
            Users user = _repositoryUsers.GetUserByUserName(userName);
            
            if (user != null)
            {
               int userId = user.UserId;
               user.File = AdapterFile.ToEntity(file);
               _repositoryUsers.Update(user);
               _repositoryUsers.UnitOfWork.SaveChanges();
            }

        }

        public void UpdateUserCulture(int UserId, int CultureId)
        {
            Users user = _repositoryUsers.GetByID(UserId);
            if (user != null)
            {
                user.IdCulture = CultureId;
                _repositoryUsers.Update(user);
                _repositoryUsers.UnitOfWork.SaveChanges();
            }
        }

        public void UpdatePasswordMobile(string userName, string passwordMobile)
        {
            Users user = _repositoryUsers.GetUserByUserName(userName);

            if (user != null)
            {
                int userId = user.UserId;

                Membership membership = _repositoryMembership.GetMembershipUserById(userId);

                membership.PasswordMobile = CryptographyHelper.GetMD5(passwordMobile);
                _repositoryMembership.Update(membership);
                _repositoryMembership.UnitOfWork.SaveChanges();

            }

        }

         public void DeleteMembership(int id)
        {
            _repositoryMembership.Delete(id);

            Save();
        }
        public List<DTORoleForUsers> GetAllDTORoleForUsers()
        {
            return AdapterRoleForUsers.ToDTOsRoleForUsers(_repositoryRoles.GetAll());
        }

        public DTOUserForRoles GetDTOUserForRolesById(int id)
        {
            return AdapterUserForRoles.ToDTOUserForRoles(_repositoryUsers.GetByID(id));
        }

        public void SaveUserWithRoles(int UserId, List<int> RoleIds)
        {
            Users user = _repositoryUsers.GetByID(UserId);

            //ROLES QUE SE DEBEN ELIMINAR
            List<Roles> RolesInUserToDelete = user.Roles.Where(ru => !RoleIds.Contains(ru.RoleId)).Select(ru => ru).ToList();

            RolesInUserToDelete.ForEach(r => user.Roles.Remove(r));

            //ROLES QUE SE DEBEN AGREGAR
            var idsToAdd = RoleIds.Where(r => !user.Roles.Any(ur => ur.RoleId == r)).ToList();

            foreach (int id in idsToAdd)
            { 
                Roles roleToAdd = _repositoryRoles.GetByID(id);
                user.Roles.Add(roleToAdd);
            }
            _repositoryUsers.Update(user);

            Save();
        }

        public bool UserExists(string userName)
        {
            Users user = _repositoryUsers.GetUserByUserName(userName);

            if (user != null && user.deleted == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<DTOCulture> GetDTOCulture() 
        {
            return AdapterCulture.ToDTOs(_repositoryCulture.GetAll());
        }
         
        public DTOUserForEdit GetDTOUserForEditById(int id)
        {
            return AdapterUserForEdit.ToDTOUserForEdit(_repositoryUsers.GetByID(id));
        }

        public int GetUserIdByUserName(string name)
        {
            return _repositoryUsers.GetUserByUserName(name).UserId;
        }

        public DTOFile GetUserFileByUserName(string name)
        {
            return AdapterFile.ToDTO(_repositoryUsers.GetUserByUserName(name).File);
        }

        public int GetCultureIdByUserId(int id)
        {
            return _repositoryUsers.GetByID(id).IdCulture;
        }

        public DTOUserForSelect GetDTOUserForSelectById(int id)
        {
            return AdapterUserForSelect.ToDTOUserForSelect(_repositoryUsers.GetByID(id));
        }

        public void UpdateUserProfile(DTOUserForEdit dto)
        {
            Users user = AdapterUserForEdit.ToEntityUserForEdit(dto);

            //Actualizo el archivo antes xq sino lo toma como nulo
            if (dto.File != null)
            {
                if (dto.File.IdFile == 0 && string.IsNullOrEmpty(dto.File.FileName) == false)
                {
                    _repositoryFile.Insert(user.File);
                }
            }
            else if (dto.FileId > 0)
            {
                var file = _repositoryFile.GetFileById(dto.FileId);
                user.File = new File();
                user.File.FileName = file.FileName;
                user.File.FileData = file.FileData;
                user.File.MimeType = file.MimeType;
                user.File.Date = file.Date;
                _repositoryFile.Insert(user.File);
            }

            _repositoryUsers.Update(user);

            Save();
        }

        public PagedDataResultExport ExportUsersList(PagedDataParametersExcel pagedParams, string NameFilter)
        {
            PagedDataResult<Domain.Entities.Users> pagedData = _repositoryUsers.GetPagedForReport(pagedParams, NameFilter);

            return new PagedDataResultExport(AdapterUserForExportList.ToDTOsForExportList(pagedData.Results).ToList());
        }

        public bool IsDeveloper(string userName)
        {
            return _repositoryUsers.IsDeveloper(userName);
        }

        private void Save()
        {
            _repositoryUsers.UnitOfWork.SaveChanges();
        }

        public List<DTOUserForSelectListItem> GetAllForSelectList()
        {
            return AdapterUserForSelectList.ToDTOsUserForSelectList(_repositoryUsers.GetAll());
        }
    }
}
