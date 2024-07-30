using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpFramework.Pages
{
    public class InventoryPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private readonly WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

        IWebElement RightMenu => driver.FindElement(By.Id("react-burger-menu-btn"));
        IWebElement TopLogo => driver.FindElement(By.ClassName("app_logo"));
        IWebElement Cart => driver.FindElement(By.CssSelector("a.shopping_cart_link"));
        IWebElement TwitterLogo => driver.FindElement(By.LinkText("Twitter"));
        IWebElement FbLogo => driver.FindElement(By.LinkText("Facebook"));
        IWebElement LinkedinLogo => driver.FindElement(By.LinkText("LinkedIn"));
        IWebElement CopyRight => driver.FindElement(By.ClassName("footer_copy"));
        IWebElement BmMenu => driver.FindElement(By.ClassName("bm-menu"));
        IWebElement CloseMenu => driver.FindElement(By.ClassName("bm-cross-button"));
        IList<IWebElement> ListMenu => driver.FindElements(By.CssSelector("div.inventory_item"));
        IWebElement AddToCart => driver.FindElement(By.Id("add-to-cart"));
        IWebElement RemoveFromCart => driver.FindElement(By.Id("remove"));

        IWebElement BackToProducts => driver.FindElement(By.Id("back-to-products"));

        public WebDriverWait Wait => wait;


        public bool VerifyRightMenu()
        {
            return RightMenu.Displayed;
        }

        public bool VerifyLogo()
        {
            return TopLogo.Displayed;
        }

        public void VerifyCart()
        {

            if (Cart.Displayed)
            {
                // cart.Click();
                Thread.Sleep(700);
                driver.LaunchMainMenuPage("All Items");
                Cart.CartItems();

            }

        }

        public bool VerifyTwitterLogo()
        {
            return TwitterLogo.Displayed;
        }

        public bool VerifyFacebookLogo()
        {
            return FbLogo.Displayed;
        }
        public bool VerifyLinkedinLogo()
        {
            return LinkedinLogo.Displayed;
        }

        public bool VerifyCopyright()
        {
            return CopyRight.Displayed;
        }

        public void VerifyRightMenuOptions()
        {
            if (RightMenu != null)
            {
                RightMenu.Click();
                IList<IWebElement> listmenu = driver.FindElements(By.ClassName("bm-item-list"));

                foreach (IWebElement element in listmenu)
                {
                    Console.WriteLine(element.Text);
                }
            }

        }

        public void closeRightMenu()
        {
            if (RightMenu != null)
            {
                if (BmMenu.Displayed)
                {
                    CloseMenu.Click();
                }
            }
        }

        public void VerifyfilterOption()
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

            driver.FilterDropDownSelection(options[1]);
            driver.FilterDropDownSelection(options[2]);
            driver.FilterDropDownSelection(options[3]);

        }

        public void VerifyNoOfItems()
        {
            int total = ListMenu.GetNoOfItems();
            Console.WriteLine("Total number of items are: " + total);

            int count = 0;
            foreach (IWebElement element in ListMenu)
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
                    IWebElement btnAddToCart = wait.Until(driver => AddToCart);
                    btnAddToCart.AddToCart();
                    IWebElement insideCart = driver.FindElement(By.CssSelector("a.shopping_cart_link"));
                    insideCart.CartItems();
                    IWebElement removeCart = wait.Until(driver => RemoveFromCart);
                    removeCart.Click();
                    BackToProducts.Click();
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
                Cart.CartItems();
            }
        }

        
    }
}
