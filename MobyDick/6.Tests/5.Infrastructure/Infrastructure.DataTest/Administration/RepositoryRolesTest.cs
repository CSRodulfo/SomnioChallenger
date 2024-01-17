using Infrastructure.Data.Administration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Infrastructure.Data.Core;
using Domain.Repository;
using Domain.Administration;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.DataTest
{


    /// <summary>
    ///Se trata de una clase de prueba para RepositoryRolesTest y se pretende que
    ///contenga todas las pruebas unitarias RepositoryRolesTest.
    ///</summary>
    [TestClass()]
    public class RepositoryRolesTest
    {


        private TestContext testContextInstance;
        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de GetRolByRoleName
        ///</summary>
        [TestMethod()]
        public void GetRolByRoleNameTest()
        {
            IRepositoryRoles target = ManagerService.GetService<IRepositoryRoles>();
            List<Menu> _menuItems = this.GetMenuByRoleName(new List<string>());

            string a = string.Empty;
            a = GetMenuName("Agregar Vehiculo", _menuItems);


            string roleName = string.Empty; // TODO: Inicializar en un valor adecuado
            object expected = null; // TODO: Inicializar en un valor adecuado
            object actual;
            actual = target.GetRolByRoleName(roleName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        private string GetMenuName(string value, ICollection<Menu> menuItem)
        {
            string title = string.Empty;
            foreach (Menu item in menuItem)
            {
                var a = GetTitle(value, item);

                if (a != string.Empty)
                {
                    title = item.Name;
                }
                else
                {
                    if (item.SubMenues != null)
                    {
                        var b = GetMenuName(value, item.SubMenues);
                        if (b != string.Empty)
                        {
                            title = item.Name + " => " + b;
                        }
                    }
                }
            }
            return title;
        }

        private string GetTitle(string value, Menu menuItem)
        {
            if (menuItem.Name == value)
            {
                return menuItem.Name;
            }
            return string.Empty;
        }

        /// <summary>
        ///Una prueba de Constructor RepositoryRoles
        ///</summary>
        [TestMethod()]
        public void RepositoryRolesConstructorTest()
        {
            IQueriableUnitOfWork UnitOfWork = null; // TODO: Inicializar en un valor adecuado
            RepositoryRoles target = new RepositoryRoles(UnitOfWork);
            Assert.Inconclusive("TODO: Implementar código para comprobar el destino");
        }

        public List<Menu> GetMenuByRoleName(List<string> roles)
        {
            IRepositoryMenu menuRepository = ManagerService.GetService<IRepositoryMenu>();
            List<Menu> _menuItems = menuRepository.GetParentMenuItems();
            return _menuItems;
        }
    }
}
