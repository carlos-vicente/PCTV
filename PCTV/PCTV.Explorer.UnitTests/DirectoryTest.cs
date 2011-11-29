using PCTV.Explorer.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Directory = PCTV.Explorer.IO.Directory;
using System.Configuration;

namespace PCTV.Explorer.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for DirectoryTest and is intended
    ///to contain all DirectoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DirectoryTest
    {
        private readonly static String ValidFolderKey = "ValidFolder";
        private readonly static String InvalidFolderKey = "InvalidFolder";

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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            testContext.Properties[ValidFolderKey] = ConfigurationManager.AppSettings[ValidFolderKey];
            testContext.Properties[InvalidFolderKey] = ConfigurationManager.AppSettings[InvalidFolderKey];
        }
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


        /// <summary>
        ///A test for Directory Constructor
        ///</summary>
        [TestMethod()]
        public void DirectoryConstructorTest()
        {
            //Arrange
            DirectoryInfo info = new DirectoryInfo((string)(TestContext.Properties[ValidFolderKey]));
            //Act
            //Assert
            Directory target = new Directory(info);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Directory Constructor
        ///</summary>
        [TestMethod()]
        public void DirectoryConstructorTest1()
        {
            Directory target = new Directory();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ToDirectoryInfo
        ///</summary>
        [TestMethod()]
        public void ToDirectoryInfoTest()
        {
            Directory target = new Directory(); // TODO: Initialize to an appropriate value
            DirectoryInfo expected = null; // TODO: Initialize to an appropriate value
            DirectoryInfo actual;
            actual = target.ToDirectoryInfo();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
