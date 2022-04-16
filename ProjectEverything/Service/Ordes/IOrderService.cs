namespace ProjectEverything.Views.Order
{
    public interface IOrderService
    {
        public void RemoveProductsFromCartToUser(string userId);
        public  void RemoveFromCartReturnQuantityOfProducts(string userId);

    }
}
