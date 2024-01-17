using Application.MainModule.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.Repository;
using System.Collections.Generic;
using System.Configuration;


namespace Application.MainModuleTest
{
    /*
    /// <summary>
    ///Se trata de una clase de prueba para ServiceVehicleTest y se pretende que
    ///contenga todas las pruebas unitarias ServiceVehicleTest.
    ///</summary>
    [TestClass()]
    public class ServiceVehicleTest
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
        // Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnStringForWebSecurity"].ConnectionString;

            NDbUnit.Core.INDbUnitTest mySqlDatabase = new NDbUnit.Core.SqlClient.SqlDbUnitTest(connectionString);

            mySqlDatabase.ReadXmlSchema(@"..\..\DataSets\MyDataset.xsd");
            mySqlDatabase.ReadXml(@"..\..\DataSets\MyXML.xml");

            mySqlDatabase.PerformDbOperation(NDbUnit.Core.DbOperationFlag.CleanInsertIdentity);
        }
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

        [TestMethod]
        public void TestMethod1()
        {
            IRepositoryVehicle rVehicle = ManagerService.GetService<IRepositoryVehicle>();
            var a = rVehicle.GetByDescription("Camaro");
            Assert.AreEqual("Camaro", a.Name);
        }


        /// <summary>
        ///Una prueba de Constructor ServiceVehicle
        ///</summary>
        [TestMethod()]
        public void ServiceVehicleConstructorTest()
        {

            // IServiceVehicle rVehicle = ManagerService.GetService<IServiceVehicle>() ; // TODO: Inicializar en un valor adecuado
            IRepositoryVehicle rVehicle = ManagerService.GetService<IRepositoryVehicle>();

            var a = rVehicle.GetByDescription("Camaro");
            Assert.AreNotEqual(null, a);
        }

        /// <summary>
        ///Una prueba de Add
        ///</summary>
        //[TestMethod()]
        //public void AddTest()
        //{
        //    //IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    //IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    //IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    //ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    //DTOVehicleForInsert vehic = null; // TODO: Inicializar en un valor adecuado
        //    //target.Add(vehic);
        //    //Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        //}

        ///// <summary>
        /////Una prueba de AddSafety
        /////</summary>
        //[TestMethod()]
        //public void AddSafetyTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    DTOSafety safety = null; // TODO: Inicializar en un valor adecuado
        //    target.AddSafety(safety);
        //    Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        //}

        ///// <summary>
        /////Una prueba de Edit
        /////</summary>
        //[TestMethod()]
        //public void EditTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    DTOVehicleForUpdate vehic = null; // TODO: Inicializar en un valor adecuado
        //    target.Edit(vehic);
        //    Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        //}

        ///// <summary>
        /////Una prueba de GetAllMakesDTO
        /////</summary>
        //[TestMethod()]
        //public void GetAllMakesDTOTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    List<DTOMake> expected = null; // TODO: Inicializar en un valor adecuado
        //    List<DTOMake> actual;
        //    actual = target.GetAllMakesDTO();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        //}

        ///// <summary>
        /////Una prueba de GetAllVehiclesForList
        /////</summary>
        //[TestMethod()]
        //public void GetAllVehiclesForListTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    List<DTOVehicleForList> expected = null; // TODO: Inicializar en un valor adecuado
        //    List<DTOVehicleForList> actual;
        //    actual = target.GetAllVehiclesForList();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        //}

        ///// <summary>
        /////Una prueba de GetAllSafeties
        /////</summary>
        //[TestMethod()]
        //public void GetAllSafetiesTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    List<DTOSafety> expected = null; // TODO: Inicializar en un valor adecuado
        //    List<DTOSafety> actual;
        //    actual = target.GetAllSafeties();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        //}

        ///// <summary>
        /////Una prueba de GetVehicleByDescription
        /////</summary>
        //[TestMethod()]
        //public void GetVehicleByDescriptionTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    string description = string.Empty; // TODO: Inicializar en un valor adecuado
        //    DTOVehicle expected = null; // TODO: Inicializar en un valor adecuado
        //    DTOVehicle actual;
        //    actual = target.GetVehicleByDescription(description);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        //}

        ///// <summary>
        /////Una prueba de GetVehicleByID
        /////</summary>
        //[TestMethod()]
        //public void GetVehicleByIDTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    int id = 0; // TODO: Inicializar en un valor adecuado
        //    DTOVehicleForUpdate expected = null; // TODO: Inicializar en un valor adecuado
        //    DTOVehicleForUpdate actual;
        //    actual = target.GetVehicleByID(id);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        //}

        ///// <summary>
        /////Una prueba de Remove
        /////</summary>
        //[TestMethod()]
        //public void RemoveTest()
        //{
        //    IRepositoryVehicle rVehicle = null; // TODO: Inicializar en un valor adecuado
        //    IRepositoryMake rMake = null; // TODO: Inicializar en un valor adecuado
        //    IRepositorySafety rSafety = null; // TODO: Inicializar en un valor adecuado
        //    ServiceVehicle target = new ServiceVehicle(rVehicle, rMake, rSafety); // TODO: Inicializar en un valor adecuado
        //    int id = 0; // TODO: Inicializar en un valor adecuado
        //    target.Remove(id);
        //    Assert.Inconclusive("Un método que no devuelve ningún valor no se puede comprobar.");
        //}
    }*/
}
