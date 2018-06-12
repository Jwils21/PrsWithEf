using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrsEf {
	public class User {
		[Required]
		[StringLength(30)]
		[Index(IsUnique=true)]
		public string Username { get; set; }
		public int Id { get; set; }
		[StringLength(30)]
		public string Password { get; set; }
		[StringLength(30)]
		public string FirstName { get; set; }
		[StringLength(30)]
		public string Lastname { get; set; }
		[StringLength(12)]
		public string Phone { get; set; }
		[StringLength(255)]
		public string Email { get; set; }
		public bool IsReviewer { get; set; }
		public bool IsAdmin { get; set; }
		public bool Active { get; set; }

		public User(string userName, int id, string password, string firstName, string lastName, string phone, string email, bool isReviewer, bool isAdmin, bool active) {
			Username = userName;
			Id = id;
			Password = password;
			FirstName = firstName;
			Lastname = lastName;
			Phone = phone;
			Email = email;
			IsReviewer = isReviewer;
			IsAdmin = isAdmin;
			Active = active;
				
		}

		public User() {

		}
	}
}
