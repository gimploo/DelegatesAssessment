using DelegatesAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAssessment.Services
{
    public class UserEventArgs : EventArgs
    {
        public User User;
        public User NewUser;
    }

    public class UserService
    {
        public event EventHandler<UserEventArgs> AddEvent; 
        public event EventHandler<UserEventArgs> UpdateEvent; 
        public event EventHandler<UserEventArgs> RemoveEvent; 

        public UserService(EmailService email, PushNotificationService push, SMSService sms)
        {
            AddEvent += (source, args) => email.Add(args.User);
            AddEvent += (source, args) => push.Add(args.User);
            AddEvent += (source, args) => sms.Add(args.User);

            UpdateEvent += (source, args) => email.Update(args.User, args.NewUser);
            UpdateEvent += (source, args) => push.Update(args.User, args.NewUser);
            UpdateEvent += (source, args) => sms.Update(args.User, args.NewUser);

            RemoveEvent += (source, args) => email.Remove(args.User);
            RemoveEvent += (source, args) => push.Remove(args.User);
            RemoveEvent += (source, args) => sms.Remove(args.User);
        }

        public void OnAdd(User user)
        {
            OnAddEvent(new UserEventArgs {
                User = user,
                NewUser = null
            });
        }
        public void OnUpdate(User oldUser, User newUser)
        {
            OnUpdateEvent(new UserEventArgs {
                User = oldUser,
                NewUser = newUser
            });
        }
        public void OnRemove(User user)
        {
            OnRemoveEvent(new UserEventArgs {
                User = user,
                NewUser = null
            });
        }

        protected virtual void OnAddEvent(UserEventArgs e)
        {
            AddEvent?.Invoke(this, e);
        }
        protected virtual void OnUpdateEvent(UserEventArgs e)
        {
            UpdateEvent?.Invoke(this, e);
        }
        protected virtual void OnRemoveEvent(UserEventArgs e)
        {
            RemoveEvent?.Invoke(this, e);
        }
    }
}
