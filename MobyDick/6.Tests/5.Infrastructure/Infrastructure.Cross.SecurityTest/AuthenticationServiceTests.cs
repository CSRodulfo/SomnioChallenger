using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Infrastructure.Cross.Security.Roles;

namespace Infrastructure.Cross.SecurityTest
{
    [TestClass]
    public class RoleServiceTests
    {
        private Mock<IRolesService> mockRole;

        public RoleServiceTests()
        {
            mockRole = new Mock<IRolesService>();
        }

        [TestMethod]
        public void GetAllRoles_List()
        {
            // Arrange
            mockRole.Setup(r => r.GetAllRoles()).Returns(new string[]
            {
                "Administrators",
                "Managers",
                "Sales",
                "Users"
            });

            // Act
            var list = mockRole.Object.GetAllRoles();

            // Assert
            Assert.AreEqual(4, list.Length);
        }

        #region Create methods
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNewRoleThrowsExceptionWithNull_RoleName()
        {
            // Arrange
            mockRole.Setup(r => r.CreateRole(null)).Throws<ArgumentNullException>();

            // Act
            mockRole.Object.CreateRole(null);

            // Assert
            mockRole.Verify(r => r.CreateRole(null), Times.AtLeastOnce());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateNewRoleThrowsArgumentexceptionWithEmptyString_RoleName()
        {
            // Arrange
            mockRole.Setup(r => r.CreateRole("")).Throws<ArgumentException>();

            // Act
            mockRole.Object.CreateRole("");

            // Assert
            // Does not get here.
        }

        [Priority(1), TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateNewRoleThrowsArgumentexceptionWith_comma_in_rolename()
        {
            // Arrange
            mockRole.Setup(r => r.CreateRole("role1,role2")).Throws<ArgumentException>();

            // Act
            mockRole.Object.CreateRole("role1,role2");

            // Assert
            // Does not get here.
        }

        [TestMethod]
        public void CreateNewRoleSucceedsWithValid_RoleName()
        {
            // Arrange
            mockRole.Setup(r => r.CreateRole("goodRoleName")).Verifiable();

            // Act
            mockRole.Object.CreateRole("goodRoleName");

            // Assert
            mockRole.Verify();
        }
        #endregion

        //#region Delete methods

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteRoleNameThrowsExceptionWithNull_RoleName()
        {
            // Arrange
            mockRole.Setup(r => r.DeleteRole(null)).Throws<ArgumentNullException>();

            // Act
            mockRole.Object.DeleteRole(null);

            // Assert
            mockRole.Verify(r => r.DeleteRole(null), Times.AtLeastOnce());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteRoleNameThrowsExceptionWithEmptyStringSs_RoleName()
        {
            // Arrange
            mockRole.Setup(r => r.DeleteRole("")).Throws<ArgumentException>();

            // Act
            mockRole.Object.DeleteRole("");

            // Assert
            mockRole.Verify(r => r.DeleteRole(null), Times.AtLeastOnce());
        }

        [TestMethod]
        public void DeleteRoleNameSucceedsWithGood_RoleName()
        {
            // Arrange
            mockRole.Setup(r => r.DeleteRole("goodRoleName")).Returns(true);

            // Act
            bool actual = mockRole.Object.DeleteRole("goodRoleName");

            // Assert
            Assert.AreEqual(true, actual);
        }

        ////[TestMethod]
        ////public void delete_rolename_fails_when_role_has_one_or_more_members()
        ////{
        ////    // Arrange
        ////    mockRole.Setup(r => r.DeleteRole("goodRoleName", true)).Returns(false);

        ////    // Act
        ////    bool actual = mockRole.Object.DeleteRole("goodRoleName", true);

        ////    // Assert
        ////    Assert.AreEqual(false, actual);
        ////}

        ////[TestMethod]
        ////public void delete_rolename_continues_when_role_has_one_or_more_members()
        ////{
        ////    // Arrange
        ////    mockRole.Setup(r => r.DeleteRole("goodRoleName", false)).Returns(true);

        ////    // Act
        ////    bool actual = mockRole.Object.DeleteRole("goodRoleName", false);

        ////    // Assert
        ////    Assert.AreEqual(true, actual);
        ////}

        //#endregion
    }
}