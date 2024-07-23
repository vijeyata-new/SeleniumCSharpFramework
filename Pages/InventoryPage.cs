using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpFramework.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        IWebElement rightMenu => driver.FindElement(By.Id("react-burger-menu-btn"));
        IWebElement topLogo => driver.FindElement(By.ClassName("app_logo"));
        IWebElement cart => driver.FindElement(By.CssSelector("a.shopping_cart_link"));
        IWebElement twitterLogo => driver.FindElement(By.LinkText("Twitter"));
        IWebElement fbLogo => driver.FindElement(By.LinkText("Facebook"));
        IWebElement linkedinLogo => driver.FindElement(By.LinkText("LinkedIn"));
        IWebElement copyRight => driver.FindElement(By.ClassName("footer_copy"));
        IWebElement bmMenu => driver.FindElement(By.ClassName("bm-menu"));
        IWebElement closeMenu => driver.FindElement(By.ClassName("bm-cross-button"));
        IList<IWebElement> listMenu => driver.FindElements(By.CssSelector("div.inventory_item"));
        IWebElement addToCart => driver.FindElement(By.Id("add-to-cart"));
        IWebElement removeFromCart => driver.FindElement(By.Id("remove"));

        IWebElement backToProducts => driver.FindElement(By.Id("back-to-products"));


        public void verifyRightMenu()
        {
            if (rightMenu != null)
            {
                Assert.That(rightMenu.Displayed, "Menu button displayed");
            }
        }

        public void verifyLogo()
        {
            if (topLogo != null)
            {
                Assert.That(topLogo.Displayed, "Top logo is displayed");
                Console.WriteLine(topLogo.Text);
            }
        }

        public void verifyCart()
        {

            if (cart.Displayed)
            {
                // cart.Click();
                Thread.Sleep(700);
                driver.launchMainMenuPage("All Items");
                cart.CartItems();

            }
            Assert.That(cart.Displayed, "Cart is displayed");

        }

        public void verifyTwitterLogo()
        {
            if (twitterLogo.Displayed)
            {
                Console.WriteLine(twitterLogo.Text);
                Assert.That(twitterLogo.Displayed, "Twitter logo displayed");
            }
        }

        public void verifyFacebookLogo()
        {
            if (fbLogo.Displayed)
            {
                Console.WriteLine(fbLogo.Text);
                Assert.That(fbLogo.Displayed, "Facebook logo displayed");
            }
        }
        public void verifyLinkedinLogo()
        {
            if (linkedinLogo.Displayed)
            {
                Console.WriteLine(linkedinLogo.Text);
                Assert.That(linkedinLogo.Displayed, "Linkedin logo displayed");
            }
        }

        public void verifyCopyright()
        {
            if (copyRight != null)
            {
                Assert.That(copyRight.Displayed, "Twitter logo displayed");
                Console.WriteLine("Copyright reserves : " + copyRight.Text);
            }
        }

        public void verifyRightMenuOptions()
        {
            if (rightMenu != null)
            {
                rightMenu.Click();
                IList<IWebElement> listmenu = driver.FindElements(By.ClassName("bm-item-list"));

                foreach (IWebElement element in listmenu)
                {
                    Console.WriteLine(element.Text);
                }
            }

        }

        public void closeRightMenu()
        {
            if (rightMenu != null)
            {
                if (bmMenu.Displayed)
                {
                    closeMenu.Click();
                }
            }
        }

        public void verifyfilterOption()
        {
            IWebElement filterElement = wait.Until(driver => driver.FindElement(By.ClassName("product_sort_container")));

            SelectElement filter = new SelectElement(filterElement);

            IWebElement activeOpt = driver.FindElement(By.CssSelector("span.active_option"));
            String defaultOpt = "Name (A to Z)";
            String selectedOpt = activeOpt.Text;

            if (selectedOpt.Equals(defaultOpt))
            {
                Console.WriteLine("Default filter is set to : " + defaultOpt);
            }
            else
            {
                Console.WriteLine("Default filter is not set");
            }

            String[] options = { "Name (A to Z)", "Name (Z to A)", "Price (low to high)", "Price (high to low)" };

            driver.filterDropDownSelection(options[1]);
            driver.filterDropDownSelection(options[2]);
            driver.filterDropDownSelection(options[3]);

        }

        public void verifyNoOfItems()
        {
            int total = listMenu.getNoOfItems();
            Console.WriteLine("Total number of items are: " + total);

            int count = 0;
            foreach (IWebElement element in listMenu)
            {
                count++;
                IWebElement titleOfItem = element.FindElement(By.CssSelector("div.inventory_item_name"));
                IWebElement priceOfItem = element.FindElement(By.CssSelector("div.inventory_item_price"));
                Console.WriteLine(count + ") Item Name : " + titleOfItem.Text + '\n' + "Item Price : " + priceOfItem.Text);
            }
        }

        public void verifyAddToCartSingleItem()
        {
            String itemToChoose = "Sauce Labs Bike Light";
            IList<IWebElement> listOps = driver.FindElements(By.ClassName("inventory_item"));
            foreach (IWebElement item in listOps)
            {
                IWebElement chosenItem = item.FindElement(By.XPath("//*[text()='Sauce Labs Bike Light']"));

                if (itemToChoose.Contains(chosenItem.Text))
                {
                    chosenItem.Click();
                    IWebElement btnAddToCart = wait.Until(driver => addToCart);
                    btnAddToCart.addToCart();
                    IWebElement insideCart = driver.FindElement(By.CssSelector("a.shopping_cart_link"));
                    insideCart.CartItems();
                    IWebElement removeCart = wait.Until(driver => removeFromCart);
                    removeCart.Click();
                    backToProducts.Click();
                }
            }
        }

        public void verifyAddtoCartMultiple()
        {
            IList<IWebElement> listOps = driver.FindElements(By.ClassName("inventory_item"));
            foreach (IWebElement item in listOps)
            {
                IWebElement btnAddtocart = item.FindElement(By.XPath("//*[text()='Add to cart']"));
                btnAddtocart.Click();
                cart.CartItems();
            }
        }

        public
    }
}
