using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    public interface ICartRepository
    {
        public  List<Cart> GetAllCarts();
        public Cart GetCartById(int cartId);
        public void CreateCart(Cart cart);
        public void UpdateCart(Cart cart);
        public void DeleteCart(int cartId);
        public void Save();
    }
}
