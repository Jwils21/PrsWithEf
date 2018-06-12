using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrsEf;

namespace PrsWithEf {
	class Program {
		private static PrsDbContext db = new PrsDbContext();

		public void AddEditUser() {
			List<User> users = db.Users.ToList();
			User user = db.Users.Find(1);
			User user1 = db.Users.Find(999);

			User adduser = new User {
				Username = "Jerry",
				Email = "J@email.com",
				FirstName = "Jerry",
				Lastname = "Of=The-Day",
				Password = "password",
				Phone = "555-555-9874",
				IsAdmin = false,
				IsReviewer = false,
				Active = true
			};
			//User addedUser = db.Users.Add(adduser);
			db.SaveChanges();

			//db.Users.Remove(addedUser);
			db.SaveChanges();

			User u1 = db.Users.SingleOrDefault(u => u.Email == "j@email.com");
			u1.IsAdmin = false;
			db.SaveChanges();

		}
		 
		public void AddEditVendor() {
			//List<Vendor> vendors = db.
		}

		static void Main(string[] args) {
			var products = db.Products.ToList();
			var product = products[0];
			var vendorNamme = product.Vendor.Name;

			var pEchoDot = new Product {
				Name = "Echo Dot",
				PartNumber = "1234",
				Price = 39.99M,
				PhotoPath = null,
				Active = true,
				VendorId=1,
				Vendor = null,
				Unit = "Each"
			};
			db.Products.Add(pEchoDot);
			db.SaveChanges();
		}
	}	
}
