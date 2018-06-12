using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrsEf;

namespace PrsWithEf {
	class Program {
		private static PrsDbContext db = new PrsDbContext();

		void LinqExamples() {
			int[] nbrs = { 7, 7, 14, 13, 1, 11, 12, 3, 20, 10, 1, 10, 18, 17, 14, 15, 6, 14, 20, 13 };
			var total = nbrs.Sum();
			total = nbrs.Where(i => i >= 10).Sum();
			total = nbrs.Where(i => i % 2 != 1).Sum();
			var count = nbrs.Where(i => i > 5 && i <= 15);

			var cout = nbrs.Min();

			var sortedNbrs = nbrs.OrderBy(i => i);
			sortedNbrs = nbrs.OrderByDescending(i => i);

			var subset = nbrs.Where(i => i % 3 == 0).ToArray();
			var subset2 = nbrs.Where(i => i % 3 == 0).ToList();
			subset2.Sort();

		}	

		static void Main(string[] args) {
			(new Program()).LinqExamples();
		}


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

		public void AddEditProduct() {
			//List<Vendor> vendors = db.
			var products = db.Products.ToList();
			var product = products[0];
			var vendorNamme = product.Vendor.Name;

			var pEchoDot = new Product {
				Name = "Echo Dot",
				PartNumber = "1234",
				Price = 39.99M,
				PhotoPath = null,
				Active = true,
				VendorId = 1,
				Vendor = null,
				Unit = "Each"
			};
			db.Products.Add(pEchoDot);
			db.SaveChanges();


			db = new PrsDbContext();
		}

		void CalcPrTotal() {
			var prid = db.PurchaseRequest.SingleOrDefault(p => p.Description == "Office Purch1").Id;
			var prTot = db.PurchaseRequestLineItem.Where(p1 => p1.PurchaseRequestId == prid).Sum(li => li.Product.Price * li.Quantity);
			var pr = db.PurchaseRequest.SingleOrDefault(fred => fred.Id == prid);
			pr.Total = Convert.ToDouble( prTot);
			db.SaveChanges();
		}


		void AddPurchReqandPurchLI() {

			var prod1 = new Product {
				Name = "Chair",
				Price = 103.99M,
				PartNumber = "14567",
				PhotoPath = null,
				Unit = "Each",
				VendorId = 1,
				Active = true
			};
			db.Products.Add(prod1);

			var prod2 = new Product {
				Name = "Table",
				Price = 549.99M,
				PartNumber = "13698",
				PhotoPath = null,
				Unit = "Each",
				VendorId = 1,
				Active = true
			};
			db.Products.Add(prod2);

			var prod3 = new Product {
				Name = "Monitor",
				Price = 156.89M,
				PartNumber = "365789",
				PhotoPath = null,
				Unit = "Each",
				VendorId = 1,
				Active = true
			};
			db.Products.Add(prod3);

			var pr1 = new PurchaseRequest {
				Description = "First Pr",
				Justification = "",
				DeliveryMode = "Pickup",
				UserId = db.Users.SingleOrDefault(u => u.Username == "jwils").Id,

			};

			db.PurchaseRequest.Add(pr1);
			db.SaveChanges();
			db = new PrsDbContext();

			var prli1 = new PurchaseRequestLineItem {
				Quantity = 3,
				ProductId = db.Products.SingleOrDefault(u => u.Name == "Chair").Id,
				PurchaseRequestId = db.PurchaseRequest.SingleOrDefault(u => u.Description == "First Pr").Id,
			};
			db.PurchaseRequestLineItem.Add(prli1);

			var prli2 = new PurchaseRequestLineItem {
				Quantity = 5,
				ProductId = db.Products.SingleOrDefault(u => u.Name == "Table").Id,
				PurchaseRequestId = db.PurchaseRequest.SingleOrDefault(u => u.Description == "First Pr").Id,
			};
			db.PurchaseRequestLineItem.Add(prli2);

			var prli3 = new PurchaseRequestLineItem {
				Quantity = 7,
				ProductId = db.Products.SingleOrDefault(u => u.Name == "Monitor").Id,
				PurchaseRequestId = db.PurchaseRequest.SingleOrDefault(u => u.Description == "First Pr").Id,
			};
			db.PurchaseRequestLineItem.Add(prli3);

			db.SaveChanges();

			db = new PrsDbContext();
			//pr1.Total =	(Convert.ToDouble((db.Products.SingleOrDefault(k=> k.Id == (db.PurchaseRequestLineItem.SingleOrDefault(i => i.PurchaseRequestId == pr1.Id).Id)).Price)) * Convert.ToDouble((db.PurchaseRequestLineItem.SingleOrDefault(j => j.PurchaseRequestId == pr1.Id).Quantity)));
			db.SaveChanges();
		}

		void Addproductlines() {


			var prod4 = new Product {
				Name = "WaterBottle",
				Price = 10M,
				PartNumber = "365781",
				PhotoPath = null,
				Unit = "Each",
				VendorId = 1,
				Active = true
			};
			db.Products.Add(prod4);

			var pr2 = new PurchaseRequest {
				Description = "Office Purch1",
				Justification = "",
				DeliveryMode = "Pickup",
				UserId = db.Users.SingleOrDefault(u => u.Username == "jwils").Id,
			};
			db.PurchaseRequest.Add(pr2);
			db.SaveChanges();

			db = new PrsDbContext();

			var prli4 = new PurchaseRequestLineItem {
				Quantity = 3,
				ProductId = db.Products.SingleOrDefault(u => u.Name == "WaterBottle").Id,
				PurchaseRequestId = db.PurchaseRequest.SingleOrDefault(u => u.Description == "Office Purch1").Id,
			};
			db.PurchaseRequestLineItem.Add(prli4);

			var prli5 = new PurchaseRequestLineItem {
				Quantity = 2,
				ProductId = db.Products.SingleOrDefault(u => u.Name == "Chair").Id,
				PurchaseRequestId = db.PurchaseRequest.SingleOrDefault(u => u.Description == "Office Purch1").Id,
			};
			db.PurchaseRequestLineItem.Add(prli5);
			db.SaveChanges();

			(new Program()).CalcPrTotal();
		}


	}
}
