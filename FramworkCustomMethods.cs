using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpFramework
{
    public static class FramworkCustomMethods
    {

        public static void LaunchSauceUrl(this IWebDriver driver, String Url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
            String title = driver.Title;
            Assert.That(title, Is.EqualTo("Swag Labs"));
        }

        public static void LoginSauceUser(this IWebDriver driver, String username, String password)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
        }
        public static void LaunchMainMenuPage(this IWebDriver driver, String pageName)
        {
            IList<IWebElement> menuList = driver.FindElements(By.Id("react-burger-menu-btn"));
            foreach (IWebElement menu in menuList)
            {
                if(pageName.Equals(menu.Text))
                {
                    menu.Click();
                }
            }
        }

        public static void FilterDropDownSelection(this IWebDriver driver, String valueToSelect)
        {
            String? chooseOption = null;
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

            IWebElement filterOption = wait.Until(driver => driver.FindElement(By.ClassName("product_sort_container")));

            SelectElement filterOpt = new(filterOption);

            String[] optionToSelect = ["Name (A to Z)", "Name (Z to A)", "Price (low to high)", "Price (high to low)"];

            foreach (String option in optionToSelect)
            {
                if(option.Contains(valueToSelect))
                {
                    chooseOption = option;
                }
            }

            try
            {
                switch (chooseOption)
                {
                    case "Name (A to Z)":
                        filterOpt.SelectByIndex(0);
                        IWebElement activeOpt1 = driver.FindElement(By.CssSelector("span.active_option"));
                        Console.WriteLine("Selected filter as : "+ activeOpt1.Text);
                        break;
                    case "Name (Z to A)":
                        filterOpt.SelectByIndex(1);
                        IWebElement activeOpt2 = driver.FindElement(By.CssSelector("span.active_option"));
                        Console.WriteLine("Selected filter as : " + activeOpt2.Text);
                        break;
                    case "Price (low to high)":
                        filterOpt.SelectByIndex(2);
                        IWebElement activeOpt3 = driver.FindElement(By.CssSelector("span.active_option"));
                        Console.WriteLine("Selected filter as : " + activeOpt3.Text);
                        break;
                    case "Price (high to low)":
                        filterOpt.SelectByIndex(3);
                        IWebElement activeOpt4 = driver.FindElement(By.CssSelector("span.active_option"));
                        Console.WriteLine("Selected filter as : " + activeOpt4.Text);
                        break;
                    default :
                        filterOpt.SelectByValue("az");
                        break;
                }
            }
            catch(StaleElementReferenceException)
            {
                Console.WriteLine("Element not recognised");
            }
        }

        public static void CartItems(this IWebElement cart)
        {

            try
            {
                IWebElement cartBadge = cart.FindElement(By.CssSelector("span.shopping_cart_badge"));

                if (cartBadge.Displayed)
                {
                    int count = int.Parse(cartBadge.Text);
                    Console.WriteLine("There are -" + count + "-items in the cart");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cart is empty");
            }
        }

        public static int GetNoOfItems(this IList<IWebElement> menu)
        {
           // menu = driver.FindElements(By.CssSelector("div.inventory_item"));
            int total = menu.Count;
            return total;
        }

        public static void AddToCart(this IWebElement addtocart)
        {
            addtocart.Click();
        }

        public static void RemoveFromCart(this IWebElement removeCart)
        {
            removeCart.Click();
        }

    }
}
