using dotNet_Lista11.DataContext;
using dotNet_Lista11.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Lista11.DataContext
{
    public class UserDataContext : ICRUDContext<UserViewModel>
    {
        private List<UserViewModel> users;
        public UserDataContext()
        {
            users = new List<UserViewModel>()
            {
                new UserViewModel("246994@student.pwr.edu.pl", "Kamil Graczyk", "46-053", Category.Admin)
            };
        }

        public bool Create(UserViewModel item)
        {
            int maxId;
            if (users.Count() == 0)
            {
                maxId = 0;
            }
            else
            {
                maxId = users[users.Count() - 1].Id;
            }

            item.Id = maxId + 1;
            users.Add(item);
            return true;
        }

        public bool Delete(int id)
        {
            bool isDelete = false;
            foreach(UserViewModel user in users)
            {
                if(user.Id == id)
                {
                    users.Remove(user);
                    isDelete = true;
                    break;
                }
            }

            return isDelete;
        }

        public List<UserViewModel> GetViewModels()
        {
            return users;
        }

        public UserViewModel Read(int id)
        {
            foreach (UserViewModel user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        public bool Update(UserViewModel item)
        {
            bool isUpdate = false;
            for (int i=0; i<users.Count; i++)
            {
                if (users[i].Id == item.Id)
                {
                    users[i] = item;
                    isUpdate = true;
                    break;
                }
            }

            return isUpdate;
        }
    }
}
