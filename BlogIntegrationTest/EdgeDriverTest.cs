using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using System.Net.Http;

namespace BlogIntegrationTest
{
    [TestClass]
    public class EdgeDriverTest
    {

        private ChromeDriver _driver;
        private string testUrl = "https://localhost:44324/";

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            // Initialize edge driver 
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
           
            _driver.Url = "https://www.bing.com";
            Assert.AreEqual("Bing", _driver.Title);
        }

        [TestMethod]
        public void VerifyPageTitle2()
        {
            
            _driver.Url = "https://www.google.com";
            Assert.AreEqual("Google", _driver.Title);
        }


        [TestMethod]
        public void VerifyPageTitle3()
        {

            _driver.Url = testUrl;
            Assert.AreEqual("firefox", _driver.Title);
        }

             
        //Index page tesCases

        //check Create Link 
        [TestMethod]
        public void checkCreateLink()
        {

            _driver.Url = testUrl;
            var createLink = _driver.FindElementById("checkLink");
            createLink.Click();
        }
        //check Create Link 
        [TestMethod]
        public void checkDelete()
        {

            _driver.Url = testUrl;
            var click_delete = _driver.FindElementById("delete");
            click_delete.Click();
        }

        [TestMethod]
        public void checkEdit()
        {

            _driver.Url = testUrl;
            var click_edit = _driver.FindElementById("edit");
            click_edit.Click();
        }

        [TestMethod]
        public void checkDetails()
        {

            _driver.Url = testUrl;
            var click_details = _driver.FindElementById("details");
            click_details.Click();
        }

        [TestMethod]
        public void loginUrl()
        {

            _driver.Url = testUrl;
            var click_details = _driver.FindElementById("Login");
            click_details.Click();

            //test User
        }

        //create Blog testCases




        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
