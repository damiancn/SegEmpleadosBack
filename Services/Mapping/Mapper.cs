
namespace Services.Mapping
{
    using AutoMapper;
    using Dtos.Beneficiary;
    using Dtos.Catalogs.Position;
    using Dtos.Employee;
    using Dtos.Security.Login;
    using Dtos.Security.Menu;
    using Dtos.Security.Page;
    using Dtos.Security.Rol;
    using Dtos.Security.RolPage;
    using Dtos.Security.RolUser;
    using Dtos.Security.User;
    using Entities.Models.Catalog;
    using Entities.Models.Security;

    public class Mapper : Profile
    {
        public Mapper()
        {
            #region Catalogs
            CreateMap<EmployeeModel, EmployeeDto>()
                .ForMember(e => e.FullName, mo => mo.MapFrom(m => m.Name + " " + m.FirstName + " " + m.SeconLastName))
                .ForMember(e => e.PositionName, mo => mo.MapFrom(m=> m.Position.Name));
            CreateMap<EmployeeDto, EmployeeModel>();
            CreateMap<BeneficiaryModel, BeneficiaryDto>()
                .ForMember(e=> e.EmployeeName, mo => mo.MapFrom(m => m.Employee.Name + " " + m.Employee.FirstName + " " + m.Employee.SeconLastName));
            CreateMap<BeneficiaryDto, BeneficiaryModel>();
            CreateMap<PositionModel, PositionDto>();
            CreateMap<PositionDto, PositionModel>();
            #endregion

            #region Securuty
            CreateMap<UserModel, UserDto>()
                .ForMember(e => e.Password, mo => mo.Ignore())
                .ForMember(e => e.EmployeeName, mo => mo.MapFrom(m => m.Employee.Name + " " + m.Employee.FirstName + " " + m.Employee.SeconLastName));
            CreateMap<UserDto, UserModel>();

            CreateMap<UserModel, LoginDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<LoginDto, UserModel>();


            CreateMap<RolModel, RolDto>();
            CreateMap<RolDto, RolModel>();

            CreateMap<PageModel, PageDto>();
            CreateMap<PageDto, PageModel>();

            CreateMap<RolPageModel, RolPageDto>()
                .ForMember(e => e.RolName, mo => mo.MapFrom(m => m.Rol.Name))
                .ForMember(e => e.PageName, mo => mo.MapFrom(m => m.Page.Name));
            CreateMap<RolPageDto, RolPageModel>();

            CreateMap<RolUserModel, RolUserDto>()
                .ForMember(e => e.RolName, mo => mo.MapFrom(m => m.Rol.Name))
                .ForMember(e => e.UserName, mo => mo.MapFrom(m => m.User.Name));
            CreateMap<RolUserDto, RolUserModel>();
            #endregion
        }
    }
}
