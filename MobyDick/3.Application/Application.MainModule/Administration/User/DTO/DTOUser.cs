//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/09/03 - 11:58:09
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MainModule.Services
{
	public partial class DTOUser
	{
		public Int32 UserId { get; set; }

		public String UserName { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public string Email { get; set; }

        public bool hasAssignedRoles { get; set; }

		public DTOUser()
		{
		}

		public DTOUser(Int32 userId, String userName)
		{
			this.UserId = userId;
			this.UserName = userName;
		}

      
    }
}
