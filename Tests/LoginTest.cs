using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumCSharpFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpFramework.Tests
{
    public class LoginTest
    {
        IWebDriver driver;
        LoginPage loginpage;

        [SetUp]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            loginpage = new LoginPage(driver);

        }

        [Test]
        public void VerifyValidUserLogin()
        {
            loginpage.launchUrl("https://www.saucedemo.com/");
            loginpage.login("standard_user", "secret_sauce");
        }

        [Test]
        public void VerifyLockedUserLogin()
        {
            loginpage.launchUrl("https://www.saucedemo.com/");
            loginpage.login("locked_out_user", "secret_sauce");
        }


        [TearDown] 
        public void Teardown() 
        {
            driver.Quit();
        }
    }
}
