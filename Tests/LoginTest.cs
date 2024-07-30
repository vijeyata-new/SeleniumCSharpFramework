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
            driver.LaunchSauceUrl("https://www.saucedemo.com/");

        }
        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                UserName = "standard_user",
                Password = "secret_sauce"
            };
            yield return new LoginModel()
            {
                UserName = "locked_out_user",
                Password = "secret_sauce"
            };
            yield return new LoginModel()
            {
                UserName = "problem_user",
                Password = "secret_sauce"
            };
            yield return new LoginModel()
            {
                UserName = "performance_glitch_user",
                Password = "secret_sauce"
            };
            yield return new LoginModel()
            {
                UserName = "error_user",
                Password = "secret_sauce"
            };
            yield return new LoginModel()
            {
                UserName = "visual_user",
                Password = "secret_sauce"
            };

        }


        [Test]
        [TestCaseSource(nameof(Login))]
        public void VerifyUserLogin(LoginModel lg)
        {
            
            loginpage.loginUser(lg.UserName, lg.Password);
            Assert.IsTrue(loginpage.isLoggedin());
        }


        [TearDown] 
        public void Teardown() 
        {
            driver.Quit();
        }
    }
}
