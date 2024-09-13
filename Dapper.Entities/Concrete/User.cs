using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Entities.Concrete
{
	[Table("Users")]
	public class User
	{
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Username")]
        public string? Username { get; set; }

        [Column("Password")]
        public string? Password { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Status")]
        public bool Status { get; set; }
    }
}
