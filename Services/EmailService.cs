using DelegatesAssessment.Models;
using DelegatesAssessment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Services
{
    public class EmailService : IBaseService
    {
        private readonly IUserRepository _repo;
        public EmailService(IUserRepository repo) 
        {
            _repo = repo;
        }

        public void Add(User user)
        {
            Console.WriteLine($"EmailService adding {user.ToString()} ...");
            _repo.Add(user);
        }

        public bool Remove(User user)
        {
            Console.WriteLine($"EmailService removing {user.ToString()} ...");
            return _repo.Remove(user);
        }

        public bool Update(User oldUser, User newUser)
        {
            Console.WriteLine($"EmailService updating from {oldUser.ToString()} to {newUser.ToString()} ...");
            return _repo.Update(oldUser, newUser);
        }
    }
}
