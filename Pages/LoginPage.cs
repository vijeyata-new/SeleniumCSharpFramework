using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpFramework.Pages
{
    public class LoginPage 
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        IWebElement errorMsg => driver.FindElement(By.XPath("//h3[contains(text(),'Sorry')]"));

        public void launchUrl(string Url)
        {
            driver.launchSauceUrl(Url);
        }

        public void login(String Username, String Password)
        {
            driver.loginSauceUser(Username, Password);

            if (Username.Equals("standard_user"))
            {
                String url = driver.Url;
                Assert.That(url.Equals("https://www.saucedemo.com/inventory.html"));
                Console.WriteLine("User logged in successfully");
            }
            else if(Username.Equals("locked_out_user"))
            {
                if(errorMsg!= null)
                {
                    Assert.Pass("Not logged in. Error Message-" + errorMsg.Text);
                    Console.WriteLine("User not logged in");
                }
            }
        }
    }
}
