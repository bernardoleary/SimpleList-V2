using Infostructure.SimpleList.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Infostructure.SimpleList.Web.Models;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Net;
using System.Text;
using Moq;

namespace Infostructure.SimpleList.Web.Tests.Services
{
    
    
    /// <summary>
    ///This is a test class for ApiServiceTest and is intended
    ///to contain all ApiServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ApiServiceTest
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

        [TestMethod()]
        public void CreateSimpleListTest()
        {
            string baseAddress = "http://" + Environment.MachineName + ":5900/ApiService";
            ServiceHost host = new ServiceHost(typeof(ApiService), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IApiService), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();            
            Console.WriteLine("Host opened");

            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            c.Encoding = Encoding.UTF8;
            Console.WriteLine(c.UploadString(baseAddress + "/SimpleList/{simpleListId}/SimpleListItem/Create?userName=bernard&password=password",
                @"{""simpleListId"":""6"",
                    {""Description"":""test""}
                }"));

            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            //host.Close();
        }
    }
}
