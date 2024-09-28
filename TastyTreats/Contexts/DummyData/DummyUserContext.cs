using TastyTreats.Models;

namespace TastyTreats.Contexts.DummyData
{
    public class DummyUserContext
    {
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "John Doe",
                    Password = "Password@123", // In practice, use hashed passwords
                    Email = "john.doe@example.com",
                    UserPicture = "john_picture.png",
                    ZipCode = "12345",
                    Country = "USA",
                    City = "New York",
                    Phone = 01234567890,
                    Role = UserRole.User
                },
                new User
                {
                    UserId = 2,
                    Name = "Jane Smith",
                    Password = "11111111", // In practice, use hashed passwords
                    Email = "jane.smith@example.com",
                    UserPicture = "jane_picture.jpg",
                    ZipCode = "54321",
                    Country = "UK",
                    City = "London",
                    Phone = 01098765432,
                    Role = UserRole.Admin
                },
                new User
                {
                    UserId = 3,
                    Name = "Sam Wilson",
                    Password = "SamWilson@99",
                    Email = "sam.wilson@example.com",
                    UserPicture = "sam_picture.jpg",
                    ZipCode = "67890",
                    Country = "Canada",
                    City = "Toronto",
                    Phone = 01987654321,
                    Role = UserRole.User
                }
            };
        }
    }
}
