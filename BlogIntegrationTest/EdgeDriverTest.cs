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


        //checkLogin
       
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
            var click_Login = _driver.FindElementByName("Login");
            click_Login.Click();


            //to ensure  wether login operation is performed successfully or not by checking textbox appeared after clicking login.
            var user_name = _driver.FindElementById("Input_Email");
            Assert.AreEqual("username", user_name);

            //to ensure  wether login operation is performed successfully or not by checking textbox appeared after clicking login.
            var user_password = _driver.FindElementById("Input_Password");
            Assert.AreEqual("userpassword", user_password);

            var user_submit = _driver.FindElementById("login-submit");
            user_submit.Click();


            //test User
        }
        [TestMethod]
        public void Registration()
        {

            _driver.Url = testUrl;
            var click_Register = _driver.FindElementByName("Register");
            click_Register.Click();


            //to ensure  wether register operation is performed successfully or not by checking  user name textbox appeared after clicking Register.
            var user_name = _driver.FindElementById("Input_Email");
            Assert.AreEqual("username", user_name);

            //to ensure  wether  Register operation is performed successfully or not by checking password textbox appeared after clicking Register.
            var user_password = _driver.FindElementById("Input_Password");
            Assert.AreEqual("userpassword", user_password);

            //to ensure  wether  Register operation is performed successfully or not by checking Confirm password textbox appeared after clicking Register.
            var Confirm_password = _driver.FindElementById("Input_ConfirmPassword");
            Assert.AreEqual("Confirmpassword", Confirm_password);

            var user_submit = _driver.FindElementById("login-submit");
            user_submit.Click();


            //test User
        }

        //create Blog testCases

        [TestMethod]
          public void userName()
        {
            _driver.Url = testUrl;
            var fullName = _driver.FindElementsById("name");
            Assert.AreEqual("fullName", fullName);

        }

        [TestMethod]
        public void Title()
        {
            _driver.Url = testUrl;
            var Title = _driver.FindElementsById("testCBV");
            Assert.AreEqual("Title", Title);

        }

        [TestMethod]
        public void Content()
        {
            _driver.Url = testUrl;
            var Content = _driver.FindElementsById("textInput");
            Assert.AreEqual("Content", Content);

        }


        [TestMethod]
        public void Image()
        {
            _driver.Url = testUrl;
            var Image = _driver.FindElementsById("image");
            Assert.AreEqual("Image", Image);

        }

        [TestMethod]
        public void Date()
        {
            _driver.Url = testUrl;
            var Date = _driver.FindElementsById("date");
            Assert.AreEqual("Date", Date);

        }

        




        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
