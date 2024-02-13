using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        public User(int id, string name, string email, string contact)
        {
            Id = id;
            Name = name;
            Email = email;
            Contact = contact;
        }

        public override string ToString()
        {
            return $"{{ {Id} : {Name} }}";
        }
    }
}
