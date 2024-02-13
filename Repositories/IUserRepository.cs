using DelegatesAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        public void Add(User user);
        public bool Update(User user, User newUser);
        public bool Remove(User user);
    }
}
