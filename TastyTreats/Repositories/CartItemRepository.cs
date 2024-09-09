using Microsoft.EntityFrameworkCore;
using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    public class CartItemRepository: ICartItemRepository
    {
        //Make Context

        TastyTreatsContext context;

        public CartItemRepository()
        {
            context = new TastyTreatsContext();
        }

        //This method add new CartItem to the Cart
        public void CreateCartItem(CartItem cartItem)
        {
           context.CartItems.Add(cartItem);
        }

        //This method delete existance CartItem from the Cart
        public void DeleteCartItem(int cartItemId)
        {
            var cartItem = GetCartItemById(cartItemId);
            if (cartItem != null)
            {
                context.CartItems.Remove(cartItem);
                context.SaveChanges();
            }
        }

        //This Function return All CartItems that include inside them actual food items from table Items in The database 
        public List<CartItem> GetAllCartItems()
        {
            return context.CartItems.Include(ci => ci.Item).ToList();
        }

        //This Function return a specific CartItems that include items on it based on CartItemId
        public CartItem GetCartItemById(int cartItemId)
        {
            return context.CartItems.Include(ci => ci.Item).FirstOrDefault(ci => ci.CartItemId == cartItemId);

        }

        //This method Save CartItem in the database
        public void Save()
        {
           context.SaveChanges();
        }

        //This method Update existance CartItem from the Cart
        public void UpdateCartItem(CartItem cartItem)
        {
            context.CartItems.Update(cartItem);
        }
    }
}
