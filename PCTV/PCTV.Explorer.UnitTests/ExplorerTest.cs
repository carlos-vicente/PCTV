using PCTV.Explorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PCTV.Explorer.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for ExplorerTest and is intended
    ///to contain all ExplorerTest Unit Tests
    ///</summary>
    [TestClass]
    public class ExplorerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod]
        public void ConstructorTest()
        {
            //Arrange
            String[] expected = GetValidDrives();

            //Act
            Explorer target = new Explorer();

            //Assert
            IEnumerable<FileSystemInfo> actual = target.GetCurrentContents();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Length, actual.Count());
            for (int i = 0; i < expected.Length; ++i)
            {
                Assert.AreEqual(String.Format("{0}:\\", expected[i]), actual.Take(i+1).Last().FullName);
            }
        }

        /// <summary>
        ///A test for Up
        ///</summary>
        [TestMethod()]
        public void UpTest()
        {
            //Arrange
            Explorer target = new Explorer();
            String[] drivers = GetValidDrives();
            target.Open(String.Format("{0}:\\", drivers[0]));

            //Act
            target.Up();

            //Assert
            Assert.AreEqual(String.Empty, target.CurrentPath);
        }

        /// <summary>
        ///A test for Open
        ///</summary>
        [TestMethod()]
        public void OpenTest()
        {
            //Arrange
            Explorer target = new Explorer();
            String[] drivers = GetValidDrives();

            //Act
            target.Open(String.Format("{0}:\\", drivers[0]));

            //Assert
            Assert.IsTrue(target.CurrentPath.StartsWith(drivers[0]));
        }

        #region Aux
        private static string[] GetValidDrives()
        {
            string config = ConfigurationManager.AppSettings["Drives"];
            return config.Split(',');
        }
        #endregion
    }
}
