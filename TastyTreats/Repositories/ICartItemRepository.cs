using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    public interface ICartItemRepository
    {
        public List<CartItem> GetAllCartItems();
        public CartItem GetCartItemById(int cartItemId);
        public void CreateCartItem(CartItem cartItem);
        public void UpdateCartItem(CartItem cartItem);
        public void DeleteCartItem(int cartItemId);

        public void Save();
    }
}
