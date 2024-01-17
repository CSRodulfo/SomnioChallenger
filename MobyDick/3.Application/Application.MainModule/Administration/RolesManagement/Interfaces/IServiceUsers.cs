using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Application.MainModule.Services;
using Domain.Resources.Libraries.PagedData;
using Application.MainModule.Administration.RolesManagement.DTO;
using Application.MainModule.Administration.FileManagement.DTO;
using Application.MainModule.Administration.Culture.DTO;

namespace Application.MainModule.Administration.RolesManagement
{
    public interface IServiceUsers
    {
        PagedDataResult<DTOUser> GetUsers(PagedDataParameters pagedParameters, string userNameFilter);

        void Edit(DTOUser user);

        void Delete(int id);

        void DeleteMembership(int id);

        List<DTORoleForUsers> GetAllDTORoleForUsers();

        DTOUserForRoles GetDTOUserForRolesById(int id);

        void SaveUserWithRoles(int UserId, List<int> SelectedKeys);

        void UpdateUserProfile(DTOUserForEdit dto);
        void UpdateUserCulture(int UserId, int CultureId);

        DTOUserForEdit GetDTOUserForEditById(int id);
        int GetCultureIdByUserId(int id);
        int GetUserIdByUserName(string userName);
        DTOFile GetUserFileByUserName(string name);
        
        bool UserExists(string userName);

        DTOUserForSelect GetDTOUserForSelectById(int id);

        bool IsDeveloper(string userName);

        List<DTOUserForSelectListItem> GetAllForSelectList();

        void UpdatePasswordMobile(string userName, string passwordMobile);

        void UpdatePhoto(string userName, DTOFile file);

        List<DTOCulture> GetDTOCulture();

        PagedDataResultExport ExportUsersList(PagedDataParametersExcel pagedParams, string NameFilter);
    }
}