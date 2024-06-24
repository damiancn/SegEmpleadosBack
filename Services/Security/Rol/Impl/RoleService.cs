using AutoMapper;
using DataAcccess.Security.Rol;
using Dtos.Security.Login;
using Dtos.Security.Page;
using Dtos.Security.Rol;
using Dtos.Security.User;
using Entities.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Rol.Impl
{
    public class RoleService : IRolService
    {
        private readonly IMapper mapper;
        private readonly IRoleDao rolDao;

        public RoleService(IMapper mapper, IRoleDao rolDao)
        {
            this.mapper = mapper;
            this.rolDao = rolDao;
        }

        public async Task<List<PageDto>> GetRolPages(UserDto model)
        {
            var usetDto = mapper.Map<UserModel>(model);
            return mapper.Map<List<PageDto>>(await rolDao.GetRolPages(usetDto));
        }

        public async Task<RolDto> GetRolUser(UserDto model)
        {
            var userModel = mapper.Map<UserModel>(model);
            return mapper.Map<RolDto>(await rolDao.GetRolUser(userModel));
        }
    }
}
