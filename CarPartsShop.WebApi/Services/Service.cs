using CarPartsShop.Data;

namespace CarPartsShop.WebApi.Services
{
    public class Service
    {
        private ShopContext context;

        protected Service()
        {
            this.context = new ShopContext();
        }

        protected ShopContext Context => this.context;
    }
}