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
            _driver.LaunchSauceUrl("https://www.saucedemo.com/");
            _driver.LoginSauceUser("standard_user", "secret_sauce");
        }

        [Test]
        public void VerifyInventoryUI()
        {
            Assert.IsTrue(inventoryPage.VerifyRightMenu());   
            Assert.IsTrue(inventoryPage.VerifyLogo());
            Assert.IsTrue(inventoryPage.VerifyTwitterLogo());
            Assert.IsTrue(inventoryPage.VerifyFacebookLogo());
            Assert.IsTrue(inventoryPage.VerifyLinkedinLogo());
            Assert.IsTrue(inventoryPage.VerifyCopyright());
            inventoryPage.VerifyCart();
        }

        [Test]
        public void VerifyMenuOptionsUI()
        {

            inventoryPage.VerifyRightMenuOptions();
            inventoryPage.closeRightMenu();
            inventoryPage.VerifyfilterOption();
        }

        [Test]
        public void VerifyListItems()
        {
            inventoryPage.VerifyNoOfItems();
        }

        [Test]
        public void verifyAddtoCart()
        {
         //   inventoryPage.verifyAddToCartSingleItem();
            inventoryPage.verifyAddtoCartMultiple();

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
