using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;
using TastyTreats.Contexts;
using TastyTreats.Models;

namespace TastyTreats.Repositories
{   
    //CRUD Operations for Cart

    public class CartRepository : ICartRepository
    {
        //Make Context

        TastyTreatsContext context;

        public CartRepository()
        {
            context = new TastyTreatsContext();
        }

        //This function create new Cart 
        public void CreateCart(Cart cart)
        {
            context.Carts.Add(cart);
           
        }

        //This function delete an existance Cart
        public void DeleteCart(int cartId)
        {
            var cart = GetCartById(cartId);
            if (cart != null)
            {
                context.Carts.Remove(cart);
            }
           
        }

        // This function retrieves all Carts and feteches the items in the Carts

        public List<Cart> GetAllCarts()
        {
            return context.Carts.Include(c => c.CartItems).ToList();
        }

        //This function retrieves a specific Cart based on its cartId and also includes the CartItems that belongs to this Cart
        public Cart GetCartById(int cartId)
        {
            return context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.CartId == cartId);

        }

        //This function Updates on an existance Cart
        public void UpdateCart(Cart cart)
        {
            context.Carts.Update(cart);
        }

        //This function save changes in the database
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
