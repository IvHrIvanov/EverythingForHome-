namespace ProjectEverything.Service.Shop
{
    public interface IShopService
    {
        int Create(
            string part,
            string year,
            decimal price,
            int quantity,
            string imageUrl,
            string description
            );
    }
}
