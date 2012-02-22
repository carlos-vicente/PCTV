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
        private readonly static String ValidFolderPathKey = "ValidFolderPath";
        private readonly static String InvalidFolderPathKey = "InvalidFolderPath";
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
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestContext.Properties[ValidFolderPathKey] = ConfigurationManager.AppSettings[ValidFolderPathKey];
            TestContext.Properties[InvalidFolderPathKey] = ConfigurationManager.AppSettings[InvalidFolderPathKey];

            TestContext.Properties[ValidFolderKey] = ConfigurationManager.AppSettings[ValidFolderKey];
            TestContext.Properties[InvalidFolderKey] = ConfigurationManager.AppSettings[InvalidFolderKey];
        }
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
        public void DirectoryConstructorWithDirectoryInfoTest()
        {
            //Arrange
            DirectoryInfo info = new DirectoryInfo((string)(TestContext.Properties[ValidFolderPathKey]));
            
            //Act
            Directory target = new Directory(info.Name, info.FullName, null);
            
            //Assert
            Assert.IsNotNull(target.Children);
            Assert.AreEqual(target.Name, info.Name);
            Assert.AreEqual(target.FullPath, info.FullName);
        }

        /// <summary>
        ///A test for Directory Constructor
        ///</summary>
        [TestMethod()]
        public void DirectoryConstructorWithoutParametersTest()
        {
            //Arrange
            
            //Act
            Directory target = new Directory();
            
            //Assert
            Assert.IsNotNull(target.Children);
        }
    }
}
