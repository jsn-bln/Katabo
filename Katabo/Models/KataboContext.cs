using Microsoft.EntityFrameworkCore;

namespace Katabo.Models
{
	public class KataboContext : DbContext
	{
		public KataboContext(DbContextOptions<KataboContext> options)
		:base(options)
		{
		
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Address> Addresses { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<ShoppingCarts> Carts { get; set; }
		public DbSet<Guest> Guests { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
					new Category
					{
						CategoryId = 1,
						Name = "Seafoods",
						DisplayOrder = 1,
						CreatedDateTime= DateTime.Now
					},
					new Category
					{
						CategoryId = 2,
						Name = "Meat",
						DisplayOrder = 2,
						CreatedDateTime = DateTime.Now
					},
					new Category
					{
						CategoryId = 3,
						Name = "Vegetables",
						DisplayOrder = 3,
						CreatedDateTime = DateTime.Now
					},
					new Category
					{
						CategoryId = 4,
						Name = "Fruits",
						DisplayOrder = 4,
						CreatedDateTime = DateTime.Now
					},
					new Category
					{
						CategoryId = 5,
						Name = "Root Crops",
						DisplayOrder = 5,
						CreatedDateTime = DateTime.Now
					}

				);

			modelBuilder.Entity<Address>().HasData(
					new Address
					{
						AddressId = 1,
						Barangay = "Maybacong",
						City = "Borongan",
						Landmark = "Near the chapel, red house",
						Province = "Eastern Samar",
						Zipcode = "6800",
						Country = "Philippines",
						UserId = 2
					},
					new Address
					{
						AddressId = 2,
						Barangay = "Sabang South",
						City = "Borongan",
						Landmark = "Fish port",
						Province = "Eastern Samar",
						Zipcode = "6800",
						Country = "Philippines",
						UserId = 1
					}
				);

			modelBuilder.Entity<User>().HasData(
					new User
					{
						UserId = 1,
						Username = "admin",
						FirstName = "admin",
						LastName = "admin",
						Email = "admin@admin.com",
						Password = "password",
						cPassword = "password",
						Birthday = DateTime.Now,
						Gender = "Male",
						Role = "Admin",
						PhoneNmber = "09091234567",
						AddressId = 2
					},
					new User
					{
						UserId = 2,
						Username = "user",
						FirstName = "user",
						LastName = "user",
						Email = "user@user.com",
						Password = "password",
						cPassword = "password",
						Birthday = DateTime.Now,
						Gender = "Female",
						Role = "User",
						PhoneNmber = "09091234567",
						AddressId = 1
					}
				);
			modelBuilder.Entity<Product>().HasData(
					new Product
					{
						ProductId = 1,
						Name = "Bangus",
						ProductDescription = "description",
						CategoryId = 1,
						Price = 150.00,
						ProductQuantity = 100,
						Image = "/images/bangus.png"
					},
					new Product
					{
						ProductId = 2,
						Name = "cabbage",
						ProductDescription = "description",
						CategoryId = 3,
						Price = 70.00,
						ProductQuantity = 100,
						Image = "/images/cabbage.png"
					},
					new Product
					{
						ProductId = 3,
						Name = "Chicken Drumsticks",
						ProductDescription = "description",
						CategoryId = 1,
						Price = 200.00,
						ProductQuantity = 100,
						Image = "/images/chicken-drumsticks.png"
					}
				);
		}


	}
}
