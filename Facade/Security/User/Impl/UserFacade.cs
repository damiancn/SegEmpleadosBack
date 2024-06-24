namespace Facade.Security.User.Impl
{
    using DataAcccess.Util;
    using Dtos.Common;
    using Dtos.Commons;
    using Dtos.Security.Credential;
    using Dtos.Security.Login;
    using Dtos.Security.Page;
    using Dtos.Security.Rol;
    using Dtos.Security.User;
    using Resources.Util;
    using Services.Interface;
    using Services.Security.Rol;
    using Services.Security.User;
    using System.IdentityModel.Tokens.Jwt;

    public class UserFacade : IUserFacade
    {
        private readonly IGenericService<UserDto> modelService;
        private readonly IUserService userService;
        private readonly IRolService rolService;

        public UserFacade(IGenericService<UserDto> modelService, IUserService userService, IRolService rolService)
        {
            this.modelService = modelService;
            this.userService = userService;
            this.rolService = rolService;
        }

        public async Task<ResponseDto<List<UserDto>>> GetAll()
        {
            return new ResponseDto<List<UserDto>>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Empleados",
                Dto = await this.modelService.GetAll(),
            };
        }

        public async Task<ResponseDto<UserDto>> GetById(Guid id)
        {
            return new ResponseDto<UserDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Empleados",
                Dto = await this.modelService.GetById(id),
            };
        }

        public async Task<ResponseDto<CredentialDto>> GetMenu(LoginDto login)
        {

            var userLog = await GetUserLogin(login);
            var rol = await GetRolUser(userLog.Dto);
            var pages = await GetRolPages(userLog.Dto);
            var credential = new CredentialDto()
            {
                Pages = pages.Dto,
                Rol = rol.Dto.Name,
                RolId = rol.Dto.Id,
                UserName = userLog.Dto.Name,
                UserId = userLog.Dto.Id,
            };
            var modelToken = new TokenUtil
            {
                Name = credential.UserName ,
                Audience = login.Audience,
                Key = login.Key,
                Issuer = login.Issuer,
            };
            credential.Token = new JwtSecurityTokenHandler().WriteToken(PasswordEncryptor.CreateToken(modelToken));
            return new ResponseDto<CredentialDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de UserLog",
                Dto = credential,
            };
        }

        public async Task<ResponseDto<List<PageDto>>> GetRolPages(UserDto model)
        {
            return new ResponseDto<List<PageDto>>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Paginas",
                Dto = await this.rolService.GetRolPages(model),
            };
        }

        public async Task<ResponseDto<RolDto>> GetRolUser(UserDto model)
        {
            return new ResponseDto<RolDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Rol",
                Dto = await this.rolService.GetRolUser(model),
            };
        }

        public async Task<ResponseDto<UserDto>> GetUserLogin(LoginDto user)
        {
            return new ResponseDto<UserDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Empleados",
                Dto = await this.userService.GetUserLogin(user),
            };
        }

        public async Task<ResponseDto<UserDto>> Post(UserDto employee)
        {
            return new ResponseDto<UserDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se generó el empleado con éxito",
                Dto = await this.modelService.Post(employee),
            };
        }

        public async Task<ResponseDto<UserDto>> Put(Guid id, UserDto employee)
        {
            return new ResponseDto<UserDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se genero el cambio con éxito",
                Dto = await this.modelService.Put(id, employee),
            };
        }
    }
}
