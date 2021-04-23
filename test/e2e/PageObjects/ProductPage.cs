using Core_e2e;
using OpenQA.Selenium;

namespace PageObjects
{
    public class ProductPage : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        public ProductPage(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/inventory.html";
        }

        public ProductPage AddItemByName(string name)
        {
            var button = Driver
                .FindElement(By.XPath($"//div[contains(text(), '{name}')]/../../..//button"));

            if (button.GetAttribute(("innerText")) == "REMOVE")
            {
                // TODO add logging
                // item already in cart (test log)

                return this;
            }

            button.Click();

            return this;
        }

        public ProductPage RemoveItemByName(string name)
        {
            var button = Driver
                .FindElement(By.XPath($"//div[contains(text(), '{name}')]/../../..//button"));

            if (button.GetAttribute(("innerText")) == "ADD TO CART")
            {
                // TODO add logging
                // item isn't in cart (test log)

                return this;
            }
            
            button.Click();
            
            return this;
        }

        public string ButtonStateByProductName(string name)
        {
            return Driver
                .FindElement(By.XPath($"//div[contains(text(), '{name}')]/../../..//button"))
                .GetAttribute("innerText");
        }

        public int NumberOfItemsInCart()
        {
            return int.Parse(Driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
        }
    }
}
