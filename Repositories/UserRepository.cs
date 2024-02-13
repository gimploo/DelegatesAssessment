using DelegatesAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _repo = new List<User>();

        public void Add(User user)
        {
            _repo.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _repo;
        }

        public bool Remove(User user)
        {
            return _repo.Remove(user);
        }

        public bool Update(User oldUser, User newUser)
        {
            if (!_repo.Remove(oldUser))
                return false;

            _repo.Add(newUser);
            return true;
        }
    }
}
