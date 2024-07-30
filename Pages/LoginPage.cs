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
        IWebElement cartIcon => driver.FindElement(By.CssSelector("a.shopping_cart_link"));



        public void loginUser(String Username, String Password)
        {
            driver.LoginSauceUser(Username, Password);
        }

        public bool isLoggedin()
        {
            try
            {
                return cartIcon.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }
    }
}
