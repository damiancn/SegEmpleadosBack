namespace Services.Security.User.Impl
{
    using AutoMapper;
    using DataAcccess.Interface;
    using DataAcccess.Security.User;
    using Dtos.Security.Login;
    using Dtos.Security.User;
    using Entities.Models.Security;
    using Services.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IGenericService<UserDto>, IUserService
    {
        private readonly ICatalogDao<UserModel> userGenericDao;
        private readonly IUserDao userDao;
        private readonly IMapper mapper;

        public UserService(ICatalogDao<UserModel> userGenericDao, IMapper mapper, IUserDao userDao
            )
        {
            this.userGenericDao = userGenericDao;
            this.mapper = mapper;
            this.userDao = userDao;
        }

        public async Task<List<UserDto>> GetAll()
        {
            return mapper.Map<List<UserDto>>(await userGenericDao.GetAll());
        }

        public async Task<UserDto> GetById(Guid id)
        {
            return mapper.Map<UserDto>(await userGenericDao.GetById(id));

        }

        public async Task<UserDto> GetUserLogin(LoginDto model)
        {
            var user = new UserModel()
            {
                Name = model.User,
                Password = model.Password,
            };
            return mapper.Map<UserDto>(await userDao.GetUserLogin(user));
        }

        public async Task<UserDto> Post(UserDto model)
        {
            var userDto = mapper.Map<UserModel>(model);
            return mapper.Map<UserDto>(await userGenericDao.Post(userDto));
        }

        public async Task<UserDto> Put(Guid id, UserDto model)
        {
            var userDto = mapper.Map<UserModel>(model);
            return mapper.Map<UserDto>(await userGenericDao.Put(id, userDto));
        }
    }
}
