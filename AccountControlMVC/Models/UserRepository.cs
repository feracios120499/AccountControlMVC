using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountControlMVC.Models
{
    public class UserRepository : IRepository<User>
    {
        private static UserRepository _instance;

        public static UserRepository _Instance
        {
            get {
                if (_instance == null)
                    _instance = new UserRepository();
                return _instance;
            }
            
        }
        private List<User> users = new List<User>();
        public void Create(User user)
        {
            var findUsers = users.Where(p => p != null);
            if (findUsers.Any())
            {
                user.Id=findUsers.Max(p => p.Id) + 1;
            }
            else
            {
                user.Id = 1;
            }
            users.Add(user);
        }

        public void Delete(User user)
        {
            users.Remove(GetById(user.Id));
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.Find(p => p.Id == id);
        }

        public void Update(User oldUser, User newUser)
        {
            var findUser = GetById(oldUser.Id);
            if (findUser == null)
                return;
            findUser.FirstName = newUser.FirstName;
            findUser.LastName = newUser.LastName;
            findUser.Login = newUser.Login;
            findUser.Password = newUser.Password;
            findUser.Email = newUser.Email;
            findUser.Phone = newUser.Phone;
            findUser.Role = newUser.Role;
        }
    }
}