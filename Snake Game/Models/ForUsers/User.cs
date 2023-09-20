using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake_Game.Models.ForUsers
{
	[Serializable]
	enum Rollar { Admin, Member };
	internal class User
	{
		public string Id { get; set; }

		public string? Password { get; set; }

		public string? Email { get; set; }

		public Rollar? Rol { get; set; }

		public User(string email, string password)
		{
			Id = Guid.NewGuid().ToString();
			Password = password;
			Email = email;
			Rol = Rollar.Member;
		}

	}
}
