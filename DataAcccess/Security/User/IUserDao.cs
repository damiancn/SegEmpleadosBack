using Entities.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Security.User
{
    public interface IUserDao
    {
        Task<UserModel> GetUserLogin(UserModel model);
    }

}
