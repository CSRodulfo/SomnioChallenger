//using Infrastructure.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Infrastructure.Data.Core;
using Domain.Entities;
using System.Collections.Generic;
using Domain.Repository;

namespace Infrastructure.DataTest
{
    
    /*
    /// <summary>
    ///Se trata de una clase de prueba para RepositoryVehicleTest y se pretende que
    ///contenga todas las pruebas unitarias RepositoryVehicleTest.
    ///</summary>
    [TestClass()]
    public class RepositoryVehicleTest
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
        ///Una prueba de GetByPrice
        ///</summary>
        [TestMethod()]
        public void GetByPriceTest()
        {
            IRepositoryVehicle target = ManagerService.GetService<IRepositoryVehicle>();

            string desc = "59"; // TODO: Inicializar en un valor adecuado
           // IEnumerable<Vehicle> expected = null; // TODO: Inicializar en un valor adecuado
            IEnumerable<Vehicle> actual;
            actual = target.GetByPrice(desc);
            //Assert.AreEqual(expected., actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetByName
        ///</summary>
        [TestMethod()]
        public void GetByNameTest()
        {
            IQueriableUnitOfWork UnitOfWork = null; // TODO: Inicializar en un valor adecuado
            RepositoryVehicle target = new RepositoryVehicle(UnitOfWork); // TODO: Inicializar en un valor adecuado
            string desc = string.Empty; // TODO: Inicializar en un valor adecuado
            IEnumerable<Vehicle> expected = null; // TODO: Inicializar en un valor adecuado
            IEnumerable<Vehicle> actual;
            actual = target.GetByName(desc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetByModel
        ///</summary>
        [TestMethod()]
        public void GetByModelTest()
        {
            IQueriableUnitOfWork UnitOfWork = null; // TODO: Inicializar en un valor adecuado
            RepositoryVehicle target = new RepositoryVehicle(UnitOfWork); // TODO: Inicializar en un valor adecuado
            string desc = string.Empty; // TODO: Inicializar en un valor adecuado
            IEnumerable<Vehicle> expected = null; // TODO: Inicializar en un valor adecuado
            IEnumerable<Vehicle> actual;
            actual = target.GetByModel(desc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetByMake
        ///</summary>
        [TestMethod()]
        public void GetByMakeTest()
        {
            IQueriableUnitOfWork UnitOfWork = null; // TODO: Inicializar en un valor adecuado
            RepositoryVehicle target = new RepositoryVehicle(UnitOfWork); // TODO: Inicializar en un valor adecuado
            List<int> desc = null; // TODO: Inicializar en un valor adecuado
            IEnumerable<Vehicle> expected = null; // TODO: Inicializar en un valor adecuado
            IEnumerable<Vehicle> actual;
            actual = target.GetByMake(desc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetByDescription
        ///</summary>
        [TestMethod()]
        public void GetByDescriptionTest()
        {
            IQueriableUnitOfWork UnitOfWork = null; // TODO: Inicializar en un valor adecuado
            RepositoryVehicle target = new RepositoryVehicle(UnitOfWork); // TODO: Inicializar en un valor adecuado
            string description = string.Empty; // TODO: Inicializar en un valor adecuado
            Vehicle expected = null; // TODO: Inicializar en un valor adecuado
            Vehicle actual;
            actual = target.GetByDescription(description);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            IQueriableUnitOfWork UnitOfWork = null; // TODO: Inicializar en un valor adecuado
            RepositoryVehicle target = new RepositoryVehicle(UnitOfWork); // TODO: Inicializar en un valor adecuado
            List<Vehicle> expected = null; // TODO: Inicializar en un valor adecuado
            List<Vehicle> actual;
            actual = target.GetAll();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de Constructor RepositoryVehicle
        ///</summary>
        [TestMethod()]
        public void RepositoryVehicleConstructorTest()
        {
            IQueriableUnitOfWork UnitOfWork = null; // TODO: Inicializar en un valor adecuado
            RepositoryVehicle target = new RepositoryVehicle(UnitOfWork);
            Assert.Inconclusive("TODO: Implementar código para comprobar el destino");
        }
    }*/
}
