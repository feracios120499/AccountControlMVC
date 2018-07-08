using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountControlMVC.Models
{
    public class RoleRepository : IRepository<Role>
    {
        private static RoleRepository _instance;

        public static RoleRepository _Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RoleRepository();
                return _instance;
            }

        }
        private List<Role> roles = new List<Role>();
        public void Create(Role role)
        {
            var findRoles = roles.Where(p => p != null);
            if (findRoles.Any())
            {
                role.Id = findRoles.Max(p => p.Id) + 1;
            }
            else
            {
                role.Id = 1;
            }
            roles.Add(role);
        }

        public void Delete(Role role)
        {
            roles.Remove(GetById(role.Id));
        }

        public IEnumerable<Role> GetAll()
        {
            return roles;
        }

        public Role GetById(int id)
        {
            return roles.Find(p => p.Id == id);
        }

        public void Update(Role oldRole, Role newRole)
        {
            var findRole = GetById(oldRole.Id);
            if (findRole == null)
                return;
            findRole.Name = newRole.Name;
        }
    }
}