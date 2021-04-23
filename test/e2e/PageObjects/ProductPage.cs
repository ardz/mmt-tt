using Core_e2e;

namespace PageObjects
{
    public class ProductPage : BasePage
    {
        protected sealed override string PageUrl { get; set; }
        public ProductPage(DriverManager driverManager) : base(driverManager)
        {
            PageUrl = "/inventory.html";
        }
    }
}
