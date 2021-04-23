using Xbehave;
using Xunit;

namespace GuiTests_e2e.Tests
{
    
    // As a subscribed member I can remove product(s) from my cart so that I can check out with a cart 
    // only containing the items I want
    public class RemoveItemFromBasketAc4 : GuiTestFixture
    {
        [Scenario]
        public void RemoveItemFromCart_ExpectNumberOfItemsToDecrease()
        {
            Login();

            "Given that I am on the inventory page with items in my basket"
                .x(() =>
                {
                    SauceDemoPages.ProductPage().NavigateTo();
                    SauceDemoPages.ProductPage()
                        .AddItemByName("Sauce Labs Backpack")
                        .AddItemByName("Sauce Labs Bike Light");
                });

            "When I click “Remove” on an item I have in my basket"
                .x(() => { SauceDemoPages.ProductPage().RemoveItemByName("Sauce Labs Backpack"); });

            "Then it will change the “Remove” button to “Add to cart”"
                .x(() =>
                {
                    Assert.Equal("ADD TO CART", SauceDemoPages.ProductPage()
                        .ButtonStateByProductName("Sauce Labs Backpack"));
                });

            "And it will reduce the basket counter icon accordingly"
                .x(() =>
                {
                    Assert.Equal(1, SauceDemoPages.ProductPage()
                        .NumberOfItemsInCart());
                });
        }

        [Scenario]
        public void AddMultipleItemsToBasket_ExpectItemsInBasketPage()
        {
            Login();

            "Given that I have multiple items in my basket"
                .x(() =>
                {
                    SauceDemoPages.ProductPage().NavigateTo();
                    SauceDemoPages.ProductPage()
                        .AddItemByName("Sauce Labs Backpack")
                        .AddItemByName("Sauce Labs Bike Light");
                });
            "When I visit the basket page"
                .x(() => { SauceDemoPages.Basket().NavigateTo(); });

            "Then I can see options to remove each product present from the basket"
                .x(() =>
                {
                    Assert.True(SauceDemoPages.Basket().ItemsInBasketHaveRemoveOption());
                });
        }
    }
}