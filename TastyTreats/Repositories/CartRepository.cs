using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;
using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories
{
    //CRUD Operations for Cart

    public class CartRepository :ICartRepository
    {
        //Make Context

        private readonly TastyTreatsContext _context;

        public CartRepository(TastyTreatsContext context)
        {
            _context = context;
        }


        // Create a new cart for a user
       private async Task<Cart?> CreateCart(int userId)
        {
            //Create new cart for user
            var cart = new Cart
            {
                UserId = userId,
                CartItems = new List<CartItem>()
            };
             await _context.AddAsync(cart);
             await _context.SaveChangesAsync();
            return cart;
        }

        //This method to add cartitem to cart
        public async Task<CartItem?> AddCartItem( int userId, CartItem cartItem)
        {
            // Get cart of this user
            var cart = await _context.Carts.FirstOrDefaultAsync(c=> c.UserId == userId);

            if (cart == null)
            {   //If user has not cart 
                cart = await CreateCart(userId);
            }

            if (cart != null)
            {
                var cartitemexist = await _context.CartItems.FirstOrDefaultAsync(i => i.ItemId == cartItem.ItemId && i.CartId==cart.CartId);
                if (cartitemexist == null)
                {
                    cartItem.CartId = cart.CartId;
                   

                    // Add the new item to the cart's CartItems collection
                    await _context.AddAsync(cartItem);

                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    return (cartItem);
                }

                cartitemexist.Quantity += cartItem.Quantity;

               // Save changes to the database
               await _context.SaveChangesAsync();

                return (cartItem);
            }
            return (null);
        }

       
    

    // Get cart by ID and User ID to ensure ownership
    public async Task<Cart?> GetCartByUserId(int userId)
        {
            return await _context.Carts.
                Include(c => c.CartItems).
                ThenInclude(ci => ci.Item).
                FirstOrDefaultAsync(c=> c.UserId == userId);
        }

        //This method to get the cartId from the CartItem
         

        // Remove item from cart
        public async Task<CartItem?> RemoveCartItem(int cartItemId)
        {   
            //Get cartItem from database
            var cartItem =await _context.CartItems.Include(c=> c.Cart).FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
               await _context.SaveChangesAsync();
            }
            return (cartItem);
        }

        // Update quantity of a cart item
        public async Task<CartItem?> UpdateCartItemQuantity(int cartItemId, int newQuantity)
        {
            var cartItem = await _context.CartItems.Include(c => c.Cart).FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = newQuantity;
                await _context.SaveChangesAsync();
            }

            return (cartItem);
        }
    }
}
