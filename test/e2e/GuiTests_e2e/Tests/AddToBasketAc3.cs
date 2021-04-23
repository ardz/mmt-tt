using Xbehave;
using Xunit;

namespace GuiTests_e2e.Tests
{
    public class AddToBasketAc3 : GuiTestFixture
    {
        [Scenario]
        public void AddItemsToEmptyBasket_ExpectItemCountToIncrease()
        {
            Login();
            
            "Given that I am on the inventory shop page with an empty basket"
                .x(() =>
                {
                    SauceDemoPages.ProductPage().NavigateTo();
                });
            
            "When I click “Add to cart” on a product"
                .x(() =>
                {
                    SauceDemoPages.ProductPage().AddItemByName("Sauce Labs Backpack");
                });

            "Then it will change the “Add to cart” button to a “Remove” button"
                .x(() =>
                {
                    Assert.Equal("REMOVE", SauceDemoPages.ProductPage()
                        .ButtonStateByProductName("Sauce Labs Backpack"));
                });
            
            "And it creates a counter on the basket icon with the value “1” in it"
                .x(() =>
                {
                    Assert.Equal(1, SauceDemoPages.ProductPage()
                        .NumberOfItemsInCart());
                });
        }

        [Scenario]
        public void AddItemsToNonEmptyBasket_ExpectItemCountToIncrease()
        {
            Login();
            
            "Given that I am on the inventory shop page with an item in my basket"
                .x(() =>
                {
                    SauceDemoPages.ProductPage().NavigateTo();
                    SauceDemoPages.ProductPage().AddItemByName("Sauce Labs Backpack");
                });
            
            "When I click “Add to cart” on a product"
                .x(() =>
                {
                    SauceDemoPages.ProductPage().AddItemByName("Sauce Labs Bike Light");
                });

            "Then it will change the “Add to cart” button to a “Remove” button"
                .x(() =>
                {
                    Assert.Equal("REMOVE", SauceDemoPages.ProductPage()
                        .ButtonStateByProductName("Sauce Labs Backpack"));
                });
            
            "Then it will increment the basket counter by 1"
                .x(() =>
                {
                    Assert.Equal(2, SauceDemoPages.ProductPage()
                        .NumberOfItemsInCart());
                });
        }
    }
}