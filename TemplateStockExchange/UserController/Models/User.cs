using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserController.Models
{
    public class User
    {
        public User(int id, string name, string email, string password, double balance)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Balance = balance;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
    }
}
