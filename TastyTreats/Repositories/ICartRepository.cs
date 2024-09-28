using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    public interface ICartRepository
    {

        //This method for Getting cart based on userId and cartId to ensure ownership
        public Task<Cart?> GetCartByUserId(int userId);

        //This method craete cart for specific user
        //public Task<Cart?> CreateCart(int userId);

        //This method to add cartitem to cart
        public Task<CartItem?> AddCartItem(int userId, CartItem cartItem);

        //This method for Updating quantity of a cart item
        public Task<CartItem?> UpdateCartItemQuantity(int cartItemId, int newQuantity);

        //This method for Removing item from cart
        public Task<CartItem?> RemoveCartItem(int cartItemId);

        //This method to get the cartId from the CartItem
        //public Task<int?> GetCartIdByCartItem(int cartItemId);
    }
}
