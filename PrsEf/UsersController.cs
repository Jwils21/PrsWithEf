using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsEf {
	public class UsersController {
		private PrsDbContext db = new PrsDbContext();

		public IEnumerable<User> List() {
			return db.Users.ToList();
		}

		public User Get(int? id) {
			if(id == null) 
				return null;
			return db.Users.Find(id);
		}

		public bool Create(User user) {
			if(user == null)
				return false;
			
			db.Users.Add(user);
			db.SaveChanges();
			return true;
		}
		public bool Change(User user) {
			if(user == null)
				return false;
			User TgUser = Get(user.Id);
			if(TgUser == null)
				return false;
			TgUser.Username = user.Username;
			TgUser.Password = user.Password;
			TgUser.Phone = user.Phone;
			TgUser.FirstName = user.FirstName;
			TgUser.Lastname = user.Lastname;
			TgUser.Email = user.Email;
			TgUser.IsAdmin = user.IsAdmin;
			TgUser.IsReviewer = user.IsAdmin;
			TgUser.Active = user.Active;
			db.SaveChanges();
			return true;
		}
		public bool Remove(User user) {
			if(user == null)
				return false;
			User TgUser = Get(user.Id);
			if(TgUser == null)
				return false;
			db.Users.Remove(user);
			db.SaveChanges();
			return true;
		}
	}
}
