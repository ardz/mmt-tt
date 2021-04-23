using System.Linq;
using Core_e2e;
using OpenQA.Selenium;

namespace PageObjects
{
    public class Basket : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        
        public Basket(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/cart.html";
        }

        public bool ItemExistsInBasket(string name)
        {
            var items = Driver
                .FindElements(By.ClassName("inventory_item_name"));

            return items.Any(item => item.Text == name);
        }

        public bool ItemsInBasketHaveRemoveOption()
        {
            var items = Driver
                .FindElements(By.XPath("//div[@class='inventory_item_name']/../../..//button"));

            return items.All(item => item.GetAttribute("innerText") == "REMOVE");
        }
    }
}