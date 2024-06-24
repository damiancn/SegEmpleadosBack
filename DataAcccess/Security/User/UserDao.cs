
namespace DataAcccess.Security.User
{
    using DataAcccess.Interface;
    using DataAcccess.Util;
    using Entities.Core;
    using Entities.Models.Security;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class UserDao : ICatalogDao<UserModel>, IUserDao
    {
        private readonly IDataBaseContext ctx;

        public UserDao(IDataBaseContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<UserModel>> GetAll()
        {
            var user = await this.ctx.Users.ToListAsync();
            SqlValidation<UserModel>.VailidateCountList(user, "Empleado");
            return user;
        }

        public async Task<UserModel> GetById(Guid id)
        {
            var user = await this.ctx.Users.FirstOrDefaultAsync();
            SqlValidation<UserModel>.VailidateFound(user, "Empleado");
            return user;
        }

        public async Task<UserModel> Post(UserModel user)
        {
            user.Id = new Guid();
            this.ctx.Users.Add(user);
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> Put(Guid id, UserModel user)
        {
            var userById = await this.ctx.Users.Where(e => e.Id == id).FirstOrDefaultAsync();
            SqlValidation<UserModel>.VailidateFound(userById, "User");
            userById.Name = user.Name;
            userById.Password = user.Password;
            userById.Active = user.Active;
            userById.Fk_Employee = user.Fk_Employee;
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return userById;
        }
        public async Task<UserModel> GetUserLogin(UserModel model)
        {
            var user = await this.ctx.Users.Where(e => e.Name == model.Name && e.Active).FirstOrDefaultAsync();
            SqlValidation<UserModel>.VailidateFound(user, "User Logged");
            return user;
        }
    }
}
