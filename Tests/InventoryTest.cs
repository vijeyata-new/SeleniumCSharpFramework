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
    public class InventoryTest
    {
        private IWebDriver _driver;
        InventoryPage inventoryPage;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            inventoryPage = new InventoryPage(_driver);
            _driver.launchSauceUrl("https://www.saucedemo.com/");
            _driver.loginSauceUser("standard_user", "secret_sauce");
        }

        [Test]
        public void VerifyInventoryUI()
        {
            inventoryPage.verifyRightMenu();   
            inventoryPage.verifyCart();
            inventoryPage.verifyLogo();
            inventoryPage.verifyTwitterLogo();
            inventoryPage.verifyFacebookLogo();
            inventoryPage.verifyLinkedinLogo();
            inventoryPage.verifyCopyright();
        }

        [Test]
        public void VerifyMenuOptionsUI()
        {

            inventoryPage.verifyRightMenuOptions();
            inventoryPage.closeRightMenu();
            inventoryPage.verifyfilterOption();
        }

        [Test]
        public void VerifyListItems()
        {
            inventoryPage.verifyNoOfItems();
        }

        [Test]
        public void verifyAddtoCart()
        {
            inventoryPage.verifyAddToCartSingleItem();
            inventoryPage.verifyAddtoCartMultiple();

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
