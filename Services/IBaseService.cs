using DelegatesAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Services
{
    public interface IBaseService
    {
        public void Add(User user);
        public bool Update(User oldUser, User newUser);
        public bool Remove(User user);
    }
}
